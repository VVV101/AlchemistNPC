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
			DisplayName.AddTranslation(GameCulture.Chinese, "反buff模式");
			Tooltip.AddTranslation(GameCulture.Chinese, "使用以切换反buff模式"
			+"\n在反buff模式中，你将免疫所有增益buff(而不是debuff)"
			+"\n没有持续时间的buff不会被禁止"
			+"\nBoss和一些小Boss会掉落永久增益物品"
			+"\n这些物品的效果只会在这个模式启动时生效");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
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
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.AntiBuffmodeactive"), 255, 255, 255);
				}
				AlchemistNPCWorld.foundAntiBuffMode = true;
				return true;
			}
			if (AlchemistNPCWorld.foundAntiBuffMode)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Mods.AlchemistNPC.Common.AntiBuffmodeisdisabled"), 255, 255, 255);
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
