using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using TheOutreach.Content.Dusts;

namespace TheOutreach.Content.Projectiles.Magic
{
	public class LithiumSparkMagic : ModProjectile
	{
		public int waittohome = 30;
		public bool startyeet = false;
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Spark");
			//Main.projFrames[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.penetrate = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.aiStyle = 0;
			Projectile.light = 1f; // How much light emit around the projectile
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
		}


		

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);

			Dust dust;
			Vector2 position = Projectile.Center;
			dust = Terraria.Dust.NewDustDirect(position, 0, 0, ModContent.DustType<Spark>(), 0f, 0f, 0);
			dust.noGravity = true;
			
			waittohome--;

			if (waittohome <= 0)
            {
				if(startyeet == false)
                {
					Projectile.velocity *= 3f;
					startyeet = true;
				}

				float maxDetectRadius = 400f;
				float projSpeed = 25f;

				NPC closestNPC = FindClosestNPC(maxDetectRadius);
				if (closestNPC == null)
					return;

				
				Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
				Projectile.rotation = Projectile.velocity.ToRotation();
			}
            else
            {
				Projectile.velocity /= 1.01f;
            }
		}

		
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy())
				{
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}
}
