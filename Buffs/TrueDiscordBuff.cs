using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class TrueDiscordBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Discord");
			Description.SetDefault("You may teleport to cursor position by using hotkey"
			+"\nBehaves exactly like Rod of Discord");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Истинный Раздор");
			Description.AddTranslation(GameCulture.Russian, "Вы можете телепортироваться к курсору, используя горячую клавишу\nПри применении ведёт себя аналогично Жезлу Раздора"); 
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.buffImmune[mod.BuffType("DiscordBuff")] = true;
		}
	}
}
