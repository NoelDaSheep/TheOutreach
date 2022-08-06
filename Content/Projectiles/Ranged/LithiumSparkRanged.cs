using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using TheOutreach.Content.Dusts;

namespace TheOutreach.Content.Projectiles.Ranged
{
	public class LithiumSparkRanged : ModProjectile
	{
		public override void SetStaticDefaults() {
			//Main.projFrames[Type] = 2;
		}

		public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			//Projectile.timeLeft = 300;
			Projectile.penetrate = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.DamageType = DamageClass.Melee;
			//Projectile.aiStyle = 1;
		}


		public override void AI() 
		{
			Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);

			//Accelerate
			Projectile.velocity *= 1.01f;
			Dust dust; // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Projectile.Center; 
			dust = Terraria.Dust.NewDustDirect(position, 0, 0, ModContent.DustType<Spark>(), 0f, 0f, 0);
			dust.noGravity = true;
		}
	}
}
