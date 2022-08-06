using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Minions;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.VineArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class VineLeggings : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Viney Chestplate");
			Tooltip.SetDefault("20% increased movement speed");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 20;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
		}

		public override void UpdateArmorSet(Player player)
        {
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RichMahoganyGreaves, 1)
				.AddIngredient(ItemID.Vine, 2)
				.AddIngredient(ItemID.JungleSpores, 4)
				.AddIngredient(ItemID.Silk, 7)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}