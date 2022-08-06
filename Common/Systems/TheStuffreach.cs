using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ReLogic.Graphics;
using System;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using TheOutreach.Content.Items.F_I_S_H;
using TheOutreach.Content.Items.Weapons.Magic;

namespace TheOutreach.Common.Systems
{
    public class TheStuffreach : ModSystem
    {
        public static bool ForagerHasMoved = false;

        public override void OnWorldLoad()
        {
            ForagerHasMoved = false;
        }

        public override void OnWorldUnload()
        {
            ForagerHasMoved = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (ForagerHasMoved)
            {
                tag["ForagerHasMoved"] = true;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            ForagerHasMoved = tag.ContainsKey("ForagerHasMoved");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = ForagerHasMoved;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ForagerHasMoved = flags[0];
        }
    }
}
