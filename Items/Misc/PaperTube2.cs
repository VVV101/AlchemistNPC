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
	public class PaperTube2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube (T2)");
			Tooltip.SetDefault("Contains blueprints of a random hardmode/post Skeletron accessory\nBring it to Tinkerer for unlocking");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус (2)");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного хардмодного/пост-Скелетронового аксессуара\nОтнесите его к Инженеру для разблокировки");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 200000;
			item.rare = 6;
			item.maxStack = 99;
		}
	}
}
