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
			projectile.CloneDefaults(616);
			projectile.timeLeft = 180;
			aiType = 616;
		}
	}
}