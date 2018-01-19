using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class CursedIce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice");
			Tooltip.SetDefault("Cursed Flame, bound in ice.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 9));
			DisplayName.AddTranslation(GameCulture.Russian, "Проклятый лёд");
			Tooltip.AddTranslation(GameCulture.Russian, "Проклятое Пламя, заключённое в лёд"); 
		}    
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.value = 5000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlock, 5);
			recipe.AddIngredient(ItemID.CursedFlame);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
