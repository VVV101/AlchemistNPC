using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class LaserBattery : ModBuff
	{
		public static int counter = 0;
		
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Laser Battery");
			Description.SetDefault("Ready to fire");
			Main.debuff[Type] = false;
			canBeCleared = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Лазерная батарея");
			Description.AddTranslation(GameCulture.Russian, "Готова к стрельбе");
            DisplayName.AddTranslation(GameCulture.Chinese, "激光电池");
            Description.AddTranslation(GameCulture.Chinese, "准备开火");
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			counter++;
			for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - player.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - player.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 350f && target.catchItem == 0 && !target.friendly && target.active && target.type != 488)
                {
                    if (counter > 20)
                    {
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
						Main.PlaySound(SoundID.Item93.WithVolume(.6f), player.position);
                        Projectile.NewProjectile(player.Center.X, player.Center.Y+4, shootToX, shootToY, 433, 60, 6, Main.myPlayer, 0f, 0f);
                        counter = 0;
                    }
                }
			}
		}
	}
}
