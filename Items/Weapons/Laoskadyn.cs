using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class Laoskadyn : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laoskadyn");
			Tooltip.SetDefault("Drops exploding homing needles from the sky on swing"
			+"\nNeedles release damaging flames");
			DisplayName.AddTranslation(GameCulture.Russian, "Лаоскадин");
            Tooltip.AddTranslation(GameCulture.Russian, "Вызывает падение взрывающихся игл с небес при взмахе\nИглы выпускают наносящие урон огни");

            DisplayName.AddTranslation(GameCulture.Chinese, "劳斯卡丁");
            Tooltip.AddTranslation(GameCulture.Chinese, "挥舞时从天上降下自动追踪敌人的针\n针会释放出有伤害的火焰");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.melee = true;
			item.damage = 100;
			item.width = 78;
			item.height = 106;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = 1000000;
			item.rare = 11;
            item.knockBack = 6;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SharpNeedle");
			Projectile.NewProjectile(position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), speedX, speedY, type, damage, knockBack, player.whoAmI);
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
