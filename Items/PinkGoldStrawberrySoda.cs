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
    public class PinkGoldStrawberrySoda : ModItem
    {
        public override void SetStaticDefaults()
		{
		DisplayName.SetDefault("Pink Gold Strawberry Soda");
		Tooltip.SetDefault("Heals for 150 hp and 150 mana, removes most debuffs for a short time");
		DisplayName.AddTranslation(GameCulture.Russian, "Сода Розово-Золотой Клубники");
        Tooltip.AddTranslation(GameCulture.Russian, "Пополняет 150 жизней и маны, убирает большинство дебаффов в течение короткого времени");
		
        DisplayName.AddTranslation(GameCulture.Chinese, "桃金草莓苏打水");
        Tooltip.AddTranslation(GameCulture.Chinese, "恢复150点生命值和150点法力值, 短时间内移除大部分Debuff");
        }    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SuperHealingPotion);
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.value = 0;
            item.rare = 6;
			item.healLife = 150;
			item.healMana = 150;
			item.potion = true;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("PinkGoldSoda"), 600);
			return true;
		}
    }
}
