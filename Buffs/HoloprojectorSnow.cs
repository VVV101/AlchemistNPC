using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class HoloprojectorSnow : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Snow''");
			Description.SetDefault("Biome state is set to Snow now");
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Голографический Проектор ''Снежный''");
			Description.AddTranslation(GameCulture.Russian, "Изменяет текущий биом на Зимний");
            DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''冰雪''");
            Description.AddTranslation(GameCulture.Chinese, "当前地形设置:冰雪");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.ZoneSnow = true;
		}
	}
}
