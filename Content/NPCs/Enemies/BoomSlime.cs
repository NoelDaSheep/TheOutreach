using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
using Terraria.Audio;

namespace TheOutreach.Content.NPCs.Enemies
{
    class BoomSlime : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boom Slime");
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
			NPC.lifeMax = 70;
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				new FlavorTextBestiaryInfoElement("Slimes that have taken dynamite from mineshafts and mutated to function the same way.")
			});
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.Dynamite, 5, 1, 1));
			npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 2, 3));
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Cavern.Chance / 2;
		}
        public override void AI()
        {
			NPC.TargetClosest(true);
		}
        public override void OnKill()
        {
			int damage = 200;
			for (int i = 0; i < Main.maxPlayers; i++)
			{
				//thank you lawnmowerking for the base damage logic
				if (Main.player[i].active && Main.player[i].Distance(NPC.Center) <= 90)
				{
					int deathMessage = Main.rand.Next(5);
					switch (deathMessage)
					{
						case 0:
							Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " got 'sploded by a Boom Slime"), damage, 0);
							break;
						case 1:
							Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " had their face griefed"), damage, 0);
							break;
						case 2:
							Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " had their limbs scattered about"), damage, 0);
							break;
						case 3:
							Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " was violently removed from " + Main.worldName), damage, 0);
							break;
						case 4:
							Main.player[i].Hurt(PlayerDeathReason.ByCustomReason(Main.player[i].name + " was knocked out (But a days rest should fix them right up...)"), damage, 0);
							break;
					}
				}
			}
		}
        public override void HitEffect(int hitDirection, double damage)
        {
			if (Main.netMode == NetmodeID.Server)
			{
				return;
			}

			if (NPC.life <= 0)
            {
				SoundEngine.PlaySound(SoundID.Item14, NPC.position);
				for(int i = 0; i < 30; i++)
                {
					Dust smoke = Dust.NewDustDirect(NPC.position, 90, 90, DustID.Smoke, 0, -2.5f);
					smoke.noGravity = false;
					if(Main.rand.NextBool(3))
                    {
						Dust flames = Dust.NewDustDirect(NPC.position, 45, 45, DustID.Torch, 0, -3.5f);
						flames.noGravity = false;
					}
				}
			}
        }
	}
}
