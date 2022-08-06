using TheOutreach.Content.Projectiles.Melee;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Weapons.Melee
{
	public class ElectrostaticKnopesh : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}

		public override void SetDefaults() {
			// Common Properties
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 3);
			Item.maxStack = 1;

			// Use Properties
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;

			// Weapon Properties
			Item.damage = 32;
			Item.knockBack = 6.5f;
			Item.noUseGraphic = false;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = false;

			// Projectile Properties
			//Item.shootSpeed = 0f;
			//tem.shoot = ModContent.ProjectileType<ElectrostaticKnopeshProj>();
		}
        /*public override bool CanUseItem(Player player)
        {
            if(player.ownedProjectileCounts[ModContent.ProjectileType<ElectrostaticKnopeshProj>()] < 1)
            {
				return true;
            }
			return false;
        }*/
        /*public override void AddRecipes()
		{
			CreateRecipe(25)
				.AddIngredient(ItemID.StoneBlock)
				.AddTile(TileID.WorkBenches)
				.Register();
		}*/

		/*public override void AddRecipes()
		{
			//anything set to amount defaults to one
			CreateRecipe(amount)
				.AddIngredient(ItemID.itemname, amount)
				.AddIngredient(ModContent.ItemType<itemname>(), amount)
				.AddTile(TileID.tilename)
				.Register();
		}*/
	}
}
