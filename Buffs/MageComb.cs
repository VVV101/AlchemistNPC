using System;
using System.Linq;
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
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Мага");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Магической Силы, Регенерации Маны, Ясновидения, Гнева и Ярости");

            DisplayName.AddTranslation(GameCulture.Chinese, "魔法药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：魔能, 魔力再生, 智慧, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HasBuff(mod.BuffType("RangerComb")))
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
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("HolyWrathBuff")))
					{
						player.thrownDamage += 0.1f;
						player.meleeDamage += 0.1f;
						player.rangedDamage += 0.1f;
						player.magicDamage += 0.35f;
						player.minionDamage += 0.1f;
						CalamityBoost(player, 0);
						if (ModLoader.GetMod("ThoriumMod") != null)
						{
							ThoriumBoosts(player, 0);
						}
						if (ModLoader.GetMod("Redemption") != null)
						{
							RedemptionBoost(player, 0);
						}
					}
					if (!player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("ProfanedRageBuff")))
					{
						player.meleeCrit += 10;
						player.rangedCrit += 10;
						player.magicCrit += 10;
						player.thrownCrit += 10;
						CalamityBoost(player, 1);
						if (ModLoader.GetMod("ThoriumMod") != null)
						{
							ThoriumBoosts(player, 1);
						}
						if (ModLoader.GetMod("Redemption") != null)
						{
							RedemptionBoost(player, 1);
						}
					}
					if (player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("HolyWrathBuff")))
					{
						player.magicDamage += 0.25f;
					}
				}
				if (ModLoader.GetMod("CalamityMod") == null)
				{
					player.thrownDamage += 0.1f;
					player.meleeDamage += 0.1f;
					player.rangedDamage += 0.1f;
					player.magicDamage += 0.35f;
					player.minionDamage += 0.1f;
					player.meleeCrit += 10;
					player.rangedCrit += 10;
					player.magicCrit += 10;
					player.thrownCrit += 10;
					if (ModLoader.GetMod("ThoriumMod") != null)
					{
						ThoriumBoosts(player, 2);
					}
					if (ModLoader.GetMod("Redemption") != null)
					{
						RedemptionBoost(player, 2);
					}
				}
				player.magicCrit += 2;
				player.manaRegenBuff = true;
				player.buffImmune[6] = true;
				player.buffImmune[7] = true;
				player.buffImmune[29] = true;
				player.buffImmune[115] = true;
				player.buffImmune[117] = true;
			}
		}
		
		private void CalamityBoost(Player player, int dc)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
			if (dc == 0)
			CalamityPlayer.throwingDamage += 0.1f;
			if (dc == 1)
            CalamityPlayer.throwingCrit += 10;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player, int dc)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			if (dc == 0 || dc == 2)
			RedemptionPlayer.druidDamage += 0.1f;
			if (dc == 1 || dc == 2)
            RedemptionPlayer.druidCrit += 10;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player, int dc)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
			if (dc == 0 || dc == 2)
			{
				ThoriumPlayer.symphonicDamage += 0.1f;
				ThoriumPlayer.radiantBoost += 0.1f;
			}
			if (dc == 1 || dc == 2)
			{
				ThoriumPlayer.symphonicCrit += 10;
				ThoriumPlayer.radiantCrit += 10;
			}
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
