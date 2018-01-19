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
	public class UniversalComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Universal Combination");
			Description.SetDefault("Perfect sum of Tank, Mage, Ranger and Summoner combinations");
			Main.buffNoSave[Type] = false;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Универсала");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание Комбинаций Танка, Мага, Стрелка и Призывателя"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
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
			player.statManaMax2 += 20;
            player.manaCost -= 0.02f;
			player.manaRegenBuff = true;
			player.statDefense += 8;
			player.archery = true;
			player.ammoPotion = true;
			player.lifeRegen += 4;
			player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
			player.buffImmune[29] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[110] = true;
			player.buffImmune[112] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			player.buffImmune[150] = true;
			player.buffImmune[mod.BuffType("BattleComb")] = true;
			player.buffImmune[mod.BuffType("TankComb")] = true;
			player.buffImmune[mod.BuffType("VanTankComb")] = true;
			player.buffImmune[mod.BuffType("RangerComb")] = true;
			player.buffImmune[mod.BuffType("MageComb")] = true;
			player.buffImmune[mod.BuffType("SummonerComb")] = true;
			player.buffImmune[mod.BuffType("LongInvincible")] = true;
			player.buffImmune[mod.BuffType("TitanSkin")] = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[13] = true;
			player.buffImmune[14] = true;
			player.endurance += 0.1f;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
			player.enemySpawns = true;
			++player.maxMinions;
			++player.maxMinions;
		}
	}
}
