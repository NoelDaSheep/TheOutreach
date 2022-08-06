using TheOutreach.Content.Dusts;
using TheOutreach.Content.Tiles;
using TheOutreach.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Materials;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Tools.Pickaxes
{
	public class LithiumDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("This is a modded hammer.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item23;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.LithiumDrill>();
			Item.shootSpeed = 40f;
			Item.tileBoost += 1;
			Item.noMelee = true;

			Item.damage = 5;
			Item.DamageType = DamageClass.Melee;
			Item.width = 20;
			Item.height = 9;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 1); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;

			Item.pick = 55; // How strong the pickaxe is, see https://terraria.gamepedia.com/Pickaxe_power for a list of common values

		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(3)
				.AddIngredient<Battery>(1)
				.AddRecipeGroup("IronBar", 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
