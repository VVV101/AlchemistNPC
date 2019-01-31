using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class HolyAvenger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''Cera Sumat'', Holy Avenger");
			Tooltip.SetDefault("[c/00FF00:Legendary Sword] of Old Duke Ehld."
			+"\nTrue Melee sword"
			+"\nInflicts Curse of Light debuff"
			+"\nMakes enemies take 20% more damage from player"
			+"\n25% to take only half of the damage from debuffed enemy"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\nBoosted stats will be shown after the first swing");
			DisplayName.AddTranslation(GameCulture.Russian, "''Сера Сумат'', Святой Мститель");
            Tooltip.AddTranslation(GameCulture.Russian, "[c/00FF00:Легендарный Меч] Старого Графа Эхлда\nОслабляет противников при ударе\nПротивники получают на 20% больше урона\n25% шанс получить половину урона от ослабленных противников\n[c/00FF00:Показатели увеличивается по мере прохождения]");

		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Muramasa);
			item.damage = 12;
			item.melee = true;
			item.width = 78;
			item.height = 78;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (!Main.hardMode)
			{
				item.autoReuse = false;
			}
			item.useTime = 15;
			item.useAnimation = 15;
			if (NPC.downedSlimeKing)
			{
				item.damage = 16;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 20;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 22;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 24;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 26;
			}
			if (Main.hardMode)
			{
				item.damage = 32;
				item.useTime = 10;
				item.useAnimation = 10;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 36;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				item.damage = 40;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 48;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 56;
			}
			if (NPC.downedFishron)
			{
				item.damage = 64;
			}
			if (NPC.downedAncientCultist)
			{
				item.damage = 81;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 100;
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

		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.buffImmune[mod.BuffType("CurseOfLight")] = false;
			target.AddBuff(mod.BuffType("CurseOfLight"), 300);
			if (Main.hardMode && !NPC.downedMechBoss1 && !NPC.downedMechBoss2 && !NPC.downedMechBoss3)
			{
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/5, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.downedGolemBoss)
			{
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/4, 0, Main.myPlayer);
			}
			if (Main.hardMode && NPC.downedGolemBoss)
			{
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/3, 0, Main.myPlayer);
			}
		}
	}
}
