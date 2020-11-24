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
	public class CursedIce : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Ice");
			Tooltip.SetDefault("Cursed Flame, encapsulated in ice.");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 8));
			DisplayName.AddTranslation(GameCulture.Russian, "Проклятый лёд");
			Tooltip.AddTranslation(GameCulture.Russian, "Проклятое Пламя, заключённое в лёд");

            DisplayName.AddTranslation(GameCulture.Chinese, "诅咒之冰");
            Tooltip.AddTranslation(GameCulture.Chinese, "诅咒之焰, 跃于冰内");
        }    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 5000;
			item.rare = ItemRarityID.Pink;
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
