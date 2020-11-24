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
     public class BewitchingPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bewitching Potion");
			Tooltip.SetDefault("Grants Bewitched buff (increases max number of minions)");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Колдовства");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт бафф Колдовства (увеличивает максимальное число прислужников)");

            DisplayName.AddTranslation(GameCulture.Chinese, "迷人药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加召唤物能力 (增加一个召唤物上限)");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            item.useStyle = ItemUseStyleID.EatingUsing;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = ItemRarityID.Lime;
            item.buffType = 150;           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Moonglow, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.Vine, 1);
			recipe.AddIngredient(ItemID.JungleSpores, 1);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
