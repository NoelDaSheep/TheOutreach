using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Placeable;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Materials
{
	public class VoltaicFeather : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'A feather of the deserts true power'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 15;

		}

		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = ItemRarityID.Blue;
		}
	}
}
