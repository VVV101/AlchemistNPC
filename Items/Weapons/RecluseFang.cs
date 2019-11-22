using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Weapons
{
	public class RecluseFang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recluse's Fang");
            Tooltip.SetDefault("Throws venomous boomerang");
            DisplayName.AddTranslation(GameCulture.Russian, "Клык Реклюзы");
            Tooltip.AddTranslation(GameCulture.Russian, "Бросает ядовитый бумеранг");
        }   
		
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Bananarang);
			item.damage = 48;
			item.melee = false;
			item.thrown = true;
			item.maxStack = 1;
			item.rare = 2;
			item.value = 3333;
			item.useTime = 15;
			item.useAnimation = 15;
			item.shootSpeed = 16f;
			item.shoot = mod.ProjectileType("RecluseFang");
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpiderFang, 12);
            recipe.AddIngredient(mod.ItemType("SpiderFangarang"), 3);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}