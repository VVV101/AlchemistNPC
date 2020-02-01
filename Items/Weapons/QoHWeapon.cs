using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class QoHWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''In the name of Love and Hate'' (O-01-04)");
			Tooltip.SetDefault("''A magical rod radiating with magical girl's lovely energy."
			+"\nBad people will be purified by its holy light and be born again."
			+"\nThey will burn. They won't want to wake up.''"
			+ "\n[c/FF0000:EGO weapon]"
			+"\nShots 4 different types of projectile"
			+"\nThey may restore HP, Mana, inflict debuff or deal double damage.");
			DisplayName.AddTranslation(GameCulture.Russian, "''Во Имя Любви и Ненависти'' (O-01-04)");
            Tooltip.AddTranslation(GameCulture.Russian, "''Волшебный жезл, излучающий любовную энергию Магической Девочки.\nПлохие люди будут очищены её святым сиянием и будут рождены вновь.\nОни сгорят. Они не захотят пробудиться.''n[c/FF0000:Оружие Э.П.О.С.]\nВыстреливает 4 типа снарядов\nОни могут восстановить ХП, Ману, наложить дебафф или нанести двойной урон");
			DisplayName.AddTranslation(GameCulture.Chinese, "''以爱与恨之名'' (O-01-04)");
			Tooltip.AddTranslation(GameCulture.Chinese, "''这根闪闪发光的魔法棒散发着魔法少女的爱之能量."
			+"\n坏蛋将会被神圣的光辉净化, 然后重生."
			+"\n他们将会被烈焰灼烧, 失去醒来的意志.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n发射4种不同种类的抛射物"
			+"\n会根据伤害类型恢复生命值, 法力值, 造成Debuff或者双倍伤害.");
        }

		public override void SetDefaults()
		{
			item.damage = 99;
			item.noMelee = true;
			item.magic = true;
			item.mana = 10;
			item.rare = 11;
			item.width = 30;
			item.height = 30;
			item.useTime = 6;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 12f;
			item.useAnimation = 6;   
			item.knockBack = 4;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.autoReuse = true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).ParadiseLost == true)
			{
				item.damage = 125;
				item.useTime = 5;
				item.useAnimation = 5;
			}
			else
			{
				item.damage = 99;
				item.useTime = 6;
				item.useAnimation = 6;
			}
			switch (Main.rand.Next(4))
			{
				case 0:
				item.shoot = mod.ProjectileType("QoH1");
				break;

				case 1:
				item.shoot = mod.ProjectileType("QoH2");
				break;
				
				case 2:
				item.shoot = mod.ProjectileType("QoH3");
				break;
				
				case 3:
				item.shoot = mod.ProjectileType("QoH4");
				break;
			}
		return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.RainbowRod);
			recipe.AddIngredient(ItemID.StarWrath);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddIngredient(ItemID.FragmentNebula, 25);
			recipe.AddIngredient(null, "ChromaticCrystal", 5);
			recipe.AddIngredient(null, "SunkroveraCrystal", 5);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 5);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(null, "EmagledFragmentation", 100);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
