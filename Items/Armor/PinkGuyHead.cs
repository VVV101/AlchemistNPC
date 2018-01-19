using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkGuyHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's hood");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон Розового Парня"); 
			Tooltip.SetDefault("A legendary clothing maybe? No one knows, but once you wear it, you can't go back.");
			Tooltip.AddTranslation(GameCulture.Russian, "Возможно, это легендарное одеяние? Никто не знает, но, одев его однажды, вы уже не сможете его снять."); 
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 100000;
			item.rare = -11;
			item.vanity = true;
		}
	}
}