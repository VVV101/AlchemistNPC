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
			DisplayName.SetDefault("Simulation Control Unit");
			Tooltip.SetDefault("Exclusive product, designed by Angela"
			+"\nLeft click to change between day and night time"
			+"\nRight click to enable or disable rain (sandstorm in desert)");
			DisplayName.AddTranslation(GameCulture.Russian, "Устройство контроля симуляции");
            Tooltip.AddTranslation(GameCulture.Russian, "Эксклюзивное творение Анджелы\nЛевый клик для смены времени суток\nПравый клик для включения или выключения дождя (песчаной бури в пустыне)");
			DisplayName.AddTranslation(GameCulture.Chinese, "模拟控制单元");
			Tooltip.AddTranslation(GameCulture.Chinese, "独家产品，安吉拉设计\n左键昼夜交换\n右键控制下雨（沙漠中控制沙尘暴）");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Pink;
			item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item4;
			item.consumable = false;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool ConsumeItem(Player player)
		{
			return false;
		}
		
		public override bool UseItem(Player player)
        {
			if (player.altFunctionUse != 2)
            {
				if (Main.dayTime)
				{
					if (Main.netMode == NetmodeID.SinglePlayer || Main.netMode == NetmodeID.MultiplayerClient)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.NightTimeSet"), 255, 255, 255);
					}
					Main.dayTime = false;
					Main.time = 0.0;
					return true;
				}
				if (!Main.dayTime)
				{
					if (Main.netMode == NetmodeID.SinglePlayer || Main.netMode == NetmodeID.MultiplayerClient)
					{
						Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.DayTimeSet"), 255, 255, 255);
					}
					Main.dayTime = true;
					Main.time = 0.0;
					return true;
				}
			}
			if (player.altFunctionUse == 2)
            {
				if (Main.netMode == NetmodeID.SinglePlayer || Main.netMode == NetmodeID.MultiplayerClient)
                {
					Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("Sandrain"), 0, 0, Main.myPlayer);
					return true;
				}

			}
			return base.UseItem(player);
		}
	}
}
