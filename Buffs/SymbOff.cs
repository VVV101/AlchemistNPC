using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SymbOff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Symbiote Offense Mode");
			Description.SetDefault("Increased attack speed");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Атакующий режим симбиота");
			Description.AddTranslation(GameCulture.Russian, "Скорость атаки увеличена");
        }
	}
}
