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

namespace TheOutreach
{
	public class TheOutreachMod : Mod
	{
		public static ModKeybind WeaponSpecialKeybind;

		public override void Load()
		{
			WeaponSpecialKeybind = KeybindLoader.RegisterKeybind(this, "Weapons Specials", "C");
		}

		public override void Unload()
		{
			WeaponSpecialKeybind = null;
		}

		public static int ToTicks(int seconds)
        {
			return seconds *= 60;
        }
	}
}