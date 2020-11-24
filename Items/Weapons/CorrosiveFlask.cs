using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class CorrosiveFlask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrosive Flask");
			Tooltip.SetDefault("Toxic Flask, improved by Celestial Powers.");
			DisplayName.AddTranslation(GameCulture.Russian, "Колба Коррозии");
            Tooltip.AddTranslation(GameCulture.Russian, "Колба с токсинами, улучшенная Небесными Силами");

            DisplayName.AddTranslation(GameCulture.Chinese, "腐蚀烧瓶");
            Tooltip.AddTranslation(GameCulture.Chinese, "被炼金师加强过的剧毒药水");
        }    
		public override void SetDefaults()
		{
			item.damage = 175;
			item.magic = true;
			item.mana = 20;
			item.width = 28;
			item.height = 28;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 10;
			item.value = 100000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item106;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CorrosiveFlaskMagic");
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