using Terraria.ID;
using Terraria.ModLoader;
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
	public class Stardust : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("It doesn't dissapear during daytime even though all you did was crush it.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

		}

		public override void SetDefaults() {
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.value = Item.sellPrice(silver: 1);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			CreateRecipe(3)
				.AddIngredient(ItemID.FallenStar, 2)
				.Register();
		}
	}
}
