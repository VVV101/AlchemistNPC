using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class BastScroll : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Description.SetDefault("Attacks obliterate enemy's armor");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Свиток Баст");
			Description.AddTranslation(GameCulture.Russian, "Атаки полностью разрушают броню противника.");
            DisplayName.AddTranslation(GameCulture.Chinese, "巴斯特卷轴");
            Description.AddTranslation(GameCulture.Chinese, "攻击完全摧毁敌人护甲");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
		AlchemistNPC.BastScroll = true;
		}
	}
}
