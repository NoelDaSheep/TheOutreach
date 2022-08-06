using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;
using TheOutreach.Common.ItemDropRules.Conditions;
using System.Collections.Generic;

namespace TheOutreach.Common.GlobalItems
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class ArmorChanges : GlobalItem
	{
        public override void UpdateEquip(Item item, Player player)
        {
            if(item.type == ItemID.CopperGreaves)
            {
                player.moveSpeed += 0.04f;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.CopperGreaves)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "+4% Movement Speed");
                tooltips.Add(tooltipLine);
            }
        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if(head.type == ItemID.CopperHelmet && body.type == ItemID.CopperChainmail && legs.type == ItemID.CopperGreaves)
            {
                return "copperArmor";
            }
            return "";
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if(set == "copperArmor")
            {
                set = set + "\n+5% Mining Speed";
                player.pickSpeed += 0.05f;
            }
        }
    }
}