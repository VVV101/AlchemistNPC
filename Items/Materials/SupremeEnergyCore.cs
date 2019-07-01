using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class SupremeEnergyCore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Supreme Energy Core");
			Tooltip.SetDefault("Infinite source of Energy");
			DisplayName.AddTranslation(GameCulture.Russian, "Превосходное энергетическое ядро");
			Tooltip.AddTranslation(GameCulture.Russian, "Бесконечный источник Энергии");
			DisplayName.AddTranslation(GameCulture.Chinese, "至高能量核心");
			Tooltip.AddTranslation(GameCulture.Chinese, "无限能量之源");
        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 5000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnergyCell", 3996);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddIngredient(null, "ChromaticCrystal");
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
