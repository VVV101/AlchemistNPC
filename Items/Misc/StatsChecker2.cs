using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class StatsChecker2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pip-Boy 4K");
			Tooltip.SetDefault("Shows most of the player's stats while in your inventory"
			+"\nLeft click to teleport home, hotkey to open teleportation menu");
			DisplayName.AddTranslation(GameCulture.Russian, "Пип-Бой 4K");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, то показывает большинство параметров игрока\nЛевый клик телепортирует вас домой, горячая клавиша открывает телепортационное меню");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.MagicMirror);
			item.width = 32;
			item.height = 32;
			item.value = 5000000;
			item.rare = 8;
			item.useAnimation = 15;
            item.useTime = 15;
			item.consumable = false;
			item.noUseGraphic = true;
		}
		
		public override bool UseItem(Player player)
		{
			player.Spawn();
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).PB4K = true;
			player.accWatch = 3;
			player.accDepthMeter = 1;
			player.accCompass = 1;
			player.accFishFinder = true;
			player.accWeatherRadio = true;
			player.accCalendar = true;
			player.accThirdEye = true;
			player.accJarOfSouls = true;
			player.accCritterGuide = true;
			player.accStopwatch = true;
			player.accOreFinder = true;
			player.accDreamCatcher = true;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1 = "Melee damage/critical strike chance boosts are " + (int)((player.meleeDamage*100)-100) + "%" + " / " + (player.meleeCrit-4) + "%";
			string text2 = "Ranged damage/critical strike chance boosts are " + (int)((player.rangedDamage*100)-100) + "%" + " / " + (player.rangedCrit-4) + "%";
			string text3 = "Magic damage/critical strike chance boosts are " + (int)((player.magicDamage*100)-100) + "%" + " / " + (player.magicCrit-4) + "%";
			string text4 = "Thrown damage/critical strike chance boosts are " + (int)((player.thrownDamage*100)-100) + "%" + " / " + (player.thrownCrit-4) + "%";
			string text5 = "Summoner damage boost is " + (int)((player.minionDamage*100)-100) + "%";
			string text6 = "Damage Reduction boost is " + (int)(player.endurance*100) + "%";
			string text7 = "Movement speed boost is " + (int)((player.moveSpeed*100)-100) + "%";
			string text8 = "Max life boost is " + (player.statLifeMax2 - player.statLifeMax);
			string text9 = "Life Regeneration is " + (player.lifeRegen);
			string text10 = "Mana usage reduction is " + (int)((player.manaCost*100)-100) + "%";
			string text11 = "Max amounts of minions/sentries are " + player.maxMinions + " / " + player.maxTurrets;
			string text12 = "Melee swing time is " + (int)(player.meleeSpeed*100) + "%";
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
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("StatsChecker"));
			recipe.AddIngredient(ItemID.CellPhone);
			recipe.AddIngredient(mod.ItemType("BeachTeleporterPotion"), 10);
			recipe.AddIngredient(mod.ItemType("OceanTeleporterPotion"), 10);
			recipe.AddIngredient(mod.ItemType("DungeonTeleportationPotion"), 10);
			recipe.AddIngredient(mod.ItemType("UnderworldTeleportationPotion"), 10);
			recipe.AddIngredient(mod.ItemType("JungleTeleporterPotion"), 10);
			recipe.AddIngredient(mod.ItemType("TempleTeleportationPotion"), 10);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
