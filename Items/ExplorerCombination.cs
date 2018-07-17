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
     public class ExplorerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explorer Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for exploring (Dangersense, Hunter, Spelunker, Night Owl, Shine, Mining, Gills, Flippers, Water Walking)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Исследователя");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт баффы, важные для Исследователя\nПредчувствие, Охотник, Шахтёр, Ночное Зрение, Сияние, Добыча, Жабры, Ласты, Хождение по воде");

            DisplayName.AddTranslation(GameCulture.Chinese, "探索者药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得你在探索时所需的Buff(危险感知, 狩猎, 洞穴探险, 夜猫子, 光芒, 挖矿, 鱼鳃, 脚蹼, 水上行走)");
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
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("ExplorerComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TrapsightPotion, 1);
			recipe.AddIngredient(ItemID.HunterPotion, 1);
			recipe.AddIngredient(ItemID.SpelunkerPotion, 1);
			recipe.AddIngredient(ItemID.NightOwlPotion, 1);
			recipe.AddIngredient(ItemID.ShinePotion, 1);
			recipe.AddIngredient(ItemID.MiningPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
