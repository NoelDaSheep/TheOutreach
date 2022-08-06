using TheOutreach.Content.Dusts;
using TheOutreach.Content.Projectiles.Magic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Magic
{
	public class VerdureStinger : ModProjectile
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 18;
			//Projectile.timeLeft = 300;
			Projectile.penetrate = -1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.netImportant = true;
			Projectile.DamageType = DamageClass.Magic;
			//Projectile.usesLocalNPCImmunity = true;
		}

		public override void AI()
        {
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2; // projectile sprite faces up
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.HornetStinger;
			return true;
		}

		/*public override void OnTileCollide(Vector2 oldVelocity)
		{
			if (Main.rand.NextBool(6))
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-2, 2) * .1f, Main.rand.Next(-2, 2) * .1f, mod.ProjectileType("VerdureSpore"), (int)(projectile.damage * .50f), 0, projectile.owner);
			}
		}*/

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(10))
			{
				//Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y - 16f, Main.rand.Next(-2, 2) * .1f, Main.rand.Next(-2, 2) * .05f, mod.ProjectileType("VerdureSpore"), (int)(projectile.damage * .50f), 0, projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity * 0.05f, ModContent.ProjectileType<VerdureSpore>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			}

			if (Main.rand.NextBool(3))
			{
				target.AddBuff(BuffID.Poisoned, 180, false);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(BuffID.Poisoned, 180, false);
			}
		}
	}
}