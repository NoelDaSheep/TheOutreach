using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace TheOutreach.Content.Projectiles.DesertUsurper
{
	public class UsurperLightningBall : ModProjectile
	{
		public override void SetStaticDefaults() {
			//Main.projFrames[Type] = 2;
		}

		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			//Projectile.timeLeft = 300;
			Projectile.penetrate = -1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.aiStyle = 1;
		}


		public override void AI() 
		{
			Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);

			//Accelerate
			Projectile.velocity *= 1.01f;
			Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Projectile.Center; 
			dust = Terraria.Dust.NewDustDirect(position, 0, 0, DustID.Electric, 0f, 0f, 0, new Color(0,22,255), 0.9883721f);
			dust.noGravity = true;
		}
	}
}
