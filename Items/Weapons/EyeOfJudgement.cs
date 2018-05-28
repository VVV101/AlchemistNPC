using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class EyeOfJudgement : ModItem
	{
		public static int counter = 15;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eye of Judgement");
			Tooltip.SetDefault("'If you keep going the way you are now..."
			+"\nYou're gonna have a bad time.'"
			+"\nEndlessly generates sharp bones, which are home to enemies while you hold this"
			+"\nDoesn't take minion slots. Can be combined with other minions"
			+"\n33% chance to reduce damage taken by player to 2 hitpoints"
			+"\nReduces player's endurance by 33%");
			DisplayName.AddTranslation(GameCulture.Russian, "Глаз Правосудия");
			Tooltip.AddTranslation(GameCulture.Russian, "Если ты продолжишь двигаться тем же путём...\nТо у тебя БУДУТ неприятности.\nБесконечно создаёт острые кости, которые наводятся на врагов\n33% шанс снизить полученный урон до 2 ХП при получении удара\nПонижает ваше сопротивление урону на 33%"); 
		}    
		public override void SetDefaults()
		{
			item.summon = true;
			item.damage = 100;
			item.width = 34;
			item.height = 36;
			item.maxStack = 1;
			item.value = 100000;
			item.holdStyle = 1;
			item.rare = 12;
			item.scale = 1f;
			item.knockBack = 4f;
		}
		
		public override void HoldItem(Player player)
		{
		player.AddBuff(mod.BuffType("Judgement"), 60);
		player.endurance -= 0.33f;
		if (counter == 15)
			{
				if (player.direction == 1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(0, 0);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*2, 0, player.whoAmI);
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*2, 0, player.whoAmI);
					counter = 0;
					}
				}
				if (player.direction == -1)
				{
					for (int h = 0; h < 1; h++) {
					Vector2 vel = new Vector2(-1, 0);
					vel *= 0f;
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-50-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*2, 0, player.whoAmI);
					Projectile.NewProjectile(player.Center.X-20-Main.rand.Next(15), player.Center.Y-40-Main.rand.Next(30), vel.X, vel.Y, mod.ProjectileType ("SharpBone"), item.damage*2, 0, player.whoAmI);
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
	}
}
