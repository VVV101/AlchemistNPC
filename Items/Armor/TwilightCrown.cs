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
	public class TwilightCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Crown (O-02-63)");
			DisplayName.AddTranslation(GameCulture.Russian, "Сумеречная Корона (O-02-63)"); 
			Tooltip.SetDefault("''Efforts of three birds to defeat the beast became one."
			+ "\nIt could stop countless incidents but you’d have to be prepared to step into the Black Forest.''"
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases melee speed by 30%");

            DisplayName.AddTranslation(GameCulture.Chinese, "天启鸟王冠 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'为了击退黑森林里的可怕“怪物”, 三只鸟齐心协力, 合为一体.'\n'它能避免很多无辜的人遇害, 但在那之前, 你必须做好万无一失的准备, 去踏入那片黑暗而又绝望的森林.'\n[c/FF0000:EGO 盔甲]\n增加30%近战伤害");

            Tooltip.AddTranslation(GameCulture.Russian, "''Усилия трёх птиц, чтобы одолеть Зверя, стали едиными.\nОно способно остановить бесчисленные несчастные случаи.\nНо вам нужно быть готовыми, чтобы войти в Тёмный Лес.''\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость ближнего боя на 30%");
		    ModTranslation text = mod.CreateTranslation("TwilightSetBonus");
		    text.SetDefault("Increases current melee/magic damage by 30% and adds 15% to melee/magic critical strike chance"
		    + "\nIncludes all bonuses from Big Bird Lamp");
            text.AddTranslation(GameCulture.Russian, "Увеличивает текущий урон в ближнем бою/магический на 30% и добаляет 15% к шансу критического удара\nВключает в себя бонусы от Лампы Большой Птицы");
            text.AddTranslation(GameCulture.Chinese, "增加30%当前近战/魔法伤害并增加15%近战/魔法暴击几率\n包含大鸟灯的全部效果");
            mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.30f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TwilightSuit") && legs.type == mod.ItemType("TwilightLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string TwilightSetBonus = Language.GetTextValue("Mods.AlchemistNPC.TwilightSetBonus");
			player.setBonus = TwilightSetBonus;
			player.meleeDamage += 0.35f;
			player.magicDamage += 0.35f;
			player.meleeCrit += 20;
			player.magicCrit += 20;
			player.AddBuff(mod.BuffType("BigBirdLamp"), 300);
			player.thrownDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JustitiaCrown");
			recipe.AddIngredient(null, "MasksBundle");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}