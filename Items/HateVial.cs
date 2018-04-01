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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hate Vial");
			Tooltip.SetDefault("Contains concentrated Hate of defeated foe");
			DisplayName.AddTranslation(GameCulture.Russian, "Сосуд с Ненавистью");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит концентрированную Ненависть поверженного врага"); 
		}    
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.value = 5000000;
			item.rare = 10;
		}
	}
}
