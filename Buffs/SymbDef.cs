using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SymbDef : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Symbiote Defense Mode");
			Description.SetDefault("Increased life regeneration, defense and damage reduction");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Защитный режим симбиота");
			Description.AddTranslation(GameCulture.Russian, "Регенерация, сопротивление урона и защита увеличены");
            DisplayName.AddTranslation(GameCulture.Chinese, "共生体防御模式");
            Description.AddTranslation(GameCulture.Chinese, "增加生命回复, 防御和伤害减免");
        }
	}
}
