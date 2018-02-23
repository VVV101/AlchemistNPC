using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote6 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #6");
			Tooltip.SetDefault("'After beating Moon Lord you could craft some Ultimate Accessories."
			+"\nOne of them is Rampage Components." 
			+"\nThey increase your ranged damage & crit by 10% and provide effect of Sniper Scope."
			+"\nAlso, they turn Musket Balls into deadly Chloroshard Bullets..."
			+"\nChloroshard Bullets are basically homing Crystal Bullets with increased damage.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #6");
			Tooltip.AddTranslation(GameCulture.Russian, "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Компоненты Буйства.\nОни повышают урон и крит дальнего боя на 10%, а также даёт эффект Снайперского Прицела.\nТакжи они превращают мушкетные патроны в смертоносные Хлорофитово-осколочные пули...\nЭти пули по сути своей являются самонаводящимися Кристальными с повышенным уроном.'"); 
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