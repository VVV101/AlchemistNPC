using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class RampageComponents : ModItem
	{

		public static bool sscope = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rampage Components");
			Tooltip.SetDefault("Turns Musket Balls into deadly Chloroshard Bullets"
			+ "\nThey work like crazy combination of Chlorophyte and Crystal Dust Bullets"
			+ "\nGives effect of Sniper Scope (10% bonus ranged damage and crit, ability to zoom)"
			+ "\nAmmo Reservation Effect"
			+ "\nUse item to disable scoping effect and use again to enable"
			+ "\nAnd the lord poked his head out from the patron clouds,"
			+ "\nto look down on his followers in chaos and anarchy as the world is already aflame,"
			+ "\nout he tossed an canister of gasoline and out from his mouth, his words were: Screw it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Компоненты Буйства");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращяет мушкетные пули в смертоносные Хлорофитово-осколочные пули\nОни работают как безумная комбинация Хлорифитовых и Пыле-кристальных пуль\nДаёт эффект Снайперского прицела \n10% бонусного урона и шанса критического удара для дальнего боя\nЭффект Экономии Патронов\nИспользуйте предмет в руках для выключения эффекта Снайперского прицела, используйте вновь для включения\nAnd the lord poked his head out from the patron clouds,\nto look down on his followers in chaos and anarchy as the world is already aflame,\nout he tossed an canister of gasoline and out from his mouth, his words were: Screw it."); 
		}
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.value = 50000;
			item.rare = 9;
			item.accessory = true;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = false;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>(mod).Rampage = true;
			if (sscope)
			{
				player.scope = true;
			}
			player.ammoPotion = true;
			player.rangedDamage += 0.1f;
			player.rangedCrit += 10;
		}

		public override bool UseItem(Player player)
		{
			if (sscope == true)
			{
			sscope = false;
			Main.PlaySound(SoundID.MenuClose, player.position, 0);
			string key = "Mods.AlchemistNPC.Change1";
			Color messageColor = Color.Orange;
			Main.NewText(Language.GetTextValue(key), messageColor);
			}
			else
			{
			sscope = true;
			Main.PlaySound(SoundID.MenuOpen, player.position, 0);
			string key = "Mods.AlchemistNPC.Change2";
			Color messageColor = Color.Orange;
			Main.NewText(Language.GetTextValue(key), messageColor);
			}
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalDustBullet", 3996);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}