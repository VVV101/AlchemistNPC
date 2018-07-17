using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class Drainer : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return (ModLoader.GetMod("CalamityMod") != null && ModLoader.GetMod("AlchemistNPCContentDisabler") == null);
		}
		
		public static int counter = 30;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drainer");
			Tooltip.SetDefault("Drains 250-400 HP, then heal by 200 while held"
			+"\nAlso lowers defense and endurance"
			+"\nPerfect for filling Rage Meter");
			DisplayName.AddTranslation(GameCulture.Russian, "Поглотитель");
            Tooltip.AddTranslation(GameCulture.Russian, "Поглощает по 250-400 ХП, затем вылечивает на 250 ХП, пока вы держите его в руках\nТакже понижает вашу защиту и сопротивление урону\nИдеален для заполнения шкалы Ярости");

            DisplayName.AddTranslation(GameCulture.Chinese, "抽血机");
            Tooltip.AddTranslation(GameCulture.Chinese, "抽出 250-400 血, 然后当持有时治疗200血\n同时降低防御力和耐力\n非常适合用来填充压力条\n温馨提示:这东西可能会把你搞死.什么?你问我是怎么知道的?你猜啊.");
        }    
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 36;
			item.maxStack = 1;
			item.value = 100000;
			item.holdStyle = 1;
			item.rare = 8;
			item.scale = 0.5f;
		}

		public override void HoldItem(Player player)
		{
		player.AddBuff(mod.BuffType("Drainer"), 20);
		if (counter == 30)
			{
				for (int h = 0; h < 1; h++) {
				Vector2 vel = new Vector2(0, -1);
				vel *= 0f;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("Drainer"), 100, 0, player.whoAmI);
				counter = 0;
				}
			}
		counter++;
		}
		
		private Vector2 GetLightPosition(Player player)
		{
			Vector2 position = Main.screenPosition;
			position.X += Main.mouseX;
			position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
			return position;
		}
		
		public override void HoldStyle(Player player)
		{
			Vector2 position = GetLightPosition(player);
			if ((position.Y >= player.Center.Y) == (player.gravDir == 1))
			{
				player.itemLocation.X = player.Center.X + 6f * player.direction;
				player.itemLocation.Y = player.position.Y + 21f + 23f * player.gravDir + player.mount.PlayerOffsetHitbox;
			}
			else
			{
				player.itemLocation.X = player.Center.X;
				player.itemLocation.Y = player.position.Y + 21f - 3f * player.gravDir + player.mount.PlayerOffsetHitbox;
			}
			player.itemRotation = 0f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Spike, 2);
			recipe.AddIngredient(null, "CrystalDust", 10);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
