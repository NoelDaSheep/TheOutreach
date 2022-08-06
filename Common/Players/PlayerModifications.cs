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
using TheOutreach.Content.Projectiles.Melee;
using TheOutreach.Content.Projectiles.Magic;
using TheOutreach.Content.Projectiles.Ranged;
using TheOutreach.Content.Projectiles.Summoner;
using TheOutreach.Content.Projectiles.Minions;
using TheOutreach.Content.Buffs;

namespace TheOutreach
{
    public class PlayerModifications : ModPlayer
    {
        public bool lithiumShield;
        public bool lithiumGun;
        public bool lithiumMageSet;
        public bool HoldingChloroRod;
        public bool HasLPFED;
        public bool HasLithiumCore;
        public PlayerDrawLayer lithiumshieldtexture;
        public int SlimeDownDash = 20;
        public bool isSlimeDownDash = false;
        public bool hasSlimeDashShoot = false;
        public bool hasEnduraShroom = false;
        public int enduraShroomDamage = 0;
        public int enduraShroomDefense = 0;
        public bool hasLifeLeaf = false;
        public bool hasAmethystAmulet = false;

        public bool hasFrozenClumpStill = false;
        public int frozenClumpTimer = 0;

        public bool hasRudeHat = false;
        public override void UpdateDead()
        {
            lithiumGun = false;
            lithiumMageSet = false;
            HasLPFED = false;
            HasLithiumCore = false;
            hasRudeHat = false;
        }
        public override void ResetEffects()
        {
            Player.tileSpeed += 5;
            Player.wallSpeed += 5;
            HoldingChloroRod = false;
            lithiumGun = false;
            lithiumMageSet = false;
            HasLPFED = false;
            HasLithiumCore = false;
            SlimeDownDash--;
            hasSlimeDashShoot = false;
            hasEnduraShroom = false;
            hasLifeLeaf = false;
            hasAmethystAmulet = false;
            hasFrozenClumpStill = false;
        }
        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
        {
            if (hasAmethystAmulet && proj.DamageType == DamageClass.Magic)
            {
                if (Main.rand.NextBool(1, 2))
                {
                    target.AddBuff(ModContent.BuffType<AmethystFlames>(), 300);
                }
            }
            if (hasEnduraShroom)
            {
                enduraShroomDamage += damage;
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (hasAmethystAmulet && proj.DamageType == DamageClass.Magic && proj.type != ProjectileID.AmethystBolt)
            {
                if(Main.rand.NextBool(1, 2))
                {
                    target.AddBuff(ModContent.BuffType<AmethystFlames>(), 300);
                    int projec = Projectile.NewProjectile(Player.GetSource_Misc("none"), proj.position, proj.velocity, ProjectileID.AmethystBolt, 15, 6, proj.owner);
                    Projectile proje = Main.projectile[projec];
                    proje.penetrate = 3;
                    proje.usesLocalNPCImmunity = true;
                }
            }
            if (hasEnduraShroom)
            {
                enduraShroomDamage += damage;
            }
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (hasEnduraShroom)
            {
                enduraShroomDamage += damage;
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            Player player = Main.LocalPlayer;
            if (hasLifeLeaf)
            {
                if(Main.rand.NextBool(1, 10))
                {
                    int sting1 = Projectile.NewProjectile(Player.GetSource_Misc("none"), player.position, Vector2.UnitX * 13, ModContent.ProjectileType<VerdureStinger>(), 15, 0, player.whoAmI);
                    int sting2 = Projectile.NewProjectile(Player.GetSource_Misc("none"), player.position, -Vector2.UnitX * 13, ModContent.ProjectileType<VerdureStinger>(), 15, 0, player.whoAmI);
                    int sting3 = Projectile.NewProjectile(Player.GetSource_Misc("none"), player.position, Vector2.UnitY * 13, ModContent.ProjectileType<VerdureStinger>(), 15, 0, player.whoAmI);
                    int sting4 = Projectile.NewProjectile(Player.GetSource_Misc("none"), player.position, -Vector2.UnitY * 13, ModContent.ProjectileType<VerdureStinger>(), 15, 0, player.whoAmI);
                    Projectile sting11 = Main.projectile[sting1];
                    Projectile sting22 = Main.projectile[sting2];
                    Projectile sting33 = Main.projectile[sting3];
                    Projectile sting44 = Main.projectile[sting4];
                    sting11.damage = 10;
                    sting11.CountsAsClass(DamageClass.Default);
                    sting22.damage = 10;
                    sting22.CountsAsClass(DamageClass.Default);
                    sting33.damage = 10;
                    sting33.CountsAsClass(DamageClass.Default);
                    sting44.damage = 10;
                    sting44.CountsAsClass(DamageClass.Default);
                }
            }
            if (hasEnduraShroom)
            {
                if (enduraShroomDefense > 0)
                {
                    Main.combatText[CombatText.NewText(Player.getRect(), Color.Red, "Streak Lost!")].lifeTime = 120;
                }
                enduraShroomDamage = 0;
                enduraShroomDefense = 0;
            }
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            Player player = Main.LocalPlayer;

            if (hasRudeHat && Main.rand.NextBool(3) && damage < player.statLife)
            {
                int hitMessage = Main.rand.Next(5);
                switch (hitMessage)
                {
                    case 0:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "How did you get hit by that.")].lifeTime = 120;
                        break;
                    case 1:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Just dodge.")].lifeTime = 120;
                        break;
                    case 2:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Ow!")].lifeTime = 120;
                        break;
                    case 3:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Why cant you just not get hit")].lifeTime = 120;
                        break;
                    case 4:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Ouchie!")].lifeTime = 120;
                        break;
                }
            }
            return true;
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            //reuse later
            /*if (HasLithiumCore)
            {
                return Main.rand.NextFloat() >= 0.10f;
            }*/
            return true;
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (HoldingChloroRod == true && Main.rand.NextBool(1, 10) && Player.ZoneJungle && !attempt.inHoney && !attempt.inLava)
            {
                itemDrop = ItemID.ChlorophyteOre;
            }
        }
        public override void ModifyCaughtFish(Item fish)
        {
            if (fish.type == ItemID.ChlorophyteOre)
            {
                fish.stack = Main.rand.Next(5, 10);
            }
            if(HasLPFED && Main.rand.NextBool(1, 7) && fish.type != ItemID.CorruptFishingCrate && fish.type != ItemID.CorruptFishingCrateHard && fish.type != ItemID.CrimsonFishingCrate && fish.type != ItemID.CrimsonFishingCrateHard && fish.type != ItemID.DungeonFishingCrate && fish.type != ItemID.DungeonFishingCrateHard && fish.type != ItemID.FloatingIslandFishingCrate && fish.type != ItemID.FloatingIslandFishingCrateHard && fish.type != ItemID.FrozenCrate && fish.type != ItemID.FrozenCrateHard && fish.type != ItemID.GoldenCrate && fish.type != ItemID.GoldenCrateHard && fish.type != ItemID.HallowedFishingCrate && fish.type != ItemID.HallowedFishingCrateHard && fish.type != ItemID.IronCrate && fish.type != ItemID.IronCrateHard && fish.type != ItemID.JungleFishingCrate && fish.type != ItemID.JungleFishingCrateHard && fish.type != ItemID.LavaCrateHard && fish.type != ItemID.OasisCrate && fish.type != ItemID.OasisCrateHard && fish.type != ItemID.OceanCrate && fish.type != ItemID.OceanCrateHard && fish.type != ItemID.WoodenCrate && fish.type != ItemID.WoodenCrateHard && fish.rare != ItemRarityID.Quest)
            {
                fish.stack += 1;
            }
        }
        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Player player = Main.LocalPlayer;
            if (lithiumMageSet && item.DamageType == DamageClass.Magic)
            {
                
                return true;
            }
            return true;
        }
        public override void PreUpdate()
        {
            Player player = Main.LocalPlayer;
            if (hasFrozenClumpStill)
            {
                frozenClumpTimer++;
                if(frozenClumpTimer >= TheOutreachMod.ToTicks(4))
                {
                    for(int i = 0; i <= 5; i++)
                    {
                        Projectile proj = Main.projectile[Projectile.NewProjectile(player.GetSource_Misc(""), player.Center, Vector2.Zero, ProjectileID.IceSpike, 15, 1)];
                        proj.friendly = true;
                        proj.hostile = false;
                        proj.owner = Player.whoAmI;
                        proj.DamageType = DamageClass.Default;
                        proj.velocity = new Vector2(8, 0).RotatedByRandom(180);
                    }
                    frozenClumpTimer = 0;
                }
            }
            if (hasEnduraShroom && enduraShroomDefense <= 10)
            {
                if(enduraShroomDamage >= 50)
                {
                    enduraShroomDefense = 1;
                }
                if (enduraShroomDamage >= 100)
                {
                    enduraShroomDefense = 2;
                }
                if (enduraShroomDamage >= 150)
                {
                    enduraShroomDefense = 3;
                }
                if (enduraShroomDamage >= 200)
                {
                    enduraShroomDefense = 4;
                }
                if (enduraShroomDamage >= 250)
                {
                    enduraShroomDefense = 5;
                }
                if (enduraShroomDamage >= 300)
                {
                    enduraShroomDefense = 6;
                }
                if (enduraShroomDamage >= 350)
                {
                    enduraShroomDefense = 7;
                }
                if (enduraShroomDamage >= 400)
                {
                    enduraShroomDefense = 8;
                }
                if (enduraShroomDamage >= 450)
                {
                    enduraShroomDefense = 9;
                }
                if(enduraShroomDamage >= 500)
                {
                    enduraShroomDefense = 10;
                }
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Player player = Main.LocalPlayer;

            if (hasRudeHat)
            {
                int hitMessage = Main.rand.Next(5);
                switch (hitMessage)
                {
                    case 0:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Wow you suck.")].lifeTime = 120;
                        break;
                    case 1:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Even I could have survived that")].lifeTime = 120;
                        break;
                    case 2:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "How did that even hit you.")].lifeTime = 120;
                        break;
                    case 3:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Come on it was only " + damage + " damage.")].lifeTime = 120;
                        break;
                    case 4:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "If you had dodged this wouldn't have happened")].lifeTime = 120;
                        break;
                }

            }
        }
        public override void OnEnterWorld(Player player)
        {
            if (hasRudeHat)
            {
                int joinMessage = Main.rand.Next(4);
                switch (joinMessage)
                {
                    case 0:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Well here we are again.")].lifeTime = 120;
                        break;
                    case 1:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "Greeting adventurer!")].lifeTime = 120;
                        break;
                    case 2:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "I liked purgatory")].lifeTime = 120;
                        break;
                    case 3:
                        Main.combatText[CombatText.NewText(player.getRect(), Color.Purple, "How did we get here")].lifeTime = 120;
                        break;
                }

            }
        }
    }
}
