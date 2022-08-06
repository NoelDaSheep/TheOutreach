using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Projectiles.Magic;
using TheOutreach.Content.Buffs;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Armor.LithiumArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class LithiumHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Mask");
			Tooltip.SetDefault("10% increased Magic damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LithiumChestplate>() && legs.type == ModContent.ItemType<LithiumLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+20 mana \nMagic Attacks will fire an extra spark";
			player.statManaMax2 += 20;
			player.GetModPlayer<PlayerModifications>().lithiumMageSet = true;

			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumMageBonus>()] < 1)
			{
				Projectile.NewProjectile(player.GetSource_FromThis(), Main.LocalPlayer.Center.X, Main.LocalPlayer.Center.Y, 1, 1, ModContent.ProjectileType<LithiumMageBonus>(), 25, 5, player.whoAmI);
				player.AddBuff(ModContent.BuffType<LithiumCoreBuff>(), 2);
			}

			if (player.setBonus == "" || player.setBonus != "+20 mana \nMagic Attacks will fire an extra spark")
			{
				player.ClearBuff(ModContent.BuffType<LithiumCoreBuff>());
				player.GetModPlayer<PlayerModifications>().lithiumMageSet = false;
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