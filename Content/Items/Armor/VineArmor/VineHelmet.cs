using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Projectiles.Ranged;
using TheOutreach.Content.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.VineArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class VineHelmet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Viney Helmet");
			Tooltip.SetDefault("10% increased Ranged damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.10f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<VineChestplate>() && legs.type == ModContent.ItemType<VineLeggings>();
		}

		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "Immunity to Poisoned\n+7% Critical Strike Chance";
			player.buffImmune[BuffID.Poisoned] = true;
			//player.armorEffectDrawShadow = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RichMahoganyHelmet, 1)
				.AddIngredient(ItemID.Vine, 2)
				.AddIngredient(ItemID.JungleSpores, 5)
				.AddIngredient(ItemID.Silk, 9)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}