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
            DisplayName.AddTranslation(GameCulture.Chinese, "真·混乱传送");
            Description.AddTranslation(GameCulture.Chinese, "你可以使用快捷键传送至鼠标位置" +
                "\n相当于裂位法杖");
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
		player.buffImmune[mod.BuffType("DiscordBuff")] = true;
		}
	}
}
