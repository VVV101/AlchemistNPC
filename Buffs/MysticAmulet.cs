using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class MysticAmulet : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
			DisplayName.SetDefault("Mystic Amulet");
			Description.SetDefault("Allows to fly freely");
			DisplayName.AddTranslation(GameCulture.Russian, "Мистический Амулет");
            Description.AddTranslation(GameCulture.Russian, "Позволяет свободно летать");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘护符");
            Description.AddTranslation(GameCulture.Chinese, "可以自由飞翔");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType("MysticAmulet"), player);
			player.buffTime[buffIndex] = 10;
			player.noKnockback = true;
			player.noFallDmg = true;
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>(mod);
			modPlayer.MysticAmuletMount = true;
			modPlayer.fc++;
			if (modPlayer.fc == 40)
			{
				modPlayer.fc = 0;
			}
		}
	}
}
