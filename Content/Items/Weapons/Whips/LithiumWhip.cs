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
    public class LithiumWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lithium Whip");
            Tooltip.SetDefault("Fires a whip that shocks enemies");
            //ItemID.Sets.SummonerWeaponThatScalesWithAttackSpeed[Item.type] = true; fiiix
        }
        public override void SetDefaults()
        {
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 25;
            Item.width = 40;
            Item.height = 36;
            Item.shoot = ProjectileType<LithiumWhipP>();
            Item.UseSound = SoundID.Item152;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.noUseGraphic = true;
            Item.damage = 13;
            Item.knockBack = 3f;
            Item.shootSpeed = 4f;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 32, 50);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<LithiumPlating>(4)
                .AddIngredient<Stardust>(6)
                .AddIngredient<Battery>(1)
                .AddRecipeGroup("IronBar", 2)
                .AddTile(TileID.Anvils)
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
    public class LithiumWhipP : WhipProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lithium Whip");
            //ProjectileID.Sets.IsAWhip[Type] = true;
        }
        public override void WhipDefaults()
        {
            originalColor = new Color(0, 134, 255);
            whipRangeMultiplier = 1.15f; //range, scales up and down from small changes
            fallOff = 0.30f; //lower the number the faster the whip speed
            tag = BuffType<LithiumWhipTag>();
        }
    }
    public class LithiumWhipTag : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shocked");
            Description.SetDefault("Slowed Speed");
            Main.debuff[Type] = false; 
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 5;
        }
    }
}
