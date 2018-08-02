using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class DriedFishBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dried Fish Bubble");     //The English name of the projectile
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(405);
			projectile.tileCollide = false;
			projectile.aiStyle = 70;
			aiType = 405;           //Act exactly like default Bullet
		}
	}
}
