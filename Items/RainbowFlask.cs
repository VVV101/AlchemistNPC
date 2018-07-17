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
     public class RainbowFlask : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flask of Rainbows");
			Tooltip.SetDefault("Your weapons inflict defense destroying and heavy damaging debuffs"
			+"\nRemoves enemy immunity to Ichor, Betsy's Curse and Daybroken");
			DisplayName.AddTranslation(GameCulture.Russian, "Флакон Радуги");
            Tooltip.AddTranslation(GameCulture.Russian, "Ваши оружия разрушают броню вашего противника и накладывают дебаффы, наносящие значительный урон противнику\nУбирает невосприимчивость противника к Ихору, Проклятию Бетси и Дневному Ожогу");

            DisplayName.AddTranslation(GameCulture.Chinese, "瓶中彩虹");
            Tooltip.AddTranslation(GameCulture.Chinese, "使你的武器造成破甲并且给予许多强力的Debuff.");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item44;                 //this is the sound that plays when you use the item
            item.useStyle = 2;                 //this is how the item is holded when used
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.width = 22;
            item.height = 34;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("RainbowFlaskBuff");           //this is where you put your Buff
            item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
            return;
        }
    }
}
