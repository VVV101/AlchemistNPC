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
