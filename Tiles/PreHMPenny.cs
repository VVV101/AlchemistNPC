using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemistNPC.Tiles
{
	public class PreHMPenny : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Simple Crafting Penny");
			name.AddTranslation(GameCulture.Russian, "Простой Крафтовый Пенни");
			AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[]
			{
			TileID.WorkBenches,
			TileID.Anvils,
			TileID.Furnaces,
			TileID.Hellforge,
			TileID.DyeVat,
			TileID.Loom,
			TileID.Bottles,
			TileID.Tables,
			TileID.Chairs,
			TileID.CookingPots,
			TileID.DemonAltar,
			TileID.Sawmill,
			TileID.TinkerersWorkbench,
			TileID.HeavyWorkBench,
			};
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("PreHMPenny"));
		}
	}
}