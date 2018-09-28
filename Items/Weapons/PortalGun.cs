using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.Weapons
{
	public class PortalGun : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rick's Portal Gun");
			Tooltip.SetDefault("Copy of Rick Sanchez's Portal Gun"
			+"\nOpens portals to the random dangerous dimensions"
			+"\nHope this thing wouldn't cause appearence of SEAL team Ricks");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.ranged = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 1;
			item.value = 1000000;
			item.rare = 11;
			item.UseSound = SoundID.Item114;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PortalGunProj");
			item.shootSpeed = 16f;
			item.useAmmo = mod.ItemType("ConcentratedDarkMatter");
		}
	}
}
