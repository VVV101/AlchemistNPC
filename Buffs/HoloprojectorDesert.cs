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
	public class HoloprojectorDesert : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Desert''");
			Description.SetDefault("Biome state is set to Desert now");
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Голографический Проектор ''Пустыня''");
			Description.AddTranslation(GameCulture.Russian, "Изменяет текущий биом на Пустыню");
            DisplayName.AddTranslation(GameCulture.Chinese, "全息投影仪 ''神圣''");
            Description.AddTranslation(GameCulture.Chinese, "当前地形设置:神圣");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			Main.sandTiles = 1001;
		}
	}
}
