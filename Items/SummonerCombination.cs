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
     public class SummonerCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summoner Combination");
			Tooltip.SetDefault("Grants buffs, which are necessary for Summoners (Summoning, Bewitched, Wrath)");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Призывателя");
            Tooltip.AddTranslation(GameCulture.Russian, "аёт баффы, необходимые для Призывателя(Призыв, Колдовство, Гнев)");
            DisplayName.AddTranslation(GameCulture.Chinese, "召唤师药剂包");
            Tooltip.AddTranslation(GameCulture.Chinese, "获得一些召唤Buff (召唤, 战斗, 迷人, 怒气)");
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
            item.height = 34;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("SummonerComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SummoningPotion, 1);
			recipe.AddIngredient(null, "BewitchingPotion", 1);
			recipe.AddIngredient(ItemID.WrathPotion, 1);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
    }
}
