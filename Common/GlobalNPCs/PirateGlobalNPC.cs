using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;

namespace TheOutreach.Common.GlobalNPCs
{
	public class PirateGlobalNPC : GlobalNPC
	{
		Player player;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.Pirate;
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			player = Main.LocalPlayer;
			if (type == NPCID.Pirate)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<FakeMap>());
				nextSlot++;
			}

		}
	}
}
