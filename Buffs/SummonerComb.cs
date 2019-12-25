using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class SummonerComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Summoner Combination");
			Description.SetDefault("Combination of Summoning, Bewitched and Wrath buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Призывателя");
			Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Призыва, Колдовства и Гнева");
            DisplayName.AddTranslation(GameCulture.Chinese, "召唤师药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：召唤, 迷人, 怒气");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.AllDamage10 = true;
			++player.maxMinions;
			++player.maxMinions;
			player.buffImmune[110] = true;
			player.buffImmune[115] = true;
			player.buffImmune[150] = true;
			if (ModLoader.GetMod("MorePotions") != null)
			{
				if (player.HasBuff(mod.BuffType("MorePotionsComb")) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")))
				{
					--player.maxMinions;
				}
			}
		}
	}
}
