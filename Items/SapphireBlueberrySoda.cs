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
    public class SapphireBlueberrySoda : ModItem
    {
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Blueberry Soda");
			Tooltip.SetDefault("Restores 175 mana, removes Mana Sickness for a short time.");
			DisplayName.AddTranslation(GameCulture.Russian, "Сода Сапфировой Голубики");
            Tooltip.AddTranslation(GameCulture.Russian, "Восстанавливает 175 маны, убирает Магическую слабость в течении короткого времени");

            DisplayName.AddTranslation(GameCulture.Chinese, "宝蓝蓝莓苏打水");
            Tooltip.AddTranslation(GameCulture.Chinese, "恢复175点法力值, 短时间内移除法力病Debuff.");
        }    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SuperManaPotion);
            item.maxStack = 999;
            item.consumable = true;
            item.value = 0;
            item.rare = 6;
			item.healMana = 175;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("SapphireSoda"), 600);
			return true;
		}
    }
}
