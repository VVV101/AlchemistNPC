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
	public class BattleComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Battle Combination");
			Description.SetDefault("Combination of Endurance, Lifeforce, Ironskin, Regeneration, Rage & Wrath buffs");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Боевая комбинация");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Регенерации, Ярости и Гнева"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(mod.BuffType("MageComb")) >= 0 ||  player.FindBuffIndex(mod.BuffType("RangerComb")) >= 0)
			{
			player.statDefense += 8;
			player.lifeRegen += 4;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
			player.endurance += 0.1f;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			}
			else
			{
			player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
			player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.magicCrit += 10;
            player.thrownCrit += 10;
			player.statDefense += 8;
			player.lifeRegen += 4;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
			player.endurance += 0.1f;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			}
		}
	}
}
