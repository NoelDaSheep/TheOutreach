using System; //what sources the code uses, these sources allow for calling of terraria functions, existing system functions and microsoft vector functions (probably more)
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheOutreach.Content.Projectiles.Magic
{
    public class StarShowerStar : ModProjectile //the class of the projectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starshower Star");     //The English name of the projectile
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Starfury);

            Projectile.DamageType = DamageClass.Magic; //magic projectile
            Projectile.usesLocalNPCImmunity = true;

            AIType = ProjectileID.Starfury;
        }

        public override bool PreKill(int timeLeft)
        {
            Projectile.type = ProjectileID.Starfury;
            return true;
        }
    }
}