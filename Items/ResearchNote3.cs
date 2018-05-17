using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ResearchNote3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note#3");
			Tooltip.SetDefault("'In my interdimensional travels I once met one scientist, called [c/00FF00:Stanford]."
			+"\nHe asked for my help in making weapon, which could even cause damage to Godlike Creature."
			+"\nIt took us about half year to actually made working [c/00FF00:Prototype #618] aka [c/00FF00:'Quantum Destabilizer']..."
			+"\nAny [c/00FF00:Chargable Blaster] would fit as base."
			+"\nLens from [c/00FF00:Heat Ray] would be just fine." 
			+"\nSome parts should be made from both Luminite and Celestial Fragments..."
			+"\nSo, [c/00FF00:Alchemical Bundle] is needed here."
			+"\nAs specially accurate weapon, it also requires [c/00FF00:Sniper Scope]."
			+"\nBut the biggest problem here is the Power Source. We can't just get energy from nothing..."
			+"\nWell, for some money, I could sell you special Energy Cells for it.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №3");
			Tooltip.AddTranslation(GameCulture.Russian, "'В моих межизмеренческих странствиях я однажды встретила учёного, которого звали [c/00FF00:Стэнфорд].\nОн попросил помощи в создании оружия, способного повредить даже богоподобному созданию.\nУ нас ушло полгода на создание [c/00FF00:Прототипа №618] или [c/00FF00:'Квантового Дестабилизатора'].\nВ качестве основы подойдёт любой [c/00FF00:Заряжаемый Бластер].\nЛинза из [c/00FF00:Теплового Луча] будет здесь в самый раз.\nНекоторые части должны быть изготовлены из Люминита и Небесных Фрагментов...\nПоэтому здесь необходим [c/00FF00:Алхимический набор].\nКак особо точное оружие, прототип №618 также требует наличие [c/00FF00:Снайперского Прицела].\nНо главной проблемой является Источник Питания. Энергия не берётся из ничего...\nНу, за некоторую сумму я могу изготовить для него особые [c/00FF00:Энергоячейки].'"); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.value = 10000000;
			item.rare = 10;
		}	
	}
}