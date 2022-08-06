using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Placeable.Furniture
{
	public class DungeonTPPainting : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Magic Painting");
			Tooltip.SetDefault("Used to teleport between your home and the Dungeon.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.createTile = ModContent.TileType<Tiles.Furniture.DungeonTPPainting>(); // This sets the id of the tile that this item should place when used.

			Item.width = 28; // The item texture's width
			Item.height = 14; // The item texture's height

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.maxStack = 1;
			Item.consumable = true;
			Item.value = 0;
		}
        public override void AddRecipes()
        {
			/*CreateRecipe()
				.AddIngredient<LithiumBricks>(30)
				.AddTile(TileID.Anvils)
				.Register();*/
        }
    }
}