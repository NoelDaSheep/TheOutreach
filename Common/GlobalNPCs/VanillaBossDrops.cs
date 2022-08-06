using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Armor;
using TheOutreach.Content.Items.Accessories;
using TheOutreach.Common.ItemDropRules.Conditions;

namespace TheOutreach.Common.GlobalNPCs
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class VanillaBossDrops : GlobalNPC
	{
		// ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
		// Here we go through all of them, and how they can be used.
		// There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if(npc.type == NPCID.SpikedIceSlime)
            {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenClump>(), 50, 1, 1));
            }
			if (npc.type == NPCID.KingSlime) 
			{
				int itemType = ItemID.MusicBoxBoss1;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimeKingsSlides>(), chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));
			}

			if (npc.type == NPCID.EyeofCthulhu)
			{
				int itemType = ItemID.MusicBoxBoss1;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.EaterofWorldsHead && !NPC.AnyNPCs(NPCID.EaterofWorldsBody) && !NPC.AnyNPCs(NPCID.EaterofWorldsTail))
			{
				int itemType = ItemID.MusicBoxBoss1;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));
			}

			if (npc.type == NPCID.BrainofCthulhu)
			{
				int itemType = ItemID.MusicBoxBoss3;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.QueenBee)
			{
				int itemType = ItemID.MusicBoxBoss5;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.SkeletronHead)
			{
				int itemType = ItemID.MusicBoxBoss1;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SkeletronsJaw>(), chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.Deerclops)
			{
				int itemType = ItemID.MusicBoxDeerclops;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.WallofFlesh)
			{
				int itemType = ItemID.MusicBoxBoss2;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.QueenSlimeBoss)
			{
				int itemType = ItemID.MusicBoxQueenSlime;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism) || npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer))
			{
				int itemType = ItemID.MusicBoxBoss2;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.TheDestroyer)
			{
				int itemType = ItemID.MusicBoxBoss3;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.SkeletronPrime)
			{
				int itemType = ItemID.MusicBoxBoss1;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.Plantera)
			{
				int itemType = ItemID.MusicBoxPlantera;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.Golem)
			{
				int itemType = ItemID.MusicBoxBoss4;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.DukeFishron)
			{
				int itemType = ItemID.MusicBoxDukeFishron;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.HallowBoss)
			{
				int itemType = ItemID.MusicBoxEmpressOfLight;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.CultistBoss)
			{
				int itemType = ItemID.MusicBoxBoss4;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}

			if (npc.type == NPCID.MoonLordCore)
			{
				int itemType = ItemID.MusicBoxLunarBoss;

				npcLoot.Add(ItemDropRule.Common(itemType, chanceDenominator: 10, minimumDropped: 1, maximumDropped: 1));

			}
		}

		// ModifyGlobalLoot allows you to modify loot that every NPC should be able to drop, preferably with a condition.
		// Vanilla uses this for the biome keys, souls of night/light, as well as the holiday drops.
		// Any drop rules in ModifyGlobalLoot should only run once. Everything else should go in ModifyNPCLoot.
		public override void ModifyGlobalLoot(GlobalLoot globalLoot) {
			//TODO: Make it so it only drops from enemies in ExampleBiome when that gets made.
		}
	}
}
