using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Summoner;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Minions
{
	// This minion shows a few mandatory things that make it behave properly.
	// Its attack pattern is simple: If an enemy is in range of 43 tiles, it will fly to it and deal contact damage
	// If the player targets a certain NPC with right-click, it will fly through tiles to it
	// If it isn't attacking, it will float near the player with minimal movement
	public class LithiumBeaconMinion : ModProjectile
	{
		public int ParentIndex
		{
			get => (int)Projectile.ai[0] - 1;
			set => Projectile.ai[0] = value + 1;
		}

		public bool HasParent => ParentIndex > -1;

		public int PositionIndex
		{
			get => (int)Projectile.ai[1] - 1;
			set => Projectile.ai[1] = value + 1;
		}

		public bool HasPosition => PositionIndex > -1;

		public Vector2 TargetsCenter;

		public float RotationTimerMax = 360;
		public float RotationTimer = 360;
		public int MinionsNumber;
		public bool haschecknum = false;

		public int ShootCoolMax = 50;
		public int ShootCool = 20;

		public Vector2 destination;
		public int damage = 15;
		public int shootspeed = 8;//velocity dumbass, 16 = 1 tile per frame so 60 tiles per second
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Beacon");
			// Sets the amount of frames this minion has on its spritesheet
			//Main.projFrames[Projectile.type] = 4;
			// This is necessary for right-click targeting
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

			Main.projPet[Projectile.type] = true; // Denotes that this projectile is a pet or minion

			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}

		public sealed override void SetDefaults() {
			Projectile.width = 18;
			Projectile.height = 28;
			Projectile.tileCollide = false; // Makes the minion go through tiles freely

			// These below are needed for a minion weapon
			Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
			Projectile.minion = true; // Declares this as a minion (has many effects)
			Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
			Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
			Projectile.damage = 0;
		}

		// Here you can decide if your minion breaks things like grass or pots
		public override bool? CanCutTiles() {
			return false;
		}

		// This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
		public override bool MinionContactDamage() {
			return true;
		}

		// The AI of this minion is split into multiple methods to avoid bloat. This method just passes values between calls actual parts of the AI.
		public override void AI() 
		{

			Player owner = Main.player[Projectile.owner];
			if (haschecknum == false)
			{

				MinionsNumber = owner.ownedProjectileCounts[ModContent.ProjectileType<LithiumBeaconMinion>()] += 1;
				//Main.NewText(MinionsNumber);
				ShootCoolMax = MinionsNumber += ShootCoolMax;
				haschecknum = true;
			}
			if (!CheckActive(owner))
			{
				return;
			}

			SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
			Visuals();
           
			ShootCool--;
			Player parentNPC = Main.player[Projectile.owner];

			// This basically turns the NPCs PositionIndex into a number between 0f and TwoPi to determine where around
			// the main body it is positioned at
			float rad = MinionsNumber / owner.ownedProjectileCounts[ModContent.ProjectileType<LithiumBeaconMinion>()] * MathHelper.TwoPi;

			// Add some slight uniform rotation to make the eyes move, giving a chance to touch the player and thus helping melee players
			RotationTimer += 0.05f;
			if (RotationTimer > RotationTimerMax) 
			{
				RotationTimer = 0;
			}

			// Since RotationTimer is in degrees (0..360) we can convert it to radians (0..TwoPi) easily
			float continuousRotation = MathHelper.ToRadians(RotationTimer);
			rad += continuousRotation;
			if (rad > MathHelper.TwoPi) {
				rad -= MathHelper.TwoPi - MinionsNumber;
			}
			else if (rad < 0) {
				rad += MathHelper.TwoPi + MinionsNumber;
			}

			float distanceFromBody = parentNPC.width + Projectile.width;

			// offset is now a vector that will determine the position of the NPC based on its index
			Vector2 offset = Vector2.One.RotatedBy(rad) * distanceFromBody;

			Vector2 destination = parentNPC.Center + offset;

				//float speed = 10f;
				//float inertia = 40f;
			Projectile.position = destination;
			//Vector2 moveTo = toDestinationNormalized * speed;
			//NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
		}

		public void Shoot()
		{
			if (ShootCool <= 0)
			{
				destination = Vector2.Normalize(TargetsCenter - Projectile.Center) * shootspeed;
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, destination, ModContent.ProjectileType<LithiumSparkSummoner>(), damage, 6, Projectile.owner);
				ShootCool = ShootCoolMax;
			}
		}

		// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
		private bool CheckActive(Player owner) {
			if (owner.dead || !owner.active) {
				owner.ClearBuff(ModContent.BuffType<LithiumBeaconBuff>());

				return false;
			}

			if (owner.HasBuff(ModContent.BuffType<LithiumBeaconBuff>())) {
				Projectile.timeLeft = 2;
			}

			return true;
		}

		

		private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter) {
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
							TargetsCenter = targetCenter;
							foundTarget = true;
						}
					}
				}
			}
			if (foundTarget)
			{
				Shoot();
			}

			// friendly needs to be set to true so the minion can deal contact damage
			// friendly needs to be set to false so it doesn't damage things like target dummies while idling
			// Both things depend on if it has a target or not, so it's just one assignment here
			// You don't need this assignment if your minion is shooting things instead of dealing contact damage
		}
		private void Visuals() {
			// So it will lean slightly towards the direction it's moving
			Projectile.rotation = Projectile.velocity.X * 0.05f;

			// This is a simple "loop through all frames from top to bottom" animation
			int frameSpeed = 5;

			Projectile.frameCounter++;

			if (Projectile.frameCounter >= frameSpeed) {
				Projectile.frameCounter = 0;
				Projectile.frame++;

				if (Projectile.frame >= Main.projFrames[Projectile.type]) {
					Projectile.frame = 0;
				}
			}

			// Some visuals here
			Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
		}
	}
}
