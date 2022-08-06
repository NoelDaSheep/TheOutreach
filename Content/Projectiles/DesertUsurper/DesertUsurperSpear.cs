using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TheOutreach.Content.Projectiles.DesertUsurper
{
	public class DesertUsurperSpear : ModProjectile
	{
		public int spintimer = 0;
		public int launchtimer = 0;
		public int spintimettwo = 0;
		public int stage = 0; //0 = spinning in place one, 1 = thrown towards a position, 2 = spinning in position, 3 = explode
		public int shootdir = 0;
		public int shoottimer = 5;
		public int speed = 13;
		public override void SetStaticDefaults() {
			//Main.projFrames[Type] = 2;
		}

		public override void SetDefaults() {
			Projectile.width = 74;
			Projectile.height = 78;
			Projectile.timeLeft = int.MaxValue;
			Projectile.penetrate = -1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.aiStyle = -1;
		}


		public override void AI() 
		{
			byte target = Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height);
			Player closestPlayer = Main.player[target]; Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);

			if(closestPlayer.active && !closestPlayer.dead)
            {
				//stages:
				//stage one
				if (stage == 0)
				{
					spintimer++;
					Projectile.rotation += MathHelper.ToRadians(10f);
					if(spintimer >= 60)
                    {
						stage = 1;
                    }
				}
				//stage two
				if (stage == 1)
				{
					launchtimer++;
					if (launchtimer == 1)
					{
						Projectile.velocity = (closestPlayer.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * speed;
						Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
						if (Projectile.spriteDirection == -1)
						{
							Projectile.rotation -= MathHelper.ToRadians(90f);
						}
					}
					if(launchtimer >= 15)
                    {
						Projectile.velocity /= 1.10f;
						Projectile.rotation += MathHelper.ToRadians(launchtimer / 5);
                    }
					if (launchtimer >= 90)
					{
						stage = 2;
					}
				}
				//stage three
				if(stage == 2)
                {
					spintimettwo++;
					shoottimer--;
					Projectile.velocity = new Vector2(0, 0);
					Projectile.rotation += MathHelper.ToRadians(20f);
					if(shoottimer <= 0)
                    {
						Vector2 vel = new Vector2(0, 15).RotatedBy(Projectile.rotation);
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel, ModContent.ProjectileType<UsurperLightningBall>(), Projectile.damage / 2, 1);
						shoottimer = 10;
                    }
					if (spintimettwo >= 300)
                    {
						stage = 3;
                    }
                }
				//stage four
				if(stage == 3)
                {
					Projectile.Kill();
                }
			}
            else
            {
				target = Player.FindClosest(Projectile.Center, Projectile.width, Projectile.height);
				closestPlayer = Main.player[target]; Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);
			}
		}
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 100; i++)
			{
				if (Utils.NextBool(Main.rand, 4))
				{
					Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
					Dust d2 = Dust.NewDustPerfect(Projectile.Center, DustID.Electric, speed2 * 7, Scale: 1f);
					d2.noGravity = true;
				}
			}

			for (int i = 0; i < 15; i++)
			{			
					Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.25f, 0.25f);
					Dust d2 = Dust.NewDustPerfect(Projectile.Center, DustID.Electric, speed2 * 5, Scale: 1f);
					d2.noGravity = false;
			}
		}
    }
}
