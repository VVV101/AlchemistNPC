using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class StatsChecker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pip-Boy 3000");
			Tooltip.SetDefault("Shows most of the player's stats while in your inventory");
			DisplayName.AddTranslation(GameCulture.Russian, "Пип-Бой 3000");
            		Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, то показывает большинство параметров игрока");
			DisplayName.AddTranslation(GameCulture.Chinese, "哔哔小子 3000");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置于物品栏时, 显示玩家的绝大部分属性");
			
			ModTranslation text = mod.CreateTranslation("Pip-Boy3000text1");
            		text.SetDefault("Melee damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.Chinese, "近战伤害/暴击率增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text2");
            		text.SetDefault("Ranged damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.Chinese, "远程伤害/暴击率增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text3");
            		text.SetDefault("Magic damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.Chinese, "魔法伤害/暴击率增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text4");
            		text.SetDefault("Thrown damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.Chinese, "投掷伤害/暴击率增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text5");
            		text.SetDefault("Summoner damage boost is ");
			text.AddTranslation(GameCulture.Chinese, "召唤伤害增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text6");
            		text.SetDefault("Damage Reduction boost is ");
			text.AddTranslation(GameCulture.Chinese, "伤害抗性增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text7");
            		text.SetDefault("Movement speed boost is ");
			text.AddTranslation(GameCulture.Chinese, "移动速度增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text8");
            		text.SetDefault("Max life boost is ");
			text.AddTranslation(GameCulture.Chinese, "最大生命增加");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text9");
            		text.SetDefault("Life regeneration is ");
			text.AddTranslation(GameCulture.Chinese, "生命再生速度");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text10");
            		text.SetDefault("Mana usage reduction is ");
			text.AddTranslation(GameCulture.Chinese, "魔法消耗减少");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text11");
            		text.SetDefault("Max amounts of minions/sentries are ");
			text.AddTranslation(GameCulture.Chinese, "最大召唤物/炮台数量");
            		mod.AddTranslation(text);
			
			text = mod.CreateTranslation("Pip-Boy3000text12");
            		text.SetDefault("Melee swing time is ");
			text.AddTranslation(GameCulture.Chinese, "近战武器挥动");
            		mod.AddTranslation(text);
        	}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 5000000;
			item.rare = ItemRarityID.Yellow;
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text1") + (int)((player.meleeDamage*100)-100) + "%" + " / " + (player.meleeCrit-4) + "%";
			string text2 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text2") + (int)((player.rangedDamage*100)-100) + "%" + " / " + (player.rangedCrit-4) + "%";
			string text3 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text3") + (int)((player.magicDamage*100)-100) + "%" + " / " + (player.magicCrit-4) + "%";
			string text4 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text4") + (int)((player.thrownDamage*100)-100) + "%" + " / " + (player.thrownCrit-4) + "%";
			string text5 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text5") + (int)((player.minionDamage*100)-100) + "%";
			string text6 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text6") + (int)(player.endurance*100) + "%";
			string text7 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text7") + (int)((player.moveSpeed*100)-100) + "%";
			string text8 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text8") + (player.statLifeMax2 - player.statLifeMax);
			string text9 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text9") + (player.lifeRegen);
			string text10 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text10") + (int)((player.manaCost*100)-100) + "%";
			string text11 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text11") + player.maxMinions + " / " + player.maxTurrets;
			string text12 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy3000text12") + (int)(player.meleeSpeed*100) + "%";
			TooltipLine line = new TooltipLine(mod, "text1", text1);
			TooltipLine line2 = new TooltipLine(mod, "text2", text2);
			TooltipLine line3 = new TooltipLine(mod, "text3", text3);
			TooltipLine line4 = new TooltipLine(mod, "text4", text4);
			TooltipLine line5 = new TooltipLine(mod, "text5", text5);
			TooltipLine line6 = new TooltipLine(mod, "text6", text6);
			TooltipLine line7 = new TooltipLine(mod, "text7", text7);
			TooltipLine line8 = new TooltipLine(mod, "text8", text8);
			TooltipLine line9 = new TooltipLine(mod, "text9", text9);
			TooltipLine line10 = new TooltipLine(mod, "text10", text10);
			TooltipLine line11 = new TooltipLine(mod, "text11", text11);
			TooltipLine line12 = new TooltipLine(mod, "text12", text12);
			line.overrideColor = Color.Red;
			line2.overrideColor = Color.LimeGreen;
			line3.overrideColor = Color.SkyBlue;
			line4.overrideColor = Color.Orange;
			line5.overrideColor = Color.MediumVioletRed;
			line6.overrideColor = Color.Gray;
			line7.overrideColor = Color.Green;
			line8.overrideColor = Color.Yellow;
			line9.overrideColor = Color.Brown;
			line10.overrideColor = Color.SkyBlue;
			line11.overrideColor = Color.Magenta;
			line12.overrideColor = Color.Red;
			tooltips.Insert(2,line);
			tooltips.Insert(3,line2);
			tooltips.Insert(4,line3);
			tooltips.Insert(5,line4);
			tooltips.Insert(6,line5);
			tooltips.Insert(7,line6);
			tooltips.Insert(8,line7);
			tooltips.Insert(9,line8);
			tooltips.Insert(10,line9);
			tooltips.Insert(11,line10);
			tooltips.Insert(12,line11);
			tooltips.Insert(13,line12);
		}
	}
}
