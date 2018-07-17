using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class LongInvincible : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Longer Invincibility");
			Description.SetDefault("Your invincibility time is increased");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Продлённая неуязвимость");
			Description.AddTranslation(GameCulture.Russian, "Ваш период неуязвимости увеличен"); 
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.longInvince = true;
		}
	}
}
