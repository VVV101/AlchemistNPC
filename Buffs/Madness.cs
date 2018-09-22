using Terraria;
using Terraria.ModLoader;
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
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.confused = true;
		}
	}
}