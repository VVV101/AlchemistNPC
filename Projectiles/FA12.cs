using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace AlchemistNPC.Projectiles
{
	public class FA12 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxic Cloud 2");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(512);
			projectile.magic = false;
			projectile.thrown = true;
			projectile.aiStyle = 92;
			aiType = 512;
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 6;
			if (!Main.hardMode)
			{
			target.AddBuff(BuffID.Poisoned, 180);
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
			target.AddBuff(BuffID.Venom, 180);
			}
			if (NPC.downedMoonlord)
			{
			target.AddBuff(mod.BuffType("Corrorion"), 180);
			}
		}
	}
}
