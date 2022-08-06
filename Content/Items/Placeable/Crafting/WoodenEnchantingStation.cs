using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Placeable.Crafting
{
	public class WoodenEnchantingStation : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Wooden Enchanting Station");
			Tooltip.SetDefault("Used to enchant magical items");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Crafting.WoodenEnchantingStation>());
			Item.value = 150;
			Item.maxStack = 99;
			Item.width = 40;
			Item.height = 34;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 25)
				.AddIngredient(ItemID.Book, 1)
				.AddIngredient(ItemID.Candle, 1)
				.Register();
		}
	}
}
