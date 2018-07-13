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