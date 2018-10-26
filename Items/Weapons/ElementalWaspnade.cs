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
	public class ElementalWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps inflicting Corrosion, Cursed Flames and Ichor debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.Russian, "Элементальная Осаната");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает дружественных ос после взрыва\nОсы накладывают Коррозию, Проклятое Пламя и Ихор\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Beenade);
			item.thrown = true;
			item.damage = 50;
			item.useTime = 15;
			item.useAnimation = 15;
			item.value = 10000;
			item.rare = 10;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ElementalWaspnade");
			item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DivineWaspnade", 25);
			recipe.AddIngredient(null, "CursedWaspnade", 25);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
