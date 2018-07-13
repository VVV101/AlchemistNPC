using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ReverberationBody : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reverberation Suit (T-04-53)");
			DisplayName.AddTranslation(GameCulture.Russian, "Костюм Реверберации (T-04-53)"); 
			Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases ranged critical strike chance by 20%");
			Tooltip.AddTranslation(GameCulture.Russian, "Гладкая поверхность всё так же прочна, как будто не была восстановлена несколько раз.\n[c/FF0000:Э.П.О.С часть брони]\nПовышает шанс критического удара в дальнем бою на 20%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 9;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedCrit += 20;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.DynastyWood, 150);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}