using TheOutreach.Content.Projectiles.Ranged;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Weapons.Ranged
{
	public class CherryBomb : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cherry Bomb");
			Tooltip.SetDefault("Throws a Cherry that explodes into a pit");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Grenade);
			Item.width = 16;
			Item.height = 20;
			Item.shoot = ModContent.ProjectileType<CherryBombProjectile>(); 
			Item.damage = 7; 
			Item.shootSpeed *= 1.25f;
			Item.maxStack = 1;
			Item.consumable = false;
		}
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Cherry)
				.AddIngredient(ItemID.Gel, 15)
				.AddIngredient(ItemID.Torch, 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
