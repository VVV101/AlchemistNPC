using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PinkGuyBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Suit");
			DisplayName.AddTranslation(GameCulture.Russian, "Комбинезон Розового Парня"); 
			Tooltip.SetDefault("Forged from the darkest of materials. Only the best of the best can wear it.");
            Tooltip.AddTranslation(GameCulture.Russian, "Скован из темнейших материалов. Лишь лучшие из лучших могут носить его.");

            DisplayName.AddTranslation(GameCulture.Chinese, "Pink Guy的衣服");
            Tooltip.AddTranslation(GameCulture.Chinese, "用最黑暗的材料锻造而出, 只有最棒最牛的人可以穿上它.\n温馨提示：想简单了解Pink Guy, 可以去B站搜索“粉红人的精♂彩时刻”");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 24;
			item.value = 1650000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}