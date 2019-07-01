using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Nyx : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nyx");
			Tooltip.SetDefault("Basically, it is just a Gauss Gun"
			+ "\nPierces through multiple enemies"
			+ "\nHas 2 modes:"
			+ "\nSlowmode on left click (1 shot per second)"
			+ "\nFastmode on right click (2 shots per second, damage is reduced)");
			DisplayName.AddTranslation(GameCulture.Russian, "Никс");
            Tooltip.AddTranslation(GameCulture.Russian, "Всего лишь пушка Гаусса.\nПробивает значительное количество противников одним выстрелом\nИмеет два режима стрельбы:\nМедленный (левая кнопка мыши) - производит один выстрел.\nБыстрый (правая кнопка мыши) - производит два выстрела с пониженным уроном.");

            DisplayName.AddTranslation(GameCulture.Chinese, "尼克斯");
            Tooltip.AddTranslation(GameCulture.Chinese, "基本上, 它只是个高斯炮\n能穿透多个敌人\n有两种发射方式:\n左键慢速发射 (1发/秒)\n右键快速发射 (2发/秒, 伤害降低)");
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