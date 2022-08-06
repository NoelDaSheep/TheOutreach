using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Localization;


namespace TheOutreach.Content.Tiles.Furniture
{
	public class DungeonTPPainting : ModTile
	{
		public override void SetStaticDefaults() {
			// Properties
			Main.tileTable[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileFrameImportant[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.IgnoredByNpcStepUp[Type] = false; // This line makes NPCs not try to step up this tile during their movement. Only use this for furniture with solid tops.

			DustType = ModContent.DustType<Dusts.Spark>();

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
			TileObjectData.addTile(Type);

			// Etc
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Painting");
			AddMapEntry(new Color(134, 162, 135));
		}
		public override void NumDust(int x, int y, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<Items.Placeable.Furniture.DungeonTPPainting>());
			Chest.DestroyChest(i, j);
		}

        public override bool RightClick(int i, int j)
        {
			Player player = Main.LocalPlayer;
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.maxTilesX; ++x) // LOOP WORLD X
			{
				for (int y = 0; y < Main.maxTilesY; ++y) // LOOP WORLD Y
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].TileType != ModContent.TileType<HomeTPPaintingDun>()) continue;
					pos = new Vector2((x - 2) * 16, y * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				player.position = pos;
			}
            else
            {
				Main.combatText[CombatText.NewText(player.getRect(), Color.Red, "Nothing Happens")].lifeTime = 120;
			}
			return base.RightClick(i, j);
        }
	}
}