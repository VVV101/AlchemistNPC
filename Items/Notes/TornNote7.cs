using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote7 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #7");
			Tooltip.SetDefault("''Continuing on the Ultimate Accessories, there are 2 more."
			+"\nOne of them is the Autoinjector."
			+"\nIt increases all damage by 10% and crit by 8%."
			+"\nPermanently grants you the effect of the Universal Combination."
			+"\nCan be consumed for permanent effects:"
			+"\nBuffs never wear off after death and cooldown of healing potions is reduced"
			+"\nHowever, the Autoinjector is pretty expensive as it requires a Mask Bundle..."
			+"\nAnother one is Bast's Scroll."
			+"\nIncreases Melee/Throwing damage & crit by 15%, gives 10% damage reduction."
			+"\nGives the abilities of a Master Ninja and allows a triple jump."
			+"\nAnd the most powerful abilities are:"
			+"\nThrowing weapons go through tiles and melee/throwing weapons ruin enemy's defense...''"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #7");
            Tooltip.AddTranslation(GameCulture.Russian, "'Продолжая тему Ультимативных Аксессуаров, осталость рассмотреть еще два.\nОдин из них - это Автоинъектор. Он увеличивает все виды урона на 10% и шансы критического удара на 8%\nТакже он даёт постоянный эффект Комбинации Универсала.\nТакже он может быть потрачен для получения постоянного эффекта:\nБаффы не будут пропадать после смерти и уменьшится откат зелий лечения.\nНо он очень дорог в крафте, поскольку требует Набор Масок...\nДругой же - Свиток Баст.\nОн повышает урон и шанс критического удара оружия ближнего/метательного оружия на 15%\nЕщё он на 10% повышает поглощение урона, даёт умения Мастера Ниндзя и позволяет прыгать 3 раза.\nНо его самое могучие способности, это:\nМетательные атаки проходят сквозь блоки\n Ближнее и метательное оружие разрушают броню противника...'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #7");
            Tooltip.AddTranslation(GameCulture.Chinese, "'不算其它终极饰品，这两个更特别." +
                "\n其中之一是自动注射器." +
                "\n它增加了10%所有伤害和8%暴击." +
                "\n同时永久给予万能药剂包Buff." +
                "\n但是自动注射器因为需要面具捆绑包所以制作起来十分的困难..." +
                "\n另一个是巴斯特卷轴." +
                "\n它增加了10%的近战/投掷伤害, 给予了10%伤害免疫." +
                "\n也给予了忍者大师的效果并且允许三段跳." +
                "\n但是它给予的最强大的能力是:" +
                "\n投掷武器能穿透物块并且所有的武器都能完全穿透敌人护甲...'" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 250000;
			item.rare = ItemRarityID.Pink;
		}
	}
}
