using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class TwilightLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Leggings (O-02-63)");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречные Поножи (O-02-63)"); 
			Tooltip.SetDefault("''Efforts of three birds to defeat the beast became one."
			+ "\nIt could stop countless incidents but you’d have to be prepared to step into the Black Forest.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\n30% increased movement speed");
            Tooltip.AddTranslation(GameCulture.Russian, "''Усилия трёх птиц, чтобы одолеть Зверя, стали едиными.\nОно способно остановить бесчисленные несчастные случаи.\nНо вам нужно быть готовыми, чтобы войти в Тёмный Лес.''\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 30%");

            DisplayName.AddTranslation(GameCulture.Chinese, "薄暝袜统 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'为了击退黑森林里的可怕“怪物”, 三只鸟齐心协力, 合为一体.'\n'它能避免很多无辜的人遇害, 但在那之前, 你必须做好万无一失的准备, 去踏入那片黑暗而又绝望的森林.'\n[c/FF0000:EGO 盔甲]\n增加30%移动速度");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.30f;
			player.AddBuff(mod.BuffType("BigBirdLamp"), 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JustitiaLeggings");
			recipe.AddIngredient(null, "BigBirdLamp");
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}