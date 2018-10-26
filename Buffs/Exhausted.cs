using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Exhausted : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Exhausted");
			Description.SetDefault("You cannot use magic now, lowered horizontal flight speed, decreased melee speed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Истощение");
			Description.AddTranslation(GameCulture.Russian, "Вы не можете использовать магию сейчас, снижена скорость горизонтального полёта, понижена скорость ближнего боя");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.silence = true;
			player.meleeSpeed -= 0.15f;
            player.statMana = 0;
			player.moveSpeed -= 0.5f;
        }
	}
}
