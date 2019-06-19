using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace AlchemistNPC.Projectiles
{
	public class StormbreakerSwing : ModProjectile
	{
		public int counter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker's Swing");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(707);
			projectile.width = 50;
			projectile.height = 40;
			projectile.aiStyle = 140;
			aiType = 707;
			projectile.scale = 1.5f;
			projectile.usesLocalNPCImmunity = true;
		}
		
		public override void AI()
		{
			counter++;
		}
		
		public override void Kill(int timeLeft)
		{
			if (counter >= 30)
			{
			Player player = Main.player[projectile.owner];
			Vector2 vector82 =  -Main.player[Main.myPlayer].Center + Main.MouseWorld;
            float ai = Main.rand.Next(100);
            Vector2 vector83 = Vector2.Normalize(vector82) * 12f;
            int n1 = Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, 580, projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			int n2 = Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X+10, vector83.Y+10, 580, projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			int n3 = Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X-10, vector83.Y-10, 580, projectile.damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			Main.projectile[n1].usesLocalNPCImmunity = true;
			Main.projectile[n2].usesLocalNPCImmunity = true;
			Main.projectile[n3].usesLocalNPCImmunity = true;
			counter = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			target.AddBuff(mod.BuffType("Electrocute"), 300);
		}
	}
}
