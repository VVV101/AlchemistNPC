using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using AlchemistNPC.Items.Weapons;

namespace AlchemistNPC.Projectiles
{
	public class TP : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Projectile");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.NebulaBlaze1);
			Main.projFrames[projectile.type] = 4;
			aiType = ProjectileID.NebulaBlaze1;
			projectile.tileCollide = false;
			projectile.penetrate = 2;
			projectile.timeLeft = 450;
		}
		
		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.NebulaBlaze1;
			return true;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.lifeMax <= 10000)
			{
			damage = 10000;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Twilight"), 600);
			target.immune[projectile.owner] = 1;
		}
	}
}