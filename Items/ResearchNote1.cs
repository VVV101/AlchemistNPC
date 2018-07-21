using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ResearchNote1 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note#1");
			Tooltip.SetDefault("'I know that Sasscade Yo-Yo exists. But how exactly it can be made?"
			+"\nI am pretty sure that the [c/00FF00:Terrarian Yo-Yo] is the first component."
			+"\nAn [c/00FF00:Alchemical Bundle] may be the second component..."
			+"\nBut what could be third? I think that it is something, related to the [c/00FF00:Sass]..." 
			+"\nMaybe inner part of the [c/00FF00:Rod of Discord] can be it?"
			+"\nAnd the final component... Is the [c/00FF00:Yo-yo Bag]. I am 100% sure about this.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №1");
            Tooltip.AddTranslation(GameCulture.Russian, "'Я знаю, что йо-йо Сасскад существует. Но как именно его сделать?\nЯ уверена, что первый компонент - [c/00FF00:Йо-Йо Террариан].\n[c/00FF00:Алхимический Набор] может быть вторым компонентом...\nНо что насчёт третьего? Я думаю, это что-то относящееся к [c/00FF00:ссорам]...\nМожет внутренняя часть [c/00FF00:Жезла Раздора] подойдёт?\nИ последний компонент... Это [c/00FF00:Сумка для Йо-Йо]. Я на 100% в этом уверена.'");

            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记#1");
            Tooltip.AddTranslation(GameCulture.Chinese, "'我知道那个名为Sasscade的悠悠球是真实存在的. 但是究竟要如何来制造它呢?" +
                "\n我很确定那个 [c/00FF00:泰拉悠悠球] 是第一个材料." +
                "\n[c/00FF00:炼金捆绑包] 也许是第二个..." +
                "\n但什么是第三个呢? 我认为那是某种, 和 [c/00FF00:Sass] 相关的东西..." +
                "\n也许 [c/00FF00:混沌法杖] 的核心就是?" +
                "\n最后的材料... 是 [c/00FF00:悠悠球袋]. 我100%确定.'");
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