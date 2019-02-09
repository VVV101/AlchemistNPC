using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Buffs
{
	public class AlchemistNPCGlobalBuffs : GlobalBuff
	{
		public override void Update(int type, Player player, ref int buffIndex)
		{
			if (type == 165)
			{
				Main.buffNoTimeDisplay[type] = false;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BuffsKeep == true)
			{
				if (type != 71 && type != 73 && type != 74 && type != 75 && type != 76 && type != 77 && type != 78 && type != 79 && type != mod.BuffType("RainbowFlaskBuff"))
				{
					if (Main.debuff[type] == false)
					{
					Main.persistentBuff[type] = true;
					}
				}
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BuffsKeep == false && NPC.downedMoonlord)
			{
				if (type != 71 && type != 73 && type != 74 && type != 75 && type != 76 && type != 77 && type != 78 && type != 79 && type != mod.BuffType("RainbowFlaskBuff"))
				{
					if (Main.debuff[type] == false)
					{
					Main.persistentBuff[type] = false;
					}
				}
			}
		}
	}
}