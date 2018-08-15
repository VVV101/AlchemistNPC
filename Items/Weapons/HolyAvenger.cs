using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class HolyAvenger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''Cera Sumat'', Holy Avenger");
			Tooltip.SetDefault("Legendary sword of Old Duke Ehld."
			+"\nTrue melee sword"
			+"\nWeakens enemies on hit"
			+"\nStats are growing through progression"
			+"\nBoosted stats will be shown after the first swing");
			DisplayName.AddTranslation(GameCulture.Russian, "''Сера Сумат'', Святой Мститель");
            Tooltip.AddTranslation(GameCulture.Russian, "Легендарный меч Старого Графа Эхлда\nОслабляет противников при ударе\nПоказатели увеличивается по мере прохождения");

		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.5f;
		}

		public override bool CanUseItem(Player player)
		{
			item.useTime = 15;
			item.useAnimation = 15;
			if (NPC.downedSlimeKing)
			{
				item.damage = 18;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 20;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 24;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 28;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 32;
			}
			if (Main.hardMode)
			{
				item.damage = 40;
				item.useTime = 10;
				item.useAnimation = 10;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 48;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				item.damage = 60;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 72;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 81;
			}
			if (NPC.downedFishron)
			{
				item.damage = 90;
			}
			if (NPC.downedAncientCultist)
			{
				item.damage = 100;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 125;
			}
			return true;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("JustitiaPale"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[mod.BuffType("CurseOfLight")] = false;
			target.AddBuff(mod.BuffType("CurseOfLight"), 36000);
			if (Main.hardMode && !NPC.downedMechBossAny)
			{
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/4, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedMechBossAny)
			{
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/3, 0, Main.myPlayer);
			}
		}
	}
}
