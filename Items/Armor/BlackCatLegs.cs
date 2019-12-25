using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BlackCatLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cat's leggings & shoes");
			DisplayName.AddTranslation(GameCulture.Russian, "Колготки и туфли Чёрной Кошки");
            DisplayName.AddTranslation(GameCulture.Chinese, "黑猫的裤子和鞋");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}