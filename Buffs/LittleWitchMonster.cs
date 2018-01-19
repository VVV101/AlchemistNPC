using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class LittleWitchMonster : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Little Witch Monster");
			Description.SetDefault("So that's what it contains...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Монстр Маленькой Ведьмы");
			Description.AddTranslation(GameCulture.Russian, "Так вот что было внутри..."); 
		}

		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("LittleWitchMonster")] > 0)
			{
				modPlayer.lwm = true;
			}
			if (!modPlayer.lwm)
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