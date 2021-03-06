using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Poro : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Poro");
			Description.SetDefault("This creature was sealed in this Amulet."
				+ "\nWorthy of those who can return it to it's proper glory.");
			DisplayName.AddTranslation(GameCulture.Russian, "Поро");
            Description.AddTranslation(GameCulture.Russian, "Это существо было запечатано в амулете.\nДостойное тех, кто может освободить его.");
            DisplayName.AddTranslation(GameCulture.Chinese, "魄罗");
            Description.AddTranslation(GameCulture.Chinese, "这个生物被封印在这个护身符里\n只有高尚之人才能释放它, 恢复其原有的荣光.");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("Poro"), player);
			player.buffTime[buffIndex] = 10;
			player.endurance += 0.15f;
			player.statDefense += 10;
			player.noKnockback = true;
			player.noFallDmg = true;
		}
	}
}
