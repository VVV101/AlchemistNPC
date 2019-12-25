using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class GreaterDangersense : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense");
			Description.SetDefault("Lights up enemy projectiles");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Великого Чувства Опасности");
			Description.AddTranslation(GameCulture.Russian, "Подсвечивает снаряды противника");
            DisplayName.AddTranslation(GameCulture.Chinese, "强效危险感知");
            Description.AddTranslation(GameCulture.Chinese, "高亮敌人的抛射物");
        }
	}
}
