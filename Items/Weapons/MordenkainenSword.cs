using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class MordenkainenSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mordenkainen's Sword");
			Tooltip.SetDefault("Immaterial sword created by Mordenkainen"
			+ "\nSlashes enemies from the distance");
			DisplayName.AddTranslation(GameCulture.Russian, "Меч Морденкайнена");
            Tooltip.AddTranslation(GameCulture.Russian, "Нематериальный клинок, созданный Морденкайненом\nМожет ранить врага на значительном расстоянии");
        }

		public override void SetDefaults()
		{
			item.melee = true;
			item.damage = 36;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 39;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 8;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("MordenkainenSword");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Excalibur);
			recipe.AddIngredient(ItemID.MagnetSphere);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
