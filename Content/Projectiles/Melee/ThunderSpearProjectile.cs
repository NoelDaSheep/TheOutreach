using TheOutreach.Content.Dusts;
using TheOutreach.Content.Projectiles.DesertUsurper;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Melee
{
	public class ThunderSpearProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunder Spear");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18; 
			Projectile.height = 102; 
			Projectile.aiStyle = 1; 
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged; 
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600; 
			Projectile.light = 0.5f; 
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
			Projectile.aiStyle = 1;
		}

        public override void AI()
        {
        }
    }
}
