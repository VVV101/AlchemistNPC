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
		public int ad = 5;
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Laetitia Coat (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Плащ Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 20%"
			+ "\nDefense grows stronger when certain bosses are killed"
			+ "\nArmor's current defense will be shown in inventory");
			Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает урон прислужников на 20%\nЗащита брони увеличивается после победы над определённым боссами\nТекущая защита брони будет показана в инвентаре");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 7;
			item.defense = ad;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.20f;
			item.defense = ad;
			ad = 5;
			if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 7;
			}
			if (Main.hardMode)
			{
			ad = 10;
			}
			if (NPC.downedMechBoss3)
			{
			ad = 14;
			}
		}
		
		public override void UpdateInventory(Player player)
		{
		item.defense = ad;
		ad = 5;
		if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 7;
			}
		if (Main.hardMode && !NPC.downedMechBossAny)
			{
			ad = 10;
			}
			if (NPC.downedMechBossAny)
			{
			ad = 14;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 25);
			recipe.AddIngredient(ItemID.Cobweb, 50);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 20);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 12);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}