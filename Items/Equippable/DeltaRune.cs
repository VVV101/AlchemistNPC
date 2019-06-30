using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class DeltaRune : ModItem
	{
		public static int count = 0;
		public static int A = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Delta Rune");
			Tooltip.SetDefault("Adds 10% melee and magic damage and critical strike chances"
				+ "\nIncreases defense by 10"
				+ "\nIncreases damage reduction by 10%"
				+ "\nYour melee attacks have a chance to release red damaging wave"
				+ "\nYour magic attacks have a chance to release swarm of homing magic missiles"
				+ "\nRegenerates life rapidly while standing still");
				DisplayName.AddTranslation(GameCulture.Russian, "Руна Дельта");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический/ближний урон и шанс критического удара на 10%\nУвеличивает защиту на 10\nУвеличивает стойкость на 10%\nДаёт шанс выпустить красную волну, наносящую урон при взмахе оружием ближнего боя\nДаёт шанс выпустить рой магических снарядов при магической атаке\nБыстро восстанавливает здоровье, пока стоишь на месте");
            DisplayName.AddTranslation(GameCulture.Chinese, "三角符文");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加10%近战/魔法伤害和暴击率\n增加10%伤害减免\n近战攻击概率释放红色破坏波\n魔法攻击概率释放追踪魔法飞弹\n站立不动时快速恢复生命");
        }
	
		public override void SetDefaults()
		{
			item.stack = 1;
			item.width = 64;
			item.height = 60;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 10;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).DeltaRune = true;
			A = 50 * ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).LifeElixir;
            player.meleeDamage += 0.1f;
            player.magicDamage += 0.1f;
			player.meleeCrit += 10;
            player.magicCrit += 10;
			player.endurance += 0.1f;
			if (player.statLife < (player.statLifeMax2 + A) && player.velocity.X == 0f && player.velocity.Y == 0f)
			{
				if (count >= 12)
				{
				count = 0;
				player.statLife += 5;
				player.HealEffect(5, true);
				}
				count++;
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SorcererEmblem);
			recipe.AddIngredient(ItemID.WarriorEmblem);
			recipe.AddIngredient(ItemID.EyeoftheGolem);
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(mod.ItemType("SoulEssence"), 3);
			recipe.AddIngredient(mod.ItemType("ChromaticCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("SunkroveraCrystal"), 5);
			recipe.AddIngredient(mod.ItemType("NyctosythiaCrystal"), 5);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NightmareFuel")), 15);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EndothermicEnergy")), 15);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 3);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 3);
			}
			recipe.AddIngredient(mod.ItemType("EmagledFragmentation"), 150);
			if (ModLoader.GetMod("CalamityMod") == null)
			{
			recipe.AddTile(mod.TileType("MateriaTransmutator"));
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddTile(mod.TileType("MateriaTransmutatorMK2"));
			}
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
	
}
