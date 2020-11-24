using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
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
			DisplayName.AddTranslation(GameCulture.Chinese, "研究笔记 #8");
			Tooltip.AddTranslation(GameCulture.Chinese, @"曾经, 我在一个有趣的世界. 那是个巨大的实验室. 这个实验室的核心是机器人, 她的名字是“GlaDos”(G姐).
她告诉我我必须通过她的“房间”测试. 房间里堆满了各种各样的谜题. 她也给我了一个名为“传送枪”的工具.
但最有趣的是这些小可爱炮塔. 我必须自己做一个!
首先, 我们需要知道这些炮塔所用的技术. 我们可以从[c/00FF00:传送枪]上学习.
然后我们也需要爱护他们, 所以我想我们需要一些[c/00FF00:伙伴方块]
最后, 我们需要给他们一个躯干. 我想那些旧日军团的[c/00FF00:烈焰哨兵炮塔]也许有用.
(注: GLaDOS,基因生命体和磁盘操作系统(Genetic Lifeform and Disk Operating System)的缩写，
是由Valve游戏公司为了Portal和Portal 2游戏所设计的一个虚构的人工智能电脑，由Aperture Science研发)");
        }
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.maxStack = 1;
			item.value = 10000000;
			item.rare = ItemRarityID.Red;
		}	
	}
}
