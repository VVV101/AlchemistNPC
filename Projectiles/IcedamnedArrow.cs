using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class IcedamnedArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icedamned Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.CursedArrow);
			aiType = ProjectileID.CursedArrow;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.CursedArrow;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(39, 600);
				target.AddBuff(44, 600);
			}
		}
	}
}