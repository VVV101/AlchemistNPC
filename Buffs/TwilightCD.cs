using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class TwilightCD : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight Cooldown");
			Description.SetDefault("You cannot use Twilight's special ability yet");
			Main.debuff[Type] = true;
			canBeCleared = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречная Перезарядка");
			Description.AddTranslation(GameCulture.Russian, "Вы пока не можете использовать специальную способность Сумерек");
        }
	}
}
