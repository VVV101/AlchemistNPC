using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class DisasterLV1 : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Disaster LV1");
			Description.SetDefault("Disaster Charge Level is 1");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Шкала Бедствия УР1");
            Description.AddTranslation(GameCulture.Russian, "Уровень заряда Бедствия равен 1");
		}
	}
}
