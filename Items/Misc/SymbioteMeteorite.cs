using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
    public class SymbioteMeteorite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mystery Meteorite");
			DisplayName.AddTranslation(GameCulture.Russian, "Загадочный метеорит");
            Tooltip.SetDefault("Its external shell is insanely durable\nYou probably need to find someone who may help you break it");
			Tooltip.AddTranslation(GameCulture.Russian, "Его внешняя оболочка невероятно прочна\nВероятно, вам стоит найти кого-нибудь, кто поможет её пробить");
        }
        public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.maxStack = 1;
			item.value = 1000000;
			item.rare = 12;
		}
    }
}