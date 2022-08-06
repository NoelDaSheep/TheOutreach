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
using TheOutreach.Common.Systems;
using TheOutreach.Content.Items.Materials;
using System;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using ReLogic.Content;

namespace TheOutreach.Content.NPCs.TownNPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Forager : ModNPC
	{
		Player player;	

		public override void SetStaticDefaults() 
		{
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[Type] = 23; // The amount of frames the NPC has

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

			// Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
			// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
			NPC.Happiness
				.SetBiomeAffection<JungleBiome>(AffectionLevel.Love) 
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)

				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Truffle, AffectionLevel.Like)
				.SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Dislike)
				.SetNPCAffection(ModContent.NPCType<Pharoh>(), AffectionLevel.Hate)
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

			AnimationType = NPCID.Nurse;
		}
        public override void AI()
        {
            if(NPCdowned.ForagerHasMoved == false)
            {
				NPCdowned.ForagerHasMoved = true;
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("The greatest Forager to ever live."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
			});
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];



				if (Main.LocalPlayer.HasItem(ItemID.Wood) && Main.LocalPlayer.HasItem(ItemID.BorealWood) && Main.LocalPlayer.HasItem(ItemID.RichMahogany) && Main.LocalPlayer.HasItem(ItemID.PalmWood))
				{
					if (WorldGen.crimson == true)
					{
						if (Main.LocalPlayer.HasItem(ItemID.Shadewood))
						{
							return true;
						}
					}
					else
					{
						if (Main.LocalPlayer.HasItem(ItemID.Ebonwood))
						{
							return true;
						}
					}
				}
				if (NPCdowned.ForagerHasMoved == true)
				{
					return true;
				}
			}
			return false;
		}
        public override List<string> SetNPCNameList()
        {
			return new List<string>() 
			{
				"Peach", //maro
				"Daisy", //wigi
				"Tiphia",
				"Mirabelle",
				"Fuchsia",
				"Leilani",
				"Matsutake", //haha mushroom funi
				"Sakura",
				"Kendra",
				"Azalea",
				"Camellia",
				"Forsythia",
				"Marigold",
				"Primrose", //not from the hunger games you fucking cretins 
				"Katniss", //also not from the hunger games you fucking cretins 
				"Petunia"
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

			int merchantIndexMechanic = NPC.FindFirstNPC(124);
			int merchantIndexNurse = NPC.FindFirstNPC(18);
			int merchantIndexGuide = NPC.FindFirstNPC(22);
			int merchantIndexDryad = NPC.FindFirstNPC(20);

			List<string> PossibleDialogs = new List<string>();
			if(Main.dayTime && !Main.eclipse)
            {
				PossibleDialogs.Add("You ever tried daybloom?");
				PossibleDialogs.Add("The world has so much plant life!");
				PossibleDialogs.Add("Some say there are trees bigger than mountains!");
				PossibleDialogs.Add("I like to wander around and collect plants and fungi.");
			}
			if(!Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon && !Main.bloodMoon)
            {
				PossibleDialogs.Add("I think I ate the wrong mushroom...");
				PossibleDialogs.Add("Some say mushrooms grow more during full moons.");
				PossibleDialogs.Add("My mother once told about a rare occurance know as the mushmoon, that only happens once every century, before I went to bed..");
				PossibleDialogs.Add("The world probably has a hundred times more species of mushrooms than ever discovered!");
			}
            if (player.HasItem(ItemID.Wood) || player.HasItem(ItemID.BorealWood) || player.HasItem(ItemID.Ebonwood) || player.HasItem(ItemID.Shadewood) || player.HasItem(ItemID.RichMahogany) || player.HasItem(ItemID.PalmWood) || player.HasItem(ItemID.Pearlwood))
            {
				PossibleDialogs.Add("If you bring me different kinds of wood I might sell you new things!");
			}
			if (Main.IsItAHappyWindyDay)
            {
				PossibleDialogs.Add("Today the spores will spread!");
				PossibleDialogs.Add("Days like these make EVERYONE happy!");

			}
			if (NPC.homeless)
            {
				PossibleDialogs.Add("Just because Im a forager doesnt mean I dont want a house.");
				PossibleDialogs.Add("I need a house to put my mushrooms.");
            }
			if (merchantIndexDryad != -1)
			{
				NPC leafgirl = Main.npc[merchantIndexDryad];
				PossibleDialogs.Add(leafgirl.GivenName + " sure knows a lot about plants too!");
			}
            if (Main.bloodMoon)
            {
				if (merchantIndexGuide != -1)
                {
					NPC hellboi = Main.npc[merchantIndexGuide];
					PossibleDialogs.Add(hellboi + "is SO ANNOYING!");
				}
				PossibleDialogs.Add("You want this 'safe' mushroom?");
				PossibleDialogs.Add("I hope you 'dont' get hurt");
				PossibleDialogs.Add("Why are you not keeping the zombies away from my mushrooms!");
				PossibleDialogs.Add("Even the zombies like my shrooms! Come on! TAKE ONE!");
			
				if(merchantIndexMechanic != -1 && merchantIndexNurse != -1)
                {
					NPC wireperson = Main.npc[merchantIndexMechanic];
					NPC armsdealeruwu = Main.npc[merchantIndexNurse];
					PossibleDialogs.Add("Why cant " + wireperson + " and " + armsdealeruwu + " just SHUT UP!");
				}

			}
			if (player.ZoneDesert || player.ZoneUndergroundDesert)
            {
				PossibleDialogs.Add("Everything is so, dead.");
				PossibleDialogs.Add("Not even mushrooms will grow here!");
				PossibleDialogs.Add("Day ???: still no plants.");
				PossibleDialogs.Add("Im pretty sure the cacti are not even useful for anything.");
				PossibleDialogs.Add("I would rather be ANYWHERE but here right now");
			}
			if (player.ZoneJungle)
            {
				PossibleDialogs.Add("The jungle has so many plants! Its unbelievable!");
				PossibleDialogs.Add("This place reminds me of a movie I watched about a rock fighting dead people.");
				PossibleDialogs.Add("I heard you can find a rare flower here that enhances magic.");
				PossibleDialogs.Add("Even the plants here are scary! I saw one with a mouth!");
				PossibleDialogs.Add("Ive heard of jungle spores, but Ive never heard of jungle mushshooms.");

				if (NPC.GivenName == "Tiphia")
                {
					PossibleDialogs.Add("I think Im named after something that lives in the giant hives here.");

				}
			}
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

			shop.item[nextSlot].SetDefaults(ItemID.Acorn);
			nextSlot++;

			if (Main.dayTime)
            {
				shop.item[nextSlot].SetDefaults(ItemID.Mushroom);
				nextSlot++;
			}
            else if (!Main.dayTime && !Main.bloodMoon)
            {
				shop.item[nextSlot].SetDefaults(ItemID.GlowingMushroom);
				nextSlot++;
			}
			else if (!Main.dayTime && Main.bloodMoon)
			{
                if (WorldGen.crimson)
                {
					shop.item[nextSlot].SetDefaults(ItemID.ViciousMushroom);
					nextSlot++;
				}
                else
                {
					shop.item[nextSlot].SetDefaults(ItemID.VileMushroom);
					nextSlot++;
				}
			}
            if (player.HasItem(ItemID.Wood))
            {
				shop.item[nextSlot].SetDefaults(ItemID.Wood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Apple);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Apricot);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Grapefruit);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Lemon);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Peach);
				nextSlot++;
			}
			if (player.HasItem(ItemID.BorealWood))
			{
				shop.item[nextSlot].SetDefaults(ItemID.BorealWood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Cherry);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Plum);
				nextSlot++;
			}
			if (player.HasItem(ItemID.Ebonwood))
			{
				shop.item[nextSlot].SetDefaults(ItemID.Ebonwood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BlackCurrant);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Elderberry);
				nextSlot++;
			}
            if (player.HasItem(ItemID.Shadewood))
            {
				shop.item[nextSlot].SetDefaults(ItemID.Shadewood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BloodOrange);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Rambutan);
				nextSlot++;
			}
			if (player.HasItem(ItemID.RichMahogany))
			{
				shop.item[nextSlot].SetDefaults(ItemID.RichMahogany);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Mango);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Pineapple);
				nextSlot++;
			}
			if (player.HasItem(ItemID.PalmWood))
			{
				shop.item[nextSlot].SetDefaults(ItemID.PalmWood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Banana);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Coconut);
				nextSlot++;
			}
			if (player.HasItem(ItemID.Pearlwood))
			{
				shop.item[nextSlot].SetDefaults(ItemID.Pearlwood);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Dragonfruit);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Starfruit);
				nextSlot++;
			}
			int DyeTraderIndex = NPC.FindFirstNPC(207);
			if (DyeTraderIndex != -1)
			{
				if (Main.dayTime && !Main.eclipse)
				{
					shop.item[nextSlot].SetDefaults(ItemID.YellowMarigold);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.SkyBlueFlower);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.BlueBerries);
					nextSlot++;
				}
				if (Main.moonPhase == 0 && !Main.dayTime)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GreenMushroom);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TealMushroom);
					nextSlot++;
				}
				if (Main.moonPhase == 4 && !Main.dayTime)
                {
					shop.item[nextSlot].SetDefaults(ItemID.OrangeBloodroot);
					nextSlot++;
				}
				if (Main.moonPhase == 4 && Main.dayTime)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PinkPricklyPear);
					nextSlot++;
				}
			}
			
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 15;
			knockback = 4f;
		}

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
			projType = ModContent.ProjectileType<Content.Projectiles.Ranged.CherryBombProjectile>();
			attackDelay = 1;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 20;
			randExtraCooldown = 20;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
