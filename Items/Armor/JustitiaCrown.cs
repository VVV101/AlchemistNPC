using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class JustitiaCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia Crown (O-02-62)");
			DisplayName.AddTranslation(GameCulture.Russian, "Корона Юстиции (O-02-62)");
            DisplayName.AddTranslation(GameCulture.Chinese, "审判鸟王冠 (O-02-62)");
            Tooltip.SetDefault("Just like anything else, it had hope at first. The desire for peace now only exists in fairy tales."
			+ "\n[c/FF0000:EGO armor piece]"
			+ "\nIncreases melee speed by 20%");
            Tooltip.AddTranslation(GameCulture.Russian, "Как и что-либо другое, оно имело надежду поначалу. Теперь же мечта о мире имеет место лишь в сказках.\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость атак ближнего боя на 20%");
            Tooltip.AddTranslation(GameCulture.Chinese, "'就像其他生物一样, 它最初也满怀着希望. 但如今, 对和平的渴望只能潜藏在幼稚的童话里.'\n[c/FF0000:EGO 盔甲]\n增加20%近战速度");

            ModTranslation text = mod.CreateTranslation("JustitiaSetBonus");
		    text.SetDefault("Increases current melee damage by 30% and adds 15% to melee critical strike chance");
            text.AddTranslation(GameCulture.Russian, "Увеличивает текущий урон в ближнем бою на 30% и добаляет 15% к шансу критического удара");
            text.AddTranslation(GameCulture.Chinese, "增加当前30%的近战伤害和15%近战暴击率");
            mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 1000000;
			item.rare = 12;
			item.defense = 25;
		}
		
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += 0.20f;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("JustitiaSuit") && legs.type == mod.ItemType("JustitiaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			string JustitiaSetBonus = Language.GetTextValue("Mods.AlchemistNPC.JustitiaSetBonus");
			player.setBonus = JustitiaSetBonus;
			player.meleeDamage += 0.30f;
			player.meleeCrit += 15;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Blindfold);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 8);
            recipe.AddIngredient(ItemID.FragmentSolar, 8);
			recipe.AddTile(null, "WingoftheWorld");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}