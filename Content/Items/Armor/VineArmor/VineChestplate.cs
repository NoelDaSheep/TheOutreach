using Terraria;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Minions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.VineArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class VineChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Viney Chestplate");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 24;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}

		//maybe have the armor provide the same stats as silver armor,
		//but also include a slight movement speed buff, a slight increase to ranged
		//damage and crit, a 20% not to consume ammo and a poison immunity or something

		public override void UpdateEquip(Player player) 
		{
			
		}

		public override void UpdateArmorSet(Player player)
		{
			player.buffImmune[BuffID.Poisoned] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.RichMahoganyBreastplate, 1)
				.AddIngredient(ItemID.Vine, 3)
				.AddIngredient(ItemID.JungleSpores, 6)
				.AddIngredient(ItemID.Silk, 11)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}