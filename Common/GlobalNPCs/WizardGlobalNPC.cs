using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Common.GlobalNPCs
{
	public class WizardGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.Wizard;
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			player = Main.LocalPlayer;
			if (type == NPCID.Wizard)
			{
				if (Main.hardMode == true && NPC.downedPlantBoss && Main.moonPhase == 1 && player.ZoneHallow && !Main.dayTime)
				{
					shop.item[nextSlot].SetDefaults(ItemID.HallowedKey);
					nextSlot++;
				}
			}

		}
	}
}
