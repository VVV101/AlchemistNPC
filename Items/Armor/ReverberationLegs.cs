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
	public class ReverberationLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation Leggings (T-04-53)");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Реверберации (T-04-53)"); 
			Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases movement speed by 25%");
            Tooltip.AddTranslation(GameCulture.Russian, "Гладкая поверхность тверда, как будто была усилена несколько раз.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 25%");

            DisplayName.AddTranslation(GameCulture.Chinese, "余香裤子 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'经过数次加工处理后, 这件护甲的表面变得光滑而又坚硬.'\n[c/FF0000:EGO 盔甲]\n增加25%移动速度");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 9;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddIngredient(ItemID.DynastyWood, 80);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}