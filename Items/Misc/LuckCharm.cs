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
	public class LuckCharm : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Luck");
			Tooltip.SetDefault("While placed in inventory, you have better change of getting good/best reforge");
			DisplayName.AddTranslation(GameCulture.Russian, "Талисман Удачи");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, вы имеет более высокий шанс получить лучшую перековку");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 8;
		}
	}
}
