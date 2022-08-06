using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Projectiles.Bobbers;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Common.Systems;

namespace TheOutreach.Content.Items.Tools.FishingRods
{
	public class LithiumFishingRod : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Fishing Rod");
			Tooltip.SetDefault("'No longer the leading cause of Global Warming!'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 48;
			Item.height = 34;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 8;
			Item.useTime = 8;
			Item.UseSound = SoundID.Item1;
			//Item.CloneDefaults(ItemID.WoodFishingPole);

			Item.fishingPole = 25; // Sets the poles fishing power
			Item.shootSpeed = 12f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.Bobbers.LithiumBobber>(); // The Bobber projectile.
		}
		public override void HoldItem(Player player)
		{
			//player.GetModPlayer<PlayerModifications>().HoldingChloroRod = true;

		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<LithiumPlating>(4)
				.AddIngredient<Battery>()
				.AddIngredient<Stardust>(3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}