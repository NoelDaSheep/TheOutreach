using TheOutreach.Content.Projectiles.Melee;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TheOutreach.Content.Items.Weapons.Melee
{
	public class CrimtaneRazor : ModItem
	{
		public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 1, silver: 75);
			Item.maxStack = 1;

			// Use Properties
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = false;

			// Weapon Properties
			Item.damage = 31;
			Item.knockBack = 6.5f;
			Item.noUseGraphic = false;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = false;
		}

		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.CrimtaneBar, 20)
				.AddIngredient(ItemID.TissueSample, 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
