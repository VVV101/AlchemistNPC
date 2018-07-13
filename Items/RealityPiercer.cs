using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items
{
	public class RealityPiercer : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reality Piercer");
			Tooltip.SetDefault("Makes Explorer to come into unobserved world.");
			DisplayName.AddTranslation(GameCulture.Russian, "Прорыватель Реальности");
			Tooltip.AddTranslation(GameCulture.Russian, "Позволяет Исследовательнице прийти в необследованный мир."); 
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
			return (!NPC.AnyNPCs(mod.NPCType("Explorer")));
		}

		public override bool UseItem(Player player)
		{
			Main.NewText("Explorer has come.", 255, 255, 255);
			NPC.NewNPC((int)player.Center.X+Main.rand.Next(-150,150), (int)player.Center.Y, mod.NPCType("Explorer"));
			return true;
		}
	}
}