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
	public class ViolentToken : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Violent Token");
			Tooltip.SetDefault("While this is in your inventory, your next accessory reforge would be ''Violent''"
			+"\nReforging priorities: Menacing->Lucky->Violent->Warding"
			+"\nConsumes in process");
			DisplayName.AddTranslation(GameCulture.Russian, "Значок Жестокости");
            Tooltip.AddTranslation(GameCulture.Russian, "Если находится в инвентаре, ваше следующая перековка аксессуара будет ''Жестокий''\nБудет потрачен в процессе");
			DisplayName.AddTranslation(GameCulture.Chinese, "暴力重铸币");
			Tooltip.AddTranslation(GameCulture.Chinese, "放置于物品栏时, 饰品下一次重铸时词缀变为'暴力'\n重铸优先级: 险恶->幸运->暴力->护佑\n在过程中将会被消耗");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 250000;
			item.rare = 7;
		}
	}
}
