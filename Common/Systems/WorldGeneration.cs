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
using Terraria.WorldBuilding;
using TheOutreach.Content.Tiles;
using Terraria.IO;

namespace TheOutreach.Common.Systems
{
	public class testsystem : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Dungeon"));

			if (ShiniesIndex != -1)
			{
				// Next, we insert our pass directly after the original "Shinies" pass.
				// ExampleOrePass is a class seen bellow
				tasks.Insert(ShiniesIndex + 1, new testnamething("thingy", 237.4298f));
			}
		}
	}
	public class testnamething : GenPass
	{
		public testnamething(string name, float loadWeight) : base(name, loadWeight)
		{
		}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			// progress.Message is the message shown to the user while the following code is running.
			// Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes.
			progress.Message = "TEST";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
			{
				WorldGen.PlaceTile(WorldGen.dungeonX * 16, WorldGen.dungeonY * 16, TileID.SolarBrick);
			}
		}
	}
}

