using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AlchemistNPC.Items.Weapons
{
	public class BanHammer : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/FF0000:Instantly kill any non-boss enemies]"
			+"\n[c/FF0000:If part of the boss is not counted as boss, it would be killed too]");
		}

		public override void SetDefaults()
		{
			item.damage = 111;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.hammer = 666;
			item.useStyle = 1;
			item.knockBack = 16;
			item.value = 10000000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.expert = true;
		}
		
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (target.boss == false)
			{
				damage = 999999;
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Electrocute"));
			}
		}	
	}
}
