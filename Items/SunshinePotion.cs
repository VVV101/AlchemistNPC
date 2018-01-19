using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
     public class SunshinePotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sunshine Potion");
			Tooltip.SetDefault("Increases light radius greatly");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Солнечного Сияния");
			Tooltip.AddTranslation(GameCulture.Russian, "Значительно увеличивает радиус освещения вокруг персонажа"); 
		}    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("Sunshine");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Fireblossom, 3);
			recipe.AddIngredient(ItemID.Daybloom, 3);
			recipe.AddIngredient(ItemID.Moonglow, 3);
			recipe.AddIngredient(ItemID.Blinkroot, 3);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
