using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Projectiles
{
	public class SeepingArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Seeping Arrow");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.IchorArrow);
			aiType = ProjectileID.IchorArrow;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.IchorArrow;
			return true;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(2) == 0)
			{
				target.AddBuff(24, 600);
				target.AddBuff(69, 600);
			}
		}
	}
}