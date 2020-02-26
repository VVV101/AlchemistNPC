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
	public class ShadowBurst : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.extraUpdates = 3;
			projectile.timeLeft = 30;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Burst");

		}

		public override void AI()
		{
			Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
			if (projectile.timeLeft > 75)
			{
				projectile.timeLeft = 75;
			}
			if (projectile.ai[0] > 1f)
			{
				float num302 = 1f;
				if (projectile.ai[0] == 8f)
				{
					num302 = 0.25f;
				}
				else if (projectile.ai[0] == 9f)
				{
					num302 = 0.5f;
				}
				else if (projectile.ai[0] == 10f)
				{
					num302 = 0.75f;
				}
				projectile.ai[0] += 1f;
				int num303 = 86;
				if (projectile.ai[1] == 0f) num303 = 72; //pink
				if (projectile.ai[1] == 1f) num303 = 109; //black
				if (projectile.ai[1] == 2f) num303 = 90; //red
				if (projectile.ai[1] == 3f) num303 = 169; //yellow
				if (projectile.ai[1] == 4f) num303 = 88; //blue
				if (Main.rand.Next(2) == 0)
				{
					int num3;
					for (int num304 = 0; num304 < 1; num304 = num3 + 1)
					{
						int num305 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num303, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
						Dust dust;
						if (Main.rand.Next(3) != 0 || (Main.rand.Next(3) == 0))
						{
							Main.dust[num305].noGravity = true;
							dust = Main.dust[num305];
							dust.scale *= 2.5f;
							Dust var_2_E189_cp_0_cp_0 = Main.dust[num305];
							var_2_E189_cp_0_cp_0.velocity.X = var_2_E189_cp_0_cp_0.velocity.X * 2f;
							Dust var_2_E1AA_cp_0_cp_0 = Main.dust[num305];
							var_2_E1AA_cp_0_cp_0.velocity.Y = var_2_E1AA_cp_0_cp_0.velocity.Y * 2f;
						}
						if (projectile.type == 188)
						{
							dust = Main.dust[num305];
							dust.scale *= 1.25f;
						}
						else
						{
							dust = Main.dust[num305];
							dust.scale *= 1.5f;
						}
						Dust var_2_E21E_cp_0_cp_0 = Main.dust[num305];
						var_2_E21E_cp_0_cp_0.velocity.X = var_2_E21E_cp_0_cp_0.velocity.X * 1.2f;
						Dust var_2_E23F_cp_0_cp_0 = Main.dust[num305];
						var_2_E23F_cp_0_cp_0.velocity.Y = var_2_E23F_cp_0_cp_0.velocity.Y * 1.2f;
						dust = Main.dust[num305];
						dust.scale *= num302;
						if (num303 == 86)
						{
							dust = Main.dust[num305];
							dust.velocity += projectile.velocity;
							if (!Main.dust[num305].noGravity)
							{
								dust = Main.dust[num305];
								dust.velocity *= 0.5f;
							}
						}
						num3 = num304;
					}
				}
			}
			else
			{
				projectile.ai[0] += 1f;
			}
			projectile.rotation += 0.3f * (float)projectile.direction;
		}
	}
}
