using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Projectiles.Minions;
using TheOutreach.Content.Buffs;
using TheOutreach.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Utilities;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Events;
using TheOutreach.Common.Systems;


namespace TheOutreach.Content.Items.Armor.LithiumArmor
{
	[AutoloadEquip(EquipType.Head)]
	public class LithiumHelm : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Helm");
			Tooltip.SetDefault("10% increased Melee damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 28;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Melee) += 0.1f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<LithiumChestplate>() && legs.type == ModContent.ItemType<LithiumLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "5% increased Melee speed" + "\nGrants the wearer an Electric Shield";
			//grant stat boosts
			player.GetAttackSpeed(DamageClass.Melee) += 0.5f;
			//handle the shield
            if (player.GetModPlayer<PlayerModifications>().lithiumShield == false)
            {
				//give buff and set lithiumShield to true
				player.AddBuff(ModContent.BuffType<LithiumShield>(), 2);
				player.GetModPlayer<PlayerModifications>().lithiumShield = true;
			}

			if (player.setBonus == "" || player.setBonus != "5% increased Melee speed" + "\nGrants the wearer an Electric Shield")
			{
				player.ClearBuff(ModContent.BuffType<LithiumShield>());
				player.GetModPlayer<PlayerModifications>().lithiumShield = false;
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

				/*spawn dust
		for (int i = 0; i < 25; i++)
		{
			Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.25f, 0.25f);
			Dust d2 = Dust.NewDustPerfect(Main.LocalPlayer.Center, ModContent.DustType<Spark>(), speed2 * 5, Scale: 1f);
			d2.noGravity = true;

			Vector2 speed3 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
			Dust d3 = Dust.NewDustPerfect(Main.LocalPlayer.Center, ModContent.DustType<Spark>(), speed3 * 5, Scale: 1f);
			d3.noGravity = true;
		}*/
	}
}