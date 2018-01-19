using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
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
		}    
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 30;
			item.maxStack = 999;
			item.value = 5000000;
			item.rare = 8;
			item.knockBack = 6;
			item.UseSound = SoundID.Item79;
			item.noMelee = true;
			item.mountType = mod.MountType("Poro");
		}
	}
}
