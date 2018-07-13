using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.PaleDamageClass
{
	public class PaleDamagePlayer : ModPlayer
	{
		public static PaleDamagePlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<PaleDamagePlayer>();
		}
		public float paleDamage = 1f;
		public float paleKnockback = 0f;
		public int paleCrit = 0;

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		private void ResetVariables()
		{
			paleDamage = 1f;
			paleKnockback = 0f;
			paleCrit = 0;
		}
	}
}
