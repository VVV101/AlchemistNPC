using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class VanTankComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tank Combination (Vanilla)");
			Description.SetDefault("Combination of Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns and Regeneration buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (без Модовых)");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов и Регенерации");
            DisplayName.AddTranslation(GameCulture.Chinese, "坦克药剂包 (原版)");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：耐力, 生命力, 铁皮, 黑曜石皮肤, 荆棘, 恢复, 抵抗");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HasBuff(mod.BuffType("BattleComb")))
			{
				if (player.HasBuff(mod.BuffType("TankComb")))
				{
				}
				else
				{
			player.lavaImmune = true;
            player.fireWalk = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.endurance += 0.1f;
				{
                        if ((double)player.thorns < 1.0)
                            player.thorns = 0.3333333f;
                }
				}
			}
			else
			{
				if (player.HasBuff(mod.BuffType("TankComb")))
				{
				}
				else
				{
			player.lavaImmune = true;
            player.fireWalk = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.endurance += 0.1f;
			player.statDefense += 8;
			player.lifeRegen += 4;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
				{
                        if ((double)player.thorns < 1.0)
                            player.thorns = 0.3333333f;
                }
				}
			}
		}
	}
}
