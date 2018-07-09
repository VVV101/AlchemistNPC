using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SapphireSoda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Sapphire Soda Effect");
			Description.SetDefault("Removes Mana Sickness debuff");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Эффект Сапфировой Соды");
			Description.AddTranslation(GameCulture.Russian, "Убирает дебафф Ослабление Волшебства");
            DisplayName.AddTranslation(GameCulture.Chinese, "宝蓝苏打加持");
            Description.AddTranslation(GameCulture.Chinese, "移除魔力病Debuff");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[94] = true;
		}
	}
}
