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
	public class ExecutionersEyes : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Executioner's Eyes");
			Description.SetDefault("Increases your damage by 15%, increases your critical strike chance by 5%, every crit has a 5% chance to double its damage");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Глаза Палача");
			Description.AddTranslation(GameCulture.Russian, "Увеличивает урон на 15%, шанс критического удара на 5%, 5% шанс на нанесение критом четырёхкратного урона");
        }
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.CalamityWorld.revenge; }
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModRevengeance)
				{
					if (player.buffTime[buffIndex] == 1) 
					{ 
					player.AddBuff(mod.BuffType("Exhausted"), 1800); 
					}
				}
				else
				{
					if (player.buffTime[buffIndex] == 1) 
					{ 
					player.AddBuff(mod.BuffType("Exhausted"), 3600); 
					}
				}
			}
			if (!ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (player.buffTime[buffIndex] == 1) 
				{ 
				player.AddBuff(mod.BuffType("Exhausted"), 3600); 
				}
			}
			player.yoraiz0rEye = 7;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
				if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
				{
				CalamityBoost(player);
				}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer CalamityPlayer = player.GetModPlayer<CalamityMod.Items.CalamityCustomThrowingDamage.CalamityCustomThrowingDamagePlayer>(Calamity);
            CalamityPlayer.throwingCrit += 5;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicCrit += 5;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
