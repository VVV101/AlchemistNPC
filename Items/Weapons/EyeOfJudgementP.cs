using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EyeOfJudgementP : ModItem
	{
		public static int counter = 15;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Pure Judgement");
			Tooltip.SetDefault("'If you keep going the way you are now..."
			+"\nYou're gonna have a bad time.'"
			+"\nEndlessly generates sharp bones, which are home to enemies while you hold this"
			+"\nCreates 8 homing bones on cursor position on use "
			+"\nDoesn't take minion slots. Can be combined with other minions"
			+"\n33% chance to reduce damage taken by player to 2 hitpoints"
			+"\nReduces player's endurance by 17%");
			DisplayName.AddTranslation(GameCulture.Russian, "Глаз Чистого Правосудия");
            Tooltip.AddTranslation(GameCulture.Russian, "Если ты дальше будешь себя так вести...\nТо у тебя БУДУТ неприятности.\nБесконечно создаёт острые кости, которые наводятся на врагов\nСоздаёт 8 самонаводящихся костей у позиции курсора при применении\n33% шанс снизить полученный урон до 2 ХП при получении удара\nПонижает ваше сопротивление урону на 17%");

            DisplayName.AddTranslation(GameCulture.Chinese, "审判之眼");
            Tooltip.AddTranslation(GameCulture.Chinese, "'如果你继续现在的道路...\n你的日子不会好过'\n当你手持此物时会不断产生骨刺自动追踪敌人\n使用时在鼠标位置产生8根会追踪敌人的骨刺\n不占用召唤栏位, 可以结合其他召唤物使用\n33%的几率减少2点所受伤害\n降低17%耐力");
        }    
		public override void SetDefaults()
		{
			item.summon = true;
			item.damage = 120;
			item.width = 34;
			item.mana = 20;
			item.height = 36;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.maxStack = 1;
			item.value = 1000000;
			item.holdStyle = 1;
			item.rare = 12;
			item.scale = 1f;
			item.knockBack = 4;
			item.shoot = mod.ProjectileType("SharpBone");
			item.autoReuse = true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 2f;
			Projectile.NewProjectile(position.X+150, position.Y+150, vel1.X, vel1.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 2f;
			Projectile.NewProjectile(position.X-150, position.Y-150, vel2.X, vel2.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 2f;
			Projectile.NewProjectile(position.X-150, position.Y+150, vel3.X, vel3.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 2f;
			Projectile.NewProjectile(position.X+150, position.Y-150, vel4.X, vel4.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 2f;
			Projectile.NewProjectile(position.X, position.Y+150, vel5.X, vel5.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 2f;
			Projectile.NewProjectile(position.X, position.Y-150, vel6.X, vel6.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 2f;
			Projectile.NewProjectile(position.X-150, position.Y, vel7.X, vel7.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 2f;
			Projectile.NewProjectile(position.X+150, position.Y, vel8.X, vel8.Y, mod.ProjectileType ("SharpBone"), item.damage, 0, Main.myPlayer);
			return false;
		}
		
		public override void HoldItem(Player player)
		{
		player.AddBuff(mod.BuffType("Judgement"), 2);
		player.endurance -= 0.17f;
		if (counter == 20)
			{
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X+20+Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*3, 0, player.whoAmI);
					Projectile.NewProjectile(player.Center.X+20+Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*3, 0, player.whoAmI);
					counter = 0;
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*3, 0, player.whoAmI);
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*3, 0, player.whoAmI);
					counter = 0;
					}
				}
			}
		counter++;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeOfJudgement");
			recipe.AddIngredient(null, "ChromaticCrystal", 3);
			recipe.AddIngredient(null, "SunkroveraCrystal", 3);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 5);
			recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25);
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
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
