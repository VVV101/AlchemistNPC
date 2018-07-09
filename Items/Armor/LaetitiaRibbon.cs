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
		public int ad = 3;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laetitia Ribbon (O-01-67)");
			DisplayName.AddTranslation(GameCulture.Russian, "Ленточка Летиции (O-01-67)"); 
			Tooltip.SetDefault("The ribbon on the coat represents a child’s yearn for happiness. A child who could not leave their friends."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases summon damage by 5%"
			+ "\nDefense grows stronger when certain bosses are killed"
			+ "\nArmor's current defense will be shown in inventory");
            Tooltip.AddTranslation(GameCulture.Russian, "Ленточка на плаще отражает мольбу дитя о счастье. Дитя, что не может покинуть своих друзей.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает урон прислужников на 5%\nЗащита брони увеличивается после победы над определённым боссами\nТекущая защита брони будет показана в инвентаре");
            DisplayName.AddTranslation(GameCulture.Chinese, "蕾蒂希娅缎带 (O-01-67)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'外套上精美的丝带和蝴蝶结寄托着少女对幸福的向往, 一个孩子不能离开朋友.'\n[c/FF0000:EGO 盔甲]\n增加5%召唤物伤害\n击败一些Boss之后增加防御力\n盔甲的当前防御力会显示在盔甲上");

            ModTranslation text = mod.CreateTranslation("LaetitiaSetBonus");
            text.SetDefault("Allows to summon Little Witch Monster from the Gift"
            + "\nMinion damage grows stronger by additional 35% in Hardmode"
            + "\nDoubles speed of Laetitia Rifle");
            text.AddTranslation(GameCulture.Russian, "Позволяет призвать Монстра Маленькой Ведьмы из Дара.\nУрон прислужников дополнительно увеличивается на 35% в Хардмоде.");
            text.AddTranslation(GameCulture.Chinese, "允许召唤来自礼物的小巫怪\n肉后增加35%召唤伤害\n蕾蒂希娅来复枪射速加倍");
            mod.AddTranslation(text);
        }
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 7;
			item.defense = ad;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("LaetitiaCoat") && legs.type == mod.ItemType("LaetitiaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string LaetitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPC.LaetitiaSetBonus");
			player.setBonus = LaetitiaSetBonus;
			AlchemistNPC.LaetitiaSet = true;
			if (Main.hardMode)
			{
			player.minionDamage += 0.35f;
			}
			player.GetModPlayer<AlchemistNPCPlayer>(mod).jr = true;
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.05f;
			item.defense = ad;
			ad = 3;
			if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 5;
			}
			if (Main.hardMode && !NPC.downedMechBossAny)
			{
			ad = 8;
			}
			if (NPC.downedMechBossAny)
			{
			ad = 12;
			}
		}
		
		public override void UpdateInventory(Player player)
		{
		item.defense = ad;
		ad = 3;
		if (NPC.downedBoss3 && !Main.hardMode)
			{
			ad = 5;
			}
		if (Main.hardMode && !NPC.downedMechBossAny)
			{
			ad = 8;
			}
		if (NPC.downedMechBossAny)
			{
			ad = 12;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.Cobweb, 30);
			recipe.AddRecipeGroup("AlchemistNPC:EvilComponent", 10);
			recipe.AddRecipeGroup("AlchemistNPC:EvilMush", 5);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}