using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;
using TheOutreach.Common.ItemDropRules.Conditions;

namespace TheOutreach.Common.GlobalNPCs
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class ExampleNPCLoot : GlobalNPC
	{
		// ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
		// Here we go through all of them, and how they can be used.
		// There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.EaterofSouls) 
			{
				// Here we make use of our own special rule we created: drop during daytime
				ExampleDropConditionEoW exampleDropCondition = new ExampleDropConditionEoW();
				ExampleDropConditionEoW exampleDropCondition2 = new ExampleDropConditionEoW();
				IItemDropRule conditionalRule = new LeadingConditionRule(exampleDropCondition);
				IItemDropRule conditionalRule2 = new LeadingConditionRule(exampleDropCondition2);

				int itemType = ItemID.ShadowScale;
				int itemType2 = ItemID.DemoniteOre;
				
				// 33% chance to drop other corresponding item in addition
				IItemDropRule rule = ItemDropRule.Common(itemType, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 2);
				IItemDropRule rule2 = ItemDropRule.Common(itemType2, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 4);

				// Apply our item drop rule to the conditional rule
				conditionalRule.OnSuccess(rule);
				conditionalRule2.OnSuccess(rule2);
				// Add the rule
				npcLoot.Add(conditionalRule);
				npcLoot.Add(conditionalRule2);
				// It will result in the drop being shown in the bestiary, but only drop if the condition is true.
			}

			if (npc.type == NPCID.Crimera)
			{
				// Here we make use of our own special rule we created: drop during daytime
				ExampleDropConditionBoC exampleDropCondition = new ExampleDropConditionBoC();
				ExampleDropConditionBoC exampleDropCondition2 = new ExampleDropConditionBoC();
				IItemDropRule conditionalRule = new LeadingConditionRule(exampleDropCondition);
				IItemDropRule conditionalRule2 = new LeadingConditionRule(exampleDropCondition2);

				int itemType = ItemID.TissueSample;
				int itemType2 = ItemID.CrimtaneOre;

				// 33% chance to drop other corresponding item in addition
				IItemDropRule rule = ItemDropRule.Common(itemType, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 2);
				IItemDropRule rule2 = ItemDropRule.Common(itemType2, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 4);

				// Apply our item drop rule to the conditional rule
				conditionalRule.OnSuccess(rule);
				conditionalRule2.OnSuccess(rule2);
				// Add the rule
				npcLoot.Add(conditionalRule);
				npcLoot.Add(conditionalRule2);
				// It will result in the drop being shown in the bestiary, but only drop if the condition is true.
			}

			if (npc.type == NPCID.BloodCrawler)
			{
				// Here we make use of our own special rule we created: drop during daytime
				ExampleDropConditionBoC exampleDropCondition = new ExampleDropConditionBoC();
				ExampleDropConditionBoC exampleDropCondition2 = new ExampleDropConditionBoC();
				IItemDropRule conditionalRule = new LeadingConditionRule(exampleDropCondition);
				IItemDropRule conditionalRule2 = new LeadingConditionRule(exampleDropCondition2);

				int itemType = ItemID.TissueSample;
				int itemType2 = ItemID.CrimtaneOre;

				// 33% chance to drop other corresponding item in addition
				IItemDropRule rule = ItemDropRule.Common(itemType, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 2);
				IItemDropRule rule2 = ItemDropRule.Common(itemType2, chanceDenominator: 3, minimumDropped: 1, maximumDropped: 4);

				// Apply our item drop rule to the conditional rule
				conditionalRule.OnSuccess(rule);
				conditionalRule2.OnSuccess(rule2);
				// Add the rule
				npcLoot.Add(conditionalRule);
				npcLoot.Add(conditionalRule2);
				// It will result in the drop being shown in the bestiary, but only drop if the condition is true.
			}

			//TODO: Add the rest of the vanilla drop rules!!
		}

		// ModifyGlobalLoot allows you to modify loot that every NPC should be able to drop, preferably with a condition.
		// Vanilla uses this for the biome keys, souls of night/light, as well as the holiday drops.
		// Any drop rules in ModifyGlobalLoot should only run once. Everything else should go in ModifyNPCLoot.
		public override void ModifyGlobalLoot(GlobalLoot globalLoot) {
			//TODO: Make it so it only drops from enemies in ExampleBiome when that gets made.
		}
	}
}
