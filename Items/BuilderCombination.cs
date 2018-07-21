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
     public class BuilderCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Builder Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for building (Calm, Builder, Mining)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Строителя");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт баффы, важные для строительства (Добыча, Строитель и Покой)");

            DisplayName.AddTranslation(GameCulture.Chinese, "建筑师药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得你在建筑时需要的Buff(镇静, 建筑工, 挖矿)");
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
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("BuilderComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BuilderPotion, 1);
			recipe.AddIngredient(ItemID.CalmingPotion, 1);
			recipe.AddIngredient(ItemID.MiningPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
