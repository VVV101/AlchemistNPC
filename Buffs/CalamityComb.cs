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
			player.meleeSpeed += 0.05f;
			player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.magicCrit += 2;
            player.thrownCrit += 2;
			player.statDefense -= 15;
			player.moveSpeed += 0.1f;
			player.minionKB += 1f;
			player.lifeRegen += 5;
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.endurance += 0.05f;
			player.lifeForce = true;
            player.statLifeMax2 += player.statLifeMax / 4;
			player.lifeMagnet = true;
			player.calmed = true;
			player.discount = true;
			player.buffImmune[2] = true;
			player.buffImmune[13] = true;
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
					if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
					{
						player.thrownDamage += 0.14f;
						player.meleeDamage += 0.14f;
						player.rangedDamage += 0.14f;
						player.magicDamage += 0.14f;
						player.minionDamage += 0.14f;
					}
					if (player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
					{
						player.thrownDamage += 0.24f;
						player.meleeDamage += 0.24f;
						player.rangedDamage += 0.24f;
						player.magicDamage += 0.24f;
						player.minionDamage += 0.24f;
					}
					CalamityBoost(player, ref buffIndex);
				}
		}
		
		private void CalamityBoost(Player player, ref int buffIndex)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			Calamity.GetBuff("TitanScale").Update(player, ref buffIndex);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					CalamityPlayer.throwingDamage += 0.14f;
				}
				if (player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					CalamityPlayer.throwingDamage += 0.24f;
				}
			}
            CalamityPlayer.throwingCrit += 2;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					RedemptionPlayer.druidDamage += 0.14f;
				}
				if (player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					RedemptionPlayer.druidDamage += 0.24f;
				}
			}
            RedemptionPlayer.druidCrit += 2;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 2;
            ThoriumPlayer.radiantCrit += 2;
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					ThoriumPlayer.symphonicDamage += 0.14f;
					ThoriumPlayer.radiantBoost += 0.14f;
				}
				if (player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Fab")))
				{
					ThoriumPlayer.symphonicDamage += 0.24f;
					ThoriumPlayer.radiantBoost += 0.24f;
				}
			}
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
