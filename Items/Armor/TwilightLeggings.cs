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
			Tooltip.SetDefault("'Efforts of three birds to defeat the beast became one."
			+ "\nIt could stop countless incidents but you’d have to be prepared to step into the Black Forest.'"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\n30% increased movement speed");
			Tooltip.AddTranslation(GameCulture.Russian, "Усилия трёх птиц, чтобы одолеть Зверя, став едиными.\nОно способно остановить бесчисленные несчастные случаи.\nНо вам нужно быть готовыми, чтобы войти в Тёмный Лес.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает скорость передвижения на 30%");
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