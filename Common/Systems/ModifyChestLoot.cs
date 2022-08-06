using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ReLogic.Graphics;
using System;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using TheOutreach.Content.Items.F_I_S_H;
using TheOutreach.Content.Items.Weapons.Magic;

namespace TheOutreach.Common.Systems
{
	public class ModifyChestLoot : ModSystem
	{
        public override void PostWorldGen()
        {
			int[] itemsToPlaceInSkyChests = { ModContent.ItemType<StarShower>() };
			int itemsToPlaceInSkyChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 13 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.Starfury)
						{
							if (Main.rand.Next(2) < 1) // a 1 in 2 chance
							{
								chest.item[inventoryIndex].SetDefaults(itemsToPlaceInSkyChests[itemsToPlaceInSkyChestsChoice]);
								itemsToPlaceInSkyChestsChoice = (itemsToPlaceInSkyChestsChoice + 1) % itemsToPlaceInSkyChests.Length;
								break;
							}
							else
							{

							}

						}
					}
				}
			}

			int[] itemsToPlaceInPyramidChests = { ItemID.AmberHook };
			int[] itemsToPlaceInPyramidChests2 = { ItemID.Amber, 3 };
			int itemsToPlaceInPyramidChestsChoice = 0;
			int itemsToPlaceInPyramidChestsChoice2 = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == ItemID.PharaohsRobe)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInPyramidChests[itemsToPlaceInPyramidChestsChoice]);
							itemsToPlaceInPyramidChestsChoice = (itemsToPlaceInPyramidChestsChoice + 1) % itemsToPlaceInPyramidChests.Length;
							break;
						}
						if (chest.item[inventoryIndex].type == ItemID.PharaohsMask)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInPyramidChests2[itemsToPlaceInPyramidChestsChoice2]);
							itemsToPlaceInPyramidChestsChoice2 = (itemsToPlaceInPyramidChestsChoice2 + 1) % itemsToPlaceInPyramidChests2.Length;
							break;
						}
					}
				}
			}
		}
    }
}
