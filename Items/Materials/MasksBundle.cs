using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class MasksBundle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Masks Bundle");
			Tooltip.SetDefault("Contains masks of all vanilla bosses"
				+ "\nRequired for making ultimate accessory");
			DisplayName.AddTranslation(GameCulture.Russian, "Набор Масок");
            Tooltip.AddTranslation(GameCulture.Russian, "Содержит в себе маски всех базовых боссов\nНеобходим для создания ультимативного аксессуара");

            DisplayName.AddTranslation(GameCulture.Chinese, "面具捆绑包");
            Tooltip.AddTranslation(GameCulture.Chinese, "打包了所有原版boss的面具\n是制作终极饰品的材料\n并不是Steam的游戏捆绑包哦!");
        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 5000000;
			item.rare = 9;
			item.knockBack = 6;
			item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.KingSlimeMask, 1);
			recipe.AddIngredient(ItemID.EyeMask, 1);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMask");
			recipe.AddIngredient(ItemID.BeeMask, 1);
			recipe.AddIngredient(ItemID.SkeletronMask, 1);
			recipe.AddIngredient(ItemID.FleshMask, 1);
			recipe.AddIngredient(ItemID.TwinMask, 1);
			recipe.AddIngredient(ItemID.DestroyerMask, 1);
			recipe.AddIngredient(ItemID.SkeletronPrimeMask, 1);
			recipe.AddIngredient(ItemID.PlanteraMask, 1);
			recipe.AddIngredient(ItemID.GolemMask, 1);
			recipe.AddIngredient(ItemID.DukeFishronMask, 1);
			recipe.AddRecipeGroup("AlchemistNPC:CultistMask");
			recipe.AddIngredient(ItemID.BossMaskMoonlord, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
