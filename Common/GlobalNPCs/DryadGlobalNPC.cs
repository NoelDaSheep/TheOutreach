using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Common.GlobalNPCs
{
	public class DryadGlobalNPC : GlobalNPC
	{
		Player player;

		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.Dryad;
		}

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
			player = Main.LocalPlayer;

			if(NPC.downedBoss2 && Main.expertMode && !WorldGen.crimson)
            {
				shop.item[nextSlot].SetDefaults(ItemID.BrainOfConfusion);
				nextSlot++;
            }
			else if (NPC.downedBoss2 && Main.expertMode && WorldGen.crimson)
            {
				shop.item[nextSlot].SetDefaults(ItemID.WormScarf);
				nextSlot++;
            }
            if (player.ZoneBeach)
            {
				shop.item[nextSlot].SetDefaults(ItemID.Coral);
				nextSlot++;
            }
			if (type == NPCID.Dryad)
			{
				if (Main.hardMode == true && NPC.downedPlantBoss && Main.bloodMoon == true && !Main.dayTime)
				{
					if (WorldGen.drunkWorldGen == true)
					{
						shop.item[nextSlot].SetDefaults(ItemID.CorruptionKey);
						nextSlot++;
						shop.item[nextSlot].SetDefaults(ItemID.CrimsonKey);
						nextSlot++;
					}
					else
					{
						if (WorldGen.crimson == true)
						{
							shop.item[nextSlot].SetDefaults(ItemID.CrimsonKey);
							nextSlot++;
						}
						else
						{
							shop.item[nextSlot].SetDefaults(ItemID.CorruptionKey);
							nextSlot++;
						}
					}
				}
			}
		}
	}
}
