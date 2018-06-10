using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class LilithEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lilith Emblem");
			Tooltip.SetDefault("Gives 15% magic bonus damage and 10% to critical strike chance"
			+ "\nDecreases mana usage by 15%"
			+ "\nIncreases max mana by 50"
			+ "\nIncreases mana regeneration rate"
			+ "\nIncreases mana stars pickup range"
			+ "\nAutomatically uses mana potions"
			+ "\nYou shoot cluster of deadly bees while using magic weapons"
			+ "\nDoesn't work with some very specific weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "Эмблема Лилит");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 15% и шанс критического удара на 10%\nУменьшает затраты маны на 15%\nУвеличивает максимальную ману на 50\nУскоряет восстановление маны\nУвеличивает радиус сбора звёзд\nАвтоматически использует зелья маны\nВы выстреливает кучку смертоносных пчёл при использовании любого магического оружия\nПоследнее не работает с некоторыми специфическими оружиями"); 
		}
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem = true;
			player.manaMagnet = true;
			player.magicDamage += 0.1f;
			player.magicCrit += 10;
			player.statManaMax2 += 50;
			player.manaFlower = true;
            player.manaCost -= 0.15f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 25;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.BeeGun);
			recipe.AddIngredient(ItemID.WaspGun);
            recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}