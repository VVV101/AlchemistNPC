using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #4");
			Tooltip.SetDefault("'After beating Moon Lord you could craft some Ultimate Accessories."
			+"\nOne of them is Sephirothic Fruit." 
			+"\nNot only it increases minion damage by 10% and gives +2 max minions..."
			+"\nIt also allows your minions ignore enemy invincibility frames'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #4");
			Tooltip.AddTranslation(GameCulture.Russian, "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Плод Сефирот.\nОн не только увеливает урон прислужников на 10% и дают 2 дополнительных слота для прислужников...\nТакже он позволяет прислужникам игнорировать период неуязвимости противника."); 
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