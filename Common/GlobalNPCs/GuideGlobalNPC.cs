using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheOutreach.Content.NPCs.TownNPCs;
using TheOutreach.Common.Systems;

namespace TheOutreach.Common.GlobalNPCs
{
	public class GuideGlobalNPC : GlobalNPC
	{
        public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			return npc.type == NPCID.Guide;
		}
		public override void ModifyNPCNameList(NPC npc, List<string> nameList)
		{
			if (npc.type == NPCID.Guide)
			{
				nameList.Add("Rhoam");
				nameList.Add("Michael");
				nameList.Add("Dwight");
				nameList.Add("Cave");
			}
		}

		public override void GetChat(NPC npc, ref string chat)
		{
			int mushroom = (ModContent.NPCType<Forager>());
			int type = npc.type;
			int merchantIndexForager = NPC.FindFirstNPC(mushroom);
			if (type == NPCID.Guide)
            {
				if (merchantIndexForager == -1 && NPCdowned.ForagerHasMoved == false)
				{
					if (Utils.NextBool(Main.rand, 5))
					{
						chat = "If you can collect all the different woods in " + Main.worldName + " a person who enjoys similar activities may arrive";

					}
				}
            }
		}
	}
}
