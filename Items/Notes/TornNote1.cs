using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #1");
			Tooltip.SetDefault("''Legends say that an Otherworldly Amulet can be obtained by defeating a Dungeon Guardian.''"
			+ "\nThere is something else, but you couldn't read it. Not without parts #2 & #3.. Maybe the Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #1");
            Tooltip.AddTranslation(GameCulture.Russian, "Некоторые легенды говорят что вещь, называемая 'Амулет Иного Мира' может быть добыта из Хранителя Подземелья.\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #1");
            Tooltip.AddTranslation(GameCulture.Chinese, "'有传说称击败地牢守卫可以获得叫做“异界护身符”的物品.'\n还有一些内容, 但是你并读不到. 除非你有碎片 #2 和 #3.. 也许珠宝师可以帮助你.");
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
