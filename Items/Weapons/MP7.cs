using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class MP7 : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.autoReuse = true;
			item.useAnimation = 2;
			item.useTime = 2;
			item.width = 72;
			item.height = 34;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 10;
			item.shootSpeed = 14f;
			item.noMelee = true;
			item.rare = 11;
			item.knockBack = 3;
			item.ranged = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MP7");
			Tooltip.SetDefault("[c/00FF00:Ultimate Tinkerer's Reward]"
			+"\nShoots up to 1K bullets per minute"
			+"\n88% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Chinese, "MP7");
			Tooltip.AddTranslation(GameCulture.Chinese, "[c/00FF00:终极工匠奖励]"
			+"\n每分钟最多发射1K颗子弹"
			+"\n88%概率不消耗弹药");
        }
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return mod.PrefixType("Shining");
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .88;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 vector = player.MountedCenter;
			int numberProjectiles = 1 + Main.rand.Next(3); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
				float scale = 1f - (Main.rand.NextFloat() * .4f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(vector.X, vector.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
