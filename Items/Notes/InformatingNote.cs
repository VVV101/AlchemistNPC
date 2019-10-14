using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class InformatingNote : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Informating Note");
			Tooltip.SetDefault("No Treasure Bags available yet."
			+"\nBeat Skeletron to unlock the first wave.");
			DisplayName.AddTranslation(GameCulture.Russian, "Информирующая Записка");
            Tooltip.AddTranslation(GameCulture.Russian, "Нет доступных Сумок Боссов.\nПобедите Скелетрона, чтобы разблокировать первую волну.");
			DisplayName.AddTranslation(GameCulture.Chinese, "说明笔记");
			Tooltip.AddTranslation(GameCulture.Chinese, "没有可用的宝藏袋.\n击败骷髅王以解锁第一波.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.rare = 3;
		}	
	}
}