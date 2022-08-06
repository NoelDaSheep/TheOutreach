using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Items.Accessories;
using Terraria.GameContent.ItemDropRules;
using TheOutreach.Content.Tiles.Furniture.Banners;

namespace TheOutreach.Content.NPCs.Enemies
{
    class CumSlime : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloud Slime");
			Main.npcFrameCount[NPC.type] = 1;

			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.Slimed,
					BuffID.Poisoned,
					BuffID.Venom,
					BuffID.Ichor,
					BuffID.BetsysCurse
				}
			});
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 22;
			NPC.aiStyle = 1;
			NPC.damage = 20;
			NPC.defense = 5;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(silver: 10);
			NPC.knockBackResist = 0.75f;
			NPC.lavaImmune = true;
			//Banner = NPC.type;
			//BannerItem = ModContent.ItemType<LithiumAutomatonBanner>();
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Sky,

				new FlavorTextBestiaryInfoElement("The tastiest of all the slimes. It is currently unknown who it comes from.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			//currently no drops
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Sky.Chance;
		}
        public override void AI()
        {
			NPC.TargetClosest(true);
		}
	}
}
