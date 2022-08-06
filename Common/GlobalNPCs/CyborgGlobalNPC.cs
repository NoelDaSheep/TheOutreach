using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace TheOutreach.Common.GlobalNPCs
{
	public class CyborgGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.Cyborg;
		}
		public override void ModifyNPCNameList(NPC npc, List<string> nameList)
		{
			if (npc.type == NPCID.Cyborg)
			{
				nameList.Add("Skynet");
			}
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{

			player = Main.LocalPlayer;

			if (type == NPCID.Cyborg)
            {
				if (Main.hardMode == true && NPC.downedPlantBoss && Main.moonPhase == 6 && player.ZoneSnow && !Main.dayTime)
				{
				shop.item[nextSlot].SetDefaults(ItemID.FrozenKey);
				nextSlot++;
				}	
            }

				
		}
	}
}
