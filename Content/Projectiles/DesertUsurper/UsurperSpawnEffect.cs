using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using TheOutreach.Content.NPCs.DesertUsurper;
using TheOutreach.Common.Systems;

namespace TheOutreach.Content.Projectiles.DesertUsurper
{
	public class UsurperSpawnEffect : ModProjectile
	{
		public int time = 690;

		public override string Texture => "TheOutreach/Content/Projectiles/InvisibleProjectile";

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Desert Usurper Spawning Effect");
		}

		public override void SetDefaults() {
			Projectile.width = 2;
			Projectile.height = 2;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.timeLeft = 690;
		}


		public override void AI() 
		{
			Main.NewText("yay", Color.White);
			time++;
			if(time == 269)
            {
				SummonUsurper();
            }

			if (time >= 270f)
			{
				if (Main.netMode != 1 && !NPC.AnyNPCs(ModContent.NPCType<NPCs.DesertUsurper.DesertUsurper>()))
				{
					Projectile.Kill();
				}
				return;
			}
			int fireReleaseRate = ((!(time > 150f)) ? 1 : 2);
			for (int i = 0; i < fireReleaseRate; i++)
			{
				if (Utils.NextBool(Main.rand, 4))
				{
					Dust dust = Dust.NewDustPerfect(Projectile.Center + new Vector2(Main.rand.NextFloat(-20f, 24f)), DustID.Electric, new Vector2(Main.rand.NextFloat(10f, 18f)), 267);
					dust.scale = Utils.NextFloat(Main.rand, 0.7f, 1f);
					dust.color = Color.Lerp(Color.Orange, Color.Red, Main.rand.NextFloat());
					dust.fadeIn = 0.7f;
					dust.velocity = -Vector2.UnitY * Utils.NextFloat(Main.rand, 1.5f, 2.8f);
					dust.noGravity = true;
				}
			}
		}
		public void SummonUsurper()
        {
			if (Main.netMode != 1)
            {
				TheOutreachUtils.SpawnBossBetter(Projectile.Center - new Vector2(60f), ModContent.NPCType<NPCs.DesertUsurper.DesertUsurper>());
			}

		}
	}
}
