using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Items.Materials;

namespace TheOutreach.Content.Items.F_I_S_H
{
	// Basic code for a boss treasure bag
	public class VileEel : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}"); // References a language key that says "Right Click To Open" in the language of the game

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 5;
		}

		public override void SetDefaults() {
			Item.maxStack = 999;
			Item.consumable = true;
			Item.width = 26;
			Item.height = 28;
			Item.rare = ItemRarityID.Blue;
		}

		public override bool CanRightClick() {
			return true;
		}

        public override void RightClick(Player player)
        {
            base.RightClick(player);
			player.QuickSpawnItem(Item.GetSource_GiftOrReward(), ItemID.ShadowScale, Main.rand.Next(5, 10));
			player.QuickSpawnItem(Item.GetSource_GiftOrReward(), ItemID.DemoniteOre, Main.rand.Next(10, 15));
		}
	}
}
