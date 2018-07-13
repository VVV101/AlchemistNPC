using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class HateVial : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hate Vial");
			Tooltip.SetDefault("Contains concentrated Hate of a defeated foe"
			+"\nCan be consumed"
			+"\nConsuming grants Hate buff and Potion Sickness debuff for 2 minutes"
			+"\nHeals 150 life"
			+"\nHate buff gives +15% to all damages and crits and +20 to life regeneration"
			+"\nAlso decreases your defense by 30 and endurance by 15%");
			DisplayName.AddTranslation(GameCulture.Russian, "Сосуд с Ненавистью");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит концентрированную Ненависть поверженного врага\nМожет быть выпит\nДаёт бафф Ненависть и дебафф Послезельевая болезнь на 2 минуты\nЛечит на 150 единиц здоровья\nБафф увеличивает все виды урона и криты на 15% и увеличивает регенерацию на 25\nНо также бафф понижает защиту на 30 и стойкость на 15%"); 
		}    
		
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.HealingPotion);
            item.maxStack = 99;
            item.consumable = true;
			item.healLife = 150;
			item.potion = true;
			item.value = 5000000;
			item.rare = 10;
		}
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(21, 7200);
			player.AddBuff(mod.BuffType("Hate"), 7200);
			return true;
		}
	}
}
