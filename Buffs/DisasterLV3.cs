using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class DisasterLV3 : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Disaster LV3");
			Description.SetDefault("Disaster Charge Level is 3");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Шкала Бедствия УР3");
            Description.AddTranslation(GameCulture.Russian, "Уровень заряда Бедствия равен 3");
		}
	}
}
