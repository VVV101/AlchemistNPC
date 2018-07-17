using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC.Items.PaleDamageClass;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ParadiseLostHead : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost Crown of Thorns (T-03-46)");
			DisplayName.AddTranslation(GameCulture.Russian, "Терновый Венец Потерянного Рая (T-03-46)"); 
			Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
			+ "\nHave thou not yet realized that pain is nothing?"
			+ "\nThou want me to prove the miracle."
			+ "\nThou shall believe in me and granted with life. I shall show you the power.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\n+100 max mana"
			+ "\nIncreases melee speed by 33%");
			Tooltip.AddTranslation(GameCulture.Russian, "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Э.П.О.С часть брони]\n+100 к максимуму маны\nУвеличивает скорость атак в ближнем бою 35%");
		ModTranslation text = mod.CreateTranslation("ParadiseLostSetBonus");
		text.SetDefault("Increases all damage by 35% and adds 25% to critical strike chances"
		+ "\nMakes EGO weapons deal much more damage"
		+ "\nChanges would be seen after first usage of weapon"
		+ "\nIf you are taking less than 150 damage, then it would be nullified.");
		text.AddTranslation(GameCulture.Russian, "Увеличивает все виды урона на 35% и добаляет 25% к шансу критического удара\nЭ.П.О.С. оружия будут наносить значительно больше урона\nЕсли вы получаете меньше 150 урона, то урон будет предотвращён");
		mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 11;
			item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 100;
			player.meleeSpeed *= 1.33f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("ParadiseLostBody") && legs.type == mod.ItemType("ParadiseLostLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			string ParadiseLostSetBonus = Language.GetTextValue("Mods.AlchemistNPC.ParadiseLostSetBonus");
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost = true;
			player.setBonus = ParadiseLostSetBonus;
			player.meleeDamage *= 1.35f;
			player.magicDamage *= 1.35f;
			player.minionDamage *= 1.35f;
			player.magicDamage *= 1.35f;
			player.thrownDamage *= 1.35f;
			player.meleeCrit += 25;
			player.magicCrit += 25;
			player.rangedCrit += 25;
            player.thrownCrit += 25;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TwilightCrown");
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 7);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 15);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}