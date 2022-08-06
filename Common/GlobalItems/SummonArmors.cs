using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;
using TheOutreach.Common.ItemDropRules.Conditions;
using System.Collections.Generic;
using Terraria.Localization;

namespace TheOutreach.Common.GlobalItems
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class SummonArmors : GlobalItem
	{
		public override bool InstancePerEntity => true;

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
			Player player = Main.LocalPlayer;

			if (item.type == ItemID.ObsidianHelm)
            {
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.FlinxFurCoat)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.SpiderMask)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.AncientBattleArmorHat)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.HallowedHood)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.AncientHallowedHood)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.TikiMask)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.SpookyHelmet)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
			if (item.type == ItemID.StardustHelmet)
			{
				TooltipLine tooltipLine = new TooltipLine(Mod, "TO", "You have " + player.slotsMinions + " out of " + player.maxMinions + " minions summoned");
				tooltips.Add(tooltipLine);
			}
		}
        
	}
}