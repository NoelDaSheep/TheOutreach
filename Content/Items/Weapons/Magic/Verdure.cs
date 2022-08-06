using TheOutreach.Content.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TheOutreach.Content.Items.Weapons.Magic
{
	public class Verdure : ModItem
	{
		public override void SetStaticDefaults() {
			//DisplayName.SetDefault("Verdure");
			Tooltip.SetDefault("Shoots Poisonous Stingers\n'Kinda looks like tree bark'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 15, copper: 25);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item17;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<VerdureStinger>();
			Item.shootSpeed = 15f;
		}

		/*public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45;
			for (int i = 0; i < 3; i++)
			{
				velocity = new Vector2(velocity.X, velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (3 - 1))) * 0.2f;
				Projectile.NewProjectile(player.GetProjectileSource_Item(Item), position.X, position.Y, velocity.X, velocity.Y, type, damage, 5, player.whoAmI);
			}
			return false;
		}*/
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int amount = 3;
			for (int i = 0; i < amount; i++)
			{
				Vector2 newVelocity = Utils.RotatedBy(velocity, i / 6.5f);
				Projectile.NewProjectileDirect(source, position + newVelocity, newVelocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		/*
		    float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45;
			for (int i = 0; i < 3; i++)
			{
				velocity = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (3 - 1))) * 0.2f;
				Projectile.NewProjectile(player.GetProjectileSource_Item(Item), position.X, position.Y, velocity.X, velocity.Y, type, damage, 5, player.whoAmI);
			}
			return false;
		 */



		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Stinger, 5)
				.AddIngredient(ItemID.Vine, 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}