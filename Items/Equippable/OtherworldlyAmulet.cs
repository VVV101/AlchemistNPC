using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class OtherworldlyAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Otherworldly Amulet");
			Tooltip.SetDefault("Only obtainable from the strongest of enemies."
				+ "\nLegends say that it can do something amazing");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(25, 36));
			DisplayName.AddTranslation(GameCulture.Russian, "Амулет Иного Мира");
            Tooltip.AddTranslation(GameCulture.Russian, "Можно добыть из сильнейшего из врагов.\nЛегенды говорят, что он способен на нечто впечатляющее");

            DisplayName.AddTranslation(GameCulture.Chinese, "异界护身符");
            Tooltip.AddTranslation(GameCulture.Chinese, "只能从最强大的敌人那里得到\n传说可以用它做一些了不起的事情");
        }    
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BlessedApple);
			item.width = 32;
			item.height = 30;
			item.value = 5000000;
			item.rare = 11;
			item.noUseGraphic = true;
			item.mountType = mod.MountType("Poro");
		}
	}
}
