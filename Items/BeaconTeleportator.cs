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
    public class BeaconTeleportator : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beacon Teleporter Potion");
			Tooltip.SetDefault("Teleports you to placed Beacon"
			+"\nWill not teleport you anywhere if Beacon is not placed");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр к Маяку");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас к Маяку\nНе телепортирует никуда, если Маяк не размещён");

            DisplayName.AddTranslation(GameCulture.Chinese, "信标传送药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "将你传送至信标处\n没有放置信标无法工作");
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
			TeleportClass.HandleTeleport(8);
			return true;
			}
			return false;
		}
    }
}
