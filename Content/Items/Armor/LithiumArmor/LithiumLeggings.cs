using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Minions;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.LithiumArmor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LithiumLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("25% increased movement speed");
			//+ "\n5% increased movement speed");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
			if (player.setBonus == "")
			{
				//clear buff
				player.ClearBuff(ModContent.BuffType<LithiumProbeBuff>());
			}
		}

		public override void UpdateArmorSet(Player player)
        {
		}





		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(5)
				.AddIngredient<Stardust>(1)
				.AddRecipeGroup("IronBar", 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}