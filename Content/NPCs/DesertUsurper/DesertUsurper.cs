using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Events;
using System;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

using TheOutreach.Content.Projectiles.DesertUsurper;
using TheOutreach.Content.Items.DesertUsurper;
using TheOutreach.Content.Dusts;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Armor.Vanity.BossVanity;
using TheOutreach.Content.Pets;
using TheOutreach.Content.BossBars;
using TheOutreach.Common.Systems;
using TheOutreach.Common.Configs;


namespace TheOutreach.Content.NPCs.DesertUsurper
{
	[AutoloadBossHead]
	public class DesertUsurper : ModNPC
	{
		public static List<string> helpphasetext = new List<string>
		{
			"Im just getting started!",
			"I need backup!",
			"I don’t need family!"
		};
		public Vector2 dashDestination
		{
			get => new Vector2(NPC.ai[1], NPC.ai[2]);
			set
			{
				NPC.ai[1] = value.X;
				NPC.ai[2] = value.Y;
			}
		}
		public int FirstStageTimerMax = 90;
		public int SecondStageTimerMax = 45;
		public int ThirdStageTimerMax = 30;

		// Auto-implemented property, acts exactly like a variable by using a hidden backing field
		public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;
		public Vector2 lastdashDestination { get; set; } = Vector2.Zero;

		public bool SecondStage = false;
		
		public bool ThirdStage = false;

		public int Phase = 0;

		public int lightDropTimer = 0;
		public ref float FirstStageTimer => ref NPC.localAI[1];
		public float dashtimer = 0;
		public ref float SecondStageTimer => ref NPC.localAI[1];
		public float ThirdStageTimer = 30;

		public ref float RemainingShields => ref NPC.localAI[2];

		public bool isOpenCutscene = true;
		public int openCutsceneTimer = 0;
		public int openCutsceneTextNumber = 0;

		public bool isDeathCutscene = false;
		public int deathCutsceneTimer = 0;
		public int deathCutsceneTextNumber = 0;

		public int spearTimer = 300;
		public int spearTimerMax = 600;

		public bool isStartBattleNoCutscene = true;
		public static int MinionType()
		{
			return ModContent.NPCType<DesertTotem>();
		}

		// Helper method to determine the amount of minions summoned
		public static int MinionCount()
		{
			int count = 3;

			if (Main.expertMode)
			{
				count += 1; // Increase by 5 if expert or master mode
			}

			if (Main.masterMode)
			{
				count += 3; // Increase by 5 if expert or master mode
			}

			if (Main.getGoodWorld)
			{
				count += 2; // Increase by 5 if using the "For The Worthy" seed
			}

			return count;
		}

		public bool SpawnedMinions
		{
			get => NPC.localAI[0] == 1f;
			set => NPC.localAI[0] = value ? 1f : 0f;
		}
		public bool isdashing = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Usurper");
			Main.npcFrameCount[Type] = 2;

			// Add this in for bosses that have a summon item, requires corresponding code in the item (See MinionBossSummonItem.cs)
			NPCID.Sets.MPAllowedEnemies[Type] = true;
			// Automatically group with other bosses
			NPCID.Sets.BossBestiaryPriority.Add(Type);

			// Specify the debuffs it is immune to
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] 
				{
					BuffID.Poisoned,

					BuffID.Confused,

					BuffID.Slow,

					BuffID.OgreSpit,

					BuffID.Electrified,

					BuffID.BetsysCurse,

					BuffID.ShadowFlame,

					BuffID.CursedInferno
				}
			};
			NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				//Velocity = -1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							   // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							   // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
		}

		public override void SetDefaults()
		{
			NPC.width = 26;
			NPC.height = 46;
			NPC.damage = 20;
			NPC.defense = 7;
			NPC.lifeMax = 4700;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath37;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.value = Item.buyPrice(gold: 10);
			NPC.SpawnWithHigherTime(30);
			NPC.boss = true;
			NPC.npcSlots = 10f; // Take up open spawn slots, preventing random NPCs from spawning during the fight

			NPC.aiStyle = -1;

			NPC.BossBar = ModContent.GetInstance<DesertUsurperBossBar>();
			
			//Need Music
			/*if (!Main.dedServ)
			{
				Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/FileName");
			}*/
		}

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
			if (Main.expertMode == true)
            {
				NPC.lifeMax = 7200;
				NPC.defense = 10;
				FirstStageTimerMax = 75;
				SecondStageTimerMax = 35;
				ThirdStageTimerMax = 25;
			}

			if (Main.masterMode == true)
            {
				NPC.lifeMax = 9800;
				NPC.defense = 12;
				FirstStageTimerMax = 60;
				SecondStageTimerMax = 35;
				ThirdStageTimerMax = 20;
			}
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{

			npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<DesertUsurperBag>()));

			//Trophy
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Furniture.BossRelics.DesertUsurperTrophy>(), 10));
			
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapons.Melee.ElectrostaticKnopesh>()));

			//Relic
			npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeable.Furniture.BossRelics.DesertUsurperRelic>()));

			//Pet
			npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<ElectricVultureItem>(), 4));

			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());

			//Feathers
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<VoltaicFeather>(), 1, 10, 15));
			//Mask
			notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<DesertUsurperMask>(), 7));

			// Finally add the leading rule
			npcLoot.Add(notExpertRule);
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			// If the NPC dies, spawn gore and play a sound
			if (Main.netMode == NetmodeID.Server)
			{
				// We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers
				return;
			}

			if (NPC.life <= 0 && Phase == 69)
			{
				// These gores work by simply existing as a texture inside any folder which path contains "Gores/"
				int backGoreType = Mod.Find<ModGore>("DesertUsurperBody").Type;
				int frontGoreType = Mod.Find<ModGore>("DesertUsurperHead").Type;
				int middleGoreType = Mod.Find<ModGore>("DesertUsurperLegs").Type;
				int armGoreType = Mod.Find<ModGore>("DesertUsurperArm").Type;

				var entitySource = NPC.GetSource_Death();

				Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
				Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
				Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), middleGoreType);
				Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), armGoreType);

				SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
				if (!NPCdowned.downedUsurper)
				{
					Main.NewText("He was but a feeble mistake, returned to us now.", Color.Red);
					NPCdowned.downedUsurper = true;
				}
			}
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// Sets the description of this NPC that is listed in the bestiary
			bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,

				new FlavorTextBestiaryInfoElement("Once an Outcast, full of revenge and spite, now freed from the emotional prison of his own creation")
			});
		}

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.HealingPotion;
		}

		public override void FindFrame(int frameHeight)
		{

			NPC.TargetClosest(true);

			if (isdashing)
			{
				NPC.frame.Y = NPC.height * 1;

			}
			if(!isdashing || isDeathCutscene)
			{
				NPC.frame.Y = NPC.height * 0;
				NPC.rotation = NPC.velocity.X * 0.05f;
			}

			NPC.spriteDirection = NPC.direction;
		}
		public void OpenCutscene()
        {
			Phase = 0;
			NPC.dontTakeDamage = true;
			NPC.velocity = new Vector2(0, 0);
			openCutsceneTimer++;
			if(openCutsceneTimer >= 240 && openCutsceneTextNumber == 0)
            {
				Main.NewText("You really think YOU are strong enough to defeat me!?", Color.BlueViolet);
				//Main.combatText[CombatText.NewText(NPC.getRect(), Color.BlueViolet, "You really think YOU are strong enough to defeat me!?")].lifeTime = 220;
				openCutsceneTextNumber = 1;
				openCutsceneTimer = 0;
			}
			if(openCutsceneTimer >= 240 && openCutsceneTextNumber == 1)
            {
				Main.NewText("I have defeated single handedly defeated entire ARMIES!", Color.BlueViolet);
				//Main.combatText[CombatText.NewText(NPC.getRect(), Color.BlueViolet, "I have defeated single handedly defeated entire ARMIES!")].lifeTime = 220;
				openCutsceneTextNumber = 2;
				openCutsceneTimer = 0;
			}
			if (openCutsceneTimer >= 240 && openCutsceneTextNumber == 2)
			{
				Main.NewText("You will regret your choice to challenge me!", Color.BlueViolet);
				//Main.combatText[CombatText.NewText(NPC.getRect(), Color.BlueViolet, "You will regret your choice to challenge me!")].lifeTime = 220;
				openCutsceneTextNumber = 3;
				openCutsceneTimer = 0;
			}
			if (openCutsceneTimer >= 240 && openCutsceneTextNumber == 3)
			{
				isOpenCutscene = false;
				Phase = 1;
			}
		}
		public void DeathCutscene()
		{
			Phase = 0;
			NPC.dontTakeDamage = true;
			NPC.velocity = new Vector2(0, 0);
			deathCutsceneTimer++;
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 0)
			{
				Main.NewText("I have taken the desert, I have slain, and stolen...", Color.CornflowerBlue);
				deathCutsceneTextNumber = 1;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 1)
			{
				Main.NewText("Yet standing here, all i can think.", Color.CornflowerBlue);
				deathCutsceneTextNumber = 2;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 2)
			{
				Main.NewText("Was this all necessary?", Color.CornflowerBlue);
				deathCutsceneTextNumber = 3;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 3)
			{
				Main.NewText("To bring myself to this fate,", Color.CornflowerBlue);
				deathCutsceneTextNumber = 4;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 4)
			{
				Main.NewText("To bring everyone I cared about to this fate?", Color.CornflowerBlue);
				deathCutsceneTextNumber = 5;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 5)
			{
				Main.NewText("I always was a little short tempered.", Color.CornflowerBlue);
				deathCutsceneTextNumber = 6;
				deathCutsceneTimer = 0;
			}
			if (deathCutsceneTimer >= 260 && deathCutsceneTextNumber == 6)
			{
				NPC.dontTakeDamage = false;
				Phase = 69;
				NPC.checkDead();
			}
		}

        public override bool CheckDead()
        {
			if(Phase != 69 && ModContent.GetInstance<TheOutreachConfigs>().CutsceneToggle && !NPCdowned.downedUsurper)
            {
				NPC.life = 1;
				NPC.dontTakeDamage = true;
				isDeathCutscene = true;
				return false;
			}
            else
            {
				return true;
            }
        }
        public override void AI()
		{
			//Frames
			if (isdashing)
			{
				NPC.frame.Y = NPC.height * 1;
				NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2; // projectile sprite faces up
			}
			if(!isdashing || isDeathCutscene || Phase == 69)
			{
				NPC.frame.Y = NPC.height * 0;
			}

			// This should almost always be the first code in AI() as it is responsible for finding the proper player target
			if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest();
			}

			Player player = Main.player[NPC.target];

			if (player.dead)
			{
				// If the targeted player is dead, flee
				NPC.velocity.Y -= 0.04f;
				// This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
				NPC.EncourageDespawn(10);
				return;
			}

			// Be invulnerable during the first stage
			//NPC.dontTakeDamage = !SecondStage;
			if (!isOpenCutscene || !isDeathCutscene || ModContent.GetInstance<TheOutreachConfigs>().CutsceneToggle == false)
			{
				if (Phase == 1)
				{
					DoFirstStage(player);
				}

				if (Phase == 2)
				{
					DoSecondStage(player);
				}


				if (Phase == 3)
				{
					DoThirdStage(player);
				}

				CheckSecondStage();
				CheckThirdStage();
			}
			if (isOpenCutscene && ModContent.GetInstance<TheOutreachConfigs>().CutsceneToggle && !NPCdowned.downedUsurper)
            {
				OpenCutscene();
            }
			if (isDeathCutscene && ModContent.GetInstance<TheOutreachConfigs>().CutsceneToggle && !NPCdowned.downedUsurper)
			{
				DeathCutscene();
			}

			if (Phase <= 0 && (!ModContent.GetInstance<TheOutreachConfigs>().CutsceneToggle || NPCdowned.downedUsurper) && isStartBattleNoCutscene)
			{
				openCutsceneTimer++;
				if(openCutsceneTimer <= 1)
                {
					Main.NewText("Lets get this over with...", Color.Red);
                }
				if(openCutsceneTimer >= 60)
                {
					Phase = 1;
				}
			}

			Lighting.AddLight(NPC.Center, Color.CornflowerBlue.ToVector3() * 0.78f);

			if(isDeathCutscene || Phase == 69)
            {
				if (Main.rand.NextFloat() < 0.1f)
				{
					Vector2 position = NPC.Center;
					Terraria.Dust.NewDustDirect(position, 1, 1, DustID.Blood, 0f, 0.23255825f, 0, new Color(255, 255, 255), 1.5f);
				}

			}
		}

		private void CheckSecondStage()
		{
			if (SecondStage)
			{
				// No point checking if the NPC is already in its second stage
				return;
			}

			if (NPC.life <= NPC.lifeMax / 2 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				// If we have no shields (aka "no minions alive"), we initiate the second stage, and notify other players that this NPC has reached its second stage
				// by setting NPC.netUpdate to true in this tick. It will send important data like position, velocity and the NPC.ai[] array to all connected clients

				// Because SecondStage is a property using NPC.ai[], it will get synced this way
				Phase = 2;
				//Main.NewText(helpphasetext[Main.rand.Next(helpphasetext.Count)], Color.BlueViolet);
				NPC.netUpdate = true;
			}
		}

		private void CheckThirdStage()
		{
			if (ThirdStage)
			{
				// No point checking if the NPC is already in its second stage
				return;
			}

			float remainingShieldsSum = 0f;
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC otherNPC = Main.npc[i];
				if (otherNPC.active && otherNPC.type == MinionType() && otherNPC.ModNPC is DesertTotem minion)
				{
					if (minion.ParentIndex == NPC.whoAmI)
					{
						remainingShieldsSum += (float)otherNPC.life / otherNPC.lifeMax;
					}
				}
			}

			// We reference this in the MinionBossBossBar
			RemainingShields = remainingShieldsSum / MinionCount();

			if (SpawnedMinions && RemainingShields <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				// If we have no shields (aka "no minions alive"), we initiate the second stage, and notify other players that this NPC has reached its second stage
				// by setting NPC.netUpdate to true in this tick. It will send important data like position, velocity and the NPC.ai[] array to all connected clients

				// Because SecondStage is a property using NPC.ai[], it will get synced this way
				Phase = 3;
				NPC.netUpdate = true;
			}
		}

		private void DoFirstStage(Player player)
		{
			NPC.dontTakeDamage = false;
			isOpenCutscene = false;
			Vector2 toPlayer = player.Center - NPC.Center;
			spearTimer--;
			float offsetX = 200f;
			var entitySource = NPC.GetSource_FromAI();

			Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

			Vector2 toAbovePlayer = abovePlayer - NPC.Center;
			Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

			// The NPC tries to go towards the offsetX position, but most likely it will never get there exactly, or close to if the player is moving
			// This checks if the npc is "70% there", and then changes direction
			float changeDirOffset = offsetX * 0.7f;

			if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
				NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
			{
				NPC.direction *= -1;
			}

			float speed = 8f;
			float inertia = 40f;

			// If the boss is somehow below the player, move faster to catch up
			if (NPC.Top.Y > player.Bottom.Y)
			{
				speed = 12f;
			}

			Vector2 moveTo = toAbovePlayerNormalized * speed;
			NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

			NPC.alpha = 0;
			FirstStageTimer--;

			if (FirstStageTimer <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
				Projectile.NewProjectile(entitySource, NPC.Center, player.Center - NPC.Center, ModContent.ProjectileType<UsurperLightningBall>(), 10, 0f, Main.myPlayer);
				FirstStageTimer = FirstStageTimerMax;
			}
			if(spearTimer <= 0)
            {
				SpearAttack(1, 1);
            }

			//NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;
		}

		private void DoSecondStage(Player player)
		{
			var entitySource = NPC.GetSource_FromAI();

			SpawnMinions();
			NPC.dontTakeDamage = true;

			Vector2 toPlayer = player.Center - NPC.Center;

			float offsetX = 300f;

			Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

			Vector2 toAbovePlayer = abovePlayer - NPC.Center;
			Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

			// The NPC tries to go towards the offsetX position, but most likely it will never get there exactly, or close to if the player is moving
			// This checks if the npc is "70% there", and then changes direction
			float changeDirOffset = offsetX * 0.7f;

			if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
				NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
			{
				NPC.direction *= -1;
			}

			float speed = 8f;
			float inertia = 40f;

			// If the boss is somehow below the player, move faster to catch up
			if (NPC.Top.Y > player.Bottom.Y)
			{
				speed = 12f;
			}

			Vector2 moveTo = toAbovePlayerNormalized * speed;
			NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

			NPC.alpha = 0;

			//NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;

			FirstStageTimer--;

			if (SecondStageTimer <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
			{
				Projectile.NewProjectile(entitySource, NPC.Center, player.Center - NPC.Center, ModContent.ProjectileType<UsurperLightningBall>(), 10, 0f, Main.myPlayer);
				SecondStageTimer = SecondStageTimerMax;
			}
		}

		private void DoThirdStage(Player player)
		{
			var entitySource = NPC.GetSource_FromAI();
			NPC.dontTakeDamage = false;

			Vector2 toPlayer = player.Center - NPC.Center;

			float offsetX = 200f;

			Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

			Vector2 toAbovePlayer = abovePlayer - NPC.Center;
			Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

			// The NPC tries to go towards the offsetX position, but most likely it will never get there exactly, or close to if the player is moving
			// This checks if the npc is "70% there", and then changes direction
			float changeDirOffset = offsetX * 0.7f;

			if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
				NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
			{
				NPC.direction *= -1;
			}

			float speed = 8f;
			float inertia = 40f;

			// If the boss is somehow below the player, move faster to catch up
			if (NPC.Top.Y > player.Bottom.Y)
			{
				speed = 12f;
			}
			if (isdashing == false)
			{
				Vector2 moveTo = toAbovePlayerNormalized * speed;
				NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;
				NPC.alpha = 0;
				ThirdStageTimer--;				
				if (FirstStageTimer <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
				{
					Projectile.NewProjectile(entitySource, NPC.Center, player.Center - NPC.Center, ModContent.ProjectileType<UsurperLightningBall>(), 10, 0f, Main.myPlayer);
					FirstStageTimer = 20;
				}
			}

			dashtimer++;
			if(dashtimer >= 200)
            {
				isdashing = true;
				DashAttack(15, player);
					if (!Main.dedServ)
						SoundEngine.PlaySound(new("TheOutreach/Assets/Sounds/UsurperDashOne"), NPC.position);

				dashtimer = 0;
            }
			if (dashtimer >= 50)
			{
				isdashing = false;
			}
			lightDropTimer++;
            if (!Main.masterMode)
            {
				if (lightDropTimer >= 300)
				{
					LightningDropAttack(5, player);
					lightDropTimer = 0;
				}
			}
            else
            {
				if (lightDropTimer >= 250)
				{
					LightningDropAttack(5, player);
					lightDropTimer = 0;
				}
			}
		}
		private void SpearAttack(int waittime, int spearspeed)
        {
			var entitySource = NPC.GetSource_FromAI();
			Vector2 vel = new Vector2(0, 0);
			Projectile.NewProjectile(entitySource, NPC.Center, vel, ModContent.ProjectileType<DesertUsurperSpear>(), NPC.damage, Main.myPlayer);
			spearTimer = spearTimerMax;
        }
		private void DashAttack(int speed, Player dashplayer)
        {

			float distance = 200; // Distance in pixels behind the player
				isdashing = true;
				Vector2 fromPlayer = NPC.Center - dashplayer.Center;

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					// Important multiplayer concideration: drastic change in behavior (that is also decided by randomness) like this requires
					// to be executed on the server (or singleplayer) to keep the boss in sync

					float angle = fromPlayer.ToRotation();
					float twelfth = MathHelper.Pi / 6;

					angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
					if (angle > MathHelper.TwoPi)
					{
						angle -= MathHelper.TwoPi;
					}
					else if (angle < 0)
					{
						angle += MathHelper.TwoPi;
					}

					Vector2 relativeDestination = angle.ToRotationVector2() * distance;

					dashDestination = dashplayer.Center + relativeDestination;
					NPC.netUpdate = true;
				}
			// Move along the vector
			Vector2 toDestination = dashDestination - NPC.Center;
			Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
			float dashspeed = Math.Min(distance, toDestination.Length());
			NPC.velocity = toDestinationNormalized * dashspeed / speed;

			if (dashDestination != lastdashDestination)
			{
				//isdashing = false;
				// If destination changed
				NPC.TargetClosest(); // Pick the closest player target again

				if (Main.netMode != NetmodeID.Server)
				{
					NPC.position += NPC.netOffset;
					//Dust.QuickDustLine(NPC.Center + toDestinationNormalized * NPC.width, dashDestination, toDestination.Length() / 20f, Color.Blue);
					NPC.position -= NPC.netOffset;
				}
			}
			lastdashDestination = dashDestination;
	}
		private void LightningDropAttack(int amount, Player dropplayer)
        {
			var entitySource = NPC.GetSource_FromAI();

			if (Main.expertMode != true)
            {
				//set spawn positions
				Vector2 positionone = new Vector2(dropplayer.position.X - 400, dropplayer.position.Y - 200);
				Vector2 positiontwo = new Vector2(dropplayer.position.X - 200, dropplayer.position.Y - 200);
				Vector2 positionthree = new Vector2(dropplayer.position.X, dropplayer.position.Y - 200);
				Vector2 positionfour = new Vector2(dropplayer.position.X + 200, dropplayer.position.Y - 200);
				Vector2 positionfive = new Vector2(dropplayer.position.X + 400, dropplayer.position.Y - 200);

				//shooting
				Projectile.NewProjectile(entitySource, positionone, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positiontwo, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionthree, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionfour, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionfive, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
			}
            else
            {
				//set spawn positions
				Vector2 positionone = new Vector2(dropplayer.position.X - 200, dropplayer.position.Y - 200);
				Vector2 positiontwo = new Vector2(dropplayer.position.X - 100, dropplayer.position.Y - 200);
				Vector2 positionthree = new Vector2(dropplayer.position.X, dropplayer.position.Y - 200);
				Vector2 positionfour = new Vector2(dropplayer.position.X + 100, dropplayer.position.Y - 200);
				Vector2 positionfive = new Vector2(dropplayer.position.X + 200, dropplayer.position.Y - 200);

				//shooting
				Projectile.NewProjectile(entitySource, positionone, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positiontwo, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionthree, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionfour, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
				Projectile.NewProjectile(entitySource, positionfive, new Vector2(0, 10), ModContent.ProjectileType<UsurperLightningBall>(), NPC.damage * 2, 6);
			}
		}
		private void SpawnMinions()
		{
			if (SpawnedMinions)
			{
				// No point executing the code in this method again
				return;
			}

			SpawnedMinions = true;

			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				// Because we want to spawn minions, and minions are NPCs, we have to do this on the server (or singleplayer, "!= NetmodeID.MultiplayerClient" covers both)
				// This means we also have to sync it after we spawned and set up the minion
				return;
			}

			int count = MinionCount();

			for (int i = 0; i < count; i++)
			{
				var entitySource = NPC.GetSource_FromAI();
				int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<DesertTotem>(), NPC.whoAmI);
				NPC minionNPC = Main.npc[index];

				// Now that the minion is spawned, we need to prepare it with data that is necessary for it to work
				// This is not required usually if you simply spawn NPCs, but because the minion is tied to the body, we need to pass this information to it

				if (minionNPC.ModNPC is DesertTotem minion)
				{
					// This checks if our spawned NPC is indeed the minion, and casts it so we can access its variables
					minion.ParentIndex = NPC.whoAmI; // Let the minion know who the "parent" is
					minion.PositionIndex = i; // Give it the iteration index so each minion has a separate one, used for movement
				}

				// Finally, syncing, only sync on server and if the NPC actually exists (Main.maxNPCs is the index of a dummy NPC, there is no point syncing it)
				if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
				{
					NetMessage.SendData(MessageID.SyncNPC, number: index);
				}
			}
			SoundEngine.PlaySound(SoundID.Thunder, NPC.Center);
			for (int i = 0; i < 25; i++)
			{
				Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.25f, 0.25f);
				Dust d2 = Dust.NewDustPerfect(Main.LocalPlayer.Center, ModContent.DustType<Spark>(), speed2 * 5, Scale: 1f);
				d2.noGravity = true;

				Vector2 speed3 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
				Dust d3 = Dust.NewDustPerfect(Main.LocalPlayer.Center, ModContent.DustType<Spark>(), speed3 * 5, Scale: 1f);
				d3.noGravity = true;
			}
		}

	}
}
