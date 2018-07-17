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
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Стойкость");
			Description.AddTranslation(GameCulture.Russian, "Вам нельзя отбросить при атаке"); 
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.noKnockback = true;
		}
	}
}
