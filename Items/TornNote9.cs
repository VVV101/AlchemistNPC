using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote9 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #9");
			Tooltip.SetDefault("'If anyone finds this, then know that this could be the last note"
			+"\nI found out that the Alchemist could make a Life Elixir..."
			+"\nA legendary brew which increases the max life of the user..."
			+"\nBut to make it, you need an Alchemical Bundle and a Philosopher's stone."
			+"\nWith all of that, he will brew you a portion of Life Elixir."
			+"\nOh no... This thing is still chasing me. And Dark Sun is right above my head now."
			+"\nI will use that Portal Device. I just don't wanna die! My only hope is that I will not stuck inbetween worlds...'"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #9");
			Tooltip.AddTranslation(GameCulture.Russian, "'Если кто-нибудь найдёт это, то пусть знает, что это - последняя записка.\nЯ выяснила, что Алхимик способен создать Эликсир Жизни\nЭто легендарный напиток, который способен увеличить максимальный запас жизней того, кто его использует...\nНо для его создания тебе потребуется собрать Алхимический набор и найти Филосовский Камень.\nПри наличии всего этого, он сварит вам порцию Эликсира Жизни.\nО нет... Оно всё ещё преследует меня. И Тёмное Солнце светит прямо над моей головой.\nЯ использую портальное устройство. Я не хочу умирать! Моя единственная надежда - это то, что я не застряну в междумирье...'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь."); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 500000;
			item.rare = 5;
		}
	}
}
