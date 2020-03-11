using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Equippable
{
	public class Symbiote : ModItem
	{
		public static int p = 5;
		public static int r = 2;
		public static int d = 2;
		public static int e = 2;
		public static int s = 10;
		public static bool show = false;
		public static bool SS = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Symbiote");
			Tooltip.SetDefault("Lowers cooldown of healing potions"
				+ "\nIncreases length of invincibility after taking hit"
				+ "\nHas two states (Offense(>50% HP) and Defense (<50% HP))"
				+ "\nOffensive state increases attack speed by 10-20%"
				+ "\nDefensive state greatly increases regeneration, defense and damage reduction"
				+ "\nStats boosts are shown when accessory is equipped");
				DisplayName.AddTranslation(GameCulture.Russian, "Симбионт");
            Tooltip.AddTranslation(GameCulture.Russian, "Усиливает регенерацию\nУменьшает откат зелий лечения\nУвеличивает период неуязвимости после получения урона\nИмеет 2 состояния (Боевое и Защитное)\nБоевое состояние увеличивает скорость ближнего боя на 20%\nАктивируется когда здоровье >50%\nЗащитное состояние сильно усиливает регенерацию, повышает защиту и поглощение урона\nАктивируется когда здоровье <50%");
			DisplayName.AddTranslation(GameCulture.Chinese, "共生体");
			Tooltip.AddTranslation(GameCulture.Chinese, "减少生命药水冷却时间\n增加受伤无敌帧\n拥有两种模式 (侵略(>50% HP)/守御(<50% HP))\n攻击模式下增加10-20%攻击速度\n防御模式下极大增加生命回复, 防御和伤害减免");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return mod.PrefixType("Xenomorphic");
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Item.potionDelay = 2100;
			show = true;
			
			if (!Main.hardMode)
			{
				p = 5;
				r = 2;
				d = 2;
				e = 5;
				s = 10;
				player.allDamage += 0.05f;
				player.lifeRegen += 2;
				player.statDefense += 2;
				player.endurance += 0.05f;
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				p = 7;
				r = 4;
				d = 4;
				e = 7;
				s = 15;
				player.allDamage += 0.07f;
				player.lifeRegen += 4;
				player.statDefense += 4;
				player.endurance += 0.07f;
			}
			if (NPC.downedMoonlord)
			{
				p = 10;
				r = 6;
				d = 6;
				e = 10;
				s = 20;
				player.allDamage += 0.1f;
				player.lifeRegen += 6;
				player.statDefense += 6;
				player.endurance += 0.1f;
			}
			player.meleeCrit += p;
			player.rangedCrit += p;
			player.magicCrit += p;
			player.thrownCrit += p;
			
			if (player.statLife > player.statLifeMax2/2)
			{
				((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).Symbiote = true;
				player.AddBuff(mod.BuffType("SymbOff"), 2, true);
				SS = true;
			}
			if (player.statLife < player.statLifeMax2/2)
			{
				player.AddBuff(mod.BuffType("SymbDef"), 2, true);
				SS = false;
				if (!Main.hardMode)
				{
					player.lifeRegen += 3;
					player.statDefense += 8;
					player.endurance += 0.05f;
					r += 3;
					d += 8;
					e += 5;
				}
				if (Main.hardMode && !NPC.downedMoonlord)
				{
					player.lifeRegen += 6;
					player.statDefense += 11;
					player.endurance += 0.08f;
					r += 6;
					d += 11;
					e += 8;
				}
				if (NPC.downedMoonlord)
				{
					player.lifeRegen += 9;
					player.statDefense += 14;
					player.endurance += 0.1f;
					r += 9;
					d += 14;
					e += 10;
				}
			}
			player.longInvince = true;
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				ThoriumBoosts(player);
			}
			if (ModLoader.GetMod("Redemption") != null)
			{
				RedemptionBoost(player);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				CalamityBoost(player);
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (!item.social && show)
			{
				string text1 = "+" + p + "% damage";
				string text2 = "+" + p + "% critical strike chance";
				string text3 = "+" + r + " life regeneration";
				string text4 = "+" + d + " defense";
				string text5 = "+" + e + "% damage reduction";
				string text6 = "+" + s + "% attack speed";
				TooltipLine line = new TooltipLine(mod, "text1", text1);
				TooltipLine line2 = new TooltipLine(mod, "text2", text2);
				TooltipLine line3 = new TooltipLine(mod, "text3", text3);
				TooltipLine line4 = new TooltipLine(mod, "text4", text4);
				TooltipLine line5 = new TooltipLine(mod, "text5", text5);
				TooltipLine line6 = new TooltipLine(mod, "text6", text6);
				line.overrideColor = Color.LimeGreen;
				line2.overrideColor = Color.LimeGreen;
				line3.overrideColor = Color.LimeGreen;
				line4.overrideColor = Color.LimeGreen;
				line5.overrideColor = Color.LimeGreen;
				line6.overrideColor = Color.LimeGreen;
				tooltips.Insert(8,line);
				tooltips.Insert(9,line2);
				tooltips.Insert(10,line3);
				tooltips.Insert(11,line4);
				tooltips.Insert(12,line5);
				if (SS) tooltips.Insert(13,line6);
			}
		}
		
		private void CalamityBoost(Player player)
        {
			CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
            CalamityPlayer.throwingCrit += p;
        }
		
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            RedemptionPlayer.druidCrit += p;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            ThoriumPlayer.symphonicCrit += p;
            ThoriumPlayer.radiantCrit += p;
        }
	}
}