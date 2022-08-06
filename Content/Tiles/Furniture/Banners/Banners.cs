using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheOutreach.Content.NPCs.Enemies;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace TheOutreach.Content.Tiles.Furniture.Banners
{
    public class Banners : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            DustType = -1;
            //DisableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int style = frameX / 18;
            int item;
            switch (style)
            {
                case 0:
                    item = ItemType<LithiumAutomatonBanner>();
                    break;

                //example on how to continue for more banners
                /*case 1:
                    item = ItemType<CrawlerBanner>();
                    break;*/

                default:
                    return;
            }
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, item);

        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].TileFrameX / 18;
                int type;
                switch (style)
                {
                    case 0:
                        type = NPCType<LithiumAutomaton>();
                        break;

                    //example on how to continue for more banners
                    /*case 1:
                        type = NPCType<Crawler>();
                        break;*/

                    default:
                        return;
                }
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
    }
}