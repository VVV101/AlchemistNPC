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
	public class PaperTube : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper Tube");
			Tooltip.SetDefault("Contains blueprints of a random prehardmode accessory\nBring it to Tinkerer for unlocking");
			DisplayName.AddTranslation(GameCulture.Russian, "Тубус");
            Tooltip.AddTranslation(GameCulture.Russian, "Хранит в себе чертёж случайного прехардмодного аксессуара\nОтнесите его к Инженеру для разблокировки");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 50000;
			item.rare = 4;
			item.maxStack = 99;
		}
	}
}
