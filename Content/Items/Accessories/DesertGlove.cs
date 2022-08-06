using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class DesertGlove : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("+4% Melee Speed\n+4% Melee Damage\nYou can no longer get pushed back in sandstorms");
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 15);
			Item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetAttackSpeed(DamageClass.Melee) += 0.04f;
			player.GetDamage(DamageClass.Melee) += 0.04f;
			player.buffImmune[BuffID.WindPushed] = true;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.AntlionMandible, 3)
				.AddIngredient(ItemID.Cactus, 15)
				.AddIngredient(ItemID.HardenedSand, 10)
				.AddIngredient(ItemID.Silk, 5)
				.AddTile(TileID.Loom)
				.Register();
        }
    }
}
