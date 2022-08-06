using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Materials
{
	public class EmptyRing : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It can focus the energy of different magics'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 99;
			Item.value = Item.buyPrice(gold: 5);
			Item.rare = ItemRarityID.Lime;
		}
	}
}
