using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LaetitiaLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Leggings (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 20%.");
			Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает урон прислужников на 20%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 7;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.2f;;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.SoulofFright, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}