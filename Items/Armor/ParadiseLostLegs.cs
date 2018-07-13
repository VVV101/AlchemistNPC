using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ParadiseLostLegs : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost Leggings (T-03-46)");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Потерянного Рая (T-03-46)"); 
			Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
			+ "\nHave thou not yet realized that pain is nothing?"
			+ "\nThou want me to prove the miracle."
			+ "\nThou shall believe in me and granted with life. I shall show you the power.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\n66% increased movement speed");
			Tooltip.AddTranslation(GameCulture.Russian, "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает скорость передвижения на 66%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 11;
			item.defense = 40;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.66f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TwilightLeggings");
			recipe.AddIngredient(null, "ChromaticCrystal", 8);
			recipe.AddIngredient(null, "SunkroveraCrystal", 8);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 8);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 11);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 20);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 4);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 4);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 4);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 200);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}