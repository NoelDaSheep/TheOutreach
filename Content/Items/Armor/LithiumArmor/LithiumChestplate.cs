using Terraria;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Projectiles.Minions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.LithiumArmor
{
	[AutoloadEquip(EquipType.Body)]
	public class LithiumChestplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Lithium Chestplate");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 22;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 7;
		}


		public override void UpdateEquip(Player player) 
		{
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
				.AddIngredient<LithiumPlating>(7)
				.AddIngredient<Stardust>(1)
				.AddRecipeGroup("IronBar", 6)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}