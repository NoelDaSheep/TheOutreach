using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheOutreach.Content.Items.Armor;

namespace TheOutreach.Common.GlobalNPCs
{
	public class SkeletonMerchantGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.SkeletonMerchant;
		}
		public override void ModifyNPCNameList(NPC npc, List<string> nameList)
		{
			if(npc.type == NPCID.SkeletonMerchant)
            {
				nameList.Add("Snes");
				nameList.Add("Pepeayrus");
				nameList.Add("Skeletor");
				nameList.Add("Acererak");
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			player = Main.LocalPlayer;
			if (type == NPCID.SkeletonMerchant)
			{
				if (Main.hardMode == true && NPC.downedPlantBoss && Main.moonPhase == 1 && player.ZoneHallow && !Main.dayTime)
				{
					shop.item[nextSlot].SetDefaults(ItemID.HallowedKey);
					nextSlot++;
				}
				if (Main.moonPhase != 1)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<SentientHat>());
					nextSlot++;
				}
			}

		}
	}
}
