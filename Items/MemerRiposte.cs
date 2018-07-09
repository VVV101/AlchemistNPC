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
			Tooltip.SetDefault("Mirrors 500% of damage back to all enemies on screen"
			+ "\nIncrease all damage by 15%"
			+ "\nCuts your critical strike chance by half, but they can deal 4x damage");
				DisplayName.AddTranslation(GameCulture.Russian, "Ответ Мемеру");
            Tooltip.AddTranslation(GameCulture.Russian, "Отражает 500% урона обратно всем противникам на экране\nУвеличивает весь урон на 15%\nУменьшает ваш шанс критического удара вдвое, но крит может нанести 4-х кратный урон");
            DisplayName.AddTranslation(GameCulture.Chinese, "Memer的反击");
            Tooltip.AddTranslation(GameCulture.Chinese, "反弹500%的伤害\n增加15%全伤害\n暴击几率减半, 但是暴击能造成4倍伤害");
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
			player.thrownDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
			player.meleeCrit /= 2;
			player.magicCrit /= 2;
			player.rangedCrit /= 2;
			player.thrownCrit /= 2;
			player.meleeCrit -= 5;
			player.magicCrit -= 5;
			player.rangedCrit -= 5;
			player.thrownCrit -= 5;
			AlchemistNPC.MemersRiposte = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "KnucklesUgandaDoll", 1);
			recipe.AddIngredient(null, "BanHammer", 1);
			recipe.AddIngredient(null, "PinkGuyHead", 1);
			recipe.AddIngredient(null, "PinkGuyBody", 1);
			recipe.AddIngredient(null, "PinkGuyLegs", 1);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}