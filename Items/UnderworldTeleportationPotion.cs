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
     public class UnderworldTeleportationPotion : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Underworld Teleporter Potion");
			Tooltip.SetDefault("Teleports you to Underworld to leftest or rightest Obsidian Tower"
			+"\nSide depends of used mouse button"
			+"\nWould be useful to drink Obsidian Skin potion before drinking that");
			DisplayName.AddTranslation(GameCulture.Russian, "Телепортёр в Ад");
            Tooltip.AddTranslation(GameCulture.Russian, "Телепортирует вас в Ад к крайней Обсидиановой башне\nСторона зависит от нажатой клавиши мыши\nБудет полезно выпить зелье Обсидиановой кожи до того, как пить это");

            DisplayName.AddTranslation(GameCulture.Chinese, "地狱传送药剂");
            Tooltip.AddTranslation(GameCulture.Chinese, "将你传送至最靠近地狱两端的黑曜石塔楼\n方向取决于鼠标按键\n我建议你这么做之前先来一瓶黑曜石皮肤药剂");
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
				TeleportClass.HandleTeleport(5);
				return true;
				}
			}
			if (player.altFunctionUse != 2)
			{
				if (Main.myPlayer == player.whoAmI)
				{
				TeleportClass.HandleTeleport(6);
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
            TeleportClass.HandleTeleport(5);
        }
		
		private static void RunTeleport(Player player, Vector2 pos, bool syncData = false, bool convertFromTiles = false)
		{
			bool postImmune = player.immune;
			int postImmunteTime = player.immuneTime;

			if (convertFromTiles)
				pos = new Vector2(pos.X * 16 + 8 - player.width / 2, pos.Y * 16 - player.height);

			LeaveDust(player);

			//Kill hooks
			player.grappling[0] = -1;
			player.grapCount = 0;
			for (int index = 0; index < 1000; ++index)
			{
				if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
					Main.projectile[index].Kill();
			}

			player.Teleport(pos, 2, 0);
			player.velocity = Vector2.Zero;
			player.immune = postImmune;
			player.immuneTime = postImmunteTime;

			LeaveDust(player);

			if (Main.netMode != 2)
				return;

			if (syncData)
			{
				RemoteClient.CheckSection(player.whoAmI, player.position, 1);
				NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, pos.X, pos.Y, 3, 0, 0);
			}
		}

		private static void LeaveDust(Player player)
		{
			//Leave dust
			for (int index = 0; index < 70; ++index)
				Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
			Main.TeleportEffect(player.getRect(), 1);
			Main.TeleportEffect(player.getRect(), 3);
		}
    }
}
