using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote5 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #5");
			Tooltip.SetDefault("'After beating Moon Lord you could craft some Ultimate Accessories."
			+"\nOne of them is Lilith Emblem." 
			+"\nNot only it combines all effects of multiple mage essential accessories..."
			+"\nIt also allows you to shoot dosens of deadly bees while using magic attacks'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #5");
			Tooltip.AddTranslation(GameCulture.Russian, "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Эмблема Лилит.\nОна не только сочетает в себе эффекты всех важных аксессуаров на мага...\nТакже она позволяет выпускать дюжины смертоносных пчёл при магических атаках."); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 150000;
			item.rare = 5;
		}
	}
}