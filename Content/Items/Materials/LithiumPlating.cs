using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Projectiles.Minions;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;

namespace TheOutreach.Content.Items.Materials
{
	public class LithiumPlating : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 60; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;

		}

		public override void SetDefaults()
		{
			Item.maxStack = 999;
			Item.value = Item.sellPrice(silver: 3, copper: 50);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumOre>(3)
				.AddTile(TileID.Furnaces)
				.Register();
		}
	}
}
