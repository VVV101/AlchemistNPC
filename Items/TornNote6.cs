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
			Tooltip.SetDefault("'Defeating the Moon Lord allows the creation of Ultimate Accessories."
			+"\nOne of them are the Rampage Components." 
			+"\nThey increase your ranged damage & crit by 10% and provide the effect of the Sniper Scope."
			+"\nThey also turn your Musket Balls into deadly Chloroshard Bullets..."
<<<<<<< HEAD
			+"\nChloroshard bullets are basically homing Crystal Bullets with increased damage.'"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
=======
			+"\nChloroshard bullets are basically homing Crystal Bullets with increased damage.'");
>>>>>>> 69d97c7c775dd0c0da6b85f343b3899e81bd7580
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #6");
			Tooltip.AddTranslation(GameCulture.Russian, "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Компоненты Буйства.\nОни повышают урон и крит дальнего боя на 10%, а также даёт эффект Снайперского Прицела.\nТакжи они превращают мушкетные патроны в смертоносные Хлорофитово-осколочные пули...\nЭти пули по сути своей являются самонаводящимися Кристальными с повышенным уроном.'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь."); 
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
