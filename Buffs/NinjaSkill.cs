using Terraria;
using System.Linq;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class NinjaSkill : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Description.SetDefault("You are a true ninja!");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ниндзя");
			Description.AddTranslation(GameCulture.Russian, "Вы - истинный ниндзя!");

            DisplayName.AddTranslation(GameCulture.Chinese, "忍者");
            Description.AddTranslation(GameCulture.Chinese, "你现在拥有忍者的能力");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
			RedemptionPlayer.druidDamage += 0.05f;
            RedemptionPlayer.druidCrit += 5;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicDamage += 0.05f;
            ThoriumPlayer.symphonicCrit += 5;
			ThoriumPlayer.radiantBoost += 0.05f;
            ThoriumPlayer.radiantCrit += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
