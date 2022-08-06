using TheOutreach.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items
{
	public class PeaceTreaty : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Favorite this item to disable Goblin Invasions\nGoblin Battle Standards will not work when this effect is active");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 26;
			Item.defense = 4;
			Item.accessory = false;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 15);
			//item.expert = true;
		}
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
				if(Main.invasionType == 1)
                {
					Main.invasionSize = 0;
				}
			}
		}
    }
}
