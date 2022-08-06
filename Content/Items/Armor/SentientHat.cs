using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.Armor
{
	// This tells tModLoader to look for a texture called MinionBossMask_Head, which is the texture on the player
	// and then registers this item to be accepted in head equip slots
	[AutoloadEquip(EquipType.Head)]
	public class SentientHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Sentient Hat");
			Tooltip.SetDefault("+5% Magic Damage\n'He has your search history'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 22;

			Item.rare = ItemRarityID.Purple;
			Item.value = Item.sellPrice(gold: 3);
			Item.maxStack = 1;
		}

        public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Magic) += 0.05f;
			player.GetModPlayer<PlayerModifications>().hasRudeHat = true;
		}
		public override void PostUpdate()
        {
			Player player = Main.LocalPlayer;
			player.GetModPlayer<PlayerModifications>().hasRudeHat = true;

		}
    }
}
