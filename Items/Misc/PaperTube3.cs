using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class PaperTube3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube (T3)");
			Tooltip.SetDefault("Contains blueprints of a random post Plantera accessory\nBring it to Tinkerer for unlocking");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус (3)");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного Пост-Плантерного аксессуара\nОтнесите его к Инженеру для разблокировки");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 200000;
			item.rare = 8;
			item.maxStack = 99;
		}
	}
}
