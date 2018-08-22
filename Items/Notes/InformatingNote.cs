using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class InformatingNote : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Informating Note");
			Tooltip.SetDefault("No Treasure Bags available yet."
			+"\nBeat Skeletron to unlock the first wave.");
			DisplayName.AddTranslation(GameCulture.Russian, "Информирующая Записка");
            Tooltip.AddTranslation(GameCulture.Russian, "Нет доступных Сумок Боссов.\nПобедите Скелетрона, чтобы разблокировать первую волну.");
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