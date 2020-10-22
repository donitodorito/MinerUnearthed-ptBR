﻿using RoR2;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace EntityStates.Miner
{
    public class DrillBreakStart : BaseSkillState
    {
        private GameObject chargePrefab = EntityStates.LemurianBruiserMonster.ChargeMegaFireball.chargeEffectPrefab;
        private GameObject chargeInstance;
        private float chargeDuration = 0.6f;
        private int charge = 0;
        private Vector3 left = new Vector3(0, 0, 1);

        protected bool ShouldKeepChargingAuthority()
        {
            return (base.fixedAge < chargeDuration) && base.IsKeyDownAuthority() && (charge * (.8f + (.2f * base.attackSpeedStat)) <= 38f);
        }

        protected EntityState GetNextStateAuthority()
        {
            return new DrillBreak();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            base.StartAimMode(0.6f, false);

            Ray aimRay = base.GetAimRay();
            if (base.isAuthority)
            {
                Vector3 direct = aimRay.direction;

                Vector2 move = new Vector2(characterMotor.moveDirection.x, characterMotor.moveDirection.z);
                Vector2 aim = new Vector2(aimRay.direction.x, aimRay.direction.z);
                float forward = Vector2.Dot(move, aim.normalized);
                Vector2 aimO = new Vector2(aimRay.direction.z, -1 * aimRay.direction.x);
                float right = Vector2.Dot(move, aimO.normalized);

                Quaternion major = Quaternion.FromToRotation(left, direct);
                chargeInstance = UnityEngine.Object.Instantiate<GameObject>(chargePrefab, aimRay.origin, transform.rotation * major);
                chargeInstance.transform.localScale *= 0.0125f;

                Util.PlaySound(MinerPlugin.Sounds.DrillChargeStart, base.gameObject);
            }

            base.PlayAnimation("Gesture, Override", "DrillChargeStart");
        }

        public override void OnExit()
        {
            if (chargeInstance)
            {
                EntityState.Destroy(chargeInstance);
            }

            base.PlayAnimation("Gesture, Override", "BufferEmpty");

            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!ShouldKeepChargingAuthority())
            {
                outer.SetNextState(GetNextStateAuthority());
                return;
            }
            Ray aimRay = base.GetAimRay();
            Vector3 direct = aimRay.direction;
            Quaternion major = Quaternion.FromToRotation(left, direct);
            chargeInstance.transform.rotation = transform.rotation * major;
            chargeInstance.transform.position = aimRay.origin;

            charge++;
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }

    public class DrillBreak : BaseSkillState
    {
        public static float damageCoefficient = 2f;
        public float baseDuration = 0.4f;

        private float duration;
        private OverlapAttack attack;
        //private StyleSystem.StyleComponent styleComponent;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = this.baseDuration;
            Ray aimRay = base.GetAimRay();
            //this.styleComponent = base.GetComponent<StyleSystem.StyleComponent>();
            base.characterMotor.disableAirControlUntilCollision = false;

            base.PlayAnimation("FullBody, Override", "DrillChargeShort");

            if (NetworkServer.active) base.characterBody.AddBuff(BuffIndex.HiddenInvincibility);

            Util.PlaySound(MinerPlugin.Sounds.DrillCharge, base.gameObject);
            base.characterMotor.velocity += 75 * aimRay.direction;

            HitBoxGroup hitBoxGroup = null;
            Transform modelTransform = base.GetModelTransform();

            base.GetModelChildLocator().FindChild("DrillBreakEffect").GetComponent<ParticleSystem>().Play();

            if (modelTransform)
            {
                hitBoxGroup = Array.Find<HitBoxGroup>(modelTransform.GetComponents<HitBoxGroup>(), (HitBoxGroup element) => element.groupName == "Charge");
            }

            this.attack = new OverlapAttack();
            this.attack.attacker = base.gameObject;
            this.attack.inflictor = base.gameObject;
            this.attack.teamIndex = base.GetTeam();
            this.attack.damage = DrillBreak.damageCoefficient * this.damageStat;
            this.attack.procCoefficient = 1;
            this.attack.hitEffectPrefab = MinerPlugin.Assets.heavyHitFX;
            this.attack.forceVector = Vector3.zero;
            this.attack.pushAwayForce = 1f;
            this.attack.hitBoxGroup = hitBoxGroup;
            this.attack.isCrit = base.RollCrit();

            EffectData effectData = new EffectData();
            effectData.origin = base.transform.position;
            effectData.scale = 8;

            EffectManager.SpawnEffect(MinerPlugin.MinerPlugin.backblastEffect, effectData, true);
        }

        public override void OnExit()
        {
            if (NetworkServer.active)
            {
                base.characterBody.RemoveBuff(BuffIndex.HiddenInvincibility);
                base.characterBody.AddTimedBuff(BuffIndex.HiddenInvincibility, 0.5f);
            }

            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                if (!base.characterMotor.disableAirControlUntilCollision) base.characterMotor.velocity *= 0.4f;
                base.PlayAnimation("FullBody, Override", "DrillChargeShortEnd");
                this.outer.SetNextStateToMain();
                return;
            }

            if (base.isAuthority)
            {
                if (this.attack.Fire())
                {
                    Util.PlayScaledSound(MinerPlugin.Sounds.Hit, base.gameObject, 0.5f);

                    base.characterMotor.velocity = Vector3.zero;

                    if (base.characterMotor && !base.characterMotor.isGrounded)
                    {
                        base.SmallHop(base.characterMotor, 12f);
                    }

                    BlastAttack blastAttack = new BlastAttack();
                    blastAttack.radius = 10f;
                    blastAttack.procCoefficient = 1f;
                    blastAttack.position = base.characterBody.corePosition;
                    blastAttack.attacker = base.gameObject;
                    blastAttack.crit = base.RollCrit();
                    blastAttack.baseDamage = base.characterBody.damage * DrillBreak.damageCoefficient;
                    blastAttack.falloffModel = BlastAttack.FalloffModel.None;
                    blastAttack.baseForce = 3f;
                    blastAttack.teamIndex = TeamComponent.GetObjectTeam(blastAttack.attacker);
                    blastAttack.damageType = DamageType.Generic;
                    blastAttack.attackerFiltering = AttackerFiltering.NeverHit;
                    blastAttack.Fire();

                    EffectData effectData = new EffectData();
                    effectData.origin = base.characterBody.corePosition;
                    effectData.scale = 6;

                    EffectManager.SpawnEffect(MinerPlugin.MinerPlugin.backblastEffect, effectData, false);

                    base.PlayAnimation("FullBody, Override", "Flip", "Flip.playbackRate", 0.4f);

                    this.outer.SetNextStateToMain();
                    return;
                }
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}
