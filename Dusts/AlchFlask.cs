using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Dusts
{
	public class AlchFlask : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.6f;
			dust.noGravity = false;
			dust.noLight = false;
			dust.scale *= 1.9f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
			dust.scale *= 0.95f;
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);
			if (dust.scale < 0.3f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}