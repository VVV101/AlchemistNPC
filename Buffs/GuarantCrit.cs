using Terraria;
using Terraria.ModLoader;
using AlchemistNPC.NPCs;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class GuarantCrit : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Guaranteed Crit");
			Description.SetDefault("Your next attack would be critical");
			Main.persistentBuff[Type] = true;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Гарантированный Крит");
			Description.AddTranslation(GameCulture.Russian, "Ваша следующая атаку ");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeCrit += 100;
			player.rangedCrit += 100;
			player.magicCrit += 100;
			player.thrownCrit += 100;
			player.AddBuff(mod.BuffType("GuarantCrit"), 2);
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).GC == false)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
