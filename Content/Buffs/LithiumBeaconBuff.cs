using TheOutreach.Content.Items;
using TheOutreach.Content.Tiles.Furniture;
using TheOutreach.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Buffs
{
	// This file contains all the code necessary for a minion
	// - ModItem - the weapon which you use to summon the minion with
	// - ModBuff - the icon you can click on to despawn the minion
	// - ModProjectile - the minion itself

	// It is not recommended to put all these classes in the same file. For demonstrations sake they are all compacted together so you get a better overwiew.
	// To get a better understanding of how everything works together, and how to code minion AI, read the guide: https://github.com/tModLoader/tModLoader/wiki/Basic-Minion-Guide
	// This is NOT an in-depth guide to advanced minion AI

	public class LithiumBeaconBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Beacon");
			Description.SetDefault("An old Mining Beacon will fight for you");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex) {
			// If the minions exist reset the buff time, otherwise remove the buff from the player
			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumBeaconMinion>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
