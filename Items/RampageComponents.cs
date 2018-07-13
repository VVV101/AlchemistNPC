using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPC.Items
{
	public class RampageComponents : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rampage Components");
			Tooltip.SetDefault("Turns Musket Balls into deadly Chloroshard Bullets"
			+ "\nThey work like crazy combination of Chlorophyte and Crystal Dust Bullets"
			+ "\nGives effect of Sniper Scope (10% bonus ranged damage and crit, ability to zoom)"
			+ "\nAmmo Reservation Effect"
			+ "\nHide visual to disable Sniper Scope effect"
			+ "\nEmpowers any Electrospheres greatly"
			+ "\n''And the lord poked his head out from the patron clouds,"
			+ "\nto look down on his followers in chaos and anarchy as the world is already aflame,"
			+ "\nout he tossed an canister of gasoline and out from his mouth, his words were: Screw it.''");
			DisplayName.AddTranslation(GameCulture.Russian, "Компоненты Буйства");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращяет мушкетные пули в смертоносные Хлорофитово-осколочные пули\nОни работают как безумная комбинация Хлорифитовых и Пыле-кристальных пуль\nДаёт эффект Снайперского прицела \n10% бонусного урона и шанса критического удара для дальнего боя\nЭффект Экономии Патронов\nОтключение видимости выключает эффект Снайперского Прицела\n''And the lord poked his head out from the patron clouds,\nto look down on his followers in chaos and anarchy as the world is already aflame,\nout he tossed an canister of gasoline and out from his mouth, his words were: Screw it.''"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 30;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>(mod).Rampage = true;
			if (!hideVisual)
			{
				player.scope = true;
			}
			player.ammoPotion = true;
			player.rangedDamage += 0.1f;
			player.rangedCrit += 10;
			AlchemistNPC.XtraT = true;
		}

		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalDustBullet", 3996);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 3996);
			recipe.AddIngredient(ItemID.SniperScope);
			recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}