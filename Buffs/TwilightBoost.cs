using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TwilightBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight Boost");
			Description.SetDefault("You are immune to damage and deal 3x damage");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречное Усиление");
			Description.AddTranslation(GameCulture.Russian, "Вы неуязвимы и наносите трёхкратный урон");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.HeldItem.type != mod.ItemType("Twilight"))
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			player.immune = true;
			player.thrownDamage += 3f;
			player.meleeDamage += 3f;
			player.rangedDamage += 3f;
			player.magicDamage += 3f;
			player.minionDamage += 3f;
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
			CalamityPlayer.throwingDamage += 3f;
        }
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 3f;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 3f;
			ThoriumPlayer.radiantBoost += 3f;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
