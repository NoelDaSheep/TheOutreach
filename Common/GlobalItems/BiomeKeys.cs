using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;
using TheOutreach.Common.ItemDropRules.Conditions;

namespace TheOutreach.Common.GlobalItems
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class BiomeKeys : GlobalItem
	{
        public override void SetDefaults(Item item)
        {
            if(item.type == ItemID.DungeonDesertKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }

            if (item.type == ItemID.CorruptionKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }

            if (item.type == ItemID.CrimsonKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }

            if (item.type == ItemID.HallowedKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }

            if (item.type == ItemID.FrozenKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }

            if (item.type == ItemID.JungleKey)
            {
                item.value = Item.buyPrice(gold: 30);
            }
        }
    }
}