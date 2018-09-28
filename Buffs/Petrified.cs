using Terraria;
using Terraria.ModLoader;
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
			DisplayName.AddTranslation(GameCulture.Russian, "Окаменён");
			Description.AddTranslation(GameCulture.Russian, "Вы полностью обращены в камень");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.stoned = true;
		}
	}
}