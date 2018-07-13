using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Nyx : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyx");
			Tooltip.SetDefault("Basically, it is just a Gauss Gun"
			+ "\nPierces through multiple enemies"
			+ "\nHas 2 firemodes:"
			+ "\nSlowmode on left click (1 shot per second)"
			+ "\nFastmode on right click (2 shot per second, damage is reduced)");
			DisplayName.AddTranslation(GameCulture.Russian, "Никс");
			Tooltip.AddTranslation(GameCulture.Russian, "Всего лишь пушка Гаусса.\nПробивает значительное количество противников одним выстрелом"); 
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SniperRifle);
			item.damage = 750;
			item.autoReuse = true;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("Nyx");
			return true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useTime = 30;
				item.useAnimation = 30;
				item.damage = 425;
			}
			else
			{
				item.useTime = 60;
				item.useAnimation = 60;
				item.damage = 750;
			}
			return base.CanUseItem(player);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.Ectoplasm, 50);
			recipe.AddIngredient(ItemID.ShroomiteBar, 8);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 10);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}