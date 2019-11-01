using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Sunshine : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sunshine");
			Description.SetDefault("You are shining like a miniature Sun");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Солнечное Сияние");
			Description.AddTranslation(GameCulture.Russian, "Вы сияете как миниатюрное Солнце");
            DisplayName.AddTranslation(GameCulture.Chinese, "阳光普照");
            Description.AddTranslation(GameCulture.Chinese, "你正像一颗小太阳一样发出光芒");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			Lighting.AddLight((int)((double)player.position.X + (double)(player.width / 2)) / 16, (int)((double)player.position.Y + (double)(player.height / 2)) / 16, 3f, 3f, 3f);
		}
	}
}
