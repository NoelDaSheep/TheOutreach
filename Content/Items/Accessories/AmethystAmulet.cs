using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class AmethystAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+20 max mana\n+5% magic damage\nMagic attacks have a chance to inflict Amethyst Flames\nMagic projectiles have a chance to spawn amethyst bolts");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 24;
			Item.defense = 5;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 1);
			//item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<PlayerModifications>().hasAmethystAmulet = true;
			player.statManaMax2 += 20;
			player.GetDamage(DamageClass.Magic) += 0.05f;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<EmptyAmulet>())
				.AddIngredient(ItemID.Amethyst, 10)
				.AddTile<Tiles.Crafting.WoodenEnchantingStation>()
				.Register();
        }
    }
}
