using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.Localization;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class ParadiseLostWings : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradise Lost Wings (T-03-46)");
			Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
			+ "\nHave thou not yet realized that pain is nothing?"
			+ "\nThou want me to prove the miracle."
			+ "\nThou shall believe in me and granted with life. I shall show you the power.''"
			+ "\n[c/FF0000:EGO Gift]"
			+ "\nWorks as Wings"
			+ "\nAlso allows to run"
			+ "\nHas very huge wing time and excellent horizontal speed");
			DisplayName.AddTranslation(GameCulture.Russian, "Крылья Потерянного Рая (T-03-46)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Э.П.О.С. Дар]\nРаботает как Крылья\nИмеют большое время полёта и великолепную горизонтальную скорость");

            DisplayName.AddTranslation(GameCulture.Chinese, "失乐园之翼 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'你不必担心, 我已经听到了你那略带惊恐的祈祷."
            + "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?"
            + "\n你要我证明奇迹."
            + "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'"
            + "\n[c/FF0000:EGO 礼物]"
            + "\n等同于翅膀"
            + "\n允许奔跑"
            + "\n拥有非常长的飞行时间和优秀的飞行速度");
        }

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("BigBirdLamp"), 60);
			player.accRunSpeed = 6.75f;
            player.moveSpeed = player.moveSpeed + 0.08f;
			player.wingTimeMax = 280;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}
		
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 18f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TwilightWings");
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 5);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 10);
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}