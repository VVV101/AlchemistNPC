using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class Drainer : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("CalamityMod") != null;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drainer");
			Tooltip.SetDefault("Drains 1/4 of HP while used, fills 1/4 of Rage Meter"
			+"\nPerfect for filling Rage Meter");
			DisplayName.AddTranslation(GameCulture.Russian, "Поглотитель");
            Tooltip.AddTranslation(GameCulture.Russian, "Поглощает 1/4 ХП при применении, пополняет 1/4 Счетчика Ярости\nИдеален для заполнения шкалы Ярости");
        }    
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 36;
			item.maxStack = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 2;
			item.value = 100000;
			item.rare = 9;
			item.UseSound = SoundID.Item4;
		}

		public override bool UseItem(Player player)
		{
		CalamityMod.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalamityPlayer>(Calamity);
			for (int h = 0; h < 1; h++) {
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(player.Center.X, player.Center.Y, vel.X, vel.Y, mod.ProjectileType ("Drainer"), 0, 0, player.whoAmI);
			}
		player.Hurt(PlayerDeathReason.LegacyEmpty(), 2, 0, false, false, false, -1);
		CalamityPlayer.stress += 2500;
		player.statLife = (player.statLife - player.statLifeMax2 / 4);
		PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
		if (Main.rand.Next(2) == 0)
		damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
		if (player.statLife <= 0)
		player.KillMe(damageSource, 1.0, 0, false);
		player.lifeRegenCount = 0;
		player.lifeRegenTime = 0;
		return true;
		}
		
		private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
		
		private Vector2 GetLightPosition(Player player)
		{
			Vector2 position = Main.screenPosition;
			position.X += Main.mouseX;
			position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
			return position;
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
