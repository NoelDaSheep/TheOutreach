using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;
using Terraria.DataStructures;
using TheOutreach.Content.Items.Materials;

namespace TheOutreach.Content.Items.Weapons.Magic
{
    public class LithiumWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoots two sparks that home in on enemies after a short delay");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			//DisplayName.SetDefault("Lithium Wand");
		}

		public override void SetDefaults()
        {
            Item.damage = 20;
            Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 32, copper: 50);
			Item.scale = 1f;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 15;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<LithiumSparkMagic>();
			Item.shootSpeed = 10;

		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Vector2 newVelocity1 = Utils.RotatedBy(velocity, 1 / 6.5f);
			Vector2 newVelocity2 = Utils.RotatedBy(velocity, -1 / 6.5f);
			Projectile.NewProjectileDirect(source, position + newVelocity1, newVelocity1, type, damage / 2, knockback, player.whoAmI);
			Projectile.NewProjectileDirect(source, position + newVelocity2, newVelocity2, type, damage / 2, knockback, player.whoAmI);
			return false;
		}

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(5)
				.AddIngredient<Battery>()
				.AddIngredient<Stardust>(3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
