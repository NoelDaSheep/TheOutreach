using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheOutreach.Content.Items.Accessories
{
	public class FrozenClump : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Every 3 seconds you don't move you release a burst of ice spikes");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 34;
			Item.defense = 3;
			Item.accessory = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(gold: 1);
			//item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if(player.velocity == new Vector2(0,0))
            {
				player.statDefense += 7;
				player.lifeRegen += 3;
				player.GetModPlayer<PlayerModifications>().hasFrozenClumpStill = true;
            }
            else
            {
				player.GetModPlayer<PlayerModifications>().frozenClumpTimer = 0;
            }
		}
    }
}
