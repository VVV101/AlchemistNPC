using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace AlchemistNPC.Tiles
{
	public class Beacon : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Beacon");
			name.AddTranslation(GameCulture.Russian, "Маяк");
            name.AddTranslation(GameCulture.Chinese, "信标");
            AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override bool CanPlace (int i, int j)
		{
			Mod mod = ModLoader.GetMod("AlchemistNPC");
			for (int x = 0; x < Main.tile.GetLength(0); ++x)
			{
				for (int y = 0; y < Main.tile.GetLength(1); ++y)
				{
					if (Main.tile[x, y] == null) continue;
					if (Main.tile[x, y].type != mod.TileType("Beacon")) continue;
					return false;
				}
			}
			return true;
		}	
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];
			if (tile.frameX < 66)
			{
				r = 0.9f;
				g = 0.9f;
				b = 0.9f;
			}
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("Beacon"));
		}
	}
}