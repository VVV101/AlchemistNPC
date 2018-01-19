using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #2");
			Tooltip.SetDefault("'It is not well known, but Wing of the World allows to make EGO equipment, which is unique in some ways."
			+ "\nAnd if anyone still asking, what EGO stands for, then here it is: Extermination of Geometrical Organ.'"
			+ "\nThere is something else, but you couldn't read this. Not without other parts. Maybe Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #2");
			Tooltip.AddTranslation(GameCulture.Russian, "'Это малоизвестно, но Крыло Мира позволяет создавать Э.П.О.С экипировку, которая по своему уникальна.\nИ если кто-то всё ещё спрашивает, что означает Э.П.О.С., то вот: Экспериментально Полученные Орудия уСмирения.'\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир."); 
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