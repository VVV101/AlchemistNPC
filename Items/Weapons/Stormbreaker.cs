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

namespace AlchemistNPC.Items.Weapons
{
	public class Stormbreaker : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Forged to fight the most powerful beings in the universe. Wield it wisely.");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Muramasa);
			item.melee = true;
			item.damage = 200;
			item.crit = 21;
			item.width = 40;
			item.height = 34;
			item.useTime = 10;
			item.useAnimation = 10;
			item.hammer = 600;
			item.axe = 120;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 10f;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.expert = true;
			item.scale = 1.5f;
			item.shootSpeed = 12f;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				item.useTime = 10;
				item.useAnimation = 10;
				item.damage = 200;
				item.shootSpeed = 12f;
				item.shoot = 0;
				item.noMelee = false;
				item.noUseGraphic = false;
			}
			if (player.altFunctionUse == 2)
			{
				item.useTime = 10;
				item.useAnimation = 10;
				item.damage = 200;
				item.shootSpeed = 24f;
				item.shoot = mod.ProjectileType("Stormbreaker");
				item.noMelee = true;
				item.noUseGraphic = true;
			}
			
			return base.CanUseItem(player);
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Electrocute"));
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("Electrocute"), 300);
			if (Main.rand.Next(4) == 0)
			{
			Vector2 vector82 =  -Main.player[Main.myPlayer].Center + Main.MouseWorld;
            float ai = Main.rand.Next(100);
            Vector2 vector83 = Vector2.Normalize(vector82) * item.shootSpeed;
            Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, 580, damage/2, .5f, player.whoAmI, vector82.ToRotation(), ai);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NimbusRod);
			recipe.AddRecipeGroup("AlchemistNPC:AnyLunarHamaxe");
			recipe.AddIngredient(ItemID.MoltenHamaxe);
			recipe.AddIngredient(ItemID.MeteorHamaxe);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
