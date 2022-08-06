using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TheOutreach.Content.Tiles
{
	public class WyrmStone : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 820; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileFlame[Type] = true;
			//Main.tileBlockLight[Type] = true;
			//Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Wyrm Stone");
			AddMapEntry(new Color(232, 138, 54), name);

			DustType = DustID.OrangeTorch;
			ItemDrop = ModContent.ItemType<Items.Placeable.WyrmStone>();
			HitSound = SoundID.Tink;
			MineResist = 10f;
			MinPick = 210;
		}
	}
}