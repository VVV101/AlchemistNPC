using Terraria;
using System.Linq;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
            Description.AddTranslation(GameCulture.Chinese, "现在你是个真正的忍者了!");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.allDamage += 0.05f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
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
