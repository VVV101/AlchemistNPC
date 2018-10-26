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
	public class DivineWaspnade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Divine Lava Waspnade");
			Tooltip.SetDefault("Releases friendly Wasps after explosion"
			+"\nWasps are inflicting On Fire! and Ichor debuffs"
			+"\nEmpowered with Hive Pack/Plague Hive equipped");
			DisplayName.AddTranslation(GameCulture.Russian, "Осаната из Вечной Лавы");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает дружественных ос после взрыва\nОсы накладывают Ихор и поджигают противников\nМогут быть усилены экипировкой Пчелиного Рюкзака/Чумного Улья");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Beenade);
			item.thrown = true;
			item.damage = 25;
			item.useTime = 15;
			item.useAnimation = 15;
			item.value = 10000;
			item.rare = 8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DivineWaspnade");
			item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Waspnade", 25);
			recipe.AddIngredient(null, "DivineLava");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 25);
			recipe.AddRecipe();
		}
	}
}
