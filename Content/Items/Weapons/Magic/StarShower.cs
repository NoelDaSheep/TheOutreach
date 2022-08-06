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
	public class StarShower : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Rains stars from the sky\n'Enchanted with the fury of heaven'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			//Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(14, 7));
		}

		public override void SetDefaults() {
			Item.scale = 1f;
			Item.damage = 25;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 5;
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<StarShowerStar>();
			Item.shootSpeed = 20;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectilestwo = 3; // shoots 6 projectiles
			for (int index = 0; index < numberProjectilestwo; ++index)
			{
				Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
				vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
				vector2_1.Y -= (float)(100 * index);
				float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
				float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if ((double)num13 < 0.0) num13 *= -1f;
				if ((double)num13 < 20.0) num13 = 20f;
				float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
				float num15 = Item.shootSpeed / num14;
				float num16 = num12 * num15;
				float num17 = num13 * num15;
				float SpeedX = num16 + (float)Main.rand.Next(-5, 5) * 0.02f; //change the Main.rand.Next here to, for example, (-10, 11) to reduce the spread. Change this to 0 to remove it altogether
				float SpeedY = num17 + (float)Main.rand.Next(-5, 5) * 0.02f;
				Projectile.NewProjectile(player.GetSource_FromThis(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, 5, player.whoAmI);

			}
			return false;
		}


        //Recipe
        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.Starfury)
				.AddTile(TileID.SkyMill)
				.Register();
        }
    }
}