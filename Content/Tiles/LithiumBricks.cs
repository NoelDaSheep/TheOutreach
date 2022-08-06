using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TheOutreach.Content.Tiles
{
	public class LithiumBricks : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			//Main.tileSpelunker[Type] = false; // The tile will be affected by spelunker highlighting
			//Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			//Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = false;
			Main.tileSolid[Type] = true;
			//Main.tileBlockLight[Type] = true;
			//Main.tileBlockLight[Type] = true;

			AddMapEntry(new Color(134, 162, 135));

			DustType = 84;
			ItemDrop = ModContent.ItemType<Items.Placeable.LithiumBricks>();
			HitSound = SoundID.Tink;
			MineResist = 0.5f;
			MinPick = 0;
		}
	}
}