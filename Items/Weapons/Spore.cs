using System;
using AlchemistNPC.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Spore : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore (O-04-66)");
			Tooltip.SetDefault("''The spear, covered with spores and attention."
			+ "\nIt expands mind, shines like a star and gradually becomes closer to weilder.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nIts attack hits enemy several times"
			+ "\nAfter certain amount of hits releases damaging spores into enemy");
			DisplayName.AddTranslation(GameCulture.Russian, "Спора (O-04-66)");
            Tooltip.AddTranslation(GameCulture.Russian, "Копьё, покрытое спорами и вниманием.\nОно раскрывает разум, сияет словно звезда и постепенно сближается с носителем.\n[c/FF0000:Э.П.О.С. оружие]\nЕго атаки наносят урон противнику несколько раз\nПри нанесении определённого количество ударов выпускает атакующие споры во врага");

            DisplayName.AddTranslation(GameCulture.Chinese, "荧光菌孢 (O-04-66)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'这是一支生长着孢子, 并且寄宿着情感的长矛.'\n'它能够揭示思维, 在他们脑海中如同繁星一般闪烁, 并且使他们逐渐变得驯服安分.'\n[c/FF0000:EGO 武器]\n攻击能多次伤害敌人\n在命中一定次数之后释放伤害性孢子进入敌人体内");
        }

		public override void SetDefaults()
		{
			item.damage = 55;
			item.useStyle = 5;
			item.useAnimation = 20;
			item.useTime = 25;
			item.shootSpeed = 3.7f;
			item.knockBack = 6;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 6;
			item.value = Item.sellPrice(gold: 50);

			item.magic = true;
			item.mana = 4;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("Spore");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 25);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
					{
					item.damage = 250;
					}
					else
					{
					item.damage = 55;
					}
			return player.ownedProjectileCounts[item.shoot] < 1; 
		}
	}
}
