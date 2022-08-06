using TheOutreach.Content.Dusts;
using TheOutreach.Content.Tiles;
using TheOutreach.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Materials;

namespace TheOutreach.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class LithiumDrill : ModProjectile
	{
		public override void SetStaticDefaults()
        {
		}

		public override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 40;
			Projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true; //so you can't hit enemies through walls
			Projectile.DamageType = DamageClass.Melee;
		}
	}
}