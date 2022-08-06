using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using TheOutreach.Content.Projectiles.Enemies;

namespace TheOutreach.Common.GlobalNPCs
{
	public class MasterModeEnemyChanges : GlobalNPC
	{
        static int sludgeTimer = 0;
        public override void SetDefaults(NPC npc)
        {
            if(Main.masterMode == true)
            {
                if (npc.type == NPCID.GiantBat)
                {
                    npc.scale = 2;
                }
                if(npc.type == NPCID.IceGolem)
                {
                    npc.scale = 0.75f;
                }
            }
        }
        public override void AI(NPC npc)
        {
            if (Main.masterMode == true)
            {
                if (npc.type == NPCID.ToxicSludge)
                {
                    sludgeTimer++;
                    if (sludgeTimer >= TheOutreachMod.ToTicks(4))
                    {
                        for (int i = 0; i <= 5; i++)
                        {
                            Projectile proj = Main.projectile[Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center, Vector2.Zero, ModContent.ProjectileType<ToxicSludgeSludge>(), 50, 1)];
                            proj.velocity = new Vector2(4, 0).RotatedByRandom(180);
                        }
                        sludgeTimer = 0;
                    }
                }
                if(npc.type == NPCID.IceGolem)
                {
                    npc.velocity = npc.oldVelocity *= 5;
                }
            }
        }
        public override void OnKill(NPC npc)
        {
            if(Main.masterMode == true)
            {
                
            }
        }
    }
}
