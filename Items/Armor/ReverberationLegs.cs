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
			Tooltip.AddTranslation(GameCulture.Russian, "Гладкая поверхность всё так же прочна, как будто не была восстановлена несколько раз.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает скорость передвижения на 25%");
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