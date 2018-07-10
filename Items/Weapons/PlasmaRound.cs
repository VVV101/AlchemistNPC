using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PlasmaRound : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasma Round");
			Tooltip.SetDefault("Contains raw energy inside"
			+"\nRequired for using Tritantrum");
			DisplayName.AddTranslation(GameCulture.Russian, "Плазменный заряд");
            Tooltip.AddTranslation(GameCulture.Russian, "Содержит грубую энергию внутри\nНеобходима для использования Тритантрума");
            DisplayName.AddTranslation(GameCulture.Chinese, "等离子体");
            Tooltip.AddTranslation(GameCulture.Chinese, "里面包含原始能量\n是三项之怒的弹药");
        }
		
		public override void SetDefaults()
		{
			item.damage = 15;
			item.ranged = true;
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("PlasmaRound");
			item.shootSpeed = 32f; 
			item.ammo = item.type; //
		}
	}
}
