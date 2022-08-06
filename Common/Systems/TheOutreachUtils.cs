using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using ReLogic.Graphics;
using System;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.UI;
using Terraria.WorldBuilding;
using Terraria.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.Enums;
using Terraria.GameContent.Events;
using Terraria.GameInput;
using Terraria.ObjectData;
using Terraria.UI.Chat;
using TheOutreach.Content.Items.F_I_S_H;
using TheOutreach.Content.Items.Weapons.Magic;

namespace TheOutreach.Common.Systems
{
	public class TheOutreachUtils
	{
		public static void BossAwakenMessage(int npcIndex)
		{
			string typeName = Main.npc[npcIndex].TypeName;
			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText(Language.GetTextValue("Announcement.HasAwoken", typeName), new Color(175, 75, 255));
			}
			/*else if (Main.netMode == 2)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", Main.npc[npcIndex].GetTypeNetName()), new Color(175, 75, 255), -1);
			}*/
		}
		//public static NPC SpawnBossBetter(Vector2 relativeSpawnPosition, int bossType, BaseBossSpawnContext spawnContext = null, float ai0 = 0f, float ai1 = 0f, float ai2 = 0f, float ai3 = 0f)

		public static NPC SpawnBossBetter(Vector2 spawnPosition, int bossType)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				return null;
			}
			int bossIndex = NPC.NewNPC(Item.GetSource_NaturalSpawn(), (int)spawnPosition.X, (int)spawnPosition.Y, bossType, 0);
			if (Main.npc.IndexInRange(bossIndex))
			{
				BossAwakenMessage(bossIndex);
				return Main.npc[bossIndex];
			}
			return null;
		}
	}
}

