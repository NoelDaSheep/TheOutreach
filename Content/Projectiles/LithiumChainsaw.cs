using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class LithiumChainsaw : ModProjectile
	{
		public override void SetStaticDefaults()
        {
		}

		public override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 48;
			Projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true; //so you can't hit enemies through walls
			Projectile.DamageType = DamageClass.Melee;
		}
	}
}