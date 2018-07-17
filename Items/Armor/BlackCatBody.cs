using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BlackCatBody : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Black Cat's dress");
			DisplayName.AddTranslation(GameCulture.Russian, "Платье Чёрной Кошки");
            DisplayName.AddTranslation(GameCulture.Chinese, "黑猫的裙子");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}