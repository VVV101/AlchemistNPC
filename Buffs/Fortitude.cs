using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Fortitude : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fortitude");
			Description.SetDefault("You cannot be knocked back");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Стойкость");
			Description.AddTranslation(GameCulture.Russian, "Получение урона не отбрасывает вас");
            DisplayName.AddTranslation(GameCulture.Chinese, "刚毅");
            Description.AddTranslation(GameCulture.Chinese, "你无法被击退");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.noKnockback = true;
		}
	}
}
