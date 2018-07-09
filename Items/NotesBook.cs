using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class NotesBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Notes Book");
			Tooltip.SetDefault("Can open open portal to Other World"
			+"\nCan be used only on certain conditions");
			DisplayName.AddTranslation(GameCulture.Russian, "Книга с Записками");
            Tooltip.AddTranslation(GameCulture.Russian, "Может открыть портал в Другой Мир\nМожет быть использована только в определённых условиях");
            DisplayName.AddTranslation(GameCulture.Chinese, "笔记本");
            Tooltip.AddTranslation(GameCulture.Chinese, "能开启一个前往其他世界的传送门\n只能在某些条件下使用");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 30;
			item.value = 5000000;
			item.rare = 11;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return (!NPC.AnyNPCs(mod.NPCType("OtherworldlyPortal")) && !NPC.AnyNPCs(mod.NPCType("Explorer")) && Main.eclipse);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("OtherworldlyPortal"));
			return true;
		}
	}
}