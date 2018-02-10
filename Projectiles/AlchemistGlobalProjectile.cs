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
		public override void SetDefaults (Projectile projectile)
		{
			if (AlchemistNPC.scroll == true && projectile.thrown == true)
			{
				projectile.tileCollide = false;
			}
		}
 
	}
}