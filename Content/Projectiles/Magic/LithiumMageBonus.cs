using TheOutreach.Content.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Summoner;
using TheOutreach.Content.Projectiles.Ranged;

namespace TheOutreach.Content.Projectiles.Magic
{
	// PurityWisp uses inheritace as an example of how it can be useful in modding.
	// HoverShooter and Minion classes help abstract common functionality away, which is useful for mods that have many similar behaviors.
	// Inheritance is an advanced topic and could be confusing to new programmers, see ExampleSimpleMinion.cs for a simpler minion example.
	public class LithiumMageBonus : ModProjectile
	{

		public int ShootCoolMax = 20;
		public int ShootCool = 20;
		public float RotationTimer = 360;
		public float RotationTimerMax = 360;

		public Vector2 TargetsCenter;
		public Vector2 destination;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Laser Core");
			// Sets the amount of frames this minion has on its spritesheet
			//Main.projFrames[Projectile.type] = 3;
			// This is necessary for right-click targeting
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

			Main.projPet[Projectile.type] = true; // Denotes that this projectile is a pet or minion

			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		public sealed override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.tileCollide = false; // Makes the minion go through tiles freely

			Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
			Projectile.minion = true; // Declares this as a minion (has many effects)
			Projectile.DamageType = DamageClass.Magic; // Declares the damage type (needed for it to deal damage)
			Projectile.minionSlots = 0f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
			Projectile.damage = 25;
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles()
		{
			return false;
		}

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage()
		{
			return true;
		}

		// The AI of this minion is split into multiple methods to avoid bloat. This method just passes values between calls actual parts of the AI.
		public override void AI()
		{
			Player owner = Main.player[Projectile.owner];

			if (owner.setBonus == "" || owner.setBonus != "+20 mana \nMagic Attacks will fire an extra spark")
			{
				owner.ClearBuff(ModContent.BuffType<LithiumCoreBuff>());
			}
			if (owner.HasBuff(ModContent.BuffType<LithiumCoreBuff>()))
			{
				Projectile.timeLeft = 2;
			}
			
			SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
			Visuals();

			Vector2 toMouse = Vector2.Normalize(owner.position - Main.MouseWorld);

			Projectile.rotation = toMouse.ToRotation() - MathHelper.PiOver2;


			// Add some slight uniform rotation to make the eyes move, giving a chance to touch the player and thus helping melee players
			// Since RotationTimer is in degrees (0..360) we can convert it to radians (0..TwoPi) easily

			// offset is now a vector that will determine the position of the NPC based on its index


			//float speed = 10f;
			//float inertia = 40f;
			destination.X = owner.position.X;
			destination.Y = owner.position.Y;
			destination.Y = destination.Y -= 70;
			Projectile.position = destination;

			Vector2 TargetRot = targetCenter - Projectile.Center;
			TargetsCenter = TargetRot;

			//Projectile.rotation = TargetRot.ToRotation() - MathHelper.PiOver2;

			ShootCool--;
			
		}

		public void Shoot()
        {
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, TargetsCenter, ModContent.ProjectileType<LithiumSparkRanged>(), 25, 6, Projectile.owner);
		}
		// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not


		private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
		{
			// Starting search distance
			distanceFromTarget = 700f;
			targetCenter = Projectile.position;
			foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			/*if (owner.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[owner.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);

				// Reasonable distance away so it doesn't target across multiple screens
				if (between < 2000f)
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					targetCenter.Y -= 70;
					foundTarget = true;
				}
			}*/

			if (!foundTarget)
			{
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];

					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;

						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}
			// friendly needs to be set to true so the minion can deal contact damage
			// friendly needs to be set to false so it doesn't damage things like target dummies while idling
			// Both things depend on if it has a target or not, so it's just one assignment here
			// You don't need this assignment if your minion is shooting things instead of dealing contact damage
			//Projectile.friendly = foundTarget;
		}

		private void Visuals()
		{
			// So it will lean slightly towards the direction it's moving
			Projectile.rotation = Projectile.velocity.X * 0.05f;

			// This is a simple "loop through all frames from top to bottom" animation
			int frameSpeed = 5;

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

			// Some visuals here
			Lighting.AddLight(Projectile.Center, Color.CornflowerBlue.ToVector3() * 0.78f);



		}
	}
}
