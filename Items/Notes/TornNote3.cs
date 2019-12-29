using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #3");
			Tooltip.SetDefault("''Defeating all Mechanical Bosses will allow you to make a special Vending Machine."
			+ "\nIts drinks can help you overcome great threats and dangers."
			+ "\nBut be careful! If you use it more than 10 times, it will release a random Mechanical Boss!"
			+ "\nAfter that, the counter resets to 0, so you can use it again after destroying or evading the boss.''"
			+ "\nThere is something else, but you can't read it. Not without parts #1 & #2. Maybe the Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #3");
            Tooltip.AddTranslation(GameCulture.Russian, "'Когда ты одолеешь всех Механических Боссов, ты сможешь сделать особый Торговый Автомат.\nНапитки из него могут помочь тебе преодолеть великие угрозы и опасности.\nНо будь осторожен! Если воспользуешься ей более 10 раз, то она призовёт случайного Механического Босса.\nЭто сбросит счётчик до 0, что позволит тебе вновь ей воспользоваться после того, как ты победишь или сбежишь от Босса'\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #3");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'当你击败所有的机械Boss之后, 你可以制造特殊的自动售卖机." +
                "\n它的饮料可以帮助你度过一些巨大的威胁和危险." +
                "\n但是要小心! 当你使用超过10次之后, 它会释放一些随机的机械Boss! " +
                "\n它会让机器计数器降为0, 所以你只有在打败这些Boss或逃跑后才能再次使用它.'" +
                "\n还有一些内容, 但是你并读不到. 除非你有碎片 #1 和 #2. 也许珠宝师可以帮助你.");
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
