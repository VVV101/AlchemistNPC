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
     public class RangerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ranger Combination");
			Tooltip.SetDefault("Grants buffs, which are necesary for Rangers (Archery, Ammo Reservation, Wrath, Rage)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Стрелка");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт баффы, необходимые стрелку (Лучник, Экономия Боеприпасов, Гнев, Ярость)");

            DisplayName.AddTranslation(GameCulture.Chinese, "射手药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得一些远程Buff (箭术, 弹药储备, 暴怒, 怒气)");
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
            item.buffType = mod.BuffType("RangerComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ArcheryPotion, 1);
			recipe.AddIngredient(ItemID.AmmoReservationPotion, 1);
			recipe.AddIngredient(ItemID.WrathPotion, 1);
			recipe.AddIngredient(ItemID.RagePotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
