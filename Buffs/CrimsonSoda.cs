using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class CrimsonSoda : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crimson Soda");
			Description.SetDefault("Greatly increases life regeneration");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Алая Сода");
			Description.AddTranslation(GameCulture.Russian, "Значительно увеличивает регенерацию здоровья");

            DisplayName.AddTranslation(GameCulture.Chinese, "绯红苏打加持");
            Description.AddTranslation(GameCulture.Chinese, "极大增加生命回复速度");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 10;
		}
	}
}
