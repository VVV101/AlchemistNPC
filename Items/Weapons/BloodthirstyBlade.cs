using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class BloodthirstyBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodthirsty Blade");
			Tooltip.SetDefault("Becomes stronger the more enemies are defeated by it"
			+"\nKilling boss gives bigger damage boost"
			+"\nBlue Slimes and Spiked Blue Slimes will not give the weapon boosts"
			+"\nDoes not getting any benefits from bonus damage/critical strike chance"
			+"\nDamage is capped until entering Hardmode (36) and beating Moon Lord (99)"
			+"\nReaching 36, 64 and 100 damage makes special things to happen");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровожадный Клинок");
            Tooltip.AddTranslation(GameCulture.Russian, "Чем больше врагов побеждено им, тем сильнее он становится\nУбийство босса даёт больший бонус к урону\nСиние и Синие шипастные слизни не дают бонуса к урону\nНе получает никаких бонусов по урону и шансу критического удара\nУрон ограничен до Хардмода (36) и победы над Лунным Лордом (99)\nДостижение 36, 64 и 100 урона производит особые изменения с мечом");
			DisplayName.AddTranslation(GameCulture.Chinese, "渴血刃");
			Tooltip.AddTranslation(GameCulture.Chinese, "用它杀死敌人会使它变得更强大"
			+"\n杀死Boss获得更大的伤害提升"
			+"\n蓝色史莱姆和蓝色尖刺史莱姆不会给予武器提升"
			+"\n不获得任何伤害/暴击率增益"
			+"\n困难模式前伤害上限为36, 月球领主前为99"
			+"\n伤害达到36, 64和100时会发生一些特殊的事情");
        }

		public override void SetDefaults()
		{
			item.damage = 10;
			item.crit = 50;
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 100000;
			item.rare = 4;
            item.knockBack = 8;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.5f;
		}

		public override void UpdateInventory(Player player)
		{
			item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP/100);
			if (item.damage >= 36)
			{
				item.shoot = mod.ProjectileType("SB");
				item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (item.damage > 36)
				{
					item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				if (item.damage > 99)
				{
					item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				item.useTime = 10;
				item.useAnimation = 10;
			}
		}
		
		public override void HoldItem(Player player)
		{
			item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP/100);
			if (item.damage >= 36)
			{
				item.shoot = mod.ProjectileType("SB");
				item.shootSpeed = 12f;
			}
			if (!Main.hardMode)
			{
				if (item.damage > 36)
				{
					item.damage = 36;
				}
			}
			if (Main.hardMode && !NPC.downedMoonlord)
			{
				item.useTime = 15;
				item.useAnimation = 15;
				if (item.damage > 99)
				{
					item.damage = 99;
				}
			}
			if (NPC.downedMoonlord)
			{
				item.useTime = 10;
				item.useAnimation = 10;
			}
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			item.damage = 10 + (((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP/100);
			if (item.damage >= 64)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				Vector2 perturbedSpeed2 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
				speedX = perturbedSpeed.X;
				speedY = perturbedSpeed.Y;
				float speedX2 = perturbedSpeed2.X;
				float speedY2 = perturbedSpeed2.Y;
				Projectile.NewProjectile(position.X, position.Y+4, speedX, speedY, mod.ProjectileType("SB"), damage/2, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y-4, speedX2, speedY2, mod.ProjectileType("SB"), damage/2, knockBack, player.whoAmI);
			}
			if (item.damage > 99)
			{
				Vector2 perturbedSpeed3 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
				Vector2 perturbedSpeed4 = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15));
				float speedX3 = perturbedSpeed3.X;
				float speedY3 = perturbedSpeed3.Y;
				float speedX4 = perturbedSpeed4.X;
				float speedY4 = perturbedSpeed4.Y;
				Projectile.NewProjectile(position.X, position.Y+5, speedX3, speedY3, mod.ProjectileType("SB"), damage/2, knockBack, player.whoAmI);
				Projectile.NewProjectile(position.X, position.Y-5, speedX4, speedY4, mod.ProjectileType("SB"), damage/2, knockBack, player.whoAmI);
			}
			damage /= 2;
			return true;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1 = "Bloodthirsty Blade points are " + ((AlchemistNPCPlayer)player.GetModPlayer(mod, "AlchemistNPCPlayer")).BBP;
			TooltipLine line = new TooltipLine(mod, "text1", text1);
			tooltips.Insert(1,line);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BloodButcherer);
			recipe.AddIngredient(ItemID.Vertebrae, 15);
			recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LightsBane);
			recipe.AddIngredient(ItemID.RottenChunk, 15);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
