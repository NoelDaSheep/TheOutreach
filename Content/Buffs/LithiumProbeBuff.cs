using Terraria;
using Terraria.ModLoader;
using TheOutreach.Content.Projectiles;
using TheOutreach.Content.Projectiles.Minions;

namespace TheOutreach.Content.Buffs
{
	public class LithiumProbeBuff: ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Probe");
			Description.SetDefault("A Little Robot is following you.");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex)
		{
			// If the minions exist reset the buff time, otherwise remove the buff from the player
			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumProbe>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}