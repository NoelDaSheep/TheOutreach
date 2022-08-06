using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Placeable.Furniture
{
	public class LithiumChest : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("This is a modded chest.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 20;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 500;
			Item.createTile = ModContent.TileType<Tiles.Furniture.LithiumFurniture.LithiumChest>();
		}

        public override void AddRecipes()
        {
			CreateRecipe()
			.AddIngredient<LithiumBricks>(8)
			.AddRecipeGroup("IronBar", 2)
			.AddTile(TileID.Anvils)
			.Register();
        }
    }
}
