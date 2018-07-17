using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class SoulEssence : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Essence");
			Tooltip.SetDefault("Contains all traits of a defeated foe");
			DisplayName.AddTranslation(GameCulture.Russian, "Эссенция Души");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит все качества поверженного врага"); 
		}    
		
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.value = 500000;
			item.rare = 9;
		}
	}
}
