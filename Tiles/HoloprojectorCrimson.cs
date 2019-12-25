using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace AlchemistNPC.Tiles
{
	public class HoloprojectorCrimson : ModTile
	{
		public static int counter = 0;
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(1, 2);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Holoprojector ''Crimson''");
			name.AddTranslation(GameCulture.Russian, "Голопроектор ''Кримзон''");
			AddMapEntry(new Color(190, 230, 190), name);
			dustType = 11;
			disableSmartCursor = true;
			animationFrameHeight = 56;
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileID.FireflyinaBottle];
			frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
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
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.player[Main.myPlayer];
				if (!player.dead)
				player.AddBuff(mod.BuffType("HoloprojectorCrimson"), 180);
			}
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("HoloprojectorCrimson"));
		}
	}
}