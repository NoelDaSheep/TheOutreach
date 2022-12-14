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
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.WorldBuilding;
using TheOutreach.Content.NPCs.DesertUsurper;

namespace TheOutreach.Content.Items.Summons
{
	// This is the item used to summon a boss, in this case the modded Minion Boss from Example Mod. For vanilla boss summons, see comments in SetStaticDefaults
	public class SkeletronSummonItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Necromantic Skull");
			Tooltip.SetDefault("Summons the Guardian of the Dungoen\nCan only be used at Night");
			if(!NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {

            }

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// If this would be for a vanilla boss that has no summon item, you would have to include this line here:
			NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;

			// Otherwise the UseItem code to spawn it will not work in multiplayer
		}
        public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 1;
			Item.value = 100;
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}

		public override bool CanUseItem(Player player) {
			// If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss.
			// If you want more constraints for the summon item, combine them as boolean expressions:
			//    return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<MinionBossBody>()); would mean "not daytime and no MinionBossBody currently alive"
			return !Main.dayTime && !NPC.AnyNPCs(NPCID.SkeletronHead);
		}

		public override bool? UseItem(Player player) 
		{
			if (player.whoAmI == Main.myPlayer) 
			{
				// If the player using the item is the client
				// (explicitely excluded serverside here)
				SoundEngine.PlaySound(SoundID.Roar, player.position);

				int type = NPCID.SkeletronHead;

				if (Main.netMode != NetmodeID.MultiplayerClient) {
					// If the player is not in multiplayer, spawn directly
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else {
					// If the player is in multiplayer, request a spawn
					// This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in MinionBossBody
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}

			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Bone, 10)
				.AddIngredient(ItemID.Silk, 5)
				.AddIngredient(ItemID.Cobweb, 5)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}