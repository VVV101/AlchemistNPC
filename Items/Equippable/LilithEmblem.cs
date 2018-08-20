using Terraria.ID;
using Terraria;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class LilithEmblem : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lilith Emblem");
			Tooltip.SetDefault("Gives 10% magic bonus damage and 10% to critical strike chance"
			+ "\nDecreases mana usage by 15%"
			+ "\nIncreases max mana by 50"
			+ "\nIncreases mana regeneration rate"
			+ "\nIncreases mana stars pickup range"
			+ "\nAutomatically uses mana potions"
			+ "\nYou shoot cluster of deadly bees while using magic weapons"
			+ "\nHide visual to disable bees"
			+ "\nDoesn't work with some very specific weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "Эмблема Лилит");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 10% и шанс критического удара на 10%\nУменьшает затраты маны на 15%\nУвеличивает максимальную ману на 50\nУскоряет восстановление маны\nУвеличивает радиус сбора звёзд\nАвтоматически использует зелья маны\nВы выстреливает кучку смертоносных пчёл при использовании любого магического оружия\nСмена видимости аксессуара выключает пчёл\nПоследнее не работает с некоторыми специфическими оружиями");

            DisplayName.AddTranslation(GameCulture.Chinese, "莉莉丝徽章");
            Tooltip.AddTranslation(GameCulture.Chinese, "给予15%额外魔法伤害和10%暴击几率\n减少15%法力消耗\n增加50点最大法力值\n增加法力恢复速度\n增加法力星拾取范围\n自动使用法力药水\n当你使用魔法武器时会发射出致命的蜜蜂\n隐藏饰品可取消蜜蜂\n不作用于某些特别的武器");
        }
	
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (!hideVisual)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem = true;
			}
			if (hideVisual)
			{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LilithEmblem = false;
			}
			player.manaMagnet = true;
			player.magicDamage += 0.1f;
			player.magicCrit += 10;
			player.statManaMax2 += 50;
			player.manaFlower = true;
            player.manaCost -= 0.15f;
			++player.manaRegenDelayBonus;
            player.manaRegenBonus += 25;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CelestialEmblem);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.ManaFlower);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.BeeGun);
			recipe.AddIngredient(ItemID.WaspGun);
            recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}