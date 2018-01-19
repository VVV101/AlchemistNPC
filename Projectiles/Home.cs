using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class Home : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Home");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
			projectile.damage = 30;
			projectile.ranged = true; 
			projectile.timeLeft = 240;
			aiType = ProjectileID.ChlorophyteBullet;
		}
	}
}