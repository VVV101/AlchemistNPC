using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Projectiles.Minions
{
	public abstract class Minion : ModProjectile
	{
		public override void AI()
		{
			CheckActive();
		}

		public abstract void CheckActive();

	}
}