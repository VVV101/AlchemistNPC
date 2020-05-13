using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CloakOfFear : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Cloak Of Fear");
			Description.SetDefault("Makes nearby non-boss enemies change their movement direction");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Плащ Страха");
			Description.AddTranslation(GameCulture.Russian, "Заставляет обычных врагов около игрока менять направление движения");
            DisplayName.AddTranslation(GameCulture.Chinese, "恐惧之袍");
            Description.AddTranslation(GameCulture.Chinese, "使附近的非Boss敌人改变移动方向");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[mod.ProjectileType("CloakOfFear")] == 0)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("CloakOfFear"), 0, 0, player.whoAmI);
				}
			}
			if (player.buffTime[buffIndex] == 1) 
			{ 
				player.AddBuff(mod.BuffType("Exhausted"), 1800); 
			}
		}
	}
}
