using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote8 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #8");
			Tooltip.SetDefault("'I found one ancient scroll which had pretty valuable information..."
			+"\nIt said that Golem could contain laboratory journal from Witch, called Fuaran, inside its body."
			+"\nIt could massively increase magical potential of any mage, weak or powerful - that doesn't matter..."
			+"\nThat journal could be great experience for everyone. I wonder if anyone would ever find it...'");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #8");
			Tooltip.AddTranslation(GameCulture.Russian, "'Я нашёл один древний свиток с весьма значительной информацией...\nТам сказано что Голем хранит внутри своего тела лабораторный журнал Ведьмы, известной как Фуаран.\nОн способен значительно увеличить магический потенциал любого мага, слабого или сильного - нет значения...\nЭтот журнал может быть важным опытом для любого. Хотел бы я узнать, найдётся ли он когда-нибудь...'"); 
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