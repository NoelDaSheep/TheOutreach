using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheOutreach.Content.Items;

namespace TheOutreach.Common.GlobalNPCs
{
	public class GoblinTinkererGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.GoblinTinkerer;
		}
		public override void ModifyNPCNameList(NPC npc, List<string> nameList)
		{
			if (npc.type == NPCID.GoblinTinkerer)
			{
				//nameList.Add("Skynet");
			}
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{

			player = Main.LocalPlayer;

			if (type == NPCID.GoblinTinkerer)
            {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<PeaceTreaty>());
				nextSlot++;
            }

				
		}
	}
}
