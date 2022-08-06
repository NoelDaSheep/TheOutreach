using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Placeable;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Projectiles.Minions;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;

namespace TheOutreach.Content.Items.Materials
{
	public class Battery : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A wonder of electronics, yet you were able to craft it. ");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 18;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(silver: 11, copper: 50);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(3)
				.AddIngredient<Stardust>(1)
				.AddRecipeGroup("IronBar", 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
