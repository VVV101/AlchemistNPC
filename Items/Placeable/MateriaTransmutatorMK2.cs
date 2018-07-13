using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class MateriaTransmutatorMK2 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return (ModLoader.GetMod("CalamityMod") != null && ModLoader.GetMod("AlchemistNPCContentDisabler") == null);
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Materia Transmutator MK2");
			Tooltip.SetDefault("Same functionality as most of crafting stations in one"
			+"\nAdded functionality of Draedon's Forge"
			+"\nAll crafting stations included :)"
			+"\nAlso works as Water/Honey/Lava source");
			DisplayName.AddTranslation(GameCulture.Russian, "Преобразователь Материи MK2");
			Tooltip.AddTranslation(GameCulture.Russian, "Выполняет функции большей части станций крафта в одной\nВсе станции крафта включены :)\nДобавлена функциональность Дредоновой Печи\nРаботает в качестве источника Воды/Мёда/Лавы"); 
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
			item.createTile = mod.TileType("MateriaTransmutatorMK2");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MateriaTransmutator");
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DraedonsForge")), 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}