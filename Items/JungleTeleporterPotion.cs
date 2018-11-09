using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC.Tiles;
 
namespace AlchemistNPC.Items
{
     public class JungleTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Teleporter Potion");
			Tooltip.SetDefault("Teleports you to the Jungle"
			+"\nSide depends on used mouse button");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр к Джунглям");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас в джунгли\nСторона зависит от нажатой кнопки мыши");
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
			return true;
			}
			return false;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(10);
				return true;
				}
			}
			if (player.altFunctionUse != 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(9);
				return true;
				}
			}
			return false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

        public override void RightClick(Player player)
        {
            TeleportClass.HandleTeleport(10);
        }
    }
}
