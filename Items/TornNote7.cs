using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote7 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #7");
			Tooltip.SetDefault("'Continuing on the Ultimate Accessories, there are 2 more."
			+"\nOne of them is the Autoinjector." 
			+"\nIt increases all damage by 10% and crit by 8%."
			+"\nIt also grants you permanently the effect of the Universal Combination."
			+"\nHowever, the Autoinjector is pretty expensive as it requires a Masks Bundle..."
			+"\nAnther one is Bast's Scroll."
			+"\nIt increases Melee/Throwing damage & crit by 10%, gives 10% damage reduction."
			+"\nIt also gives the abilities of a Master Ninja and allows a triple jump."
			+"\nBut its most powerful abilities are:"
			+"\nThrowing weapons go through tiles and any weapon destroys enemy defense totally...'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #7");
			Tooltip.AddTranslation(GameCulture.Russian, "'Не считая всех Ультимативных Аксессуаров, эти 2 более необычны.\nОдин из них - это Автоинъектор. Он увеличивает все виды урона на 10% и шансы критического удара на 8%\nТакже он даёт постоянный эффект Комбинации Универсала.\nНо он очень дорог в крафте, поскольку требует Набор Масок...\nДругой же - Свиток Баст.\nОн повышает урон и шанс критического удара ближнебойного/метательного оружия на 10%, а также на 10% повышает поглощение урона..\nЕщё он даёт умения Мастера Ниндзя и позволяет прыгать 3 раза.\nНо его самое могучие способности, это:\nМетательные атаки проходят сквозь блоки, а любые атаки разрушают броню противника полностью..."); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 250000;
			item.rare = 5;
		}
	}
}
