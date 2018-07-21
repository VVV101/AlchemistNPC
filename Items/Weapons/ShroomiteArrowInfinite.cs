using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class ShroomiteArrowInfinite : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enhanced Shroomite Arrow");
			Tooltip.SetDefault("Releases electric cloud, which shoots electric beams to enemies"
			+"\nSpeeds up over time"
			+"\nInfinite");
			DisplayName.AddTranslation(GameCulture.Russian, "Улучшенная Грибная стрела");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает электрическое облако, стреляющее электическими лучами\nБесконечна");

            DisplayName.AddTranslation(GameCulture.Chinese, "强化型菱形箭");
            Tooltip.AddTranslation(GameCulture.Chinese, "释放出电云, 电云会向敌人发射电束\n越飞越快\n无限");
        }

		public override void SetDefaults()
		{
			item.damage = 22;
			item.ranged = true;
			item.width = 14;
			item.height = 38;
			item.maxStack = 1;
			item.consumable = false;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10000;
			item.rare = 11;
			item.shoot = mod.ProjectileType("ShroomiteArrow");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 12f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShroomiteArrow", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
