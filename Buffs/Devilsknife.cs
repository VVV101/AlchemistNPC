using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Devilsknife : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Description.SetDefault("METAMORPHOSIS!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Кинжал Дьявола");
			Description.AddTranslation(GameCulture.Russian, "МЕТАМОРФОЗА!");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Devilsknife")] > 0)
			{
				modPlayer.devilsknife = true;
			}
			if (!modPlayer.devilsknife)
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