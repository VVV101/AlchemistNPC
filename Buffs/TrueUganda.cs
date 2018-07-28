using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TrueUganda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Uganda's Curse");
			Description.SetDefault("DEW U NO DE WEI?");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Истинное Проклятие Уганды");
			Description.AddTranslation(GameCulture.Russian, "DEW U NO DE WEI?");
            DisplayName.AddTranslation(GameCulture.Chinese, "乌干达之诅咒");
            Description.AddTranslation(GameCulture.Chinese, "DEW U NO DE WAY?");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.noItems = true;
            player.lifeRegen -= 9999999;
        }
	}
}
