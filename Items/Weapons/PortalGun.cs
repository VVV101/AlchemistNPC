using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PortalGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rick's Portal Gun");
			Tooltip.SetDefault("Copy of Rick Sanchez's Portal Gun"
			+"\nOpens portals to the random dangerous dimensions"
			+"\nRequires Energy Capsules as ammo"
			+"\nHope this thing wouldn't cause appearence of SEAL team Ricks");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Портальная пушка Рика");
            Tooltip.AddTranslation(GameCulture.Russian, "Копия портальной пушки Рика Санчеза\nОткрывает порталы в различные измерения\nТребует Капсулы с энергией в качестве патронов\nНадеюсь, что она не вызовет появление Рик спецназа");
			DisplayName.AddTranslation(GameCulture.Chinese, "瑞克的传送枪");
			Tooltip.AddTranslation(GameCulture.Chinese, "瑞克·桑切斯的传送枪的复制品"
			+"\n打开通往随机危险维度的传送门"
			+"\n需要能量胶囊作为弹药"
			+"\n希望这玩意别引来瑞克海豹突击队");
		}

		public override void SetDefaults()
		{
			item.damage = 75;
			item.ranged = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 1000000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item114;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PortalGunProj");
			item.shootSpeed = 16f;
			item.useAmmo = mod.ItemType("EnergyCapsule");
		}
	}
}
