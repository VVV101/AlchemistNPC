using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SymbolOfPain : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Symbol of Pain");
			Description.SetDefault("Weakens enemies");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Символ Боли");
			Description.AddTranslation(GameCulture.Russian, "Ослабляет противников");
            DisplayName.AddTranslation(GameCulture.Chinese, "痛苦法印");
            Description.AddTranslation(GameCulture.Chinese, "虚弱敌人");
        }
	}
}
