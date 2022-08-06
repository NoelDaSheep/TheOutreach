using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
namespace TheOutreach.Content.Items.Accessories
{
	public class SlimeKingsSlides : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Double tap down to dash downwards\nafter the dash you will bounce\n+10% Jump Speed");
		}

		public override void SetDefaults()
		{
			Item.accessory = true;
			Item.rare = ItemRarityID.Master;
			Item.value = Item.sellPrice(silver: 15);
			Item.defense = 0;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.jumpSpeedBoost += 0.1f;
			if (player.whoAmI == Main.myPlayer && player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)
			{
				player.velocity.Y += 16;
				player.GetModPlayer<PlayerModifications>().SlimeDownDash = 20;
				player.GetModPlayer<PlayerModifications>().isSlimeDownDash = true;
			}
			if(player.velocity.Y != 0 && player.GetModPlayer<PlayerModifications>().isSlimeDownDash == true)
            {
				player.maxFallSpeed = 20;
				player.noFallDmg = true;
            }
            else
            {
				player.maxFallSpeed = 10;
                if (player.GetModPlayer<PlayerModifications>().isSlimeDownDash)
                {
					SoundEngine.PlaySound(SoundID.Item14, player.Center);
					player.velocity.Y -= 10;

					for (int i = 0; i < 15; i++)
					{
						Dust dust;
						Vector2 position = Main.LocalPlayer.Center;
						dust = Terraria.Dust.NewDustDirect(position, 0, 4, DustID.Smoke, 0f, -1, 0, new Color(255, 255, 255), 2f);
					}
				}
				player.GetModPlayer<PlayerModifications>().isSlimeDownDash = false;
			}
		}
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
			Item.scale += 1;
			return true;
        }
    }
}
