using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class MageComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mage Combination");
			Description.SetDefault("Combination of Magic Power, Mana Regeneration, Clairvoyance, Wrath & Rage buffs");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Мага");
            Description.AddTranslation(GameCulture.Russian, "Сочетание баффов Магической Силы, Регенерации Маны, Ясновидения, Гнева и Ярости");

            DisplayName.AddTranslation(GameCulture.Chinese, "魔法药剂包");
            Description.AddTranslation(GameCulture.Chinese, "包含以下Buff：魔能, 魔力再生, 智慧, 暴怒, 怒气");
        }
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
            player.magicDamage += 0.25f;
			player.magicCrit += 2;
			player.statManaMax2 += 20;
            player.manaCost -= 0.02f;
			player.manaRegenBuff = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[29] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
		}
	}
}
