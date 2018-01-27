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
     public class FishingCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fishing Combination");
			Tooltip.SetDefault("Grants Crate, Sonar, Fishing, Regeneration, Thorns, Iron Skin, Calming & Inferno buffs");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Рыбака");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт баффы Ящиков, Сонара, Рыбалки, Регенерации, Шипов, Железной Кожи, Покоя и Инферно"); 
		}    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item44;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("FishingComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FishingPotion, 1);
			recipe.AddIngredient(ItemID.SonarPotion, 1);
			recipe.AddIngredient(ItemID.CratePotion, 1);
			recipe.AddIngredient(ItemID.RestorationPotion, 1);
			recipe.AddIngredient(ItemID.IronskinPotion, 1);
			recipe.AddIngredient(ItemID.ThornsPotion, 1);
			recipe.AddIngredient(ItemID.InfernoPotion, 1);
			recipe.AddIngredient(ItemID.CalmingPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
