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