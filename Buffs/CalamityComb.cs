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
	public class CalamityComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Description.SetDefault("Perfect sum of Calamity buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Каламити");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание баффов Каламити мода");
            DisplayName.AddTranslation(GameCulture.Chinese, "万能药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下药剂包的Buff：\n坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.2f;
            player.meleeDamage += 0.2f;
			player.meleeSpeed += 0.1f;
            player.rangedDamage += 0.2f;
            player.magicDamage += 0.2f;
            player.minionDamage += 0.2f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
			player.statDefense -= 5;
			player.moveSpeed += 0.15f;
			player.kbBuff = true;
			player.minionKB += 5f;
			player.lifeRegen += 4;
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.endurance += 0.1f;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 5;
			player.statLifeMax2 -= 50;
			player.lifeMagnet = true;
			player.calmed = true;
			player.discount = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Cadence")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("YharimPower")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("TitanScale")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("FabsolVodka")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Omniscience")] = true;
		}
	}
}
