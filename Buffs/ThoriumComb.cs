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
	public class ThoriumComb : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			return ModLoader.GetMod("ThoriumMod") != null;
		}
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Thorium Combination");
			Description.SetDefault("Perfect sum of Thorium buffs"
			+"\nAssassin, Blood, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Ториума");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание баффов Ториум мода");
            DisplayName.AddTranslation(GameCulture.Chinese, "瑟银药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了瑟银药剂的Buff：\n精准药剂、嗜血药剂、狂热药剂、狂怒药剂、光辉药剂、圣洁药剂以及动能药剂");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("AssassinBuff")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("BloodRush")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Frenzy")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("RadiantBoost")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("HolyBonus")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("CreativityDrop")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("EarwormBuff")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("InspirationReach")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("HydrationBuff")] = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player, ref buffIndex);
			}
		}
		
		private void ThoriumBoosts(Player player, ref int buffIndex)
        {
			Thorium.GetBuff("AssassinBuff").Update(player, ref buffIndex);
			Thorium.GetBuff("BloodRush").Update(player, ref buffIndex);
			Thorium.GetBuff("Frenzy").Update(player, ref buffIndex);
			Thorium.GetBuff("RadiantBoost").Update(player, ref buffIndex);
			Thorium.GetBuff("HolyBonus").Update(player, ref buffIndex);
			Thorium.GetBuff("CreativityDrop").Update(player, ref buffIndex);
			Thorium.GetBuff("EarwormBuff").Update(player, ref buffIndex);
			Thorium.GetBuff("InspirationReach").Update(player, ref buffIndex);
			Thorium.GetBuff("HydrationBuff").Update(player, ref buffIndex);
        }
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
