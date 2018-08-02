using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class ShieldofSpring : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Shield of Spring");
			Description.SetDefault("Reduces all incoming damage by 15%");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Щит Весны");
			Description.AddTranslation(GameCulture.Russian, "Уменьшает весь входящий урон на 15%");
            DisplayName.AddTranslation(GameCulture.Chinese, "源泉之盾");
            Description.AddTranslation(GameCulture.Chinese, "减免15%所有伤害");
        }
		public override void Update(Player player, ref int buffIndex)
		{
		player.endurance += 0.15f;
			if (player.ownedProjectileCounts[mod.ProjectileType("SpringShield")] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("SpringShield"), 0, 0, player.whoAmI);
				}
			}
		}
	}
}
