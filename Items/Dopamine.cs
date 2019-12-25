using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
     public class Dopamine : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dopamine");
			Tooltip.SetDefault("Makes you Happy");
			DisplayName.AddTranslation(GameCulture.Russian, "Допамин");
            Tooltip.AddTranslation(GameCulture.Russian, "Делает вас счастливым");
			DisplayName.AddTranslation(GameCulture.Chinese, "多巴胺");
			Tooltip.AddTranslation(GameCulture.Chinese, "让你愉快");
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
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 3;
            item.buffType = 146;           //this is where you put your Buff
            item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Sunflower, 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
