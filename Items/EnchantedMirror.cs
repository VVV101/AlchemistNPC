using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
    public class EnchantedMirror : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Mirror");
			Tooltip.SetDefault("Left click return you home"
			+ "\nRight click teleports you back to recall point");
			DisplayName.AddTranslation(GameCulture.Russian, "Зачарованное Зеркало");
			Tooltip.AddTranslation(GameCulture.Russian, "Возвращает вас домой при использовании\nВозвращает вас на место предыдущей телепортации по нажатию правой кнопки мыши"); 
		}    
		public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MagicMirror);
            item.maxStack = 1;
			item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = false;
            return;
        }
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 0)
			{
			AlchemistNPC.ppx = player.position.X;
			AlchemistNPC.ppy = player.position.Y;
			player.Spawn();
			player.AddBuff(BuffID.ChaosState, 300);
			}
			if (player.altFunctionUse == 2)
			{
			HandleRecallTeleport(player);
			player.AddBuff(BuffID.ChaosState, 300);
			}
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			return (player.HasBuff(BuffID.ChaosState) == false);
		}
		
		private static void HandleRecallTeleport(Player player, bool syncData = false)
		{
			if (AlchemistNPC.ppx != 0f)
			{
			RunTeleport(player, new Vector2(AlchemistNPC.ppx, AlchemistNPC.ppy), syncData, false);
			}
			else return;
		}
		
		private static void RunTeleport(Player player, Vector2 pos, bool syncData = false, bool convertFromTiles = false)
		{
			bool postImmune = player.immune;
			int postImmunteTime = player.immuneTime;

			if (convertFromTiles)
				pos = new Vector2(pos.X * 16 + 8 - player.width / 2, pos.Y * 16 - player.height);

			LeaveDust(player);

			player.grappling[0] = -1;
			player.grapCount = 0;
			for (int index = 0; index < 1000; ++index)
			{
				if (Main.projectile[index].active && Main.projectile[index].owner == player.whoAmI && Main.projectile[index].aiStyle == 7)
					Main.projectile[index].Kill();
			}

			player.Teleport(pos, 2, 0);
			player.velocity = Vector2.Zero;
			player.immune = postImmune;
			player.immuneTime = postImmunteTime;

			LeaveDust(player);

			if (Main.netMode != 2)
				return;

			if (syncData)
			{
				RemoteClient.CheckSection(player.whoAmI, player.position, 1);
				NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, pos.X, pos.Y, 3, 0, 0);
			}
		}

		private static void LeaveDust(Player player)
		{
			for (int index = 0; index < 70; ++index)
				Main.dust[Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.2f, player.velocity.Y * 0.2f, 150, Color.Cyan, 1.2f)].velocity *= 0.5f;
			Main.TeleportEffect(player.getRect(), 1);
			Main.TeleportEffect(player.getRect(), 3);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Beacon");
			recipe.AddIngredient(ItemID.MagicMirror);
			recipe.AddIngredient(ItemID.RecallPotion, 30);
			recipe.AddIngredient(ItemID.WormholePotion, 30);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
    }
}
