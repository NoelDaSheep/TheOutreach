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
	public class LithiumShield : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Shield");
			Description.SetDefault("Grants +3 defense and 10 max life.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.debuff[Type] = false; // Add this so the nurse doesn't remove the buff when healing
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 3; // Grant a +4 defense boost to the player while the buff is active.
			player.statLifeMax2 += 10;

			if (player.GetModPlayer<PlayerModifications>().lithiumShield == true)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				player.GetModPlayer<PlayerModifications>().lithiumShield = false;
			}
			if (player.setBonus == "" || player.setBonus != "5% increased Melee speed" + "\nGrants the wearer an Electric Shield")
            {
				player.GetModPlayer<PlayerModifications>().lithiumShield = false;
			}
		}
    }
}