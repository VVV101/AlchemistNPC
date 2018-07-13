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
	[AutoloadEquip(EquipType.Body)]
	public class ParadiseLostBody: ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Paradise Lost Suit (T-03-46)");
			DisplayName.AddTranslation(GameCulture.Russian, "Костюм Потерянного Рая (T-03-46)"); 
			Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
			+ "\nHave thou not yet realized that pain is nothing?"
			+ "\nThou want me to prove the miracle."
			+ "\nThou shall believe in me and granted with life. I shall show you the power.''"
				+ "\n[c/FF0000:EGO armor piece]"
				+ "\n+300 maximum HP"
				+ "\n+33% damage reduction"
				+ "\nImmune to most vanilla debuffs");
			Tooltip.AddTranslation(GameCulture.Russian, "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Э.П.О.С часть брони]\n+300 к максимальному здоровью\n+33% к поглощению урона\nИммунитет к большинству немодовых дебаффов");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 11;
			item.defense = 45;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 300;
			player.endurance += 0.33f;
			player.buffImmune[46] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;
			player.buffImmune[24] = true;
			player.buffImmune[39] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[69] = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TwilightSuit");
			recipe.AddIngredient(null, "ChromaticCrystal", 10);
			recipe.AddIngredient(null, "SunkroveraCrystal", 10);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}