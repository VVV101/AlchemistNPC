using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class MysticAmulet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystic Amulet");
			Tooltip.SetDefault("Grants Telekinesis ability to its wielder"
				+ "\nCan be used for flying");
			DisplayName.AddTranslation(GameCulture.Russian, "Мистический Амулет");
            Tooltip.AddTranslation(GameCulture.Russian, "Даёт носителю способность к Телекинезу\nПозволяет летать");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘护符");
            Tooltip.AddTranslation(GameCulture.Chinese, "使使用者获得心灵促动的能力\n可用来飞行");
        }    
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BlessedApple);
			item.width = 32;
			item.height = 30;
			item.value = 5000000;
			item.rare = ItemRarityID.Purple;
			item.mountType = mod.MountType("MysticAmulet");
		}
	}
}
