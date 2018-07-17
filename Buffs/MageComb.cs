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
	public class MageComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mage Combination");
			Description.SetDefault("Combination of Magic Power, Mana Regeneration, Clairvoyance, Wrath & Rage buffs");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Мага");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Магической Силы, Регенерации Маны, Ясновидения, Гнева и Ярости");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔法药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：魔能, 魔力再生, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(mod.BuffType("RangerComb")) >= 0)
			{
            player.magicDamage += 0.25f;
			player.magicCrit += 2;
			player.statManaMax2 += 20;
            player.manaCost -= 0.02f;
			player.manaRegenBuff = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[29] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			}
			else
			{
			player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.35f;
            player.minionDamage += 0.1f;
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 12;
            player.thrownCrit += 10;
			player.manaRegenBuff = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[29] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			}
		}
	}
}
