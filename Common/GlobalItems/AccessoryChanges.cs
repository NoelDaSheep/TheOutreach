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
	public class AccessoryChanges : GlobalItem
	{
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(item.type == ItemID.RoyalGel)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "+10% Jump Speed");
                tooltips.Add(tooltipLine);
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if(item.type == ItemID.RoyalGel)
            {
                player.jumpSpeedBoost += 1;
            }

            if (item.type == ItemID.AnkhCharm)
            {
                player.buffImmune[BuffID.Stoned] = true;
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
            }

            if (item.type == ItemID.AnkhShield)
            {
                player.buffImmune[BuffID.Stoned] = true;
                player.buffImmune[BuffID.Chilled] = true;
                player.buffImmune[BuffID.Frozen] = true;
            }
        }
    }
}