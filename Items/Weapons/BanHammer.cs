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
			+"\n[c/FF0000:If a part of the boss doesn't count as boss, it would be killed too]"
			+"\nDungeon Guardian requires at least 2 hits to be killed");
			
			DisplayName.AddTranslation(GameCulture.Russian, "Банхаммер");
			Tooltip.AddTranslation(GameCulture.Russian, "[c/FF0000:Мгновенно убивает всё, что не является боссом.]\n[c/FF0000:Если часть босса не считается боссом - она будет уничтожена.]\nХранитель Данжа требует как минимум 2 попадания для убийства");

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
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Electrocute"));
			}
		}	
	}
}
