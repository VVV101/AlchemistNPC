using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class MindBurn : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mind Burn");
			Description.SetDefault("Your mind is burning!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Mind Burn");
			Description.AddTranslation(GameCulture.Russian, "Горение Разума");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 9999999;
        }
	}
}
