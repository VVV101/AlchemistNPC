using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class UgandanWarrior : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Ugandan Warrior");
			Description.SetDefault("FO DE QWEEN!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Воин Уганды");
			Description.AddTranslation(GameCulture.Russian, "ЗА КОРОЛЕВУ!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("UgandanWarrior")] > 0)
			{
				modPlayer.uw = true;
			}
			if (!modPlayer.uw)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}