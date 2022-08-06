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
	public class LithiumHelmet : ModItem
	{
		Player player;
		public string greetings;

		public static List<string> greetText = new List<string>
		{
			"owo",
			">w<",
			"^w^",
			".w."
		}; 
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Helmet");
			Tooltip.SetDefault("10% increased Summon damage");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
		}
        public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Summon) += 0.1f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<LithiumChestplate>() && legs.type == ModContent.ItemType<LithiumLeggings>();
		}
		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "+1 minion slot" + "\nSummons a really dumb robot to protect you";
			player.maxMinions += 1;
			//player.whipUseTimeMultiplier *= 0.01f;
			//player.whipRangeMultiplier += 0.01f;


			//Minion Logic

			if (player.ownedProjectileCounts[ModContent.ProjectileType<LithiumProbe>()] < 1)
			{
				//give buff/spawn projectile
				Projectile.NewProjectile(player.GetSource_FromThis(), Main.LocalPlayer.Center.X, Main.LocalPlayer.Center.Y, 1, 1, ModContent.ProjectileType<LithiumProbe>(), 25, 5, player.whoAmI);
				player.AddBuff(ModContent.BuffType<LithiumProbeBuff>(), 2);
				greetings = greetText[Main.rand.Next(greetText.Count)];
				Main.combatText[CombatText.NewText(player.getRect(), new Color(66, 173, 245), greetings)].lifeTime = 120;
			}

			if (player.setBonus == "" || player.setBonus != "+1 minion slot" + "\nSummons a really dumb robot to protect you")
			{
				player.ClearBuff(ModContent.BuffType<LithiumProbeBuff>());
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