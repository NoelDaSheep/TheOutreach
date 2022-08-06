using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class LithiumJackhammer : ModProjectile
	{
		public override void SetStaticDefaults()
        {
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 44;
			Projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true; //so you can't hit enemies through walls
			Projectile.DamageType = DamageClass.Melee;
		}
        public override void AI()
        {
			int frameSpeed = 4;

			Projectile.frameCounter++;

			if (Projectile.frameCounter >= frameSpeed)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;

				if (Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
			}
		}
        
	}
}