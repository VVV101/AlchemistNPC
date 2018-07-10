using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Fortitude : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Fortitude");
			Description.SetDefault("You cannot be knockbacked");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Стойкость");
			Description.AddTranslation(GameCulture.Russian, "Вам нельзя отбросить при атаке");
            DisplayName.AddTranslation(GameCulture.Chinese, "刚毅");
            Description.AddTranslation(GameCulture.Chinese, "你无法被击退");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.noKnockback = true;
		}
	}
}
