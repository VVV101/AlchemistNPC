using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #3");
			Tooltip.SetDefault("'When you will beat all Mechanical Bosses, you could make special Vending Machine."
			+ "\nIts drinks could help you overcome some great threats and dangers."
			+ "\nBut be careful! If you use it more than 10 times, it will release a random Mechanical Boss!"
			+ "\nThis will reset machine counter to 0, so you could use it again after destroying or evading the boss.'"
			+ "\nThere is something else, but you couldn't read this. Not without parts #1 & #2. Maybe Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #3");
			Tooltip.AddTranslation(GameCulture.Russian, "'Когда ты одолеешь всех Механических Боссов, ты сможешь сделать особую Машину по продаже напитков.\nОни могут помочь тебе преодолеть великие угрозы и опасности.\nНо будь осторожен! Если воспользуешься ей более 10 раз, то она призовёт случайного Механического Босса.\nЭто сбросит счётчик Машины на 0, что позволит тебе вновь ей воспользоваться после того, как ты победишь или сбежишь от Босса'\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир."); 
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