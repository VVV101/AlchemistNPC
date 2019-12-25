using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Madness : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Madness Unleashed");
			Description.SetDefault("Pure madness");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Выпущенное безумие");
			Description.AddTranslation(GameCulture.Russian, "Чистое безумие");
            DisplayName.AddTranslation(GameCulture.Chinese, "疯狂释放");
            Description.AddTranslation(GameCulture.Chinese, "纯粹的疯狂");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.confused = true;
		}
	}
}