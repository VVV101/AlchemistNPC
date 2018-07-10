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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Essence");
			Tooltip.SetDefault("Contains all traits of defeated foe");
			DisplayName.AddTranslation(GameCulture.Russian, "Эссенция Души");
			Tooltip.AddTranslation(GameCulture.Russian, "Хранит все качества поверженного врага");
            DisplayName.AddTranslation(GameCulture.Chinese, "灵魂精华");
            Tooltip.AddTranslation(GameCulture.Chinese, "充满着来自被击败敌人的特征");
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
