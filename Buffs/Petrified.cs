using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Petrified : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Petrified");
			Description.SetDefault("You are completely petrified!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Окаменение");
			Description.AddTranslation(GameCulture.Russian, "Вы окаменели");
            DisplayName.AddTranslation(GameCulture.Chinese, "石化");
            Description.AddTranslation(GameCulture.Chinese, "你完全石化了!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.stoned = true;
		}
	}
}
