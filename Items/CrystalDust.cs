using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class CrystalDust : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dust");
			Tooltip.SetDefault("Dust, which is made from Crystal Shards.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальная пыль");
			Tooltip.AddTranslation(GameCulture.Russian, "Пьль, сделанная из осколков кристалла"); 
		}    
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 14;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Autohammer);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
