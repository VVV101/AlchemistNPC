using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Mounts
{
	public class Poro : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = 143;
			mountData.buff = mod.BuffType("Poro");
			mountData.heightBoost = 36;
			mountData.fallDamage = 0f;
			mountData.runSpeed = 15f;
			mountData.dashSpeed = 12f;
			mountData.flightTimeMax = 0;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 50;
			mountData.acceleration = 1f;
			mountData.jumpSpeed = 10f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 6;
			mountData.constantJump = true;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 32;
			}
			mountData.playerYOffsets = array;
			mountData.xOffset = 10;
			mountData.bodyFrame = 3;
			mountData.yOffset = 16;
			mountData.playerHeadOffset = 50;
			mountData.standingFrameCount = 2;
			mountData.standingFrameDelay = 50;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 4;
			mountData.runningFrameDelay = 100;
			mountData.runningFrameStart = 2;
			mountData.flyingFrameCount = 0;
			mountData.flyingFrameDelay = 0;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 4;
			mountData.inAirFrameDelay = 50;
			mountData.inAirFrameStart = 2;
			mountData.idleFrameCount = 6;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
			if (Main.netMode != 2)
			{
				mountData.textureWidth = mountData.backTexture.Width + 20;
				mountData.textureHeight = mountData.backTexture.Height;
			}
		}
	}
}