using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class WatcherCrystal : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Watcher Crystal");
			Description.SetDefault("The powers of galaxy supports you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Кристалл-наблюдатель");
			Description.AddTranslation(GameCulture.Russian, "Силы Галактики поддерживают вас"); 
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("WatcherCrystal")] > 0)
			{
				modPlayer.watchercrystal = true;
			}
			if (!modPlayer.watchercrystal)
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