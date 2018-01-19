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
	public class TankComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tank Combination (w/Modded)");
			Description.SetDefault("Combination of Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration, Titan Skin, Invincibility buffs");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (с Модовыми)");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов, Регенерации, Кожи Титана и Неуязвимости"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(mod.BuffType("BattleComb")) >= 0)
			{
			player.longInvince = true;
			player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[mod.BuffType("LongInvincible")] = true;
			player.buffImmune[mod.BuffType("TitanSkin")] = true;
			player.endurance += 0.1f;
				{
                        if ((double)player.thorns < 1.0)
                            player.thorns = 0.3333333f;
                }
			}
			else
			{
			player.longInvince = true;
			player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[mod.BuffType("LongInvincible")] = true;
			player.buffImmune[mod.BuffType("TitanSkin")] = true;
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
