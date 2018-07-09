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
		public int ad = 4;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Leggings (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 10%"
			+ "\nDefense grows stronger when certain bosses are killed"
			+ "\nArmor's current defense will be shown in inventory");
            Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает урон прислужников на 10%\nЗащита брони увеличивается после победы над определённым боссами\nТекущая защита брони будет показана в инвентаре");
            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅袜统 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'外套上精美的丝带和蝴蝶结寄托着少女对幸福的向往, 一个孩子不能离开朋友.'\n[c/FF0000:EGO 盔甲]\n增加10%召唤物伤害\n击败一些Boss之后增加防御力\n盔甲的当前防御力会显示在盔甲上");
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
			player.minionDamage += 0.1f;;
			item.defense = ad;
			ad = 4;
			if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 6;
			}
			if (Main.hardMode && !NPC.downedMechBossAny)
			{
			ad = 9;
			}
			if (NPC.downedMechBossAny)
			{
			ad = 13;
			}
		}
		
		public override void UpdateInventory(Player player)
		{
		item.defense = ad;
		ad = 4;
		if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 6;
			}
		if (Main.hardMode)
			{
			ad = 9;
			}
		if (NPC.downedMechBossAny)
			{
			ad = 13;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.Cobweb, 40);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 15);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}