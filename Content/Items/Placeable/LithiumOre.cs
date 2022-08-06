using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Projectiles.Minions;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;


namespace TheOutreach.Content.Items.Placeable
{
	public class LithiumOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<TheOutreach.Content.Tiles.LithiumOre>();
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(silver: 1, copper: 50);
		}
	}
}
