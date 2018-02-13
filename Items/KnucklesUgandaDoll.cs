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
     public class KnucklesUgandaDoll : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("National Ugandan Treasure");
			Tooltip.SetDefault("I'm 100% sure this will kill you - Gregg");
			DisplayName.AddTranslation(GameCulture.Russian, "Национальное сокровище Уганды");
			Tooltip.AddTranslation(GameCulture.Russian, "Я на 100 процентов уверен, что это тебя убьёт - Gregg"); 
		}    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RecallPotion);
            item.maxStack = 99;
            item.consumable = true;
            return;
        }
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("Uganda"), 300);
			return true;
		}
    }
}
