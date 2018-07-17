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

            DisplayName.AddTranslation(GameCulture.Chinese, "狂暴组件");
            Tooltip.AddTranslation(GameCulture.Chinese, "把子弹转变成致命的橓裂弹\n他们看起来就像是叶绿弹和水晶尘子弹的疯狂组合\n给予狙击镜的效果 (10% 的额外远程伤害和暴击, 允许缩放)\n拥有弹药箱效果\n隐藏可见性关闭狙击镜的效果\n极大增加电疗效果\n'上帝从云中探出头来, 轻蔑地看着处在混乱与动荡中的追随者, 世界已陷入火海.\n他丢出一个汽油罐, 并从嘴中吐出一句话：去他妈的.'");
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