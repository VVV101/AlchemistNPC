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
    public class CrimsonCherrySoda : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Cherry Soda");
			Tooltip.SetDefault("Heals for 175 hp and increases life regeneration greatly for a short time.");
			DisplayName.AddTranslation(GameCulture.Russian, "Алая Вишневая Сода");
			Tooltip.AddTranslation(GameCulture.Russian, "Лечит на 175 HP и значительно увеличивает регенерацию на короткое время");

            DisplayName.AddTranslation(GameCulture.Chinese, "绯红樱桃苏打水");
            Tooltip.AddTranslation(GameCulture.Chinese, "恢复175点生命值, 并在短时间内极大增加生命恢复速度.");
        }    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SuperHealingPotion);
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.value = 0;
            item.rare = 6;
			item.healLife = 175;
			item.potion = true;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("CrimsonSoda"), 2700);
			return true;
		}
    }
}
