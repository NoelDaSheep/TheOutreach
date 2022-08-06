using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Projectiles.Ranged;
using TheOutreach.Content.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;


namespace TheOutreach.Content.Items.Armor.LithiumArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class LithiumVisor : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lithium Visor");
			Tooltip.SetDefault("10% increased Ranged damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Ranged) += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LithiumChestplate>() && legs.type == ModContent.ItemType<LithiumLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "25% Increased Movement Speed";
			//player.allDamage -= 0.2f;
			// Here are the individual weapon class bonuses
			player.moveSpeed += 0.25f;
			player.GetModPlayer<PlayerModifications>().lithiumGun = true;

			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumGun>()] < 1)
			{
				//give buff/spawn projectile
				Projectile.NewProjectile(player.GetSource_FromThis(), Main.LocalPlayer.Center.X, Main.LocalPlayer.Center.Y, 1, 1, ModContent.ProjectileType<LithiumGun>(), 25, 5, player.whoAmI);
				player.AddBuff(ModContent.BuffType<LithiumGunBuff>(), 2);
			}

			if (player.setBonus == "" || player.setBonus != "25% Increased Movement Speed")
            {
				player.ClearBuff(ModContent.BuffType<LithiumGunBuff>());
				player.GetModPlayer<PlayerModifications>().lithiumGun = false;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<LithiumPlating>(4)
				.AddIngredient<Stardust>(3)
				.AddIngredient<Battery>(1)
				.AddRecipeGroup("IronBar", 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}