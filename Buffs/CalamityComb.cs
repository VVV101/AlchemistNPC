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
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CalamityComb : ModBuff
	{
		
		public override bool Autoload(ref string name, ref string texture)
		{
		return ModLoader.GetMod("CalamityMod") != null;
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Calamity Combination");
			Description.SetDefault("Perfect sum of Calamity buffs"
			+"\nYharim's Stimulants, Cadence, Fabsol's Vodka, Titan Scale and Omniscience");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Каламити");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание баффов Каламити мода\nДает эффект Стимулянтов Ярима, Каденции, Водки Фабсола, Титановой Чешуи и Всевидения");
            DisplayName.AddTranslation(GameCulture.Chinese, "灾厄药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下灾厄药剂的Buff：\n魔君牌兴奋剂、尾音药剂、Fabsol伏特加、泰坦之鳞药剂以及全知药剂");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.18f;
            player.meleeDamage += 0.18f;
			player.meleeSpeed += 0.1f;
            player.rangedDamage += 0.18f;
            player.magicDamage += 0.18f;
            player.minionDamage += 0.18f;
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
            player.statLifeMax2 += player.statLifeMax / 10;
			player.lifeMagnet = true;
			player.calmed = true;
			player.discount = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Cadence")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("YharimPower")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("TitanScale")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("FabsolVodka")] = true;
			player.buffImmune[ModLoader.GetMod("CalamityMod").BuffType("Omniscience")] = true;
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetMod("CalamityMod") != null)
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			CalamityPlayer.throwingDamage += 0.18f;
            CalamityPlayer.throwingCrit += 5;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.18f;
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.18f;
            ThoriumPlayer.symphonicCrit += 5;
			ThoriumPlayer.radiantBoost += 0.18f;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
