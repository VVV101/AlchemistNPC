using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LaetitiaRibbon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Ribbon (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Ленточка Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 15%.");
			Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает урон прислужников на 15%");
		
		ModTranslation text = mod.CreateTranslation("LaetitiaSetBonus");
		text.SetDefault("Allows to summon Little Witch Monster from the Gift");
		text.AddTranslation(GameCulture.Russian, "Позволяет призвать Монстра Маленькой Ведьмы из Дара");
		mod.AddTranslation(text);
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 7;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LaetitiaCoat") && legs.type == mod.ItemType("LaetitiaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string LaetitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPC.LaetitiaSetBonus");
			player.setBonus = LaetitiaSetBonus;
			player.GetModPlayer<AlchemistNPCPlayer>(mod).jr = true;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.15f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}