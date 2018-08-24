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
			+"\nAccuracy, Blood, Combat, Frenzy, Glowing, Holy, Dash");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Ториума");
			Description.AddTranslation(GameCulture.Russian, "Идеальное сочетание баффов Ториум мода");
            DisplayName.AddTranslation(GameCulture.Chinese, "万能药剂包");
            Description.AddTranslation(GameCulture.Chinese, "完美结合了以下药剂包的Buff：\n坦克药剂包、魔法药剂包、射手药剂包以及召唤师药剂包");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			player.meleeSpeed += 0.18f;
			player.pickSpeed -= 0.1f;
			player.moveSpeed += 0.1f;
			player.armorPenetration += 3;
			player.meleeDamage += 0.10f;
			player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.thrownCrit += 6;
			player.discount = true;
			player.dash = 1;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("CritChance")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("BloodRush")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("CombatProwess")] =true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("Frenzy")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("RadiantBoost")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("HolyBonus")] = true;
			player.buffImmune[ModLoader.GetMod("ThoriumMod").BuffType("DashBuff")] = true;
				if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
				ThoriumBoosts(player);
				}
				if (ModLoader.GetLoadedMods().Contains("Redemption"))
				{
				RedemptionBoost(player);
				}
		}
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>(Redemption);
            RedemptionPlayer.druidCrit += 6;
        }
		private readonly Mod Redemption = ModLoader.GetMod("Redemption");
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>(Thorium);
            ThoriumPlayer.symphonicCrit += 6;
			ThoriumPlayer.radiantBoost += 0.1f;
            ThoriumPlayer.radiantCrit += 6;
			ThoriumPlayer.healBonus += 5;
        }
		
		private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
	}
}
