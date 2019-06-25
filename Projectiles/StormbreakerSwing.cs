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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stormbreaker's Swing");
		}

        public override void SetDefaults()
        {
            projectile.width = 110;
            projectile.height = 94;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 8;
        }

        public override void AI()
        {
            projectile.ai[0]++;
            //-------------------------------------------------------------Sound-------------------------------------------------------
            projectile.soundDelay--;
            if (projectile.soundDelay <= 0)//this is the proper sound delay for this type of weapon
            {
                Main.PlaySound(SoundID.Item1);    //this is the sound when the weapon is used
                projectile.soundDelay = 45;    //this is the proper sound delay for this type of weapon
            }
            //-----------------------------------------------How the projectile works---------------------------------------------------------------------
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer == projectile.owner)
            {
                if (!player.channel || player.noItems || player.CCed)
                {
                    projectile.Kill();
                }
            }
            projectile.Center = player.MountedCenter;
            projectile.position.X += player.width / 2 * player.direction;
            projectile.spriteDirection = player.direction;
            projectile.rotation += 0.7f * player.direction;
            if (projectile.rotation > MathHelper.TwoPi)
            {
                projectile.rotation -= MathHelper.TwoPi;
            }
            else if (projectile.rotation < 0)
            {
                projectile.rotation += MathHelper.TwoPi;
            }
            player.heldProj = projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = projectile.rotation;
        }


        public override void Kill(int timeLeft)
		{
			if (projectile.ai[0] >= 30)
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
                projectile.ai[0] = 0;
			}
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 5;
			target.AddBuff(mod.BuffType("Electrocute"), 300);
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)  //this make the projectile sprite rotate perfectaly around the player
        {
            Texture2D texture = Main.projectileTexture[projectile.type];
            spriteBatch.Draw(texture, projectile.Center - Main.screenPosition, null, Color.White, projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), 1f, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}
