using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
    public class CaughtUnicorn : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Caught Unicorn");
            Tooltip.SetDefault("It is still hostile, better do not release him");
			DisplayName.AddTranslation(GameCulture.Russian, "Пойманный единорог");
			Tooltip.AddTranslation(GameCulture.Russian, "Он всё ещё агрессивен, лучше не выпускайте его");
			DisplayName.AddTranslation(GameCulture.Chinese, "被捕获的独角兽");
			Tooltip.AddTranslation(GameCulture.Chinese, "仍充满敌意, 最好别释放他");
        }
		
        public override void SetDefaults()
        {
            item.width = 46;
            item.height = 42;
            item.maxStack = 1;
            item.rare = 10;
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.consumable = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item44;
			item.makeNPC = NPCID.Unicorn;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 16));
        }
		
		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!Collision.SolidCollision(vector2, player.width, player.height));
		}
		
        public override string Texture
		{
			get { return "Terraria/NPC_86"; }
		}
    }
}