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
	public class GlobalTeleporterUp : ModItem
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Modified World Warper");
			Tooltip.SetDefault(@"Teleports you to any point of the map
Use right-click on full screen map to teleport
Will not work if any boss is alive
Not breaks after use
''O, the azure justice, the crimson love,
In the name of the one buried in destiny,
I shall make an oath to the light,
that we will show those who
stand in front of us - the power of love!''");
			DisplayName.AddTranslation(GameCulture.Russian, "Модифицорованный мировой Телепортер");
            Tooltip.AddTranslation(GameCulture.Russian, @"Телепортирует вас в любую точку мира
Нажмите правую кнопку мыши на полноэкранной карте для телепорта
Не сработает, если любой босс жив
Не ломается после использования
''O, the azure justice, the crimson love,
In the name of the one buried in destiny,
I shall make an oath to the light,
that we will show those who
stand in front of us - the power of love!''");
			DisplayName.AddTranslation(GameCulture.Chinese, "改良世界传送装置");
			Tooltip.AddTranslation(GameCulture.Chinese, @"将你传送到地图的任意位置
在全屏地图界面点击右键传送
Boss存活时无法使用
使用后不会破坏
''噢, 蔚蓝的正义, 深红的爱,
为了被命运吞没的人而战
我向光明宣誓
邪恶的坏蛋不能阻挡我们
爱之力量守护我们!''");
        }

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.maxStack = 99;
			item.value = 333333333;
			item.rare = 11;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).GlobalTeleporterUp = true;
		}
	}
}
