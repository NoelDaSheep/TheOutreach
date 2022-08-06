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
	public class WarAxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("War-axe");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 25);
			Item.maxStack = 1;

			// Use Properties
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = false;

			// Weapon Properties
			Item.damage = 15;
			Item.knockBack = 6.5f;
			Item.noUseGraphic = false;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = false;
		}

		public override void AddRecipes()
		{
			//anything set to amount defaults to one
			CreateRecipe(1)
				.AddIngredient(ItemID.Wood, 5)
				.AddRecipeGroup(RecipeGroupID.IronBar)
				.AddTile(TileID.Anvils)
				.Register();
		}
		/*public override void HoldStyle(Player player, Rectangle heldItemFrame)
		{
			heldItemFrame.X -= 12;
			heldItemFrame.Y -= 6;
			HoldStyle(player, heldItemFrame);
		}*/
	}
}
