using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class FlaskoftheAlchemist : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flask of the Alchemist");
            Tooltip.SetDefault("Very own weapon of legendary Alchemist, Gregg"
			+"\n[c/00FF00:Legendary Weapon]"
			+"\nThrows Flask of random type"
			+"\n[c/00FF00:Stats are growing through progression]");
            DisplayName.AddTranslation(GameCulture.Russian, "Колба Алхимика");
            Tooltip.AddTranslation(GameCulture.Russian, "Оружие легендарного Алхимика, Грегга\n[c/00FF00:Легендарное Оружие]\nБросает колбу случайного типа\n[c/00FF00:Статы улучшаются по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.Chinese, "炼金师烧瓶");
			Tooltip.AddTranslation(GameCulture.Chinese, "传奇炼金师格雷格的武器"
			+"\n[c/00FF00:传奇武器]"
			+"\n投掷随机种类的的烧瓶"
			+"\n[c/00FF00:属性随进程成长]");
        }    
		public override void SetDefaults()
		{
			item.damage = 7;
			item.thrown = true;
			item.width = 28;
			item.height = 28;
			item.useTime = 55;
			item.useAnimation = 55;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 1000000;
			item.rare = 9;
			item.UseSound = SoundID.Item106;
			item.shoot = mod.ProjectileType("FA1");
			item.autoReuse = true;
			item.shootSpeed = 16f;
			item.noUseGraphic = true;
			item.noMelee = true;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				item.damage = 8;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 10;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 14;
			}
			if (NPC.downedQueenBee)
			{
				item.damage = 16;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 21;
			}
			if (Main.hardMode)
			{
				item.damage = 28;
				item.useTime = 45;
				item.useAnimation = 45;
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
				item.damage = 44;
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
				item.damage = 72;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 111;
			}
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "profaned guardians"))
				{
					item.damage = 140;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (ThoriumModDownedRagnarok)
				{
					item.damage = 200;
				}
			}
			if (Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "providence"))
				{
					item.damage = 200;
				}
				if ((bool)Calamity.Call("Downed", "polterghast"))
				{
					item.damage = 300;
				}
				if ((bool)Calamity.Call("Downed", "dog"))
				{
					item.damage = 1000;
				}
				if ((bool)Calamity.Call("Downed", "yharon"))
				{
					item.damage = 3000;
				}
				if ((bool)Calamity.Call("Downed", "supreme calamitas"))
				{
					item.damage = 10000;
				}
			}
			return true;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			switch (Main.rand.Next(4))
			{
				case 0:
				type = mod.ProjectileType("FA1");
				damage /= 2;
				break;

				case 1:
				type = mod.ProjectileType("FA2");
				damage /= 2;
				break;
				
				case 2:
				type = mod.ProjectileType("FA3");
				damage /= 2;
				break;
				
				case 3:
				type = mod.ProjectileType("FA4");
				break;
			}
			return true;
		}
		
        public bool ThoriumModDownedRagnarok
        {
			get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
	}
}