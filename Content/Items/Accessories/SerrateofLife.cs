using TheOutreach.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class SerrateofLife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Serrate of Thorns");
			Tooltip.SetDefault("Small Damage Boost\nSmall chance to fire a cross of thorns\n'A rare flora with impressive offensive measures'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//+5% damage, +5% melee speed, +20 mana, +1 minion slot, +10% chance not to consume ammo
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 26;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 1);
			//item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) += 0.04f;
			player.GetModPlayer<PlayerModifications>().hasLifeLeaf = true;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Vine, 2)
				.AddIngredient(ItemID.Stinger, 5)
				.AddIngredient(ItemID.RichMahogany, 15)
				.AddTile(TileID.AlchemyTable)
				.Register();
        }
    }
}
