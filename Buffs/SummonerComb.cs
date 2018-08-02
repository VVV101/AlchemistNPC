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
	public class SummonerComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Summoner Combination");
			Description.SetDefault("Combination of Summoning, Bewitched and Wrath buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Призывателя");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Призыва, Колдовства и Гнева");
            DisplayName.AddTranslation(GameCulture.Chinese, "召唤师药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：召唤, 迷人, 怒气");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.FindBuffIndex(mod.BuffType("MageComb")) >= 0 ||  player.FindBuffIndex(mod.BuffType("RangerComb")) >= 0 || player.FindBuffIndex(mod.BuffType("BattleComb")) >= 0)
			{
			++player.maxMinions;
			++player.maxMinions;
			player.buffImmune[13] = true;
			player.buffImmune[110] = true;
			player.buffImmune[115] = true;
			player.buffImmune[150] = true;
			}
			else
			{
			player.thrownDamage += 0.1f;
            player.meleeDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
			++player.maxMinions;
			++player.maxMinions;
			player.buffImmune[13] = true;
			player.buffImmune[110] = true;
			player.buffImmune[115] = true;
			player.buffImmune[150] = true;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
			}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.1f;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.1f;
			ThoriumPlayer.radiantBoost += 0.1f;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
