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
     public class TankCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tank Combination (w/Modded)");
			Tooltip.SetDefault("Grants buffs, which are necessary for Tanks (Swiftness, Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration, Titan Skin, Invincibility)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Танка (с модовыми)");
            Tooltip.AddTranslation(GameCulture.Russian, "Включает в себя следующие баффы: Быстрота, Выносливость, Жизненные Силы, Железную Кожу\nОбсидиановую Кожу, Шипы, Регенерацию, Кожу Титана и Неуязвимость");

            DisplayName.AddTranslation(GameCulture.Chinese, "坦克药剂包 (模组)");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得一些坦克Buff (耐力, 生命力, 铁皮, 敏捷, 黑曜石皮肤, 荆棘, 再生, 泰坦皮肤, 无敌)");
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
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = ItemRarityID.Red;
            item.buffType = mod.BuffType("TankComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SwiftnessPotion, 1);
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
