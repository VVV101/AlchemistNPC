using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote8 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #8");
			Tooltip.SetDefault("''I once found an ancient scroll which had pretty valuable information..."
			+"\nIt was said that the Golem can contain the laboratory journal from the Witch, called Fuaran, inside its body."
			+"\nIt can massively increase the magical potential of any mage, weak or powerful - that doesn't matter..."
			+"\nThat journal can be a great experience for everyone. I wonder if anyone will ever find it...''"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #8");
            Tooltip.AddTranslation(GameCulture.Russian, "'Я нашла один древний свиток с весьма ценной информацией...\nТам сказано что Голем хранит внутри своего тела лабораторный журнал Ведьмы, известный как Фуаран.\nОн способен значительно увеличить магический потенциал любого мага, слабого или сильного - нет значения...\nЭтот журнал может быть важным опытом для любого. Хотела бы я узнать, найдётся ли он когда-нибудь...'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #8");
            Tooltip.AddTranslation(GameCulture.Chinese, "'我发现了一个古老的卷轴，里面有很多有价值的信息..." +
                "\n它说石头人可能有来自女巫的实验室日志, 叫做魔泉书, 就在它的身体里." +
                "\n它可以大量增加法师的潜能, 羸弱抑或强大 - 这并不重要..." +
                "\n这份日志对每个人来说都是一份极大的经验. 我想知道有没有人可以得到它...'" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片. 也许珠宝师可以帮助你.");
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
