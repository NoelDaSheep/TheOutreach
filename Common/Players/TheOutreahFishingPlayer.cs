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

namespace TheOutreach
{
	public class TheOutreachFishingPlayer : ModPlayer
	{
		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			// In this example, we will fish up an Example Person from the water in Example Surface Biome,
			// as long as there isn't one in the world yet
			// NOTE: if a fishing rod has multiple bobbers, then each one can spawn the NPC
			if (!attempt.inLava && !attempt.inHoney && Main.rand.NextBool(1, 10) && Player.ZoneCorrupt && NPC.downedBoss2)
			{
				itemDrop = ModContent.ItemType<VileEel>();
			}

			if (!attempt.inLava && !attempt.inHoney && Main.rand.NextBool(1, 10) && Player.ZoneCrimson && NPC.downedBoss2)
			{
				itemDrop = ModContent.ItemType<CarrionJelly>();
			}

			/*if (!attempt.inLava && !attempt.inHoney && Main.rand.NextBool(1, 10) && Player.ZoneDirtLayerHeight && WorldGen.quest)
			{
				itemDrop = ModContent.ItemType<LithiumOctosquid>();
			}*/
		}

		// If fishing with ladybug, we will receive multiple "fish" per bobber. Does not apply to quest fish
		public override void ModifyCaughtFish(Item fish)
		{
			// In this example, we make sure that we got a Ladybug as bait, and later on use that to determine what we catch
			/*if (Player.GetFishingConditions().BaitItemType == ItemID.LadyBug && fish.rare != ItemRarityID.Quest)
			{
				fish.stack += Main.rand.Next(1, 4);
			}*/
		}
	}
}
