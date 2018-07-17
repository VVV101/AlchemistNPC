using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class PaleStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pale Star");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.SporeTrap);
			projectile.magic = true; 
			aiType = ProjectileID.ChlorophyteBullet;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 1;
		}
		
		public override void ModifyHitNPC (NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.lifeMax <= 300000)
			damage = target.life/100;
			if (target.lifeMax > 300000)
			damage = target.life/300;
		}
	}
}