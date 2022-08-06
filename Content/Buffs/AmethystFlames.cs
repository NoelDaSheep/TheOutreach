using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using ReLogic.Graphics;
using System;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using TheOutreach.Content.Items.F_I_S_H;
using TheOutreach.Common.Systems;


namespace TheOutreach.Content.Buffs
{
	public class AmethystFlames : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amethyst Flames");
			Description.SetDefault("Losing life");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true; // Add this so the nurse doesn't remove the buff when healing
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.color = Color.Magenta;
			npc.lifeRegen -= 7;
        }
        public override void Update(Player player, ref int buffIndex)
        {
			player.lifeRegen = -7;
		}
    }
}