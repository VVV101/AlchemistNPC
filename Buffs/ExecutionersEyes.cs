using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
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
            DisplayName.AddTranslation(GameCulture.Chinese, "行刑者之眼");
            Description.AddTranslation(GameCulture.Chinese, "增加15%伤害,增加5%暴击率,暴击有5%概率造成4倍伤害");
        }
		
		public bool CalamityModRevengeance
		{
        get { return CalamityMod.World.CalamityWorld.revenge; }
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (ModLoader.GetMod("CalamityMod") != null)
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
			if (ModLoader.GetMod("CalamityMod") == null)
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
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            CalamityPlayer.throwingCrit += 5;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += 5;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
