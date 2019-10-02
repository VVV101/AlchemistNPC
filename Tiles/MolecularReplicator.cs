using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ObjectData;

namespace AlchemistNPC.Tiles
{
	public class MolecularReplicator : ModTile
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
			name.SetDefault("Molecular Replicator");
			name.AddTranslation(GameCulture.Chinese, "分子复制器");
			AddMapEntry(new Color(190, 230, 190), name);
			dustType = 11;
			disableSmartCursor = true;
			animationFrameHeight = 56;
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
		
		public override void PlaceInWorld(int i, int j, Item item) 	
		{
			counter = 0;
		}
		
		public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex) 	
		{
			counter++;
			if (counter == 60)
			{
			Projectile.NewProjectile((i + 1.5f) * 16f, (j + 1.5f) * 16f, 0f, 0f, mod.ProjectileType("HealingPulse"), 0, 10f, Main.myPlayer, 0f, 0f);
			counter = 0;
			}
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType<Items.Placeable.MolecularReplicator>());
		}
	}
}