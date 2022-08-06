using TheOutreach.Content.Dusts;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Magic
{
	public class VerdureSpore : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			//ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
			//ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 5;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.timeLeft = 180;
		}

		public override void AI()
        {

		}

		public override void Kill(int timeLeft)
		{

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(BuffID.Poisoned, 180, false);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(5))
			{
				target.AddBuff(BuffID.Poisoned, 180, false);
			}
		}
	}
}