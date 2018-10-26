using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Drainer : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Drain");
			Description.SetDefault("Removes most of defense and endurance while held");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Иссушение");
			Description.AddTranslation(GameCulture.Russian, "Значительно снижает защиту и поглощение урона пока удерживается Поглотитель");
            DisplayName.AddTranslation(GameCulture.Chinese, "抽血");
            Description.AddTranslation(GameCulture.Chinese, "极大降低防御力和耐力");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.endurance -= 0.15f;
			player.statDefense -= 300;
			player.longInvince = false;
        }
	}
}
