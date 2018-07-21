using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ResearchNote6 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note#6");
			Tooltip.SetDefault("'Once, there was existing an actual incarnation of [c/00FF00:FEAR] itself..."
			+"\nAfter countless battles, this being was finally defeated."
			+"\nSoul, which was persisting after host's death, was put into deep observations."
			+"\nEssence of FEAR was extracted during these observations."
			+"\nAnd I managed to get a few vials of it." 
			+"\nIf you find other ingredients, then I could make an [c/00FF00:''Akumu''], very powerful scythe."
			+"\n[c/00FF00:Death Sickle] is needed as base for it."
			+"\n[c/00FF00:Hate Vial] is required for unleashing full potential of FEAR essence."
			+"\nFor stabilizing components, we need an [c/00FF00:Alchemical Bundle]."
			+"\nAnd for the last ingredient, we need [c/00FF00:Celestial Stone].'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №6");
            Tooltip.AddTranslation(GameCulture.Russian, "'Однажды существовало воплощение самого [c/00FF00:Страха]...\nПосле бесчисленных сражений, это существо было наконец побеждено..\nДуша, что осталась после смерти носителя, была отправлена на глубокое обследование.\nВ результате этих исследований была извлечена Эссенция Страха.\nЯ смогла раздобыть несколько пробирок.\nЕсли ты раздобудешь остальные ингредиенты, то я смогу изготовить [c/00FF00:''Акуму''], очень могущественную косу.\nВ качестве основы потребуется [c/00FF00:Коса Смерти].\nДля раскрытия полного потенциала Эссенции Страха потребуется [c/00FF00:Сосуд с Ненавистью].\nДля стабилизации компонентов нам потребуется [c/00FF00:Алхимический Набор].\nА последний ингредиент - [c/00FF00:Небесный Камень].'");

            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记#6");
            Tooltip.AddTranslation(GameCulture.Chinese, "'曾经, [c/00FF00:恐惧] 有它真实的化身..."
            + "\n经历了数不清的战斗后, 这些存在最终被打败了."
            + "\n灵魂, 这种就算主人死亡也不曾消散的东西, 我对它进行了深入的观察."
            + "\n观察的过程中提取出了恐惧的本质."
            + "\n我设法得到了几小瓶."
            + "\n如果你找到其它材料, 我就可以制造一个 [c/00FF00:''Akumu''], 非常强大的镰刀."
            + "\n[c/00FF00:死神镰刀] 是基础必需品."
            + "\n需要 [c/00FF00:仇恨之瓶] 来释放恐惧的全部本质."
            + "\n用于稳定各部件, 我们需要 [c/00FF00:炼金捆绑包]."
            + "\n最后一项材料, 我们需要一个 [c/00FF00:天界石].'");
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