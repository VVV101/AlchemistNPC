using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class TornNote2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Torn Note #2");
			Tooltip.SetDefault("''It is not well known, but the Wing of the World allows you to make EGO equipment, which is unique in its own ways."
			+ "\nIf you place it in an empty housing, it would attract a special NPC, called Operator."
			+ "\nAnd if you are wondering what EGO stands for: Extermination of Geometrical Organ.''"
			+ "\nThere is something else, but you can't read it. Not without parts #1 & #3. Maybe the Jeweler could help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Изорванная записка #2");
            Tooltip.AddTranslation(GameCulture.Russian, "'Это малоизвестно, но Крыло Мира позволяет создавать экипировку Э.П.О.С., которая по своему уникальна.\nЕсли Крыло Мира установить в свободном доме, то оно привлечёт особого NPC (Оператора)\nИ если кто-то всё ещё спрашивает, что означает Э.П.О.С., то вот: Экспериментально Полученные Орудия уСмирения.'\nТам есть что-то ещё, но вы не можете прочесть это без других частей. Возможно, вам сможет помочь Ювелир.");

            DisplayName.AddTranslation(GameCulture.Chinese, "破损的笔记 #2");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'它并不是众所周知的, 但是世界之翼可以制作EGO器材, 某种意义上来说是独一无二的." +
                "\n如果世界之翼被放置在了一间空房子里, 就会招来一个特殊的NPC, 叫做操作员" +
                "\n如果你想知道, EGO到底代表了什么, 答案是：Extermination of Geometrical Organ.'" +
                "\n(汉化组无聊科普：全套EGO装备来自于游戏《脑叶公司》, 本模组EGO部分翻译参考中文Wiki)" +
                "\n还有一些内容, 但是你并读不到. 除非你有碎片 #1 和 #3. 也许珠宝师可以帮助你.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 150000;
			item.rare = ItemRarityID.Pink;
		}
	}
}
