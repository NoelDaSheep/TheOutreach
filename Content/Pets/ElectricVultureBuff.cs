using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TheOutreach.Content.Pets
{
	public class ElectricVultureBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electric Vulture");
			Description.SetDefault("Zap");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) { // This method gets called every frame your buff is active on your player.
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<ElectricVultureProjectile>();

			// If the player is local, and there hasn't been a pet projectile spawned yet - spawn it.
			if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0) {
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
			}
		}
	}
}
