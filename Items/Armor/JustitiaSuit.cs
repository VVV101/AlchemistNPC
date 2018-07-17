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
	public class JustitiaSuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Justitia Suit (O-02-62)");
			DisplayName.AddTranslation(GameCulture.Russian, "Костюм Юстиции (O-02-62)");
			Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
				+ "\n[c/FF0000:EGO armor piece]"
				+ "\n+100 maximum HP"
				+ "\n+15% damage reduction");
            Tooltip.AddTranslation(GameCulture.Russian, "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире имеет место лишь в сказках.\n[c/FF0000:Э.П.О.С часть брони]\n+100 к максимальному здоровью\n+15% к поглощению урона");
            DisplayName.AddTranslation(GameCulture.Chinese, "审判鸟外套 (O-02-62)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'就像其他生物一样, 它最初也满怀着希望. 但如今, 对和平的渴望只能潜藏在幼稚的童话里.'\n[c/FF0000:EGO 盔甲]\n增加100点最大生命值\n增加15%伤害免疫");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.defense = 35;
		}

		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 100;
			player.endurance += 0.15f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(ItemID.FragmentNebula, 15);
            recipe.AddIngredient(ItemID.FragmentSolar, 15);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}