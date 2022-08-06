using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

using TheOutreach.Content.Projectiles.DesertUsurper;

namespace TheOutreach.Content.NPCs.DesertUsurper
{
	[AutoloadBossHead]
	public class DesertTotem : ModNPC
	{
		public int ParentIndex 
		{
			get => (int)NPC.ai[0] - 1;
			set => NPC.ai[0] = value + 1;
		}

		public bool HasParent => ParentIndex > -1;

		public int PositionIndex 
		{
			get => (int)NPC.ai[1] - 1;
			set => NPC.ai[1] = value + 1;
		}

		public bool HasPosition => PositionIndex > -1;

		public const float RotationTimerMax = 360;
		public ref float RotationTimer => ref NPC.ai[2];
		public int addamount;
		public int AttackTimer = 60;
		public int AttackTimerMax = 60;
		public int chargetimer = 500;
		public int chargetimermax = 500;
		public bool isCharging = false;
		public static int BodyType() {
			return ModContent.NPCType<DesertUsurper>();
		}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Desert Totem");
			Main.npcFrameCount[Type] = 5;

			// By default enemies gain health and attack if hardmode is reached. this NPC should not be affected by that
			NPCID.Sets.DontDoHardmodeScaling[Type] = true;
			// Enemies can pick up coins, let's prevent it for this NPC
			NPCID.Sets.CantTakeLunchMoney[Type] = true;
			// Automatically group with other bosses
			NPCID.Sets.BossBestiaryPriority.Add(Type);

			// Specify the debuffs it is immune to
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				SpecificallyImmuneTo = new int[] {
					BuffID.Poisoned,

					BuffID.Confused, // Most NPCs have this

					BuffID.Slow,

					BuffID.OgreSpit,

					BuffID.Electrified,

					BuffID.BetsysCurse,

					BuffID.ShadowFlame,

					BuffID.CursedInferno
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

			// Optional: If you don't want this NPC to show on the bestiary (if there is no reason to show a boss minion separately)
			// Make sure to remove SetBestiary code aswell
			// NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
			//	Hide = true // Hides this NPC from the bestiary
			// };
			// NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);
		}

		public override void SetDefaults() {
			NPC.width = 23;
			NPC.height = 23;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.lifeMax = 1000;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.knockBackResist = 0.8f;
			NPC.alpha = 255; // This makes it transparent upon spawning, we have to manually fade it in in AI()
			NPC.netAlways = true;

			NPC.aiStyle = -1;
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			if (Main.expertMode == true)
			{
				NPC.lifeMax = 1350;
				AttackTimerMax = 45;
			}

			if (Main.masterMode == true)
			{
				NPC.lifeMax = 1750;
				AttackTimerMax = 30;
			}
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// Makes it so whenever you beat the boss associated with it, it will also get unlocked immediately
			int associatedNPCType = BodyType();
			bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[associatedNPCType], quickUnlock: true);

			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,
				new FlavorTextBestiaryInfoElement("A totem of electricity, created by the Usurper to protect him in battle.")
			});
		}

		public override Color? GetAlpha(Color drawColor) {
			if (NPC.IsABestiaryIconDummy) {
				// This is required because we have NPC.alpha = 255, in the bestiary it would look transparent
				return NPC.GetBestiaryEntryColor();
			}
			return Color.White * NPC.Opacity;
		}

		public override void HitEffect(int hitDirection, double damage) {
			if (NPC.life <= 0) {
				// If this NPC dies, spawn some visuals

				int dustType = 59; // Some blue dust, read the dust guide on the wiki for how to find the perfect dust
				for (int i = 0; i < 20; i++) {
					Vector2 velocity = NPC.velocity + new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f));
					Dust dust = Dust.NewDustPerfect(NPC.Center, dustType, velocity, 26, Color.White, Main.rand.NextFloat(1.5f, 2.4f));
					dust.noLight = true;
					dust.noGravity = true;
					dust.fadeIn = Main.rand.NextFloat(0.3f, 0.8f);
				}
			}
		}

		public override void AI() 
		{

			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest();
			}

			Player player = Main.player[NPC.target];

			if (Despawn()) {
				return;
			}

			FadeIn();

			MoveInFormation();

			NPC.rotation = NPC.velocity.X * 0.05f;

			AttackTimer--;
			chargetimer--;

			AttackTimerMax = 60 + (int)PositionIndex;
			chargetimermax = 500;

			if (AttackTimer <= 0 && Main.netMode != NetmodeID.MultiplayerClient && !isCharging)
			{
				int damage = NPC.damage;
				Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center, player.Center - NPC.Center, ModContent.ProjectileType<UsurperLightningBall>(), 10, 0f, Main.myPlayer);
				AttackTimer = AttackTimerMax;
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			int speed = 8;
			if (NPC.frameCounter >= speed)
			{
				NPC.frameCounter = 0;
				NPC.frame.Y += frameHeight;
				if (NPC.frame.Y >= frameHeight * Main.npcFrameCount[NPC.type])
				{
					NPC.frame.Y = 0;
				}
			}

			// Some visuals here
			Lighting.AddLight(NPC.Center, Color.CornflowerBlue.ToVector3() * 0.78f);
		}

		private bool Despawn() {
			if (Main.netMode != NetmodeID.MultiplayerClient &&
				(!HasPosition || !HasParent || !Main.npc[ParentIndex].active || Main.npc[ParentIndex].type != BodyType())) {
				// * Not spawned by the boss body (didn't assign a position and parent) or
				// * Parent isn't active or
				// * Parent isn't the body
				// => invalid, kill itself without dropping any items
				NPC.active = false;
				NPC.life = 0;
				NetMessage.SendData(MessageID.SyncNPC, number: NPC.whoAmI);
				return true;
			}
			return false;
		}

		private void FadeIn() {
			// Fade in (we have NPC.alpha = 255 in SetDefaults which means it spawns transparent)
			if (NPC.alpha > 0) {
				NPC.alpha -= 10;
				if (NPC.alpha < 0) {
					NPC.alpha = 0;
				}
			}
		}

		private void MoveInFormation()
		{
			NPC parentNPC = Main.npc[ParentIndex];

			// This basically turns the NPCs PositionIndex into a number between 0f and TwoPi to determine where around
			// the main body it is positioned at
			float rad = (float)PositionIndex / DesertUsurper.MinionCount() * MathHelper.TwoPi;

			// Add some slight uniform rotation to make the eyes move, giving a chance to touch the player and thus helping melee players
			RotationTimer += 0.5f;
			if (RotationTimer > RotationTimerMax) 
			{
				RotationTimer = 0;
			}

			// Since RotationTimer is in degrees (0..360) we can convert it to radians (0..TwoPi) easily
			float continuousRotation = MathHelper.ToRadians(RotationTimer);
			rad += continuousRotation;
			if (rad > MathHelper.TwoPi) {
				rad -= MathHelper.TwoPi;
			}
			else if (rad < 0) {
				rad += MathHelper.TwoPi;
			}

			float distanceFromBody = parentNPC.width + NPC.width;

			// offset is now a vector that will determine the position of the NPC based on its index
			Vector2 offset = Vector2.One.RotatedBy(rad) * distanceFromBody;

			Vector2 destination = parentNPC.Center + offset;
			Vector2 toDestination = destination - NPC.Center;
			Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.Zero);

			//float speed = 10f;
			//float inertia = 40f;
			NPC.position = destination;
			//Vector2 moveTo = toDestinationNormalized * speed;
			//NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
		}
	}
}
