using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Common.GlobalNPCs
{
	public class WitchDoctorGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.WitchDoctor;
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			player = Main.LocalPlayer;

			if (type == NPCID.WitchDoctor)
			{
				if (Main.hardMode == true && NPC.downedPlantBoss && Main.moonPhase == 0 && player.ZoneJungle && !Main.dayTime)
				{
				shop.item[nextSlot].SetDefaults(ItemID.JungleKey);
				nextSlot++;
				}
			}
			
		}
	}
}
