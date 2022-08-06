using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Common.GlobalItems
{
	// This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand.
	// See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
	public class SummonModifications : GlobalItem
	{
		// Here we make sure to only instance this GlobalItem for the Copper Shortsword, by checking item.type
		public override void SetDefaults(Item item) {
            //StardustDragonStaff
            if (item.type == ItemID.StardustDragonStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //StardustCellStaff
            if (item.type == ItemID.StardustCellStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //XenoStaff
            if (item.type == ItemID.XenoStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //ImpStaff
            if (item.type == ItemID.ImpStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //OpticStaff
            if (item.type == ItemID.OpticStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //TempestStaff
            if (item.type == ItemID.TempestStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //PygmyStaff
            if (item.type == ItemID.PygmyStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //SlimeStaff
            if (item.type == ItemID.SlimeStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //StaffOfTheFrostHydra
            if (item.type == ItemID.StaffoftheFrostHydra)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //RavenStaff
            if (item.type == ItemID.RavenStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //HornetStaff
            if (item.type == ItemID.HornetStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //QueenSpiderStaff
            if (item.type == ItemID.QueenSpiderStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //SpiderStaff
            if (item.type == ItemID.SpiderStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //PirateStaff
            if (item.type == ItemID.PirateStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //DeadlySphereStaff
            if (item.type == ItemID.DeadlySphereStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }

            //1.4 Items

            //Abigails Flower
            if (item.type == ItemID.AbigailsFlower)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Finch Staff
            if (item.type == ItemID.BabyBirdStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Flinx Staff
            if (item.type == ItemID.FlinxStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Vampire Frog Staff
            if (item.type == ItemID.VampireFrogStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Sanguine Staff
            if (item.type == ItemID.SanguineStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Blade Staff
            if (item.type == 4758)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Desert Tiger Staff
            if (item.type == ItemID.StormTigerStaff)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
            //Terraprisma
            if (item.type == ItemID.EmpressBlade)
            {
                item.useTime = 15;
                item.useAnimation = 15;
                item.autoReuse = true;
            }
        }
	}
}
