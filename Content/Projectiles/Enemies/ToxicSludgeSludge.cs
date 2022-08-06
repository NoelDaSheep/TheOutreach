using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace TheOutreach.Content.Projectiles.Enemies
{
	public class ToxicSludgeSludge : ModProjectile
	{
		public override void SetStaticDefaults() 
		{

		}

		public override void SetDefaults() {
			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.timeLeft = TheOutreachMod.ToTicks(10);
			Projectile.penetrate = -1;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.aiStyle = 1;
			Projectile.alpha = 75;
		}


		public override void AI() 
		{
			Projectile.rotation = Projectile.velocity.ToRotation();
			Projectile.velocity.Y = Projectile.velocity.Y + 0.4f;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.NextBool(2))
            {
				target.AddBuff(BuffID.Poisoned, TheOutreachMod.ToTicks(15));
			}
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.velocity = Vector2.Zero;
			return false;
        }
    }
}
