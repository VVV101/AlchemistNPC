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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("somebody0214's Hood");
			Tooltip.SetDefault("Great for impersonating a Sun Praiser!");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон somebody0214");
			Tooltip.AddTranslation(GameCulture.Russian, "Отлично подходит для подражания Молящемуся Солнцу"); 
		}
		
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = -11;
			item.vanity = true;
		}
	}
}