using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote9 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #9");
			Tooltip.SetDefault("'If anyone finds this, then know that it's the last note"
			+"\nI found out that the Alchemist could make a Life Elixir..."
			+"\nA legendary brew which increases the max life of the user..."
			+"\nBut to make it, you need an Alchemical Bundle and a Philosopher's stone."
			+"\nWith all of that, he will brew you a portion of Life Elixir.'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #9");
			Tooltip.AddTranslation(GameCulture.Russian, "'Если кто-нибудь найдёт это, то пусть знает, что это - последняя записка.\nЯ выяснил, что Алхимик способен создать Эликсир Жизни\nЭто легендарный напиток, который способен увеличить максимальный запас жизней того, кто его использует...\nНо для его создания тебе потребуется собрать Алхимический набор и найти Философкий Камень.\nПри наличии всего этого, он сварит вам порцию Эликсира Жизни.'"); 
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
