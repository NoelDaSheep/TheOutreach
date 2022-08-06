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
using TheOutreach.Common.Systems;
using TheOutreach.Content.Items.Materials;
using System;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using ReLogic.Content;
using TheOutreach.Common.Systems;

using TheOutreach.Content.Items.Materials;

namespace TheOutreach.Content.NPCs.TownNPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Pharoh : ModNPC
	{
		Player player;
		//Names
		private string npcName;

		public static List<string> PossibleNames = new List<string>
		{
			"Ramses II",
			"Tut",
			"Narmer",
			"Pepi II",
			"Sensuret",
			"Amenhotep",
			"Neferefre",
			
		};

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[Type] = 25; // The amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = -1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = -1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			NPC.Happiness
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Love)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Like)
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)

				.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Angler, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Dislike)
				.SetNPCAffection(ModContent.NPCType<Forager>(), AffectionLevel.Hate)
			; // < Mind the semicolon!
		}

		public override void SetDefaults() {
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}
		public override void AI()
		{
			if (NPCdowned.PharaohHasMoved == false)
			{
				NPCdowned.PharaohHasMoved = true;
			}
		}
		public override bool CanChat()
		{
			return true;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("The Ruler of a ruined civilization, doesn’t care for peasants."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
			});
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];

				//bool rich = money >= 50;


				if (!player.active) {
					continue;
				}
				if (player.active)
				{
					return true;
				}
				if(NPCdowned.PharaohHasMoved == true)
                {
					return true;
                }
			}
			return false;
		}

		public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left + 5; x <= right + 5; x++) {
				for (int y = top + 5; y <= bottom + 5; y++) {
					int type = Main.tile[x, y].TileType;
					if (type == (TileID.Sand) || type == (TileID.HardenedSand))
                    {
						++score;
					}
				}
			}
			if (score >= 25)
            {
				return true;
            }
            else
            {
				return false;
            }
		}
        public override List<string> SetNPCNameList()
        {
			return new List<string>
			{
				"Ramses II",
				"Tut",
				"Narmer",
				"Pepi II",
				"Sensuret",
				"Amenhotep",
				"Neferefre"
			};
		}
		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() 
		{
			Player player = Main.LocalPlayer;

			List<string> PossibleDialogs = new List<string>();
            if (NPC.homeless)
            {
				PossibleDialogs.Add("To think I used to sit at a throne just to be thrown for the antlions");
			}
			PossibleDialogs.Add("There are many people with troubles around this world, perhaps if you help them they may return the favor.");
			PossibleDialogs.Add("My family had a cat until my father died, haven’t seen it since.");
			PossibleDialogs.Add("What has four legs, then 3, then zero? An antlion after I'm done with it.");
			PossibleDialogs.Add("I always liked putting snakes in my temples as traps. No one likes snakes.");
			PossibleDialogs.Add("The desert is a place of infinite possibilities. And sand. LOTS of sand.");
			int merchantIndexMainOne = NPC.FindFirstNPC(588);
			if (merchantIndexMainOne != -1)
			{
				NPC gopher = Main.npc[merchantIndexMainOne];
				PossibleDialogs.Add("Hey, has " + gopher.GivenName + " been talking about me? Why? Oh, no reason I just wanted to know.");
			}
			int merchantIndexMainTwo = NPC.FindFirstNPC(107);
			if (merchantIndexMainTwo != -1)
			{
				NPC goblindeeznuts = Main.npc[merchantIndexMainTwo];
				PossibleDialogs.Add("Once " + goblindeeznuts.GivenName + " told me the desert was once a great ocean, after which I said, and goblins were once geniuses. Him and I are no longer on good terms.");
			}
			PossibleDialogs.Add("Why are there cactus toilets? Why not!");
			PossibleDialogs.Add("");

			if (player.head == 61 && player.body == 42)
            {
				PossibleDialogs.Add("Father?");
			}
			if (NPC.GivenName == "Pepi II")
			{
				PossibleDialogs.Add("You have NO idea how long I have been ruling.");
			}
			if (!Main.dayTime && Main.bloodMoon)
			{
				PossibleDialogs.Add("The Red Moon has given many people powers some consider, unnatural.");
				PossibleDialogs.Add("Hey is that my cat?");
				PossibleDialogs.Add("Where are all the mummies?");
				int merchantIndex = NPC.FindFirstNPC(20);
				if (merchantIndex != -1)
				{
					NPC leafgirl = Main.npc[merchantIndex];
					PossibleDialogs.Add("I don’t like " + leafgirl.GivenName + "'s attitude.");
				}
				int merchantIndexTwo = NPC.FindFirstNPC(633);
				if (merchantIndexTwo != -1)
				{
					NPC furry = Main.npc[merchantIndexTwo];
					PossibleDialogs.Add(furry.GivenName + " looks a bit different tonight.");
				}
				int merchantIndexThree = NPC.FindFirstNPC(369);
				if (merchantIndexThree != -1)
				{
					NPC sonofa = Main.npc[merchantIndexThree];
					PossibleDialogs.Add("I hope the blood eels get to " + sonofa.GivenName);
				}
			}
			else if (!Main.dayTime && !Main.bloodMoon && !Main.pumpkinMoon && !Main.snowMoon)
			{
				PossibleDialogs.Add("When I was a child my mother would bring me to the market at night, but now it is nothing but ruin...");
				int merchantIndex = NPC.FindFirstNPC(19);
				if (merchantIndex != -1)
				{
					NPC drugdealer = Main.npc[merchantIndex];
					PossibleDialogs.Add("People like " + drugdealer.GivenName + " are the reason the desert gets a bad rap.");
				}
				PossibleDialogs.Add("Ive always enjoyed looking at the moon. It is much better than staring at the sun.");
				//PossibleDialogs.Add("");
			}
			if (Main.dayTime && !Main.eclipse)
			{
				PossibleDialogs.Add("I once had a grand temple, but it has been brought to ruin by the (Cult Name).");
				PossibleDialogs.Add("Don't ask me how I'm wearing this much gold. It's hotter than you could ever imagine.");
				//PossibleDialogs.Add("");
			}
			if(player.ZoneUndergroundDesert && Main.dayTime)
            {
				PossibleDialogs.Add("Be careful to not attract the worms");
				PossibleDialogs.Add("You ever just want to blow up all the antlion nests?");
				PossibleDialogs.Add("Sometimes I look around and think, 'Why are there so many damn antlions'.");

			}
			if (!Main.hardMode)
			{
				PossibleDialogs.Add("The desert is weakened by unnatural forces. Perhaps there is a way to release that energy and return it to its former glory.");
				int merchantIndex = NPC.FindFirstNPC(22);
				if (merchantIndex != -1)
				{
					NPC hellboi = Main.npc[merchantIndex];
					PossibleDialogs.Add("I don’t like the way " + hellboi.GivenName + " has been acting.");
				}
			}
			if (Main.hardMode)
            {
				PossibleDialogs.Add("I sense great evils have awoken, you should be wary where you walk.");
				PossibleDialogs.Add("The desert has grown greatly in it's power, don't underestimate it's wrath.");
			}
			//make him say Dad? if player wearing pharaoh set
			return PossibleDialogs[Main.rand.Next(PossibleDialogs.Count)];
		}

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			shop = true;
		}

		public override void SetupShop(Chest shop, ref int nextSlot) 
		{
			player = Main.LocalPlayer;

			shop.item[nextSlot].SetDefaults(ModContent.ItemType<EmptyAmulet>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<EmptyRing>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<EmptyCirclet>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<EmptyBand>());
			nextSlot++;
			if (Main.hardMode == true && NPC.downedPlantBoss && Main.moonPhase == 4 && player.ZoneDesert && !Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.DungeonDesertKey);
				nextSlot++;
			}
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
