using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class DiscordBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Discord");
			Description.SetDefault("You may teleport to cursor position by using hotkey"
			+"\nDistorts player for 1 second after teleport"
			+"\nInflicts heavy damage while you have Chaos State"
			+"\nChaos State time is increased to 10 seconds");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Раздор");
			Description.AddTranslation(GameCulture.Russian, "Позволяет телепортироваться на курсор при нажатии горячей клавиши\nНарушает гравитацию игрока на 1 секунду после использования\nНаносит значительные повреждения, если вы в Хаотическом состоянии\nДлительность дебаффа увеличена до 10 секунд");
			
		}
	}
}
