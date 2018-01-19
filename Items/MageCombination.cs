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
     public class MageCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mage Combination");
			Tooltip.SetDefault("Grants buffs, which are necesary for Mages (Magic Power, Mana Regeneration, Wrath, Rage)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Мага");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт баффы, важные для Магов (Магическая Сила, Регенерация Маны, Гнев и Ярость)"); 
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
            item.rare = 10;
            item.buffType = mod.BuffType("MageComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MagicPowerPotion, 1);
			recipe.AddIngredient(ItemID.ManaRegenerationPotion, 1);
			recipe.AddIngredient(ItemID.WrathPotion, 1);
			recipe.AddIngredient(ItemID.RagePotion, 1);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
