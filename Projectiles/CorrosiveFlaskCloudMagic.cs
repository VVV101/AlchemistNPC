using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.UI;

namespace AlchemistNPC.Projectiles
{
	public class CorrosiveFlaskCloudMagic : ModProjectile
	{
        public override void SetDefaults()
        {
            projectile.damage = 250;
			projectile.width = 32;
            projectile.height = 32;
            projectile.penetrate = 12;
            projectile.aiStyle = 92;
            aiType = 511;
            projectile.friendly = true;
            projectile.timeLeft = 600;
			projectile.magic = true;
			projectile.thrown = false;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(mod.BuffType("Corrosion"), 300);
				target.immune[projectile.owner] = 3;
			}
    }
}