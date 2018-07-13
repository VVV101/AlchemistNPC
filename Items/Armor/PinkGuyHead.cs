using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkGuyHead : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Hood");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон Розового Парня"); 
			Tooltip.SetDefault("A legendary clothing maybe? No one knows, but once you wear it, you can't go back.");
			Tooltip.AddTranslation(GameCulture.Russian, "Возможно, это легендарное одеяние? Никто не знает, но, одев его однажды, вы уже не сможете его снять."); 
		
		ModTranslation text = mod.CreateTranslation("PGSetBonus");
		text.SetDefault("Increases current ranged/melee damage by 15% and adds 15% to ranged/melee critical strike chance"
		+ "\n+56 defense"
		+ "\nIncreases movement speed greatly"
		+ "\nPlayer is under permanent effect of Tank Combination"
		+ "\nNational Ugandan Treasure can now be dropped from Moon Lord"
		+ "\nMay be required to equip set to all players in MP to make NUT drop");
		text.AddTranslation(GameCulture.Russian, "Увеличивает текущий урон в дальнем/ближнем бою на 15% и добавляет 15% к шансу критического удара\n+56 защиты\nНациональное Сокровище Уганды может выпасть с Лунного Лорда\nВ мультиплеере может быть необходимо экипировать сет на всех игроков");
		mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("PinkGuyBody") && legs.type == mod.ItemType("PinkGuyLegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			AlchemistNPC.PGSWear = true;
			string PGSetBonus = Language.GetTextValue("Mods.AlchemistNPC.PGSetBonus");
			player.setBonus = PGSetBonus;
            player.statDefense += 56;
			player.rangedDamage += 0.15f;
            player.meleeDamage += 0.15f;
            player.rangedCrit += 15;
			player.meleeCrit += 15;
			player.moveSpeed += 0.50f;
			player.AddBuff(mod.BuffType("TankComb"), 30);
		}
	}
}