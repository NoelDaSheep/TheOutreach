using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Weapons.Melee;
using TheOutreach.Content.Projectiles.DesertUsurper;
using TheOutreach.Content.Projectiles.Melee;
using TheOutreach.Content.Dusts;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace TheOutreach.Content.Projectiles.Melee
{
	public class LithiumScytheProjectile : ModProjectile
	{

		public bool HasHit = false;

		Vector2 velocityThreshhold;

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Scythe");
		}

		public override void SetDefaults() {
			// This method right here is the backbone of what we're doing here; by using this method, we copy all of
			// the Meowmere Projectile's SetDefault stats (such as projectile.friendly and projectile.penetrate) on to our projectile,
			// so we don't have to go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner;
			// if you're going to copy the stats of a projectile, use CloneDefaults().

			Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);

			// To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
			// the projectile to essentially behave the same way as the vanilla projectile.
			AIType = ProjectileID.EnchantedBoomerang;

			// After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
			// For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
			// This can be done by modifying projectile.penetrate
			//Projectile.penetrate += 3;
		}

		// While there are several different ways to change how our projectile could behave differently, lets make it so
		// when our projectile finally dies, it will explode into 4 regular Meowmere projectiles.
		public override void Kill(int timeLeft)
		{
			
		}

		//chain stuff 
        /*public override bool PreDraw(ref Color lightColor)
        {
			Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
			Vector2 center = Projectile.Center;
			Vector2 distToProj = playerCenter - Projectile.Center;
			float projRotation = distToProj.ToRotation() - 1.57f;
			float distance = distToProj.Length();
			for (int i = 0; i < 1000; i++)
			{
				if (distance > 4f && !float.IsNaN(distance))
				{
					distToProj.Normalize();
					distToProj *= 8f;
					center += distToProj;
					distToProj = playerCenter - center;
					distance = distToProj.Length();
					Color drawColor = lightColor;

					//Draw chain
					Main.EntitySpriteDraw(Request<Texture2D>("TheOutreach/Content/Projectiles/Melee/LithiumScytheChain").Value, new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y),
						new Rectangle(0, 0, 18, 12), drawColor, projRotation,
						new Vector2(18 * 0.5f, 12 * 0.5f), 1f, SpriteEffects.None, 0);
				}
			}

			return true;
		}*/
        // Now, using CloneDefaults() and aiType doesn't copy EVERY aspect of the projectile. In Vanilla, several other methods
        // are used to generate different effects that aren't included in AI. For the case of the Meowmete projectile, since the
        // richochet sound is not included in the AI, we must add it ourselves:
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if(HasHit == false)
            {
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.UnitX * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -Vector2.UnitX * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.UnitY * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -Vector2.UnitY * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
				HasHit = true;
            }
			
		}
		public override bool OnTileCollide(Vector2 oldVelocity) {
			// Since there are two Richochet sounds for the Meowmere, we can randomly choose between them like this:
			if (HasHit == false)
			{
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.UnitX * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -Vector2.UnitX * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Vector2.UnitY * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -Vector2.UnitY * 7, ModContent.ProjectileType<LithiumSparkMelee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
				SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
				HasHit = true;
			}
			return base.OnTileCollide(oldVelocity);
		}
        public override void AI()
        {
            if (Main.rand.NextBool(1, 4))
            {
				Dust dust;
				Vector2 position = Projectile.Center;
				dust = Terraria.Dust.NewDustDirect(position, 0, 0, ModContent.DustType<Spark>(), 0f, 0f, 0);
				dust.noGravity = true;
			}
		}
	}
}
