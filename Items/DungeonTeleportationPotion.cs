using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC.Items;
 
namespace AlchemistNPC.Items
{
     public class DungeonTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Teleportation Potion");
			Tooltip.SetDefault("Teleports you to Dungeon entrance");
			DisplayName.AddTranslation(GameCulture.Russian, "Зелье телепортации в Данж");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас ко входу в Данж\nНе работает в мультиплеере :(");
            DisplayName.AddTranslation(GameCulture.Chinese, "地牢传送药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "将你传送至地牢入口");
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
			TeleportClass.HandleTeleport(0);
			return true;
			}
			return false;
		}
    }
}
