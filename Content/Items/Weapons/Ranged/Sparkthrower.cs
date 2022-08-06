using TheOutreach.Content.Projectiles;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Weapons.Ranged
{
	// Flamethrowers have some special characteristics, such as shooting several projectiles in one click, and only consuming ammo on the first projectile
	// The most important characteristics, however, are explained in the FlamethrowerProjectile code.
	public class Sparkthrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots a stream of sparks\nUses gel as ammo\n'How does it even work!?'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{

			Item.damage = 13; 
			Item.DamageType = DamageClass.Ranged;	
			Item.width = 42;
			Item.height = 18;
			Item.useTime = 6;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0.4f;
			Item.value = Item.sellPrice(silver: 32, copper: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SparkthrowerProjectile>();
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.Gel;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
			return player.itemAnimation >= player.itemAnimationMax - 4;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 60f;
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -2f);
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(4)
				.AddIngredient<Stardust>(6)
				.AddIngredient<Battery>(1)
				.AddRecipeGroup("IronBar", 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
