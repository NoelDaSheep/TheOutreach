using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Items.F_I_S_H
{
	public class LithiumOctosquid : ModItem
	{
		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() {
			Item.questItem = true;
			Item.maxStack = 1;
			Item.width = 24;
			Item.height = 24;
			Item.uniqueStack = true; // Make this item only stack one time.
			Item.rare = ItemRarityID.Quest; // Sets the item's rarity. This exact line uses a special rarity for quest items.
		}

		public override bool IsQuestFish() => true; // Makes the item a quest fish

		public override bool IsAnglerQuestAvailable() => !Main.hardMode; // Makes the quest only appear in hard mode. Adding a '!' before Main.hardMode makes it ONLY available in pre-hardmode.

		public override void AnglerQuestChat(ref string description, ref string catchLocation) {
			// How the angler describes the fish to the player.
			description = "I've heard stories of a fish that ate a bunch of robots and became one! Go get me one or I will eat you and steal your fishing power.";
			// What it says on the bottom of the angler's text box of how to catch the fish.
			catchLocation = "Caught anywhere Underground";
		}
	}
}
