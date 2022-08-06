using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Common.GlobalNPCs
{
	public class DyeTraderGlobalNPC : GlobalNPC
	{
		NPC npcagain;
		public override bool InstancePerEntity => true;
		public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
		{
			if (npc.type == NPCID.DyeTrader)
			{
				npcagain = npc;
            }
			return npc.type == NPCID.DyeTrader;
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			//int moonphase = Terraria.Enums.MoonPhase.ThreeQuartersAtLeft();
			if(type == NPCID.DyeTrader)
            {
				Player player = Main.LocalPlayer;
				shop.item[nextSlot].SetDefaults(ItemID.AcidDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BlueAcidDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.RedAcidDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.MushroomDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.MirageDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.NegativeDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.PurpleOozeDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveCopperDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveGoldDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveObsidianDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveMetalDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ReflectiveSilverDye);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ShadowDye);
				nextSlot++;
				if (Main.hardMode)
				{
					shop.item[nextSlot].SetDefaults(ItemID.GelDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.GrimDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.HadesDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.BurningHadesDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.ShadowflameHadesDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.PhaseDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.ShiftingSandsDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.TwilightDye);
					nextSlot++;
				}
				if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				{
					shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.LivingOceanDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.LivingFlameDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.LivingRainbowDye);
					nextSlot++;
				}
				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults(ItemID.PixieDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.WispDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.InfernalWispDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.UnicornWispDye);
					nextSlot++;
				}
				if (NPC.downedEmpressOfLight)
				{
					shop.item[nextSlot].SetDefaults(ItemID.HallowBossDye);
					nextSlot++;
				}
				if (NPC.downedMartians)
				{
					shop.item[nextSlot].SetDefaults(ItemID.MartianArmorDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.MidnightRainbowDye);
					nextSlot++;
				}
				if (NPC.downedMoonlord)
				{
					shop.item[nextSlot].SetDefaults(ItemID.DevDye);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(ItemID.LokisDye);
					nextSlot++;
				}
			}
			
		}
	}
}
