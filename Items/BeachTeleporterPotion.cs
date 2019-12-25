using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC.Tiles;
 
namespace AlchemistNPC.Items
{
     public class BeachTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beach Teleporter Potion");
			Tooltip.SetDefault("Teleports you to the Beach"
			+"\nSide depends on used mouse button");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр к Пляжу");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас на пляж\nСторона зависит от нажатой кнопки мыши");

            DisplayName.AddTranslation(GameCulture.Chinese, "海滩传送药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "将你传送至海滩 (靠近最左/右边的棕榈木处)"
			+"\n方向取决于使用的鼠标按键"
			+"\n如果没有棕榈木, 则无法传送");
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
				TeleportClass.HandleTeleport(3);
				return true;
				}
			}
			if (player.altFunctionUse != 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(4);
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
			if (Main.myPlayer == player.whoAmI)
			{
            TeleportClass.HandleTeleport(3);
			}
        }
    }
}
