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
     public class VanTankCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tank Combination (Vanilla)");
			Tooltip.SetDefault("Grants buffs, which are necessary for Tanks (Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (без Модовых)");
            Tooltip.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов и Регенерации");

            DisplayName.AddTranslation(GameCulture.Chinese, "坦克药剂包 (原版)");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得一些坦克Buff (耐力, 生命力, 铁皮, 黑曜石皮肤, 荆棘, 恢复, 抵抗)");
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
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("VanTankComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EndurancePotion, 1);
			recipe.AddIngredient(ItemID.LifeforcePotion, 1);
			recipe.AddIngredient(ItemID.IronskinPotion, 1);
			recipe.AddIngredient(ItemID.RestorationPotion, 1);
			recipe.AddIngredient(ItemID.ObsidianSkinPotion, 1);
			recipe.AddIngredient(ItemID.ThornsPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
