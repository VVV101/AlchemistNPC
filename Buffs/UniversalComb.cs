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
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class UniversalComb : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Universal Combination");
			Description.SetDefault("Perfect sum of Tank, Mage, Ranger and Summoner combinations");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Универсальная комбинация");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание Комбинаций Танка, Мага, Стрелка и Призывателя");
            DisplayName.AddTranslation(GameCulture.Chinese, "万能药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下药剂包的Buff：\n坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.AllDamage10 = true;
			modPlayer.AllCrit10 = true;
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			player.magicDamage += 0.25f;
            player.magicCrit += 2;
			player.statManaMax2 += 20;
            player.manaCost -= 0.02f;
			player.manaRegenBuff = true;
			player.archery = true;
			player.ammoPotion = true;
			player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
			player.buffImmune[29] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
			player.buffImmune[110] = true;
			player.buffImmune[112] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[115] = true;
			player.buffImmune[117] = true;
			player.buffImmune[150] = true;
			player.buffImmune[mod.BuffType("BattleComb")] = true;
			player.buffImmune[mod.BuffType("TankComb")] = true;
			player.buffImmune[mod.BuffType("VanTankComb")] = true;
			player.buffImmune[mod.BuffType("RangerComb")] = true;
			player.buffImmune[mod.BuffType("MageComb")] = true;
			player.buffImmune[mod.BuffType("SummonerComb")] = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[5] = true;
			player.buffImmune[6] = true;
			player.buffImmune[7] = true;
			player.buffImmune[14] = true;
			++player.maxMinions;
			++player.maxMinions;
			if (ModLoader.GetMod("MorePotions") != null)
			{
				if (player.HasBuff(mod.BuffType("MorePotionsComb")) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("SoulbindingElixerPotionBuff")))
				{
					--player.maxMinions;
				}
				if (player.HasBuff(mod.BuffType("MorePotionsComb")) || player.HasBuff(ModLoader.GetMod("MorePotions").BuffType("DiamondSkinPotionBuff")))
				{
					player.statDefense -= 8;
				}
			}
		}
	}
}
