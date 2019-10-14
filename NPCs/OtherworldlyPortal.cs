using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.NPCs
{
	[AutoloadHead]
	public class OtherworldlyPortal : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 7;
			DisplayName.SetDefault("Otherworldly Portal");
			DisplayName.AddTranslation(GameCulture.Russian, "Портал Иного Мира");
            DisplayName.AddTranslation(GameCulture.Chinese, "异界传送门");
			ModTranslation text = mod.CreateTranslation("PortalName");
            text.SetDefault("Otherworldly Portal");
            text.AddTranslation(GameCulture.Russian, "Портал Иного Мира");
            text.AddTranslation(GameCulture.Chinese, "异界传送门");
            mod.AddTranslation(text);
		}

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.BoundMechanic);
			npc.townNPC = true;
			npc.width = 50;
			npc.height = 114;
			npc.damage = 1;
			npc.defense = 500;
			npc.lifeMax = 500;
			npc.knockBackResist = 0.1f;
			npc.noGravity = true;
			npc.rarity = 5;
		}
		
		public override string GetChat()
		{
			string barrierStabilized = Language.GetTextValue("Mods.AlchemistNPC.barrierStabilized");
			Main.NewText(barrierStabilized, 55, 55, 255);
			npc.Transform(mod.NPCType("Explorer"));
			return Language.GetTextValue("Mods.AlchemistNPC.portalOpen");
		}
		
		public override string TownNPCName()
        {
			string PortalName = Language.GetTextValue("Mods.AlchemistNPC.PortalName");
            return PortalName;
        }
		
		const int Frame_P11 = 0;
		const int Frame_P12 = 1;
		const int Frame_P13 = 2;
		const int Frame_P14 = 3;
		const int Frame_P15 = 4;
		const int Frame_P16 = 5;
		const int Frame_P17 = 6;
		
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter < 12)
			{
				npc.frame.Y = Frame_P11 * frameHeight;
			}
			else if (npc.frameCounter < 24)
			{
				npc.frame.Y = Frame_P12 * frameHeight;
			}
			else if (npc.frameCounter < 36)
			{
				npc.frame.Y = Frame_P13 * frameHeight;
			}
			else if (npc.frameCounter < 48)
			{
				npc.frame.Y = Frame_P14 * frameHeight;
			}
			else if (npc.frameCounter < 60)
			{
				npc.frame.Y = Frame_P15 * frameHeight;
			}
			else if (npc.frameCounter < 72)
			{
				npc.frame.Y = Frame_P16 * frameHeight;
			}
			else if (npc.frameCounter < 84)
			{
				npc.frame.Y = Frame_P17 * frameHeight;
			}
			else
			{
				npc.frameCounter = 0;
			}
		}
		
		public override void AI()
        {
			Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			
			if (Main.rand.Next(2) == 0)
			{
				for (int i = 0; i < 5; i++)
				{
					int dustType = Main.rand.Next(51, 54);
					int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
					Dust dust = Main.dust[dustIndex];
					dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
					dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
					dust.scale *= 0.95f;
					dust.noGravity = true;
				}
			}
            if (npc.aiStyle == 0)
            {
                for (int index = 0; index < (int)byte.MaxValue; ++index)
                {
                    if (Main.player[index].active && Main.player[index].talkNPC == npc.whoAmI)
                    {
						npc.Transform(mod.NPCType("Explorer"));
						return;
					}
				}
			}
		}
	}
}
