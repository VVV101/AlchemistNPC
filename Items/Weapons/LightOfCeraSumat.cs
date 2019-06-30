using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
	public class LightOfCeraSumat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("''The Light of Cera Sumat''");
			Tooltip.SetDefault("[c/00FF00:Legendary Sword] of Old Duke Ehld."
			+"\nTrue Melee sword"
			+"\nInflicts Curse of Light debuff"
			+"\nMakes enemies take 20% more damage from player"
			+"\n25% to take only half of the damage from debuffed enemy"
			+"\n[c/00FF00:Stats are growing up through post Moon Lord progression]"
			+"\nBoosted stats will be shown after the first swing");
			DisplayName.AddTranslation(GameCulture.Russian, "''Свет Сера Сумат''");
            Tooltip.AddTranslation(GameCulture.Russian, "[c/00FF00:Легендарный Меч] Старого Графа Эхлда\nОслабляет противников при ударе\nОслабленные противники получают на 20% больше урона\n25% шанс получить половину урона от ослабленных противников\n[c/00FF00:Показатели увеличивается по мере пост Мунлордного прохождения]");
			DisplayName.AddTranslation(GameCulture.Chinese, "''塞拉苏门之光''");
			Tooltip.AddTranslation(GameCulture.Chinese, "老公爵埃尔德的[c/00FF00:传奇之剑]"
			+"\n纯近战剑"
			+"\n造成诅咒之光Debuff"
			+"\n来自玩家的攻击对敌人多造成20%伤害"
			+"\n来自带有诅咒之光Debuff敌人的攻击有25%概率只造成一半伤害"
			+"\n[c/00FF00:属性随进程成长]"
			+"\n提升过后的属性将会在使用后显示");

		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Muramasa);
			item.damage = 110;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)
		{
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModDownedGuardian)
				{
					item.damage = 120;
				}
			}
			if (ModLoader.GetLoadedMods().Contains("ThoriumMod"))
			{
				if (ThoriumModDownedRagnarok)
				{
					item.damage = 150;
				}
			}
			if (ModLoader.GetLoadedMods().Contains("CalamityMod"))
			{
				if (CalamityModDownedProvidence)
				{
					item.damage = 150;
				}
				if (CalamityModDownedPolter)
				{
					item.damage = 222;
				}
				if (CalamityModDownedDOG)
				{
					item.damage = 300;
				}
				if (CalamityModDownedYharon)
				{
					item.damage = 400;
				}
				if (CalamityModDownedSCal)
				{
					item.damage = 500;
				}
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
			target.AddBuff(mod.BuffType("CurseOfLight"), 300);
			Vector2 vel1 = new Vector2(0, 0);
			vel1 *= 0f;
			Projectile.NewProjectile(target.position.X, target.position.Y, vel1.X, vel1.Y, mod.ProjectileType("ExplosionAvenger"), damage/2, 0, Main.myPlayer);
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 81;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HolyAvenger"));
			recipe.AddIngredient(mod.ItemType("Pommel"));
			recipe.AddTile(mod.TileType("MateriaTransmutator"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public bool CalamityModDownedGuardian
		{
		get { return CalamityMod.CalamityWorld.downedGuardians; }
		}
		public bool CalamityModDownedBirb
		{
		get { return CalamityMod.CalamityWorld.downedBumble; }
		}
		public bool CalamityModDownedPolter
		{
		get { return CalamityMod.CalamityWorld.downedPolterghast; }
		}
		public bool CalamityModDownedDOG
		{
		get { return CalamityMod.CalamityWorld.downedDoG; }
		}
		public bool CalamityModDownedYharon
		{
		get { return CalamityMod.CalamityWorld.downedYharon; }
		}
		public bool CalamityModDownedSCal
		{
		get { return CalamityMod.CalamityWorld.downedSCal; }
		}
		public bool CalamityModDownedProvidence
        {
        get { return CalamityMod.CalamityWorld.downedProvidence; }
        }
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
	}
}
