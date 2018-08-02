using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class DisasterLV2 : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Disaster LV2");
			Description.SetDefault("Disaster Charge Level is 2");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Шкала Бедствия УР2");
            Description.AddTranslation(GameCulture.Russian, "Уровень заряда Бедствия равен 2");
		}
	}
}
