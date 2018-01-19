using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class NinjaSkill : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Description.SetDefault("Now you have Ninja abilities");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Ниндзя");
			Description.AddTranslation(GameCulture.Russian, "Теперь вы обладаете способностями Ниндзя"); 
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
			player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
            player.thrownCrit += 5;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
	}
}
