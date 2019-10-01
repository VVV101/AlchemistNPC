using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class TomeOfOrder : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tome of Order");
			Tooltip.SetDefault("[c/00FF00:Legendary Weapon]"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\n''Only the ones who are equally good and evil may weild this''"
			+"\nShoots energy bolts which stick to enemies and tiles"
			+"\nThey explode after some time or can be blown up manually, dealing extra damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Том Порядка");
            Tooltip.AddTranslation(GameCulture.Russian, "[c/00FF00:Легендарное Оружие]\n''Лишь тот, кто в равной степени добр и зол может использовать это''\n[c/00FF00:Характеристики оружия улучшаются по мере прохождения]\nВыстреливает энергетические снаряды, способные застревать во врагах или блоках\nОни взрываются по прошествии времени или вручную, нанося дополнительный урон");
        }

		public override void SetDefaults()
		{
			item.damage = 9;
			item.noMelee = true;
			item.magic = true;
			item.mana = 6;
			item.rare = 11;
			item.width = 30;
			item.height = 30;
			item.useTime = 12;
			item.UseSound = SoundID.Item9;
			item.useStyle = 5;
			item.shootSpeed = 12f;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.autoReuse = true;
			item.useTime = 10;
			item.useAnimation = 30;
			item.shoot = mod.ProjectileType("Bolt");
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 83;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				item.damage = 10;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 12;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 15;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 18;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 21;
			}
			if (Main.hardMode)
			{
				item.damage = 32;
				item.useTime = 8;
				item.useAnimation = 24;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 36;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				item.damage = 42;
				item.useTime = 7;
				item.useAnimation = 21;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 52;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 60;
				item.useTime = 6;
				item.useAnimation = 18;
			}
			if (NPC.downedFishron)
			{
				item.damage = 70;
			}
			if (NPC.downedAncientCultist)
			{
				item.damage = 80;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 100;
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModDownedGuardian)
				{
					item.damage = 150;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (ThoriumModDownedRagnarok)
				{
					item.damage = 200;
				}
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (CalamityModDownedProvidence)
				{
					item.damage = 200;
				}
				if (CalamityModDownedPolter)
				{
					item.damage = 350;
				}
				if (CalamityModDownedDOG)
				{
					item.damage = 1000;
				}
				if (CalamityModDownedYharon)
				{
					item.damage = 3000;
				}
				if (CalamityModDownedSCal)
				{
					item.damage = 10000;
				}
			}
			if (player.altFunctionUse == 2)
			{
				for(int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].type == mod.ProjectileType("Bolt"))
					{
						Main.projectile[i].Kill();
					}
				}
				return false;
			}
			else
			{
				return true;
			}
			return true;
		}
		
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.World.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedBirb
		{
		get { return CalamityMod.World.CalamityWorld.downedBumble; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.World.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.World.CalamityWorld.downedDoG; }
		}
		public bool CalamityModDownedYharon
		{
		get { return CalamityMod.World.CalamityWorld.downedYharon; }
		}
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.World.CalamityWorld.downedSCal; }
		}
		public bool CalamityModDownedProvidence
        {
        get { return CalamityMod.World.CalamityWorld.downedProvidence; }
        }
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, mod.ProjectileType("Bolt"), damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
