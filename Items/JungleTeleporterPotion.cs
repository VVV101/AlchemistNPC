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
     public class JungleTeleporterPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Teleporter Potion");
			Tooltip.SetDefault("Teleports you to the Jungle"
			+"\nLeft click teleports to jungle plant"
			+"\nRight click teleports to living machogany leaves");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр к Джунглям");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас в джунгли\nЛевая кнопка телепортирует к джунглевому растению\nПравая кнопка телепортирует к листьям живой махогани");
			DisplayName.AddTranslation(GameCulture.Chinese, "丛林传送药剂");
			Tooltip.AddTranslation(GameCulture.Chinese, "将你传送至丛林"
			+"\n左键传送至丛林植物"
			+"\n右键传送至生命桃木树叶");
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
