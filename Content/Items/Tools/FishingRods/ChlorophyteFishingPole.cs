using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Projectiles.Bobbers;
using TheOutreach.Common.Systems;

namespace TheOutreach.Content.Items.Tools.FishingRods
{
	public class ChlorophyteFishingPole : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chlorophyte Fishing Pole");
			Tooltip.SetDefault("Has a small chance to fish up chlorophyte in the jungle");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 8;
			Item.useTime = 8;
			Item.UseSound = SoundID.Item1;
			//Item.CloneDefaults(ItemID.WoodFishingPole);

			Item.fishingPole = 40; // Sets the poles fishing power
			Item.shootSpeed = 12f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.Bobbers.ChlorophyteBobber>(); // The Bobber projectile.
		}
		public override void HoldItem(Player player)
		{
			player.GetModPlayer<PlayerModifications>().HoldingChloroRod = true;

		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.FiberglassFishingPole)
				.AddIngredient(ItemID.ChlorophyteBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}