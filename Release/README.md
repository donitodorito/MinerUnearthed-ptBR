## MinerUnearthed
- Adds the Miner from Risk of Rain 1, a ground up rewrite of the original Miner Mod by Gnome
- Fully multiplayer compatible and with more content planned
- Has completed item displays, including some modded items
- Has a bunch of ~~unlockable~~ skins and skills, ~~as well as a challenge to unlock him~~
- Now includes Direseeker, a custom boss based on the original from RoR1

[![](https://cdn.discordapp.com/attachments/469291841859092488/780784218816380938/unknown.png)]()

[![](https://cdn.discordapp.com/attachments/469291841859092488/780787095731437588/unknown.png)]()

[![](https://cdn.discordapp.com/attachments/747757793339244576/787552348523724830/minericon.png)]()

join the discord to share feedback/bugs- https://discord.gg/HpQB9fC
or ping/dm me- ~~@rob#2365~~ @TheTimesweeper#5727

## New Mod?
As we know, rob has recently left the modding community. Like Paladin, Miner is left in the hands of the community.
rob, Gnome, TheTimesweeper, Papazach, all got together with the Enforcer gang, and we all worked on this guy too. Only makes sense he's uploaded here now.
mainly rob and Gnome, let's not be mistaken

#### What does this mean?
nothing!
I've kept the internal mod name the same, so configs and unlocks (when they're fixed) will carry over like it's just an update to the previous mod.

## Overview
Miner is a high speed melee character, who uses high mobility and invincibility to help with combat. 
Sounds somewhat like Mercenary, but where Mercenary slips in and out, Miner rushes in and swings wildly like a crackhead.

- His primaries, coupled with his passive `Gold Rush` encourage you to be offensive to build long kill combos.
- `Drill Charge` and `Backblast` are high mobility options with invincibility during and slightly after the dash. 
- `Drill Charge` increases damage by being held to charge longer, but will always go the full distance.
- `Backblast` can be held to go backwards farther. Use as a long mobility option, or to stay in combos.
- `To the Stars`, when used correctly, can land huge damage on larger enemies. Use lower to the ground to maximize its damage.

Read Gnome's original mod page for more detailed descriptions. Gameplay is still the same for the most part

## Direseeker
Adds a custom boss, Direseeker, along with Miner. Disables itself if the standalone Direseeker mod is installed. The one included in this mod is basically Direseeker lite.

Direseeker is a massive Elder Lemurian with currently a new extremely powerful fireball attack. It's roughly Imp Overlord tier and only spawns on Abyssal Depths.

[![](https://cdn.discordapp.com/attachments/469291841859092488/784510230054436904/unknown.png)]()

[![](https://cdn.discordapp.com/attachments/469291841859092488/784511696118218812/unknown.png)]()

[![](https://cdn.discordapp.com/attachments/747757793339244576/783952180834992128/direIconRed.png)]()

## Known Issues
- Achivements currently not implemented
- Plague mask isn't green

## Credits
Gnome - Made the original Miner mod, a fantastic base to work off of
fuu - Made the Miner model
rob - coding, rewrite, polish
TheTimeSweeper - coding, adrenaline flame particles, various other help
PapaZach - Skill icons
Jot - CSS animation
redacted - Grand Mastery skin
bruh - Swag model
Neik - Blacksmith concept
Ruxbieno - Direseeker logbook entry

## Changelog
`1.5.4`
- Fixed all item displays. Thanks minka for reaching out about them
- Fixed modded item displays for aetherium and sivsitems
- as well as fuckhuge ancient scepter and golden coast items
- supply drop fuck you for having a plague mask forcing me to do your displays too - timesweeper xoxo

`1.5.3`
- Updated to work on the latest RoR2 version

`1.5.2`
- Updated to work on the latest RoR2 version
- Item displays and achievements broken for now

`1.5.1`
- Removed ClassicItems support and instead migrated to the Standalone Ancient Scepter

`1.5.0`
- Made Crush an actual skill (thanks Timesweeper!)
- Added Grand Mastery skin (model by redacted)
- Emotes can no longer be used while chat is active (thanks DestroyedClone for the fix)
- Updated primary skill icons
- Tweaked walk animation
- Networked Gouge hit sounds
- Fixed Crack Hammer animation being broken in multiplayer
- Replaced most instances of Miner in the code with Digger in another fruitless attempt to get Windows Defender to fuck off :]]]]

`1.4.4`
- Changed the internal name to DiggerUnearthed, hopefully stops this antivirus nonsense
- Fixed clients taking fall damage when using Falling Comet
- Fixed Gouge second swing taking longer than the first swing, moderately improving dps

`1.4.3`
- Changed the dll filename to stop antivirus falseflagging (it is seriously not a bitcoin miner..)

`1.4.2`
- Added drip
- Updated character portrait
- Changed unlock condition to killing Direseeker when Direseeker standalone is installed
- Tweaked some animations and VFX
- Tweaked skill icons
- Fixed Aetherium item displays
- Fixed clients suffering from fall damage when using Falling Comet
- Fixed Gouge creating duplicate effects in multiplayer and properly networked swings

`1.4.1`
- Direseeker now exists as a separate mod, so this one will disable itself if you have both mods installed- otherwise unchanged

`1.4.0`
- Updated Direseeker visuals, added some extra flair
- Increased Direseeker's fireball damage, increased fireball count to 15 and increased spread
- No longer counted as a boss when spawned normally
- Some more Survivorseeker fixes
- Fixed Miner's model being positioned slightly above the ground
- Made Miner: Tempered achievement a little more reasonable

`1.3.9`
- Fixed Direseeker survivor for real this time
- Tweaked Direseeker textures
- Reverted Blacksmith textures

`1.3.8`
- Accidentally left Direseeker survivor enabled by default, oops
- Fixed the survivor to actually work and interact with things

`1.3.7`
- Reverted Life Savings nerf- didn't work as intended, will figure something else out
- Added a custom boss, Direseeker

`1.3.6`
- Added a new skin
- Adrenaline glow now properly smooths from white to red, now applies on Tundra and the new skin added
- Updated some skill VFX
- Fixed Falling Comet applying fall damage to clients and stopped weird physics nonsense
- Added a new emote(bound to 3 by default)
- Fixed Miner's logbook display using the wrong shader

`1.3.5`
- Fixed infinite adrenaline bug because I can't code apparently
- Pickaxe/visor glow now transitions smoothly just like the adrenaline animations
- Fixed inaccurate Drill Charge description

`1.3.4`
- Nerfed Life Savings interaction- now requires a minimum of 3 gold earned to count towards adrenaline stacks
-- Goal isn't to kill the interaction but to stop it from breaking runs so easily with just one stack
- Reverted Crack Hammer sound
- Added config for primary damage and secondary damage/cooldown
- Tweaked adrenaline animations
- Fixed adrenaline visuals no longer working for clients

`1.3.3`
- Fix an issue with Backblast

`1.3.2`
- Adrenaline visuals now transition smoothly
- Locked alt skills behind challenges
- Changed Tundra skin unlock to reaching Rallypoint Delta in under 8 minutes
- Added Puple skin back
- Fixed emotes giving adrenaline stacks

`1.3.1`
- Miner is now locked- can be force unlocked via config
- Updated portrait
- Added some more adrenaline eye candy

`1.3.0`
- More animation work
- Finished item displays and added display rules for Siv's Items and Aetherium
- Added an upgraded special for ClassicItems' Ancient Scepter- Falling Comet: Jump into the air, shooting a wide spray of explosive projectiles downwards for 30x90% damage total, then fall downwards creating a huge blast on impact that deals 1500% damage and ignites enemies hit.
- Added a new skin(must be enabled via config)
- Added a ton of visual feedback for adrenaline passive
- Gouge moved to default primary slot, added a stacking armor debuff that's soft capped by attack speed
- Updated Drill Charge and Crack Hammer VFX
- Crack Hammer cooldown lowered to 4s, damage lowered to 2x200%, hitbox size decreased to stop accidentally getting caught on enemies
- Lowered To he Stars projectile count to 30
- Buffed Backblast damage to 600%
- Improved Cave In's reliability
- Added two emotes, bound to 1 and 2 by default
- Updated character portrait

`1.2.0`
- Cleaned up animations
- Updated Molten skin
- Lowered Crush damage to 225%
- Added alternate primary, secondary and utility skills
- Added some extra skins, must be toggled on via config
- Added configuration for Gold Rush passive
- Fixed Backblast effect sometimes not appearing
- Fixed Resonance Disc's item display	

`1.1.0`
- Nerfed passive attack speed
- Reduced Crush duration, buffed air stall slightly
- Increased projectile size on To The Stars to help with hitting smaller enemies
- Fixed compatibility with Aatrox
- Added agile keyword to Crush
- Added a couple more display rules and some visual tweaks
- Properly anchored picks to the hands

`1.0.0`
- Initial release

## Future Plans
- Alt special
- Skills++ support