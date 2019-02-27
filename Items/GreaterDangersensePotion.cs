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
     public class GreaterDangersensePotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense Potion");
			Tooltip.SetDefault("Grants Greater Dangersense buff (light up enemy projectiles)"
			+"\nThis effect is global for all players");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Великого Чувства Опасности");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт бафф Великого Чувства Опасности (подсвечивает вражеские снаряды)\nЭффект действует для всех игроков");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 7;
            item.buffType = mod.BuffType("GreaterDangersense");
            item.buffTime = 36000;
            return;
        }
    }
}
