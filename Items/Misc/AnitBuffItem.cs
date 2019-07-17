using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class AntiBuffItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Anti Buff");
			Tooltip.SetDefault("Use to toggle Anti Buff mode"
			+"\nDuring Anti Buff mode, you are immune to all buffs (not debuffs)"
			+"\nBuffs without duration display are not disabled"
			+"\nBosses and minibosses may drop permament boosting items"
			+"\nTheir effects would work only if mode is on");
			DisplayName.AddTranslation(GameCulture.Russian, "Анти Бафф");
            Tooltip.AddTranslation(GameCulture.Russian, "Используйте для переключения Анти Бафф режима\nВы имунны ко всем баффам (не дебаффам)\nБаффы не показывающие длительности разрешены\nИз боссов и минибоссов могут выпадать предметы, дающие эффекты постоянного усиления\nЭти эффекты активны только когда режим включён");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 500000;
			item.rare = 5;
			item.useAnimation = 20;
            item.useTime = 20;
            item.useStyle = 4;
			item.UseSound = SoundID.Item4;
		}
		
		public override bool UseItem(Player player)
        {
			if (!AlchemistNPCWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText("Anti Buff mode is active", 255, 255, 255);
				}
				AlchemistNPCWorld.foundAntiBuffMode = true;
				return true;
			}
			if (AlchemistNPCWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText("Anti Buff mode is disabled", 255, 255, 255);
				}
				AlchemistNPCWorld.foundAntiBuffMode = false;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
