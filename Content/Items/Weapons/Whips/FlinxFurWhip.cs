using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TheOutreach.Content.Items.Materials;

namespace TheOutreach.Content.Items.Weapons.Whips
{
    public class FlinxFurWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flinx Fur Whip");
            Tooltip.SetDefault("Inflicts Frostburn\n'Flinx fur is surprisingly strong when frozen properly'");
            //ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Item.type] = true; fiiix
        }
        public override void SetDefaults()
        {
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 25;
            Item.width = 18;
            Item.height = 18;
            Item.shoot = ProjectileType<FlinxFurWhipP>();
            Item.UseSound = SoundID.Item152;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.noUseGraphic = true;
            Item.damage = 17;
            Item.knockBack = 3f;
            Item.shootSpeed = 4f;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 0, 50, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlinxFur, 6)
                .AddRecipeGroup("TheOutreach:GoldBar", 10)
                .AddTile(TileID.WorkBenches)
            .Register();
        }

        public override bool? CanAutoReuseItem(Player player)
        {
            if (player.autoReuseGlove)
                return true;
            else
                return false;
        }
    }
    public class FlinxFurWhipP : WhipProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flinx Fur Whip");
            //ProjectileID.Sets.IsAWhip[Type] = true;
        }
        public override void WhipDefaults()
        {
            originalColor = new Color(0, 134, 255);
            whipRangeMultiplier = 1.30f; //range, scales up and down from small changes
            fallOff = 0.20f; //lower the number the faster the whip speed
            tag = BuffID.Frostburn;
        }
    }
    /*public class FlinxFurWhipTag : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TBD");
            Description.SetDefault("TBD");
            Main.debuff[Type] = false; 
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
        }
    }*/
}
