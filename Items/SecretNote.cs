using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class SecretNote : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Secret Note");
			Tooltip.SetDefault("'If you are reading this, then know, that you could spawn your own Grim Reaper."
			+ "\nTo do this, you simply need to find the 'Suspicious Looking Scythe', which drops with 1/150 chance from any Treasure Bag in Hardmode."
			+ "\nGLHF!'"
			+ "\nThere seems to be something important, but you can't read it yet. Not without other parts. Maybe Jeweler can help you.");
			DisplayName.AddTranslation(GameCulture.Russian, "Тайная записка");
            Tooltip.AddTranslation(GameCulture.Russian, "'Если ты читаешь это, то знай, что ты можешь призвать своего собственного Жнеца.\nДля того, чтобы сделать это, найти предмет 'Подозрительно Выглядящая Коса'.\nC вероятностью 1/80 выпадает из любой сумки босса в Хардмоде.\nGLHF!'");

            DisplayName.AddTranslation(GameCulture.Chinese, "秘密笔记");
            Tooltip.AddTranslation(GameCulture.Chinese, "'如果你阅读这篇文章, 之后就会知道, 你可以召唤出自己的死神." +
                "\n要做到这一点, 你需要找到一个叫做“可疑镰刀”的物品, 它有1/150的几率从任意肉后宝藏袋中掉落." +
                "\nGLHF!(祝你好运)" +
                "\n还有一些内容, 但是你并读不到. 除非你有其它碎片.. 也许珠宝师可以帮助你'");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 99;
			item.value = 1000000;
			item.rare = 5;
		}	
	}
}