using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class HeartAche : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Heart Ache");
			Description.SetDefault("You cannot use Potion of Darkness now");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Боль Сердца");
			Description.AddTranslation(GameCulture.Russian, "Вы не можете использовать Зелье Тьмы сейчас");
        }
	}
}
