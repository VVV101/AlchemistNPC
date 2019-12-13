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
     public class OceanTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocean Teleporter Potion");
			Tooltip.SetDefault("Teleports you to the Ocean (near leftest or rightest сoral)"
			+"\nSide depends on used mouse button"
			+"\nWill not teleport you anywhere if no сorals exist");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр в Океан");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас крайнему Кораллу\nСторона зависит от нажатой кнопки мыши\nНе телепортирует никуда, если кораллов не существует в мире");

            DisplayName.AddTranslation(GameCulture.Chinese, "海洋传送药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "将你传送到海里 (最左边或最右边的珊瑚)\n方向取决于鼠标按键\n如果没有珊瑚存在将无法工作");
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
			if (Main.myPlayer == player.whoAmI)
			{
			return true;
			}
			return false;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(1);
				return true;
				}
			}
			if (player.altFunctionUse != 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(2);
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
            TeleportClass.HandleTeleport(1);
        }
    }
}
