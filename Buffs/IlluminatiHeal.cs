using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class IlluminatiHeal : ModBuff
	{
		public static int count = 0;
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Illuminati Heal");
			Description.SetDefault("Healing up to 75% HP");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			longerExpertDebuff = false;
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Лечение иллюминатов");
			Description.AddTranslation(GameCulture.Russian, "Лечение до 75% ХП");
            DisplayName.AddTranslation(GameCulture.Chinese, "光照会之愈");
            Description.AddTranslation(GameCulture.Chinese, "回复75%生命值");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.statLife < player.statLifeMax2)
			{
				if (count >= 12)
				{
				count = 0;
				player.statLife += 20;
				player.HealEffect(20, true);
				}
				count++;
			}
			if (player.statLife >= player.statLifeMax2)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
