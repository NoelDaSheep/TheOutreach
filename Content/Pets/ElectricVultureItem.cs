using TheOutreach.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace TheOutreach.Content.Pets
{
	public class ElectricVultureItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Usurped Mask");
			Tooltip.SetDefault("Summons a powerful creature to watch you in combat");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.ZephyrFish); // Copy the Defaults of the Zephyr Fish Item.

			Item.shoot = ModContent.ProjectileType<ElectricVultureProjectile>(); // "Shoot" your pet projectile.
			Item.buffType = ModContent.BuffType<ElectricVultureBuff>(); // Apply buff upon usage of the Item.
			Item.master = true;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(Item.buffType, 3600);
			}
		}
	}
}
