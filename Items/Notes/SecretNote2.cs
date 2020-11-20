using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class SecretNote2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret Note #2");
			Tooltip.SetDefault("''I saw a pretty strange creature a few times"
			+ "\nShe looked like a Fairy, but at the same time..."
			+ "\nThere was something strange in her appearance."
			+ "\nShe was... way too perfect for an ordinary Fairy."
			+ "\nSadly, I never saw her again..."
			+ "\nShe got beaten by an unknown creature, somewhere nearby Plantera's habitat,"
			+ "\nand was transformed into a Crystal.''"
			+ "\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Тайная записка 2");
            Tooltip.AddTranslation(GameCulture.Russian, "Несколько раз я видела одно довольно странное создание.\nОна выглядела как Фея, но в то же время...\nБыло что-то странное в её облике.\nОна выглядела... слишком совершенной для обычной Феи.\nК сожелению, это был последний раз, когда я её видела.\nЕё победило неизвестное существо и утащило с собой, превратив в Кристалл.\nЭто произошло неподалёку от мест обитания Плантеры.''\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");
			DisplayName.AddTranslation(GameCulture.Chinese, "秘密笔记 #2");
			Tooltip.AddTranslation(GameCulture.Chinese, "''有过几次, 我见到了一个十分古怪的生物."
			+"\n她看起来像个仙女, 但与此同时..."
			+"\n她的外貌上有些古怪之处."
			+"\n她... 对于一个普通的仙女来说, 过于完美了."
			+"\n令人沮丧的是, 那是我最后一次见到她..."
			+"\n她被一个未知的生物击败, 并转化成了一个水晶."
			+"\n就在世纪之花的栖息地附近.''"
			+"\n还有一些内容, 但是你并读不到. 除非你有其它碎片.. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 1000000;
			item.rare = 5;
		}	
	}
}