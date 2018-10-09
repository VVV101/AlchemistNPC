using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class PandoraPF422 : ModItem
	{
		public override bool Autoload(ref string name)
		{
		return ModLoader.GetMod("AlchemistNPCContentDisabler") == null;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pandora (PF422)");
			Tooltip.SetDefault("'A weapon of the underworld, capable of 666 different forms'"
			+"\nSadly, as prototype, that one is capable to transform to only one"
			+"\nLaunches sharp shuriken, which sticks to enemies.");
			DisplayName.AddTranslation(GameCulture.Russian, "Пандора (Форма 422)");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оружие преисподней, имеющее 666 различных форм'\nК сожалению, этот экземпляр всего лишь прототип, способный лишь к одной трансформации\nЗапускает бритвенно-острый сюрикен, цепляющийся за противников");

            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉 (PF422)");
            Tooltip.AddTranslation(GameCulture.Chinese, "'来自地狱的武器, 有666种不同的形式 (外国666代表撒旦)'\n遗憾的是, 作为原型, 只能呈现一种形式");
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.PiranhaGun);
			item.ranged = false;
			item.thrown = true;
			item.damage = 88;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.noUseGraphic = true;
			item.rare = 11;
			item.knockBack = 8;
			item.shoot = mod.ProjectileType("PF422");
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("PF422");
			return true;
		}
	}
}