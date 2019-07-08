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
	public class UniversalComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Universal Combination");
			Description.SetDefault("Perfect sum of Tank, Mage, Ranger and Summoner combinations");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Универсальная комбинация");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание Комбинаций Танка, Мага, Стрелка и Призывателя");
            DisplayName.AddTranslation(GameCulture.Chinese, "万能药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下药剂包的Buff：\n坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包");
        }
		
		public override void Update(Player player, ref int buffIndex)
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
			player.statManaMax2 += 20;
            player.manaCost -= 0.02f;
			player.manaRegenBuff = true;
			player.statDefense += 8;
			player.archery = true;
			player.ammoPotion = true;
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
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (!player.HasBuff(mod.BuffType("CalamityComb")) && !player.HasBuff(ModLoader.GetMod("CalamityMod").BuffType("Cadence")))
				{
					player.lifeRegen += 4;
					player.lifeForce = true;
					player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
				}
			}
			if (ModLoader.GetMod("CalamityMod") == null)
			{
				player.lifeRegen += 4;
				player.lifeForce = true;
				player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
			}
			++player.maxMinions;
			++player.maxMinions;
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
