using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TornNote1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #1");
			Tooltip.SetDefault("'Some legends says that thing called Otherworldly Amulet could be gotten from Dungeon Guardian.'"
			+ "\nThere is something else, but you couldn't read this. Not without parts #2 & #3.. Maybe Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #1");
			Tooltip.AddTranslation(GameCulture.Russian, "Некоторые легенды говорят что вещь, называемая 'Амулет Иного Мира' может быть добыта из Хранителя Данжа.\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир."); 
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