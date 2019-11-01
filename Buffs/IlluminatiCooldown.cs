using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class IlluminatiCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Illuminati Gift's cooldown");
			Description.SetDefault("Illuminati Gift's effect cannot be activated");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			DisplayName.AddTranslation(GameCulture.Russian, "Откат Дара Иллюминатов");
			Description.AddTranslation(GameCulture.Russian, "Эффект Дара Иллюминатов не может быть активирован");
            DisplayName.AddTranslation(GameCulture.Chinese, "光照会礼物 冷却");
            Description.AddTranslation(GameCulture.Chinese, "无法激活光照会礼物的效果");
        }
	}
}
