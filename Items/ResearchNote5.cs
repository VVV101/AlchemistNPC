using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ResearchNote5 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note#5");
			Tooltip.SetDefault("'Long ago, I have seen one half-demon, called [c/00FF00:Dante]."
			+"\nHe is a powerful Demon Hunter. He uses some... interesting devices in his battles."
			+"\nEspecially, I was very intrigued by one of his ranged weapons, [c/00FF00:Pandora]."
			+"\nAccording to legends, it has 666 forms. And it looks like technical weapon."
			+"\nAfter some researches, I was sure I could made a copy of it." 
			+"\nSadly, the prototype I made was able to transform into only 1 form, PF422..."
			+"\nIs is Grief, sharp Shuriken, which targets one enemy, slashing it to death."
			+"\nI was using metal from [c/00FF00:Piranha Gun] as base."
			+"\n[c/00FF00:Flask of Rainbows] was used as covering for base."
			+"\nAs always, some parts can only be made from [c/00FF00:Alchemical Bundle]."
			+"\nAnd final ingredient is [c/00FF00:Moon Stone].'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №5");
			Tooltip.AddTranslation(GameCulture.Russian, "'Достаточно давно, я встретила одного полудемона, которого звали Дантэ.\nОн могущественный охотник на демонов и использует... интересные приспособления в битвах.\nВ особенности, я была заинтригована одним из оружий дальнего боя, Пандорой.\nСогласно легенде, она имеет 666 различных форм, при этом являясь техническим устройством.\nПосле некоторых исследований, я была уверена, что смогу изготовить копию.\nК сожалению, сделанный мной прототип оказался способен лишь к 1 трансформации, PF422.\nЭто Отчаяние, острый Сюрикен, который, будучи направленным на цель, изрежет её до смерти.\nЯ использовала металл с [c/00FF00:Пушки Пираньи] в качестве основы.\n[c/00FF00:Флакон Радуги] использовался для обработки корпуса.\nНекоторые части были изготовлены с помощью содержимого [c/00FF00:Алхимического Набора].\nА последний ингредиент - [c/00FF00:Лунный Камень].'"); 
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