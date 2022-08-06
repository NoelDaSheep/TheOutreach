using TheOutreach.Content.Dusts;
using TheOutreach.Content.Tiles;
using TheOutreach.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Materials;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Tools.Axes
{
	public class LithiumChainsaw : ModItem
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
			Item.shoot = ModContent.ProjectileType<Content.Projectiles.LithiumChainsaw>();
			Item.shootSpeed = 40f;
			Item.tileBoost += 1;
			Item.noMelee = true;

			Item.damage = 7;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 18;
			Item.useTime = 7;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 25);
			Item.rare = ItemRarityID.Green;

			Item.axe = 12; 

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
