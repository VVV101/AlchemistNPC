using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class TurretStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Turret Staff");
			Tooltip.SetDefault("Summons deadly GLaDOS turret to fight for you");
			DisplayName.AddTranslation(GameCulture.Russian, "Посох турели");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает смертоносную турель ГЛаДОС");
			DisplayName.AddTranslation(GameCulture.Chinese, "G姐炮塔召唤杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤致命的G姐炮塔为你而战");
        
        }    
		
		public override void SetDefaults()
		{
			item.damage = 66;
			item.mana = 100;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.knockBack = 10;
			item.value = Item.buyPrice(5, 0, 0, 0);
			item.rare = 10;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Turret");
			item.summon = true;
			item.sentry = true;
			item.buffType = mod.BuffType("Turret");
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
		
		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Main.PlaySound(2, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PortalTurretDeploy"));
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			if (player.ownedProjectileCounts[mod.ProjectileType("Turret")] < player.maxTurrets)
			{
				return true;
			}
			return false;
		}
	}
}
