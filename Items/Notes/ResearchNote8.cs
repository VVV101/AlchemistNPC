using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace AlchemistNPC.Items.Notes
{
	public class ResearchNote8 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Research Note #8");
			Tooltip.SetDefault(@"Once, I was in an interesting world. It was a giant laboratory. Heart of this laboratory was robot, her name was ''GlaDOS''.
She has told me that I must test her ''rooms''. There were halls with tons of puzzles. She also gave me a tool called ''Portal Gun''.
But the most interesting thing was these cute turrets. I must make one for my own!
First, we need tech which these turrets use. We can get it from the [c/00FF00:Portal Gun].
Also we need to give them love, so I think we need some sort of ''[c/00FF00:Companion Cube]''.
And as the last part, we need to give them a body. I think  that [c/00FF00:fire sentry] from the Elders army could work.");
			DisplayName.AddTranslation(GameCulture.Russian, "Запись исследования №8");
            Tooltip.AddTranslation(GameCulture.Russian, @"Однажды, я побывала в довольно интересном мире. Это была гигантская лаборатория. Сердцем лаборатории был робот по имени ''ГЛаДОС''.
Она сказала, что я должна испытать её ''камеры''. Это были комнаты с кучей паззлов. Она также выдала мне устройство, названное ''Портальная пушка''.
Но самой интересной частью были эти милые турели. Я обязана сделать хотя бы одну для себя!
Для начала, необходима электроника. Мы можем добыть её из [c/00FF00:Портальной пушки].
Также мы должны подарить им любовь, что означает, что нам необходим ''[c/00FF00:Куб-компаньон]''.
А в качестве последней части, нам необходимо дать ей тело. Думаю, что [c/00FF00:Огненная турель] Древних нам подойдёт.");
        }

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.value = 10000000;
			item.rare = 10;
		}	
	}
}
