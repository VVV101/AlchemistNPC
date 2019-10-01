using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class NULL : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("NULL");
			Description.SetDefault("");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "NULL");
			Description.AddTranslation(GameCulture.Russian, "");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			if (player.buffTime[buffIndex] >= 299)
			{
				for (int k = 0; k < 200; k++)
				{
					NPC npc = Main.npc[k];
					npc.velocity.X /= 5;
					npc.velocity.Y /= 5;
				}
				for (int j = 0; j < 1000; j++)
				{
					Projectile projectile = Main.projectile[j];
					if (!projectile.friendly)
					{
						projectile.velocity.X /= 5;
						projectile.velocity.Y /= 5;
					}
				}
			}
			if (player.buffTime[buffIndex] >= 30)
			{
				Main.monolithType = 2;
			}
		}
	}
}