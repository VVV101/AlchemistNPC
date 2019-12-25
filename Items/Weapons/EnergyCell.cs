using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EnergyCell : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Requred to shoot from Quantum Destabilizer");
			DisplayName.AddTranslation(GameCulture.Russian, "Энергоячейка");
            Tooltip.AddTranslation(GameCulture.Russian, "Необходима для стрельбы из Квантового Дестабилизатора");

            DisplayName.AddTranslation(GameCulture.Chinese, "能源电池");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于量子干扰器的能源");
        }

		public override void SetDefaults()
		{
			item.damage = 1;
			item.ranged = true;
			item.width = 14;
			item.height = 22;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 1;
			item.value = Item.sellPrice(0, 0, 75, 0);
			item.rare = 10;
			item.shoot = mod.ProjectileType("QuantumDestabilizer");
			item.ammo = item.type; // The first item in an ammo class sets the AmmoID to it's type
		}
	}
}
