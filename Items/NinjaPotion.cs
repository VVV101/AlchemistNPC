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
     public class NinjaPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja Potion");
			Tooltip.SetDefault("Increases damage and critical chance by 5% and grants abilities of a Master Ninja"
			+"\nNON-CALAMITY BUFF POTION");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Ниндзя");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон и шанс критического удара любым типом на 5% и даёт способности Мастера Ниндзя"); 
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
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("NinjaSkill");           //this is where you put your Buff
            item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Daybloom, 1);
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.RottenChunk, 2);
			recipe.AddIngredient(ItemID.CursedFlame, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Daybloom, 1);
			recipe.AddIngredient(ItemID.Waterleaf, 1);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddIngredient(ItemID.Vertebrae, 2);
			recipe.AddIngredient(ItemID.Ichor, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
