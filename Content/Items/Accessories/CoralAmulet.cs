using TheOutreach.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class CoralAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+20 Mana" +
				"\n+5% Magic Damage\nPermanent Water Breathing\n'An amulet of the sea'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.defense = 3;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 3);
			//item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) += 0.05f;
			player.statManaMax2 += 20; 
			player.breath += 2;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EmptyAmulet>());
			recipe.AddIngredient(ItemID.Coral, 5);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		public override void AddRecipes()
		{

			CreateRecipe()
				.AddIngredient<EmptyAmulet>()
				.AddIngredient(ItemID.Coral, 5)
				.AddRecipeGroup("TheOutreach:GoldBar", 5)
				.AddTile(ModContent.TileType<Tiles.Crafting.WoodenEnchantingStation>())
				.Register();
		}
	}
}
