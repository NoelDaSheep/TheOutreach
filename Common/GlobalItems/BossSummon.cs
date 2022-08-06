using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items;
using TheOutreach.Common.ItemDropRules.Conditions;

namespace TheOutreach.Common.GlobalItems
{
	public class BossSummon : GlobalItem
	{
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.SlimeCrown)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.SuspiciousLookingEye)
            {
                item.maxStack = 1;
                item.consumable = false;
            }
            
            if(item.type == ItemID.WormFood)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.BloodySpine)
            {
                item.maxStack = 1;
                item.consumable = false;
            }
            
            if(item.type == ItemID.Abeemination)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.DeerThing)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.QueenSlimeCrystal)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.MechanicalEye)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.MechanicalWorm)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.MechanicalSkull)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if (item.type == ItemID.EmpressButterfly)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if (item.type == ItemID.CelestialSigil)
            {
                item.maxStack = 1;
                item.consumable = false;
            }
            //events
            if(item.type == ItemID.GoblinBattleStandard)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.PumpkinMoonMedallion)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if(item.type == ItemID.NaughtyPresent)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if (item.type == ItemID.BloodMoonStarter)
            {
                item.maxStack = 1;
                item.consumable = false;
            }

            if (item.type == ItemID.PirateMap)
            {
                item.maxStack = 1;
                item.consumable = false;
            }
        }
    }
}