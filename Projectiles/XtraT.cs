using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class XtraT : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("XraT Electric Beam");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(435);
			projectile.aiStyle = 1;
			aiType = 435;
			projectile.hostile = false;
			projectile.friendly = true;
		}
		
		public override bool PreKill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item12.WithVolume(.5f), projectile.position);
			return base.PreKill(timeLeft);
		}
		
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Electrocute"), 300);
			target.immune[projectile.owner] = 1;
		}
	}
}
