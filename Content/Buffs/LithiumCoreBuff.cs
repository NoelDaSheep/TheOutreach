using Terraria;
using Terraria.ModLoader;
using TheOutreach.Content.Projectiles;
using TheOutreach.Content.Projectiles.Magic;

namespace TheOutreach.Content.Buffs
{
	public class LithiumCoreBuff: ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Core");
			Description.SetDefault("Magic attacks also shoot sparks");

			Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
			Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumMageBonus>()] > 0)
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