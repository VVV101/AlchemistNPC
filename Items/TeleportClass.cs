using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class TeleportClass : GlobalItem
	{
		
		public static void HandleTeleport(int teleportType = 0, bool forceHandle = false, int whoAmI = 0)
		{
			bool syncData = forceHandle || Main.netMode == 0;
			if (syncData)
			{
				TeleportPlayer(teleportType, forceHandle, whoAmI);
			}
			else
			{
				SyncTeleport(teleportType);
			}
		}
		
		private static void SyncTeleport(int teleportType = 0)
		{
			var netMessage = AlchemistNPC.instance.GetPacket();
			netMessage.Write((byte)AlchemistNPC.AlchemistNPCMessageType.TeleportPlayer);
			netMessage.Write(teleportType);
			netMessage.Send();
		}
		
		private static void TeleportPlayer(int teleportType = 0, bool syncData = false, int whoAmI = 0)
		{
			Player player;
			if (!syncData)
			{
				player = Main.LocalPlayer;
			}
			else
			{
				player = Main.player[whoAmI];
			}
				switch (teleportType)
				{
					case 0:
						HandleDungeonTeleport(player, syncData);
						break;
					case 1:
						HandleOceanTeleport(player, syncData);
						break;
					case 2:
						HandleOceanTeleportLeft(player, syncData);
						break;
					case 3:
						HandlePalmTeleport(player, syncData);
						break;
					case 4:
						HandlePalmTeleportLeft(player, syncData);
						break;
					case 5:
						HandleHellTeleport(player, syncData);
						break;
					case 6:
						HandleHellTeleportLeft(player, syncData);
						break;
					case 7:
						HandleTempleTeleport(player, syncData);
						break;
					case 8:
						HandleBeaconTeleport(player, syncData);
						break;
					default:
						break;
				}
			}
		
		private static void HandleDungeonTeleport(Player player, bool syncData = false)
		{
			RunTeleport(player, new Vector2(Main.dungeonX, Main.dungeonY), syncData, true);
		}
		
		private static void HandleOceanTeleport(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 81) continue;
					pos = new Vector2((x+1) * 16, (y-16) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandleOceanTeleportLeft(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 8400; x > 0; --x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 81) continue;
					pos = new Vector2((x-1) * 16, (y-16) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandleHellTeleport(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 75) continue;
					pos = new Vector2((x-3) * 16, (y+2) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandleHellTeleportLeft(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 8400; x > 0; --x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 75) continue;
					pos = new Vector2((x+3) * 16, (y+2) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandlePalmTeleport(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 323) continue;
					pos = new Vector2((x) * 16, (y+4) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandlePalmTeleportLeft(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 8400; x > 0; --x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 323) continue;
					pos = new Vector2((x) * 16, (y+4) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandleTempleTeleport(Player player, bool syncData = false)
		{
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != 237) continue;
					pos = new Vector2((x + 2) * 16, y * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
		}
		
		private static void HandleBeaconTeleport(Player player, bool syncData = false)
		{
			Mod mod = ModLoader.GetMod("AlchemistNPC");
			Vector2 prePos = player.position;
			Vector2 pos = prePos;
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != mod.TileType("Beacon")) continue;
					pos = new Vector2((x-1) * 16, (y-2) * 16);
					break;
				}
			}
			if (pos != prePos)
			{
				RunTeleport(player, new Vector2(pos.X, pos.Y), syncData, false);
			}
			else return;
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
