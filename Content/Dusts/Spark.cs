using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace TheOutreach.Content.Dusts
{
	public class Spark : ModDust
	{
		public override void OnSpawn(Dust dust) {
			//dust.velocity *= 0.4f; // Multiply the dust's start velocity by 0.4, slowing it down
			dust.noGravity = true; // Makes the dust have no gravity.
			dust.noLight = true; // Makes the dust emit no light.
			// If our texture had 3 different dust on top of each other (a 30x90 pixel image), we might do this:
			dust.frame = new Rectangle(0, Main.rand.Next(3) * 12, 12, 12);
		}

		public override bool Update(Dust dust) { // Calls every frame the dust is active
			//dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.95f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, Color.CornflowerBlue.ToVector3() * 0.78f);
			if (dust.scale < 0.5f) {
				dust.active = false;
			}
			return false; // Return false to prevent vanilla behavior.
		}
	}
}
