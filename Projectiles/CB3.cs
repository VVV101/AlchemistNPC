using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemistNPC.Projectiles
{
    public class CB3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("CB3");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.ignoreWater = true;
            projectile.extraUpdates = 2;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 150;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type == mod.NPCType("BillCipher"))
			{
			damage /= 150;
			}
		}

        public override void AI()
        {
            projectile.rotation =
					projectile.velocity.ToRotation() +
					MathHelper.ToRadians(
						90f);
        }
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.DD2_ExplosiveTrapExplode, projectile.position);
			for (int index1 = 0; index1 < 20; ++index1)
			{
				int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 29, 0.0f, 0.0f, 100, new Color(), 1f);
				Main.dust[index2].velocity *= 1.1f;
				Main.dust[index2].scale *= 0.99f;
			}
		}
    }
}
