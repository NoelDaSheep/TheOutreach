using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Placeable.Furniture
{
	public class LithiumForge : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Forge");
			Tooltip.SetDefault("Used to craft Lithium Furniture");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.createTile = ModContent.TileType<Tiles.Furniture.LithiumFurniture.LithiumForge>(); // This sets the id of the tile that this item should place when used.

			Item.width = 28; // The item texture's width
			Item.height = 14; // The item texture's height

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.maxStack = 99;
			Item.consumable = true;
			Item.value = 150;
		}
        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient<LithiumBricks>(30)
				.AddTile(TileID.Anvils)
				.Register();
        }
    }
}