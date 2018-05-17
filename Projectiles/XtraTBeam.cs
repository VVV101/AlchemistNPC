using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class XtraTBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("XtraT Beam");
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public bool once = false;
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.width = 6;
			projectile.height = 32;
			projectile.penetrate = 999;
			projectile.timeLeft = 120;
			projectile.tileCollide = false;
			aiType = ProjectileID.Bullet;
		}

		public override bool PreAI()
		{
			if (!once)
			{
			Main.PlaySound(SoundID.Item12, projectile.position);
			once = true;
			}
			return true;
		}
		
		public override void AI()
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, mod.DustType("ShroomiteTrail"),
						projectile.velocity.X * .5f, projectile.velocity.Y * .5f, 300, Scale: 1f);
			dust.velocity += projectile.velocity * 0.9f;
			dust.velocity *= 0.9f;
			dust.noGravity = true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
			target.AddBuff(mod.BuffType("Electrocute"), 300);
			if (Main.rand.Next(4) == 0)
			{
			projectile.penetrate--;
			}
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
		}
	
	}
}