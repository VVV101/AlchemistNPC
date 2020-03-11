using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;

namespace AlchemistNPC.Projectiles
{
	public class SpiderFangarang : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spider Fangarang");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
		
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
            
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int i = 0; i < projectile.oldPos.Length; i++) {
                Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - i) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle(0, projectile.frame * Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type], Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

		public override void SetDefaults()
		{
			projectile.CloneDefaults(272);
			projectile.melee = false;
			projectile.thrown = true;
			projectile.aiStyle = 3;
			aiType = 272;
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			return base.OnTileCollide(oldVelocity);
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[BuffID.Poisoned] = false;
			target.AddBuff(BuffID.Poisoned, 300);
		}
	}
}
