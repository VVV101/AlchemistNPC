using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;
using System.Linq;

namespace AlchemistNPC.Tiles
{
	public class AlchemistGlobalTiles : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
		if (type == mod.TileType("MateriaTransmutator"))
			{
				Main.LocalPlayer.adjHoney = true;
				Main.LocalPlayer.adjLava = true;
				Main.LocalPlayer.adjWater = true;
			}
			return new int[0];
		}
	}
}