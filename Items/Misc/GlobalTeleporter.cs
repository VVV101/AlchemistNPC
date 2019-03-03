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
	public class GlobalTeleporter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("World Warper");
			Tooltip.SetDefault(@"Teleports you to any point of the map
Use right-click on full screen map to teleport
Will not work if any boss is alive
Breaks after use
''O, the azure justice, the crimson love,
In the name of the one buried in destiny,
I shall make an oath to the light,
that we will show those who
stand in front of us - the power of love!''");
			DisplayName.AddTranslation(GameCulture.Russian, "Мировой Телепортер");
            Tooltip.AddTranslation(GameCulture.Russian, @"Телепортирует вас в любую точку мира
Нажмите правую кнопку мыши на полноэкранной карте для телепорта
Не сработает, если любой босс жив
Ломается после использования
''O, the azure justice, the crimson love,
In the name of the one buried in destiny,
I shall make an oath to the light,
that we will show those who
stand in front of us - the power of love!''");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.value = 333333;
			item.rare = 6;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).GlobalTeleporter = true;
		}
	}
}
