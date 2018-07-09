using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class ResearchNote2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note#2");
			Tooltip.SetDefault("'I have found some information about the [c/00FF00:Royal Magic Wand] in one ancient manuscript."
			+"\nThere said... That no matter how exactly Wand was destroyed, it can still be recreated."
			+"\nBase for Magic Wand is [c/00FF00:the Rainbow Rod]."
			+"\n[c/00FF00:Last Prism] could work as Magical Focus..." 
			+"\n[c/00FF00:Angel Wings] are required too."
			+"\n[c/00FF00:Butterfly Dust] may be useful to cheat allowed user check."
			+"\nAnd as we don't know how to put Unicorn inside as power source, we need something else as substitude..."
			+"\nYou can try to catch [c/00FF00:Gold Bunny] and I will check if it would fit there.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №2");
            Tooltip.AddTranslation(GameCulture.Russian, "'Я нашла информацию о Королевской Волшебной Палочке в одном древнем манускрипте.\nТам сказано, что не важно, как именно Палочка была разрушена. Её всё равно можно воссоздать.\nОсновой послужит [c/00FF00:Радужный Жезл].\n[c/00FF00:Последняя Призма] подойдёт в качестве Магического Фокуса...\n[c/00FF00:Крылья Ангела] тоже необходимы.\n[c/00FF00:Пыль Бабочки] может быть полезна для обхода проверки пользователя.\nИ поскольку мы не знаем, как поместить единорога в качестве источника питания, то нам нужна замена...\nТы можешь попробовать поймать [c/00FF00:Золотого Кролика], а я проверю, подойдёт ли он.'");
            DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记#2");
            Tooltip.AddTranslation(GameCulture.Chinese, "'在一个古老的手稿中, 我找到了一些关于 [c/00FF00:皇家魔杖] 的信息." +
                "\n上面说道... 无论用何种方式摧毁魔杖, 它都能再生出来." +
                "\n魔杖的基础是 [c/00FF00:彩虹魔杖] ." +
                "\n[c/00FF00:终极棱镜] 可以作为魔力聚焦仪..." +
                "\n[c/00FF00:天使之翼] 也是必须的." +
                "\n[c/00FF00:蝴蝶尘] 也许在欺骗使用者权限上很好用." +
                "\n因为我们仍然不知道如何将作为能源的独角兽角放入, 我们需要替代物..." +
                "\n你可以尝试携带 [c/00FF00:金兔子] , 我会检查这东西是否合适.'");
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