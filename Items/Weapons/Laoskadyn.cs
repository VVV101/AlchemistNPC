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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Laoskadyn");
			Tooltip.SetDefault("Drops exploding needle from the sky on swing");
			DisplayName.AddTranslation(GameCulture.Russian, "Лаоскадин");
			Tooltip.AddTranslation(GameCulture.Russian, "Вызывает падение взрывающихся игл с небес при взмахе"); 
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);
			item.melee = true;
			item.damage = 150;
			item.width = 78;
			item.height = 106;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = 1000000;
			item.rare = 11;
            item.knockBack = 6f;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("SharpNeedle");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Twilight"), 600);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
