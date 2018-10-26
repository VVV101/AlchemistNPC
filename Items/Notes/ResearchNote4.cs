using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class ResearchNote4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #4");
			Tooltip.SetDefault("'I used to think that only humans could use magic."
			+"\nI saw it with my own eyes. Skeleton was using magic. Despite them being magical creatures, they normally can't use it..."
			+"\nHe fought against Human Child. At first, I was going to help poor kid, but later on..."
			+"\nI was shocked seeing how kid brutally crushed that Skeleton to pile of bones."
			+"\nWhen this... monster was gone, I took some dust from this pile." 
			+"\nStrangely, it was glowing from magic, contained inside."
			+"\nLater on, I found the way to create artifact, containing that incredible power."
			+"\nI mixed some stuff from [c/00FF00:Alchemical Bundle] with [c/00FF00:enormously big bone] from ''Skeletron'' ."
			+"\nThen I added contents of [c/00FF00:Hate Vial]."
			+"\nAnd then, just polished everything with [c/00FF00:Flask of Rainbows]'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №4");
            Tooltip.AddTranslation(GameCulture.Russian, "' Раньше я думала, что только люди способны использовать магию.\nЯ видела своими глазами. Скелет использовал магию.\nХотя они и магические создания, использовать её они обычно не способны...\nОн сражался с Человеческим Ребёнком. Поначалу, я хотела помочь бедному дитя, но...\nЯ была поражена тем, как жестоко это ребёнок сокрушил этого скелета в кучу костей.\nКогда этот... монстр ушёл, я собрала немного пыли из той кучи.\nСтранно, но она просто сияла от содержащейся в ней магии.\nПозже, я нашла способ создать артефакт, хранящий эту невероятную силу.\nЯ смешала содержимое [c/00FF00:Алхимического Набора] с [c/00FF00:Огромной Костью] от 'Скелетрона'.\nТакже, я добавила содержимое [c/00FF00:Сосуда с Ненавистью] туда.\nА потом, я заполировала всё [c/00FF00:Флаконом Радуги]'");

            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记#4");
            Tooltip.AddTranslation(GameCulture.Chinese, "'在那之前我从来没有想过不止有人类可以使用魔法." +
                "\n那天我亲眼看见, 骷髅居然在用魔法. 好像他们本身不是不会魔法是生物..." +
                "\n他们与人类的小孩打架. 一开始, 我准备去帮助弱小的孩子, 但是之后..." +
                "\n我十分震惊的看着孩子们是如何残忍地把那个骷髅拆成一片一片碎骨头的." +
                "\n在这个... 怪物走开之后, 我从骨堆中得到了一些粉尘." +
                "\n奇怪的是, 它发出魔力的光芒, 包含在其中." +
                "\n之后, 我找到了制造人工制品的方法, 包含着那股难以置信的力量." +
                "\n我将来自 [c/00FF00:炼金捆绑包] 的一些材料和来自骷髅王的 [c/00FF00:巨大骨头] 混合在一起." +
                "\n然后我将 [c/00FF00:仇恨之瓶] 之中的东西在这里加了进去." +
                "\n最后, 用 [c/00FF00:瓶中彩虹] 把所有东西都进行抛光'");
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