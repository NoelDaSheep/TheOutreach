using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class EnduraFungi : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("For every 50 damage you deal you gain 1 defense up to 10 defense\nIf you are hit during the streak the defense resets");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 32;
			//Item.defense = 7;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 1);
			//item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<PlayerModifications>().hasEnduraShroom = true;
			player.statDefense += player.GetModPlayer<PlayerModifications>().enduraShroomDefense;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddRecipeGroup("IronBar", 15)
				.AddIngredient(ItemID.GlowingMushroom, 10)
				.AddIngredient(ItemID.Mushroom, 10)
				.AddRecipeGroup("TheOutreach:StrangePlant", 1)
				.Register();
        }
    }
}
