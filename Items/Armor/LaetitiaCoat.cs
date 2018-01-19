using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LaetitiaCoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Laetitia Coat (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Плащ Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 20%.");
			Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 7;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 25);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}