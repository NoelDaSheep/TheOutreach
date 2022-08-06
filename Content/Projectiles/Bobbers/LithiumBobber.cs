using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Bobbers
{
	public class LithiumBobber : ModProjectile
	{

		private bool initialized;
		// This holds the index of the fishing line color in the PossibleLineColors array.
		private int fishingLineColorIndex;

		private Color FishingLineColor => new Color(0, 134, 255);

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lithium Bobber");
		}

		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 12;
			Projectile.aiStyle = 61;
			Projectile.bobber = true;
			Projectile.penetrate = -1;
			Projectile.netImportant = true;

			//DrawOriginOffsetY = -8; // Adjusts the draw position
		}
		public override void ModifyFishingLine(ref Vector2 lineOriginOffset, ref Color lineColor) {
			// Change these two values in order to change the origin of where the line is being drawn.
			// This will make it draw 47 pixels right and 31 pixels up from the player's center, while they are looking right and in normal gravity.
			lineOriginOffset = new Vector2(40, -25);
			// Sets the fishing line's color. Note that this will be overridden by the colored string accessories.
			lineColor = FishingLineColor;
		}
		// These last two methods are required so the line color is properly synced in multiplayer.
		public override void SendExtraAI(BinaryWriter writer) {
			writer.Write((byte)fishingLineColorIndex);
		}

		public override void ReceiveExtraAI(BinaryReader reader) {
			fishingLineColorIndex = reader.ReadByte();
		}
	}
}