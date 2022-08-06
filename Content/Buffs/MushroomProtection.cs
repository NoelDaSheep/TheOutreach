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
	public class MushroomProtection : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mushroom Protection");
			Description.SetDefault("You take less damage temporarily");
			Main.buffNoTimeDisplay[Type] = true;
			Main.debuff[Type] = false; // Add this so the nurse doesn't remove the buff when healing
		}
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.GetModPlayer<PlayerModifications>().hasEnduraShroom == true)
            {
				player.buffTime[buffIndex] = 18000;
			}
            else
            {
				player.ClearBuff(buffIndex);
            }
		}
    }
}