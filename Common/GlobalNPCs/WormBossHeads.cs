using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheOutreach.Common.Configs;

namespace TheOutreach.Common.GlobalNPCs
{
    [AutoloadBossHead]
	public class WormBossHeads : GlobalNPC
	{

        public static int secondStageHeadSlot = -1;
        public static int secondStageHeadSlot2 = -1;
        public static int secondStageHeadSlot3 = -1;

        public static int secondStageHeadSlot4 = -1;
        public static int secondStageHeadSlot5 = -1;
        public static int secondStageHeadSlot6 = -1;

        public static int HallowedMimicHeadSlot = -1;

        public static int CorruptMimicHeadSlot = -1;

        public static int CrimsonMimicHeadSlot = -1;

        public static int DreadnautilisBossHeadSlot = -1;

        public static int MothronBossHeadSlot = -1;

        public static int GoblinSummonerBossHeadSlot = -1;

        public static int IceGolemBossHeadSlot = -1;

        public override bool InstancePerEntity => true;
        public override void Load()
        {
            string texture = "TheOutreach/Assets/Textures/NewEoWHead"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1); // -1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
            string texture2 = "TheOutreach/Assets/Textures/NewEoWBody"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot2 = Mod.AddBossHeadTexture(texture2, -1);
            string texture3 = "TheOutreach/Assets/Textures/NewEoWTail"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot3 = Mod.AddBossHeadTexture(texture3, -1);

            string texture4 = "TheOutreach/Assets/Textures/NewDestroyerHead";
            secondStageHeadSlot4 = Mod.AddBossHeadTexture(texture4, -1);
            string texture5 = "TheOutreach/Assets/Textures/NewDestroyerBody";
            secondStageHeadSlot5 = Mod.AddBossHeadTexture(texture5, -1);
            string texture6 = "TheOutreach/Assets/Textures/NewDestroyerTail";
            secondStageHeadSlot6 = Mod.AddBossHeadTexture(texture6, -1);

            string HallowedMimicHead = "TheOutreach/Assets/Textures/HallowedMimicBossHead";
            HallowedMimicHeadSlot = Mod.AddBossHeadTexture(HallowedMimicHead, -1);

            string CorruptMimicHead = "TheOutreach/Assets/Textures/CorruptMimicBossHead";
            CorruptMimicHeadSlot = Mod.AddBossHeadTexture(CorruptMimicHead, -1);

            string CrimsonMimicHead = "TheOutreach/Assets/Textures/CrimsonMimicBossHead";
            CrimsonMimicHeadSlot = Mod.AddBossHeadTexture(CrimsonMimicHead, -1);
            
            string DreadnautilisBossHead = "TheOutreach/Assets/Textures/DreadnautilisBossHead";
            DreadnautilisBossHeadSlot = Mod.AddBossHeadTexture(DreadnautilisBossHead, -1);

            string MothronBossHead = "TheOutreach/Assets/Textures/MothronBossHead";
            MothronBossHeadSlot = Mod.AddBossHeadTexture(MothronBossHead, -1);

            string GoblinSummonerBossHead = "TheOutreach/Assets/Textures/GoblinSummonerBossHead";
            GoblinSummonerBossHeadSlot = Mod.AddBossHeadTexture(GoblinSummonerBossHead, -1);
            string IceGolemBossHead = "TheOutreach/Assets/Textures/IceGolemBossHead";
            IceGolemBossHeadSlot = Mod.AddBossHeadTexture(IceGolemBossHead, -1);
        }
        public override void BossHeadSlot(NPC npc, ref int index)
        {
            if (ModContent.GetInstance<TheOutreachConfigs>().BossHeadChanges == true)
            {
                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    int slot = secondStageHeadSlot;
                    index = slot;
                }

                if (npc.type == NPCID.EaterofWorldsBody)
                {
                    int slot = secondStageHeadSlot2;
                    index = slot;
                }

                if (npc.type == NPCID.EaterofWorldsTail)
                {
                    int slot = secondStageHeadSlot3;
                    index = slot;
                }

                if (npc.type == NPCID.TheDestroyer)
                {
                    int slot = secondStageHeadSlot4;
                    index = slot;
                }
                if (npc.type == NPCID.TheDestroyerBody)
                {
                    int slot = secondStageHeadSlot5;
                    index = slot;
                }
                if (npc.type == NPCID.TheDestroyerTail)
                {
                    int slot = secondStageHeadSlot6;
                    index = slot;
                }
            }
            if (ModContent.GetInstance<TheOutreachConfigs>().ExtraMapIcons == true)
            {

                if (npc.type == NPCID.BigMimicHallow)
                {
                    int slot = HallowedMimicHeadSlot;
                    index = slot;
                }
                if (npc.type == NPCID.BigMimicCorruption)
                {
                    int slot = CorruptMimicHeadSlot;
                    index = slot;
                }
                if (npc.type == NPCID.BigMimicCrimson)
                {
                    int slot = CrimsonMimicHeadSlot;
                    index = slot;
                }
                if (npc.type == NPCID.BloodNautilus)
                {
                    int slot = DreadnautilisBossHeadSlot;
                    index = slot;
                } 
                if (npc.type == NPCID.Mothron)
                {
                    int slot = MothronBossHeadSlot;
                    index = slot;
                }
                if (npc.type == NPCID.GoblinSummoner)
                {
                    int slot = GoblinSummonerBossHeadSlot;
                    index = slot;
                }
                if (npc.type == NPCID.IceGolem)
                {
                    int slot = IceGolemBossHeadSlot;
                    index = slot;
                }
            }
        }
        public override void BossHeadRotation(NPC npc, ref float rotation)
        {
            if (ModContent.GetInstance<TheOutreachConfigs>().BossHeadChanges == true)
            {
                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    rotation = npc.rotation;
                }
                if (npc.type == NPCID.EaterofWorldsBody)
                {
                    rotation = npc.rotation;
                }
                if (npc.type == NPCID.EaterofWorldsTail)
                {
                    rotation = npc.rotation;
                }


                if (npc.type == NPCID.TheDestroyer)
                {
                    rotation = npc.rotation;
                }
                if (npc.type == NPCID.TheDestroyerBody)
                {
                    rotation = npc.rotation;
                }
                if (npc.type == NPCID.TheDestroyerTail)
                {
                    rotation = npc.rotation;
                }
                if (npc.type == NPCID.BloodNautilus)
                {
                    rotation = npc.rotation;
                }
            }
        }
    }
}
