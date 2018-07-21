using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class DivineLava : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Lava");
			Tooltip.SetDefault("Ichor & Lava, combined together by magic");
			DisplayName.AddTranslation(GameCulture.Russian, "Вечная Лава");
			Tooltip.AddTranslation(GameCulture.Russian, "Лава и Ихор, слитые воедино магией");

            DisplayName.AddTranslation(GameCulture.Chinese, "奇异岩浆");
            Tooltip.AddTranslation(GameCulture.Chinese, "用法力把灵液和岩浆相结合");
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
			recipe.AddIngredient(ItemID.Ichor);
			recipe.AddIngredient(ItemID.LavaBucket);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor);
			recipe.AddTile(TileID.CrystalBall);
			recipe.needLava = true;
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
