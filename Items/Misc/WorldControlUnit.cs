using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class WorldControlUnit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Simalation Control Unit");
			Tooltip.SetDefault("Exclusive product, designed by Angela"
			+"\nLeft click to change between day and night time"
			+"\nRight click to enable or disable rain (sandstorm in desert)");
			DisplayName.AddTranslation(GameCulture.Russian, "Устройства контроля симуляции");
            Tooltip.AddTranslation(GameCulture.Russian, "Эксклюзивное творение Анджелы\nЛевый клик для смены времени суток\nПравый клик для включения или выключения дождя (песчаной бури в пустыне)");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = 5;
			item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 4;
			item.UseSound = SoundID.Item4;
			item.consumable = false;
		}
		
		public override bool CanRightClick()
        {            
            return true;
        }

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

        public override void RightClick(Player player)
        {
			Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("Sandrain"), 0, 0, Main.myPlayer);
		}
		
		public override bool UseItem(Player player)
        {
			if (Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.NightTimeSet"), 255, 255, 255);
				}
				Main.dayTime = false;
				Main.time = 0.0;
				return true;
			}
			if (!Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.DayTimeSet"), 255, 255, 255);
				}
				Main.dayTime = true;
				Main.time = 0.0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
