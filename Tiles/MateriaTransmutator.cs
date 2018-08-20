using System;
using System.Linq;
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
	public class MateriaTransmutator : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16, 18 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Materia Transmutator");
			name.AddTranslation(GameCulture.Russian, "Преобразователь Материи");
            name.AddTranslation(GameCulture.Chinese, "物质嬗变器");
            AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = true;
			adjTiles = new int[]
			{
			mod.TileType("WingoftheWorld"),
			TileID.WorkBenches, 
			TileID.Anvils, 
			TileID.Furnaces, 
			TileID.Hellforge, 
			TileID.Bookcases,
			TileID.Sinks,
			TileID.Solidifier,
			TileID.Blendomatic,
			TileID.MeatGrinder,
			TileID.Loom,
			TileID.LivingLoom,
			TileID.FleshCloningVat,
			TileID.GlassKiln,
			TileID.BoneWelder,
			TileID.SteampunkBoiler,
			TileID.Bottles,
			TileID.LihzahrdFurnace,
			TileID.ImbuingStation,
			TileID.DyeVat,
			TileID.Kegs,
			TileID.HeavyWorkBench,
			TileID.Tables, 
			TileID.Chairs,
			TileID.CookingPots,
			TileID.DemonAltar, 
			TileID.Sawmill,
			TileID.CrystalBall, 
			TileID.AdamantiteForge, 
			TileID.MythrilAnvil,
			TileID.TinkerersWorkbench,
			TileID.Autohammer,
			TileID.IceMachine,
			TileID.SkyMill,
			TileID.HoneyDispenser,
			TileID.AlchemyTable,
			TileID.LunarCraftingStation
			};
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
				{
                Array.Resize(ref adjTiles, adjTiles.Length + 3);
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil");
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator");
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("ThoriumMod").TileType("SoulForge");
				}
			if (ModLoader.GetLoadedMods().Contains("Fargowiltas"))
				{
				Array.Resize(ref adjTiles, adjTiles.Length + 1);
                adjTiles[adjTiles.Length - 1] = ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet");
				}
			dustType = mod.DustType("JustitiaPale");
			animationFrameHeight = 74;
		}
		
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
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
		
		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = Main.tileFrame[TileID.FireflyinaBottle];
			frameCounter = Main.tileFrameCounter[TileID.FireflyinaBottle];
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("MateriaTransmutator"));
		}
		
		public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.alchemyTable = true;
		}
	}
}
