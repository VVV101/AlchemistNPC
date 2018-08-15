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

            DisplayName.AddTranslation(GameCulture.Chinese, "班锤");
            Tooltip.AddTranslation(GameCulture.Chinese, "[c/FF0000:秒杀一切非Boss敌人]" +
                "\n[c/FF0000:如果Boss的某个部分不算做Boss, 同样也会被秒杀]");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Muramasa);
			item.melee = true;
			item.damage = 88;
			item.crit = 100;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.hammer = 666;
			item.value = 10000000;
			item.rare = 11;
            item.knockBack = 10;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.expert = true;
			item.scale = 1.5f;
		}
		
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (target.boss == false)
			{
				damage = 999999;
			}
			if (target.type == NPCID.DungeonGuardian)
			{
				damage = 999999999;
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Electrocute"));
			}
		}	
	}
}
