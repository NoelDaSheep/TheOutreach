using TheOutreach.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class LithiumPortableFishingEnhancementDevice : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Portable Fishing Enhancement Device");
			Tooltip.SetDefault("+5 Fishing Power" +
				"\nChance to double caught fish\n'Now water proof!'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 3);
			//item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.fishingSkill += 5;
			player.GetModPlayer<PlayerModifications>().HasLPFED = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(5)
				.AddIngredient<Battery>(2)
				.AddIngredient<Stardust>(3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
