using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Hate : ModBuff
	{
		public static int count = 0;
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Hate");
			Description.SetDefault("You are ready to unleash your Hate");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ненависть");
			Description.AddTranslation(GameCulture.Russian, "Вы готовы выпустить свою Ненависть");
            DisplayName.AddTranslation(GameCulture.Chinese, "仇恨");
            Description.AddTranslation(GameCulture.Chinese, "准备好释放你的仇恨吧!");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
		if (player.statLife < player.statLifeMax2)
		{
			if (count >= 12)
			{
			count = 0;
			player.statLife += 5;
			player.HealEffect(5, true);
			}
			count++;
		}
		player.thrownDamage += 0.15f;
        player.meleeDamage += 0.15f;
        player.rangedDamage += 0.15f;
        player.magicDamage += 0.15f;
        player.minionDamage += 0.15f;
		player.meleeCrit += 15;
        player.rangedCrit += 15;
        player.magicCrit += 15;
        player.thrownCrit += 15;
		player.lifeRegen += 20;
		player.endurance -= 0.15f;
		player.statDefense -= 30;
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
			CalamityPlayer.throwingDamage += 0.15f;
            CalamityPlayer.throwingCrit += 15;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.15f;
            RedemptionPlayer.druidCrit += 15;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.15f;
            ThoriumPlayer.symphonicCrit += 15;
			ThoriumPlayer.radiantBoost += 0.15f;
            ThoriumPlayer.radiantCrit += 15;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
