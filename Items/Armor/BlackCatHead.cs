using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BlackCatHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cat's bow and ears");
			DisplayName.AddTranslation(GameCulture.Russian, "Бантик и ушки Чёрной Кошки"); 
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
	}
}