using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			+ "\nArmor's base defense is 5");
            Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не могло покинуть своих друзей.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает урон прислужников на 20%\nЗащита увеличивается после убийства определенных боссов\nБазовая защита равна 5");
            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅外套 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'外套上精美的丝带和蝴蝶结寄托着少女对幸福的向往, 一个孩子不能离开朋友.'\n[c/FF0000:EGO 盔甲]\n增加20%召唤物伤害\n击败特定Boss之后增加防御力\n基础防御力为5");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = ItemRarityID.Lime;
			item.defense = ad;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.2f;
			item.defense = ad;
			ad = 5;
			if (NPC.downedQueenBee)
			{
				ad = 6;
			}
			if (NPC.downedBoss3)
			{
				ad = 7;
			}
			if (Main.hardMode)
			{
				ad = 10;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 12;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 14;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 16;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 18;
			}
			if (NPC.downedFishron)
			{
				ad = 20;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 21;
			}
			if (NPC.downedMoonlord)
			{
				ad = 24;
			}
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			item.defense = ad;
			ad = 5;
			if (NPC.downedQueenBee)
			{
				ad = 6;
			}
			if (NPC.downedBoss3)
			{
				ad = 7;
			}
			if (Main.hardMode)
			{
				ad = 10;
			}
			if (NPC.downedMechBossAny)
			{
				ad = 12;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				ad = 14;
			}
			if (NPC.downedPlantBoss)
			{
				ad = 16;
			}
			if (NPC.downedGolemBoss)
			{
				ad = 18;
			}
			if (NPC.downedFishron)
			{
				ad = 20;
			}
			if (NPC.downedAncientCultist)
			{
				ad = 21;
			}
			if (NPC.downedMoonlord)
			{
				ad = 24;
			}
			string text1 = ad + " defense";
			TooltipLine line = new TooltipLine(mod, "text1", text1);
			line.overrideColor = Color.White;
			tooltips.RemoveAt(2);
			tooltips.Insert(2,line);
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