using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.World.Generation;

namespace AlchemistNPC.Items.Weapons
{
	public class BanHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("[c/FF0000:Instantly kills any non-boss enemies]"
			+"\n[c/FF0000:If a part of the boss doesn't count as boss, it would be killed too]");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Банхаммер");
			Tooltip.AddTranslation(GameCulture.Russian, "[c/FF0000:Мгновенно убивает всё, что не является боссом.]\n[c/FF0000:Если часть босса не считается боссом - она будет уничтожена]");

            DisplayName.AddTranslation(GameCulture.Chinese, "班锤");
            Tooltip.AddTranslation(GameCulture.Chinese, "[c/FF0000:秒杀一切非Boss敌人]" +
                "\n[c/FF0000:如果Boss的某个部分不算做Boss, 同样也会被秒杀]"
				+"\n地牢守卫者需要至少2击才能杀死");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Muramasa);
			item.melee = true;
			item.damage = 88;
			item.crit = 100;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.hammer = 666;
			item.value = 500000;
			item.rare = 10;
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
				target.buffImmune[mod.BuffType("Banned")] = false;
				target.AddBuff(mod.BuffType("Banned"), 60);
			}
			if (target.type == 134 || target.type == 135 || target.type == 136 || target.type == 325 || target.type == 327 || target.type == 325 || target.type == 344 || target.type == 345 || target.type == 346)
			{
				damage = 88;
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				if (target.type == mod.NPCType("CeaselessVoid"))
				{
					damage = 1;
				}
			}
			if (target.type == NPCID.DungeonGuardian)
			{
				target.buffImmune[mod.BuffType("Banned")] = false;
				target.AddBuff(mod.BuffType("Banned"), 60);
			}
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
		}	
	}
}
