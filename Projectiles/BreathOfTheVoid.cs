using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace AlchemistNPC.Projectiles
{
    public class BreathOfTheVoid : ModProjectile
    {
		public int counter = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Breath of the Void");
        }

        public override void SetDefaults()
        {
            projectile.width = 118;
            projectile.height = 118;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			
			float num = 1.57079637f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.ai[0] += 1f;
			int num2 = 0;
			if (projectile.ai[0] >= 30f)
			{
				num2++;
			}
			if (projectile.ai[0] >= 60f)
			{
				num2++;
			}
			if (projectile.ai[0] >= 90f)
			{
				num2++;
			}
			int num3 = 24;
			int num4 = 6;
			projectile.ai[1] += 1f;
			bool flag = false;
			if (projectile.ai[1] >= (float)(num3 - num4 * num2))
			{
				projectile.ai[1] = 0f;
				flag = true;
			}
			if (projectile.ai[1] == 1f && projectile.ai[0] != 1f)
			{
				Vector2 vector2 = Vector2.UnitX * 24f;
				vector2 = vector2.RotatedBy((double)(projectile.rotation - 1.57079637f), default(Vector2));
				Vector2 value = projectile.Center + vector2;
			}
			if (flag && Main.myPlayer == projectile.owner)
			{
				if (player.channel && !player.noItems && !player.CCed)
				{
					float scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;
					Vector2 vector3 = vector;
					Vector2 value2 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY) - vector3;
					if (player.gravDir == -1f)
					{
						value2.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - vector3.Y;
					}
					Vector2 vector4 = Vector2.Normalize(value2);
					if (float.IsNaN(vector4.X) || float.IsNaN(vector4.Y))
					{
						vector4 = -Vector2.UnitY;
					}
					vector4 *= scaleFactor;
					if (vector4.X != projectile.velocity.X || vector4.Y != projectile.velocity.Y)
					{
						
					}
					projectile.velocity = vector4;
					float scaleFactor2 = 14f;
					int num7 = 7;
				
					vector3 = projectile.Center + new Vector2((float)Main.rand.Next(-num7, num7 + 1), (float)Main.rand.Next(-num7, num7 + 1));
					Vector2 vector5 = Vector2.Normalize(projectile.velocity) * scaleFactor2;
					vector5 = vector5.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
					if (float.IsNaN(vector5.X) || float.IsNaN(vector5.Y))
					{
						vector5 = -Vector2.UnitY;
					}
				}
			}
			projectile.netUpdate = true;
			if (player.direction == 1)
			{
				projectile.spriteDirection = 1;
				projectile.position.X = player.position.X - 160;
				
			}
			if (player.direction == -1)
			{
				projectile.spriteDirection = -1;
				projectile.position.X = player.position.X + 90;
			}
			
			projectile.position.Y = player.position.Y - 120;
			projectile.rotation = projectile.velocity.ToRotation() + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
            if (!player.channel)
			{
				projectile.Kill();
			}
			counter++;
			if (projectile.owner == Main.myPlayer && counter == 5)
            {
				counter = 0;
				float num10 = 12f;
				Vector2 vector8 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float f1 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
				float f2 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
				if ((double)player.gravDir == -1.0)
					f2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector8.Y;
				float num8 = (float)Math.Sqrt((double)f1 * (double)f1 + (double)f2 * (double)f2);
				float num9;
				if (float.IsNaN(f1) && float.IsNaN(f2) || (double)f1 == 0.0 && (double)f2 == 0.0)
				{
					f1 = (float)player.direction;
					f2 = 0.0f;
					num9 = num10;
				}
				else
					num9 = num10 / num8;
				float SpeedX = f1 * num9;
				float SpeedY = f2 * num9;
				Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 34);
				int numberProjectiles = 3;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(vector8.X, vector8.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("Void"), projectile.damage, projectile.knockBack, player.whoAmI);
				}
				int numberProjectiles1 = 6;
				for (int i = 0; i < numberProjectiles1; i++)
				{
					Vector2 perturbedSpeed1 = new Vector2(SpeedX, SpeedY).RotatedByRandom(MathHelper.ToRadians(5));
					Projectile.NewProjectile(vector8.X, vector8.Y, perturbedSpeed1.X, perturbedSpeed1.Y, mod.ProjectileType("VoidDummy"), projectile.damage, projectile.knockBack, player.whoAmI);
				}
			}
        }
    }
}
