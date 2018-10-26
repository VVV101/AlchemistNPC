using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote5 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #5");
			Tooltip.SetDefault("''Defeating the Moon Lord allows the creation of Ultimate Accessories."
			+"\nOne of them is the Lilith Emblem." 
			+"\nNot only does it combine all the effects of multiple mage essential accessories..."
			+"\nBut it also allows you to shoot dozens of deadly bees while using magic attacks''"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #5");
            Tooltip.AddTranslation(GameCulture.Russian, "'После победы на Лунным Лордом ты сможешь скрафтить Ультимативные Аксессуары.\nОдин из них - это Эмблема Лилит.\nОна не только сочетает в себе эффекты всех важных аксессуаров на мага...\nТакже она позволяет выпускать дюжины смертоносных пчёл при магических атаках.'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #5");
            Tooltip.AddTranslation(GameCulture.Chinese, "'在击败月亮领主之后, 你可以制造一些终极饰品." +
                "\n其中之一是莉莉丝徽章." +
                "\n它不仅给予你魔法师所需要的大部分Buff..." +
                "\n同时也会在你使用魔法武器的同时发射出一打致命的蜜蜂'" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片. 也许珠宝师可以帮助你.");
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
