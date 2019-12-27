using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
	public class TinkererHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tinkerer Horcrux");
			Tooltip.SetDefault("The piece of Tinkerer's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.Russian, "Крестраж Инженера");
			Tooltip.AddTranslation(GameCulture.Russian, "Часть души Инженера находится внутри");
			DisplayName.AddTranslation(GameCulture.Chinese, "音乐家魂器");
			Tooltip.AddTranslation(GameCulture.Chinese, "里面有音乐家的一片灵魂.");
        }

		public override void SetDefaults()
		{
			item.width = 46;
            item.height = 42;
            item.maxStack = 30;
            item.rare = 10;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item37;
			item.makeNPC = (short)mod.NPCType("Tinkerer");
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(mod.NPCType("Tinkerer")) && !Collision.SolidCollision(vector2, player.width, player.height));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Tinkerer is spawned.", 255, 255, 255);
		}
	}
}