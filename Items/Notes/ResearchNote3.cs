using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class ResearchNote3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #3");
			Tooltip.SetDefault("'In my interdimensional travels I have met a scientist, name's [c/00FF00:Stanford]."
			+"\nHe asked fme to aid him in making a weapon which could cause damage to a Godlike Creature."
			+"\nIt took us about half year to actually made working [c/00FF00:Prototype #618] aka [c/00FF00:'Quantum Destabilizer']..."
			+"\n[c/00FF00:Charged Blaster] from Martians would fit as base."
			+"\nLens from [c/00FF00:Heat Ray] would be just fine." 
			+"\nSome parts should be made from both Luminite and Celestial Fragments..."
			+"\nAs usual, [c/00FF00:Alchemical Bundle] is needed here."
			+"\nSince this is an extremely accurate weapon, it also requires [c/00FF00:Sniper Scope]."
			+"\nBut the biggest problem here is the Power Source. We can't just get energy from nothing..."
			+"\nWell, for some money, I could sell you special Energy Cells for it.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №3");
            Tooltip.AddTranslation(GameCulture.Russian, "'В моих межизмеренческих странствиях я однажды встретила учёного, которого звали [c/00FF00:Стэнфорд].\nОн попросил помощи в создании оружия, способного повредить даже богоподобному созданию.\nУ нас ушло полгода на создание [c/00FF00:Прототипа №618] или [c/00FF00:'Квантового Дестабилизатора'].\nВ качестве основы подойдёт любой [c/00FF00:Заряжаемый Бластер].\nЛинза из [c/00FF00:Теплового Луча] будет здесь в самый раз.\nНекоторые части должны быть изготовлены из Люминита и Небесных Фрагментов...\nКак обычно, здесь необходим [c/00FF00:Алхимический набор].\nКак особо точное оружие, прототип №618 также требует наличие [c/00FF00:Снайперского Прицела].\nНо главной проблемой является Источник Питания. Энергия не берётся из ничего...\nНу, за некоторую сумму я могу изготовить для него особые [c/00FF00:Энергоячейки].'");

            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记 #3");
            Tooltip.AddTranslation(GameCulture.Chinese, "'在次元旅行中我遇见过一个科学家, 名字叫做 [c/00FF00:斯坦福] ." +
                "\n他想让我帮他制作武器, 一种甚至可以伤害到神灵的武器." +
                "\n我们花了大半年来制作 [c/00FF00:蓝图 #618] 亦称 [c/00FF00:'量子干扰器']..." +
                "\n任意 [c/00FF00:带电爆破炮] 都可以作为基础." +
                "\n来自 [c/00FF00:高温射线枪] 的透镜很合适." +
                "\n某些部件需要夜明锭和天体碎片来制作..." +
                "\n所以, 这里需要 [c/00FF00:炼金捆绑包]." +
                "\n作为一个精准度极高的武器, 他需要一个 [c/00FF00:狙击镜]." +
                "\n但是最大的问题是能源. 我们不能凭空变出能量..." +
                "\nemmmm..., 只需要花点钱, 我可以卖给你专用的能源电池.'");
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