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
     public class TempleTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Temple Teleportation Potion");
			Tooltip.SetDefault("Teleports you to Temple");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье телепортации в Храм Джунглей");
			Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас в Храм Джунглей"); 
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
			if (Main.myPlayer == player.whoAmI)
			{
			TeleportClass.HandleTeleport(7);
			return true;
			}
			return false;
		}
    }
}
