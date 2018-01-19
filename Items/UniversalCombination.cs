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
     public class UniversalCombination : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Universal Combination");
			Tooltip.SetDefault("Gives combined effects of Tank, Ranger, Mage and Summoner Combinations in a single buff.");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинация Универсала");
			Tooltip.AddTranslation(GameCulture.Russian, "Идеальное сочетание Комбинаций Танка, Мага, Стрелка и Призывателя в одном баффе"); 
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
            item.width = 38;
            item.height = 42;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.buffType = mod.BuffType("UniversalComb");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
