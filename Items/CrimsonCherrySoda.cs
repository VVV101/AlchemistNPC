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
			DisplayName.AddTranslation(GameCulture.Russian, "Сода Вишни Кримзона");
			Tooltip.AddTranslation(GameCulture.Russian, "Лечит на 175 HP и значительно увеличивает регенерацию на короткое время"); 
		}    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SuperHealingPotion);
            item.maxStack = 99;                 //this is where you set the max stack of item
            item.consumable = true;           //this make that the item is consumable when used
            item.value = Item.sellPrice(0, 1, 0, 0);
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
