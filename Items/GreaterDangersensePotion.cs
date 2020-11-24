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
     public class GreaterDangersensePotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greater Dangersense Potion");
			Tooltip.SetDefault("Grants Greater Dangersense buff (light up enemy projectiles)"
			+"\nThis effect is global for all players");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье Великого Чувства Опасности");
			Tooltip.AddTranslation(GameCulture.Russian, "Даёт бафф Великого Чувства Опасности (подсвечивает вражеские снаряды)\nЭффект действует для всех игроков");
			DisplayName.AddTranslation(GameCulture.Chinese, "强效危险感知药剂");
			Tooltip.AddTranslation(GameCulture.Chinese, "获得强效危险感知Buff (高亮敌人抛射物)"
            +"\n该效果对所有玩家起效");
        }    
		public override void SetDefaults()
        {
            item.UseSound = SoundID.Item3;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTurn = true;
            item.useAnimation = 17;
            item.useTime = 17;
            item.maxStack = 99;
            item.consumable = true;
            item.width = 20;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = ItemRarityID.Lime;
            item.buffType = mod.BuffType("GreaterDangersense");
            item.buffTime = 36000;
            return;
        }
    }
}
