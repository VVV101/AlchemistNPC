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
     public class TankCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tank Combination (w/Modded)");
			Tooltip.SetDefault("Grants buffs, which are necessary for Tanks (Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration, Titan Skin, Invincibility)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (с модовыми)");
			Tooltip.AddTranslation(GameCulture.Russian, "Сочетание баффов Выносливости, Жизненных Сил, Железной Кожи, Обсидиановой Кожи, Шипов, Регенерации, Кожи Титана и Неуязвимости"); 
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
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("TankComb");           //this is where you put your Buff
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
			recipe.AddIngredient(null, "TitanSkinPotion", 1);
			recipe.AddIngredient(null, "InvincibilityPotion", 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
