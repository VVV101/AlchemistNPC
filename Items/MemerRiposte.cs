using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class MemerRiposte : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Memer's Riposte");
			Tooltip.SetDefault("Mirrors 500% of contact damage back to enemy"
			+ "\nIncrease all damage by 15%");
				DisplayName.AddTranslation(GameCulture.Russian, "Ответ Мемеру");
			Tooltip.AddTranslation(GameCulture.Russian, "Отражает 500% контактного урона обратно противнику\nУвеличивает весь урон на 15%"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thorns = 5f;
			player.thrownDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KnucklesUgandaDoll", 1);
			recipe.AddIngredient(null, "PinkGuyHead", 1);
			recipe.AddIngredient(null, "PinkGuyBody", 1);
			recipe.AddIngredient(null, "PinkGuyLegs", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}