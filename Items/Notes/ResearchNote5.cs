using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class ResearchNote5 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #5");
			Tooltip.SetDefault("'Long ago, I have seen one half-demon, called [c/00FF00:Dante]."
			+"\nHe is a powerful Demon Hunter. He uses some... interesting devices in his battles."
			+"\nEspecially, I was very intrigued by one of his ranged weapons, [c/00FF00:Pandora]."
			+"\nAccording to legends, it has 666 forms. And it looks like technical weapon."
			+"\nAfter some researches, I was sure I could made a copy of it." 
			+"\nSadly, the prototype I made was able to transform into only 1 form, PF422..."
			+"\nIt is Grief, sharp Shuriken, which targets one enemy, slashing it to death."
			+"\nI was using metal from [c/00FF00:Piranha Gun] as base..."
			+"\nCovered it with [c/00FF00:Flask of Rainbows] for extra durability..."
			+"\nAs always, some parts can only be made from [c/00FF00:Alchemical Bundle]."
			+"\nAnd final ingredient is [c/00FF00:Moon Stone].'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №5");
            Tooltip.AddTranslation(GameCulture.Russian, "'Достаточно давно, я встретила одного полудемона, которого звали Данте.\nОн могущественный охотник на демонов и использует... интересные приспособления в битвах.\nВ особенности, я была заинтригована одним из оружий дальнего боя, Пандорой.\nСогласно легенде, она имеет 666 различных форм, при этом являясь техническим устройством.\nПосле некоторых исследований, я была уверена, что смогу изготовить копию.\nК сожалению, сделанный мной прототип оказался способен лишь к 1 трансформации, PF422.\nЭто Отчаяние, острый Сюрикен, который, будучи направленным на цель, изрежет её до смерти.\nЯ использовала металл с [c/00FF00:Пушки Пираньи] в качестве основы.\n[c/00FF00:Флакон Радуги] использовался для обработки корпуса.\nНекоторые части были изготовлены с помощью содержимого [c/00FF00:Алхимического Набора].\nА последний ингредиент - [c/00FF00:Лунный Камень].'");

            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记 #5");
            Tooltip.AddTranslation(GameCulture.Chinese, "'很久以前, 我见过一个半恶魔, 叫 [c/00FF00:但丁]."
            + "\n他是一个强大的恶魔猎人. 在战斗中他使用一些... 十分有趣的物品."
            + "\n尤其是, 我对他的一个远程武器十分好奇, 它叫 [c/00FF00:潘多拉]."
            + "\n传说, 它有666种形式. 它看起来就像是种科技武器."
            + "\n在经过一些研究后, 我确定我可以制作一个复制品."
            + "\n不幸的是, 我所制作的潘多拉只有一种形态, PF422..."
            + "\n它是悲伤的, 尖锐的手里剑, 一直盯着一个敌人, 直至死亡."
            + "\n我使用来自 [c/00FF00:食人鱼枪] 的材料作为基础."
            + "\n[c/00FF00:瓶中彩虹] 作为基础的外表覆盖物."
            + "\n一如既往, 某些部分只能使用 [c/00FF00:炼金捆绑包]."
            + "\n最后的构成是 [c/00FF00:月亮石].'");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.value = 10000000;
			item.rare = ItemRarityID.Red;
		}	
	}
}