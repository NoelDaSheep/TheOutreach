using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace TheOutreach.Common.ItemDropRules.Conditions
{
	// Very simple drop condition: drop during daytime
	public class ExampleDropConditionEoW : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info) {
			if (!info.IsInSimulation) {
				return NPC.downedBoss2;
			}
			return false;
		}

		public bool CanShowItemDropInUI() {
			return true;
		}

		public string GetConditionDescription() {
			return "(Drops after The Eater of Worlds is defeated)";
		}
	}
	public class ExampleDropConditionBoC : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
			{
				return NPC.downedBoss2;
			}
			return false;
		}

		public bool CanShowItemDropInUI()
		{
			return true;
		}

		public string GetConditionDescription()
		{
			return "(Drops after The Brain of Cthulhu is defeated)";
		}
	}
}
