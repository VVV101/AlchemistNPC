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
	public class BlackCatHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cat's bow and ears");
			DisplayName.AddTranslation(GameCulture.Russian, "Бантик и ушки Чёрной Кошки");
            DisplayName.AddTranslation(GameCulture.Chinese, "黑猫的头箍和耳朵");
			
			ModTranslation text = mod.CreateTranslation("BlackCatSetBonus");
		    text.SetDefault("Increases current melee damage by 25% and adds 15% to melee critical strike chance"
		    + "\n+48 defense"
		    + "\nIncreases movement speed by 33%"
		    + "\nPlayer is under permanent effect of Battle Combination"
            + "\nGrants the abilities of a Master Ninja");
			text.AddTranslation(GameCulture.Russian, "Увеличивает текущий урон в ближнем бою на 25% и добавляет 15% к шансу критического удара\n+48 защиты\nИгрок находится под постоянным эффектом комбинации Битвы\nДаёт способности Мастера Ниндзя");
			text.AddTranslation(GameCulture.Chinese, "增加25%当前近战伤害, 增加15%近战暴击几率"
            + "\n增加 48 防御力"
            + "\n极大增加移动速度"
            + "\n给予永久坦战药剂包效果"
            + "\n并获得忍者大师的能力");
			mod.AddTranslation(text);
        }
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("BlackCatBody") && legs.type == mod.ItemType("BlackCatLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
            string BlackCatSetBonus = Language.GetTextValue("Mods.AlchemistNPC.BlackCatSetBonus");
			player.setBonus = BlackCatSetBonus;
            player.statDefense += 48;
            player.meleeDamage += 0.25f;
			player.meleeCrit += 15;
			player.moveSpeed += 0.33f;
			player.AddBuff(mod.BuffType("BattleComb"), 30);
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
	}
}