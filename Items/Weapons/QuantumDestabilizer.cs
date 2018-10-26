using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class QuantumDestabilizer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Experiment #618"
			+"\nReleases entity destabilizing beam, which deals extremely high damage"
			+"\nRequires 1 seconds to charge the shot"
			+"\nRequires Energy Cells as ammo");
			DisplayName.AddTranslation(GameCulture.Russian, "Квантовый Дестабилизатор");
            Tooltip.AddTranslation(GameCulture.Russian, "Эксперимент №618\nВыпускает луч, дестабилизирующий состояние противника и наносящий очень высокие повреждения\nТребует 1 секунду на заряд\nТребует Энергоячейки в качестве патронов");

            DisplayName.AddTranslation(GameCulture.Chinese, "量子干扰器");
            Tooltip.AddTranslation(GameCulture.Chinese, "蓝图 #618\n释放出一束物质破坏光束, 能造成极高的伤害\n需要一秒钟充能\n需要能源电池作为弹药");
        }

		public override void SetDefaults()
		{
			item.damage = 700;
			item.noMelee = true;
			item.ranged = true;
			item.channel = true;
			item.rare = 11;
			item.width = 30;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;   
			item.knockBack = 10;			
			item.shoot = mod.ProjectileType("QuantumDestabilizer");
			item.useAmmo = mod.ItemType("EnergyCell");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-14, 1);
		}
	}
}
