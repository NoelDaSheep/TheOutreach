using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Placeable;
using TheOutreach.Content.Items.Accessories;
using Terraria.GameContent.ItemDropRules;
using TheOutreach.Content.Tiles.Furniture.Banners;

namespace TheOutreach.Content.NPCs.Enemies
{
	public class LithiumAutomaton : ModNPC
	{
		private enum ActionState
        {
			Idle,
			NoticeJump,
			Fall,
			Attack
        }

		private enum Frame
        {
			Idle,
			NoticeJump,
			Fall,
			Attack
        }

		public ref float AI_State => ref NPC.ai[0];
		public ref float AI_Timer => ref NPC.ai[1];
		public ref float AI_JumpCool => ref NPC.ai[2];

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lithium Power Core");
			Main.npcFrameCount[NPC.type] = 1;

			NPCID.Sets.DebuffImmunitySets.Add(Type, new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[] {
					BuffID.Electrified, 
					BuffID.Poisoned,
					BuffID.Venom,
					BuffID.Venom
				}
			});
		}

		public override void SetDefaults()
		{
			NPC.width = 30; // The width of the npc's hitbox (in pixels)
			NPC.height = 30; // The height of the npc's hitbox (in pixels)
			NPC.aiStyle = -1; // This npc has a completely unique AI, so we set this to -1. The default aiStyle 0 will face the player, which might conflict with custom AI code.
			NPC.damage = 15; // The amount of damage that this npc deals
			NPC.defense = 4; // The amount of defense that this npc has
			NPC.lifeMax = 75; // The amount of health that this npc has
			NPC.HitSound = SoundID.NPCHit4; // The sound the NPC will make when being hit.
			NPC.DeathSound = SoundID.NPCDeath14; // The sound the NPC will make when it dies.
			NPC.value = Item.buyPrice(silver: 5);
			NPC.knockBackResist = 0.75f;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LithiumAutomatonBanner>();
		}

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
			{
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				new FlavorTextBestiaryInfoElement("An old power core of unknown origin.")
			});
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LithiumOre>(), 2, 2, 4));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Stardust>(), 3, 1, 3));
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LithiumCore>(), 20, 1, 1));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			return SpawnCondition.Cavern.Chance * 1.40f;
        }

        public override void AI()
        {
            switch (AI_State)
            {
				case (float)ActionState.Idle:
					Idle();
					break;
				case (float)ActionState.NoticeJump:
					NoticeJump();
					break;
				case (float)ActionState.Fall:
					if(NPC.velocity.Y == 0)
                    {
						AI_State = (float)ActionState.Attack;
                    }
					break;
				case (float)ActionState.Attack:
					Attack();
					break;
            }

			NPC.TargetClosest(true);
		}

        public override void FindFrame(int frameHeight)
        {
			if(AI_State == (float)ActionState.Attack)
            {
				if(NPC.direction == 1)
                {
					NPC.rotation += 0.1f;
				}
                else
                {
					NPC.rotation -= 0.1f;
				}
			}
        }
        public void Idle()
        {
			NPC.TargetClosest(true);

			if(NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) < 500)
            {
				AI_State = (float)ActionState.NoticeJump;
				AI_Timer = 0;
            }
        }

		public void NoticeJump()
		{
			AI_Timer++;

			if(AI_Timer == 1)
            {
				NPC.velocity.Y = -5f;
            }
			else if (AI_Timer > 20)
            {
				AI_State = (float)ActionState.Attack;
				AI_Timer = 0;
            }
		}

		public void Attack()
		{
			NPC.velocity.X = NPC.direction * 4;
			AI_JumpCool--;
			if (Main.player[NPC.target].position.Y < NPC.position.Y - 16 && NPC.velocity.Y == 0 && AI_JumpCool <= 0)
            {
				AI_Timer = 0;
				AI_Timer++;
            }
			if(AI_Timer == 1)
            {
				NPC.velocity.Y = -7;
				AI_Timer = 0;
				AI_JumpCool = 60;
			}
		}
	}
}
