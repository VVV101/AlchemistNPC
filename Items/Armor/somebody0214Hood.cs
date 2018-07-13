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
	public class somebody0214Hood : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("somebody0214's Hood");
			Tooltip.SetDefault("Great for impersonating a Sun Praiser!");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон somebody0214");
			Tooltip.AddTranslation(GameCulture.Russian, "Отлично подходит для подражания Молящемуся Солнцу"); 
			
			ModTranslation text = mod.CreateTranslation("somebody0214SetBonus");
		text.SetDefault("Increases current magic damage by 30% and adds 20% to magic critical strike chance"
		+ "\n+32 defense"
		+ "\n+25% damage reduction");
		text.AddTranslation(GameCulture.Russian, "Увеличивает текущий магический урон на 30% и добаляет 20% к шансу критического удара\n+32 защиты\n25% поглощение урона");
		mod.AddTranslation(text);
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = -11;
			item.value = 2500000;
			item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("somebody0214Robe");
		}
		
		public override void UpdateArmorSet(Player player)
		{
			string somebody0214SetBonus = Language.GetTextValue("Mods.AlchemistNPC.somebody0214SetBonus");
			player.setBonus = somebody0214SetBonus;
			player.magicDamage *= 1.30f;
			player.magicCrit += 20;
			player.statDefense += 32;
			player.endurance += 0.25f;
		}
	}
}