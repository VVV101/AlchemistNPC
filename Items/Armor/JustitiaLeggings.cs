using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class JustitiaLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Leggings (O-02-62)");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Юстиции (O-02-62)"); 
			Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
				+ "\n[c/FF0000:EGO armor piece]"
				+ "\n25% increased movement speed");
				Tooltip.AddTranslation(GameCulture.Russian, "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире имеет место лишь в сказках.\n[c/FF0000:Э.П.О.С часть брони]\nУвеличивает скорость передвижения на 25%");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.defense = 30;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}