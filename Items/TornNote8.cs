using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote8 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #8");
			Tooltip.SetDefault("'I once found an ancient scroll which had pretty valuable information..."
			+"\nIt was said that the Golem can contain the laboratory journal from the Witch, called Fuaran, inside its body."
			+"\nIt can massively increase the magical potential of any mage, weak or powerful - that doesn't matter..."
			+"\nThat journal can be a great experience for everyone. I wonder if anyone will ever find it...'"
			+"\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #8");
			Tooltip.AddTranslation(GameCulture.Russian, "'Я нашёл один древний свиток с весьма значительной информацией...\nТам сказано что Голем хранит внутри своего тела лабораторный журнал Ведьмы, известной как Фуаран.\nОн способен значительно увеличить магический потенциал любого мага, слабого или сильного - нет значения...\nЭтот журнал может быть важным опытом для любого. Хотел бы я узнать, найдётся ли он когда-нибудь...'\nЗдесь ещё есть что-то важное, но вы не можете это прочесть. Не без других частей.\nВозможно, Ювелир сможет помочь."); 
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
