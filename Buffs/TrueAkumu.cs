using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TrueAkumu : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Akumu's Shield");
			Description.SetDefault("Reflects any hostile projectiles");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Защита Акуму");
			Description.AddTranslation(GameCulture.Russian, "Отражает любые снаряды противника");
            DisplayName.AddTranslation(GameCulture.Chinese, "仇恨");
            Description.AddTranslation(GameCulture.Chinese, "准备好释放你的仇恨吧!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[mod.ProjectileType("TrueAkumuShield")] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.position.X-15, player.position.Y, vel.X, vel.Y, mod.ProjectileType("TrueAkumuShield"), 0, 0, player.whoAmI);
				}
			}
		}
	}
}
