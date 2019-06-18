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
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class HoloprojectorJungle : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Jungle''");
			Description.SetDefault("Biome state is set to Jungle now");
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Голографический Проектор ''Джунгли''");
			Description.AddTranslation(GameCulture.Russian, "Изменяет текущий биом на Джунглевый");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.ZoneJungle = true;
		}
	}
}
