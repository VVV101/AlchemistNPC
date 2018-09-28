using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Mounts
{
	public class MysticAmulet : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 226;
			mountData.spawnDustNoGravity = true;
			mountData.buff = mod.BuffType("MysticAmulet");
			mountData.heightBoost = 0;
			mountData.flightTimeMax = Int32.MaxValue;
			mountData.fatigueMax = Int32.MaxValue;
			mountData.fallDamage = 0f;
			mountData.usesHover = true;
			mountData.runSpeed = 15f;
			mountData.dashSpeed = 24f;
			mountData.acceleration = 3f;
			mountData.jumpHeight = 24;
			mountData.jumpSpeed = 16f;
			mountData.blockExtraJumps = true;
			mountData.totalFrames = 1;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 0;
			}
			mountData.playerYOffsets = new int[] { 0 };
			mountData.xOffset = 16;
			mountData.bodyFrame = 5;
			mountData.yOffset = 16;
			mountData.playerHeadOffset = 18;
			mountData.standingFrameCount = 0;
			mountData.standingFrameDelay = 0;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 0;
			mountData.runningFrameDelay = 0;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 0;
			mountData.inAirFrameDelay = 0;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 0;
			mountData.idleFrameDelay = 0;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = 0;
			mountData.swimFrameDelay = 0;
			mountData.swimFrameStart = 0;
			if (Main.netMode != 2)
			{
				mountData.textureWidth = mountData.backTexture.Width;
				mountData.textureHeight = mountData.backTexture.Height;
			}
		}
	}
}