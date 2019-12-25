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
    public class TrapsPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trapper Potion");
            Tooltip.SetDefault("Empoweres all traps");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье мастера ловушек");
            Tooltip.AddTranslation(GameCulture.Russian, "Усиливает все ловушки");
			DisplayName.AddTranslation(GameCulture.Chinese, "布陷人药剂");
			Tooltip.AddTranslation(GameCulture.Chinese, "增强所有陷阱");
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
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("TrapsBuff");           //this is where you put your Buff
            item.buffTime = 36000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
