using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;
using AlchemistNPC.Items.PaleDamageClass;
using AlchemistNPC;

namespace AlchemistNPC.Items.Weapons
{
	public class DriedFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dried Fish");
			Tooltip.SetDefault("Releases damaging bubbles on enemy hit");
			DisplayName.AddTranslation(GameCulture.Russian, "Сушёная Вобла");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает ранящие пузыри при ударе по противнику");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.melee = true;
			item.crit = 10;
			item.width = 52;
			item.height = 52;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = 100000;
			item.rare = 5;
            item.knockBack = 4;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.5f;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Wet, 600);
			Vector2 vel1 = new Vector2(-1, -1);
			vel1 *= 12f;
			Projectile.NewProjectile(target.position.X+200, target.position.Y+200, vel1.X, vel1.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel2 = new Vector2(1, 1);
			vel2 *= 12f;
			Projectile.NewProjectile(target.position.X-200, target.position.Y-200, vel2.X, vel2.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel3 = new Vector2(1, -1);
			vel3 *= 12f;
			Projectile.NewProjectile(target.position.X-200, target.position.Y+200, vel3.X, vel3.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel4 = new Vector2(-1, 1);
			vel4 *= 12f;
			Projectile.NewProjectile(target.position.X+200, target.position.Y-200, vel4.X, vel4.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel5 = new Vector2(0, -1);
			vel5 *= 12f;
			Projectile.NewProjectile(target.position.X, target.position.Y+200, vel5.X, vel5.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel6 = new Vector2(0, 1);
			vel6 *= 12f;
			Projectile.NewProjectile(target.position.X, target.position.Y-200, vel6.X, vel6.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel7 = new Vector2(1, 0);
			vel7 *= 12f;
			Projectile.NewProjectile(target.position.X-200, target.position.Y, vel7.X, vel7.Y, mod.ProjectileType("DriedFishBubble"), damage/4, 0, Main.myPlayer);
			Vector2 vel8 = new Vector2(-1, 0);
			vel8 *= 12f;
			Projectile.NewProjectile(target.position.X+200, target.position.Y, vel8.X, vel8.Y, mod.ProjectileType("DriedFishBubble") ,damage/4, 0, Main.myPlayer);
		}
	}
}
