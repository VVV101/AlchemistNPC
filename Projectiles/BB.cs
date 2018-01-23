using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class BB : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bleeding Bullet");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.timeLeft = 300;
			aiType = ProjectileID.Bullet;           //Act exactly like default Bullet
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		target.AddBuff(BuffID.OnFire, 720);
		}
	}
}
