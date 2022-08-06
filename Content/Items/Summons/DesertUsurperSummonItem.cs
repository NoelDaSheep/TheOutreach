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
using TheOutreach.Content.NPCs.DesertUsurper;
using TheOutreach.Content.Projectiles.DesertUsurper;

namespace TheOutreach.Content.Items.Summons
{
	// This is the item used to summon a boss, in this case the modded Minion Boss from Example Mod. For vanilla boss summons, see comments in SetStaticDefaults
	public class DesertUsurperSummonItem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Electrostatic Plumage");
			Tooltip.SetDefault("Summons the Desert Usurper\nCan only be used in Daylight");


			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			ItemID.Sets.SortingPriorityBossSpawns[Type] = 12; // This helps sort inventory know that this is a boss summoning Item.

			// If this would be for a vanilla boss that has no summon item, you would have to include this line here:
			// NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;

			// Otherwise the UseItem code to spawn it will not work in multiplayer
		}

		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = 100;
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Projectile.NewProjectile(source, position, new Vector2(0,0), type, 0, 0);
            return false;
        }
        public override bool CanUseItem(Player player) {
			// If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss.
			// If you want more constraints for the summon item, combine them as boolean expressions:
			//    return !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<MinionBossBody>()); would mean "not daytime and no MinionBossBody currently alive"
			return player.ZoneDesert && Main.dayTime && !Main.eclipse && !NPC.AnyNPCs(ModContent.NPCType<NPCs.DesertUsurper.DesertUsurper>()) && player.ownedProjectileCounts[ModContent.ProjectileType<UsurperSpawnEffect>()] < 1;
		}

		public override bool? UseItem(Player player) 
		{
			//Projectile.NewProjectile(player.GetProjectileSource_Item(Item), Main.LocalPlayer.Center.X, Main.LocalPlayer.Center.Y, 0, 0, ModContent.ProjectileType<UsurperSpawnEffect>(), 0, 0, player.whoAmI);
			
			Vector2 thePos = new Vector2(Main.LocalPlayer.position.X, Main.LocalPlayer.position.Y - 200);
			/*int timer = 0;
			timer++;
			if (timer < 180)
            {
				if(Utils.NextBool(Main.rand, 4))
                {
					Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
					Dust d2 = Dust.NewDustPerfect(thePos, DustID.Electric, speed2 * 5, Scale: 1f);
					d2.noGravity = true;
				}
			}*/
			//if(timer > 180)
           // {
				for (int i = 0; i < 200; i++)
				{
					if (Utils.NextBool(Main.rand, 4))
					{
						Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
						Dust d2 = Dust.NewDustPerfect(thePos, DustID.Electric, speed2 * 5, Scale: 1f);
						d2.noGravity = true;
					}
					if (Utils.NextBool(Main.rand, 4))
					{
						Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
						Dust d2 = Dust.NewDustPerfect(thePos, DustID.Electric, speed2 * 7, Scale: 1f);
						d2.noGravity = true;
					}
					if (Utils.NextBool(Main.rand, 4))
					{
						Vector2 speed2 = Main.rand.NextVector2CircularEdge(0.50f, 0.50f);
						Dust d2 = Dust.NewDustPerfect(thePos, DustID.Electric, speed2 * 10, Scale: 1f);
						d2.noGravity = true;
					}
				}
				Main.NewText(Language.GetTextValue("Announcement.HasAwoken", "The Desert Usurper"), new Color(175, 75, 255));
				NPC.NewNPC(NPC.GetSource_None(), (int)thePos.X, (int)thePos.Y, ModContent.NPCType<NPCs.DesertUsurper.DesertUsurper>(), 0);

			//}
			return true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() 
		{
			CreateRecipe()
				.AddIngredient(ItemID.AntlionMandible, 7)
				.AddIngredient(ItemID.Bone, 20)
				.AddRecipeGroup("TheOutreach:EvilMaterial", 15)
				.AddTile(TileID.DemonAltar)
				.Register();

		}
	}
}