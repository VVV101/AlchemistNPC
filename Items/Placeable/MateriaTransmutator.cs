using System;
using System.Linq;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class MateriaTransmutator : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Same functionality as most of crafting stations in one"
            + "\nAll crafting stations included :)"
            + "\nAlso works as Water/Honey/Lava source");
            DisplayName.AddTranslation(GameCulture.Russian, "Преобразователь Материи");
            Tooltip.AddTranslation(GameCulture.Russian, "Выполняет функции большей части станций крафта в одной\nВсе станции крафта включены :)\nРаботает в качестве источника Воды/Мёда/Лавы");

            DisplayName.AddTranslation(GameCulture.Chinese, "物质嬗变器");
            Tooltip.AddTranslation(GameCulture.Chinese, "非常多制造环境的集合\n包含了所有的原版制作环境 :)\n同样也属于水/蜂蜜/岩浆环境");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 11;
			item.value = 1000000;
			item.createTile = mod.TileType("MateriaTransmutator");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "PreHMPenny");
			recipe.AddIngredient(null, "HMCraftPound");
			recipe.AddIngredient(null, "SpecCraftPoint");
			recipe.AddIngredient(null, "WingoftheWorld");
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.DD2ElderCrystalStand);
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").TileType("ThoriumAnvil")));
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator")));
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").TileType("SoulForge")));
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}