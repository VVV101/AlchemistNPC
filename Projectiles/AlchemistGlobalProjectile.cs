using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AlchemistNPC.Projectiles;
using System.IO;
using AlchemistNPC;
using Terraria.ModLoader.IO;

namespace AlchemistNPC.Projectiles
{
   public class AlchemistGlobalProjectile : GlobalProjectile
   {
		public int counter = 0;
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
		
		public override void SetDefaults (Projectile projectile)
		{
			if (AlchemistNPC.scroll == true && projectile.thrown == true)
			{
				projectile.tileCollide = false;
			}
		}
		public override void AI(Projectile projectile)
		{
			if (projectile.magic && AlchemistNPC.LE)
			{
				if (counter == 0)
				{
				if (projectile.type != mod.ProjectileType("Bees"))
					{
			for (int g = 0; g < 3; g++)
						{
					Vector2 vel = new Vector2(0, -1);
					float rand = Main.rand.NextFloat() * 6.283f;
					vel = vel.RotatedBy(rand);
					vel *= 5f;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, mod.ProjectileType("Bees"), projectile.damage, 0, Main.myPlayer);
					counter -= 10;
						}
					}
				}
			}
			return;
			counter++;
		}
	}
}