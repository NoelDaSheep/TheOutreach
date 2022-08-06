using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Placeable
{
	public class LithiumBricks : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 50;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<TheOutreach.Content.Tiles.LithiumBricks>();
			Item.width = 16;
			Item.height = 16;
			Item.value = 0;
		}

		public override void AddRecipes()
		{
			CreateRecipe(5)
			.AddIngredient<LithiumOre>()
			.AddIngredient(ItemID.StoneBlock, 3)
			.AddTile(TileID.Anvils)
			.Register();
			
        }
    }
}
