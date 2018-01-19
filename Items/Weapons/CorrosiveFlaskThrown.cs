using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CorrosiveFlaskThrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
			Tooltip.SetDefault("Toxic Flask, improved by Celestial Powers.");
			DisplayName.AddTranslation(GameCulture.Russian, "Колба Коррозии");
			Tooltip.AddTranslation(GameCulture.Russian, "Колба с токсинами, улучшенная Небесными Силами"); 
		}    
		public override void SetDefaults()
		{
			item.damage = 175;
			item.thrown = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 100000;
			item.rare = 8;
			item.UseSound = SoundID.Item106;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CorrosiveFlask");
			item.shootSpeed = 16f;
			item.noUseGraphic = true;
			item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ToxicFlask, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}