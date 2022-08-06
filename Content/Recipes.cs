using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheOutreach.Content.Items.Materials;
using TheOutreach.Content.Items.Weapons.Magic;
using TheOutreach.Content.Items.Weapons.Melee;
using TheOutreach.Content.Items.Weapons.Ranged;
using TheOutreach.Content.NPCs.Enemies;
using TheOutreach.Content.NPCs.DesertUsurper;
using TheOutreach.Content.NPCs.TownNPCs;

namespace TheOutreach.Content
{
	// This class contains thoughtful examples of item recipe creation.
	public class Recipes : ModSystem
	{
		// A place to store the recipe group so we can easily use it later
		public static RecipeGroup GoldBarRecipeGroup;
		public static RecipeGroup AdamantiteBarRecipeGroup;
		public static RecipeGroup EvilMaterialRecipeGroup;
		public static RecipeGroup SilverRecipeGroup;
		public static RecipeGroup StrangePlantRecipeGroup;

		public override void Unload() {
			GoldBarRecipeGroup = null;
			AdamantiteBarRecipeGroup = null;
			EvilMaterialRecipeGroup = null;
			SilverRecipeGroup = null;
			StrangePlantRecipeGroup = null;
		}

		public override void AddRecipeGroups() {
			// Create a recipe group and store it
			// Language.GetTextValue("LegacyMisc.37") is the word "Any" in english, and the corresponding word in other languages
			GoldBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}",
				ItemID.GoldBar, ItemID.PlatinumBar);

			RecipeGroup.RegisterGroup("TheOutreach:GoldBar", GoldBarRecipeGroup);

			AdamantiteBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.AdamantiteBar)}",
				ItemID.AdamantiteBar, ItemID.TitaniumBar);

			RecipeGroup.RegisterGroup("TheOutreach:AdamantiteBarRecipeGroup", AdamantiteBarRecipeGroup);

			EvilMaterialRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {"Evil Material"}",
				ItemID.ShadowScale, ItemID.TissueSample);

			RecipeGroup.RegisterGroup("TheOutreach:EvilMaterial", EvilMaterialRecipeGroup);

			SilverRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}",
				ItemID.SilverBar, ItemID.TungstenBar);

			RecipeGroup.RegisterGroup("TheOutreach:SilverBar", SilverRecipeGroup);

			StrangePlantRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.StrangePlant1)}",
				ItemID.StrangePlant1, ItemID.StrangePlant2, ItemID.StrangePlant3, ItemID.StrangePlant4);

			RecipeGroup.RegisterGroup("TheOutreach:StrangePlant", StrangePlantRecipeGroup);
		}

		public override void AddRecipes()
		{
			Recipe IceSkates = Recipe.Create(ItemID.IceSkates);
			IceSkates.AddIngredient(ItemID.Silk, 5);
			IceSkates.AddRecipeGroup("IronBar", 5);
			IceSkates.AddIngredient(ItemID.IceBlock, 25);
			IceSkates.AddIngredient(ItemID.SnowBlock, 25);
			IceSkates.AddTile(TileID.IceMachine);
			IceSkates.Register();
			
			Recipe DesertBoots = Recipe.Create(ItemID.SandBoots);
			DesertBoots.AddIngredient(ItemID.Silk, 5);
			DesertBoots.AddIngredient(ItemID.SandBlock, 25);
			DesertBoots.AddIngredient(ItemID.HardenedSand, 25);
			DesertBoots.AddTile(TileID.Loom);
			DesertBoots.Register();

			Recipe HermesBoots = Recipe.Create(ItemID.HermesBoots);
			HermesBoots.AddIngredient(ItemID.Silk, 5);
			HermesBoots.AddIngredient(ItemID.Daybloom, 3);
			HermesBoots.AddTile(TileID.Loom);
			HermesBoots.Register();

			Recipe MagicMirror = Recipe.Create(ItemID.MagicMirror);
			MagicMirror.AddRecipeGroup("TheOutreach:SilverBar", 10);
			MagicMirror.AddIngredient(ItemID.Glass, 15);
			MagicMirror.AddIngredient(ItemID.ManaCrystal);
			MagicMirror.AddTile(TileID.Anvils);
			MagicMirror.Register();

			Recipe IceMirror = Recipe.Create(ItemID.IceMirror);
			IceMirror.AddRecipeGroup("TheOutreach:SilverBar", 10);
			IceMirror.AddIngredient(ItemID.IceBlock, 15);
			IceMirror.AddIngredient(ItemID.ManaCrystal);
			IceMirror.AddTile(TileID.Anvils);
			IceMirror.Register();

			Recipe LifeCrystal = Recipe.Create(ItemID.LifeCrystal);
			LifeCrystal.AddIngredient(ItemID.Ruby, 3);
			LifeCrystal.AddIngredient(ItemID.HealingPotion, 5);
			LifeCrystal.AddIngredient(ItemID.StoneBlock, 10);
			LifeCrystal.AddTile(TileID.DemonAltar);
			LifeCrystal.Register();

			Recipe BandOfRegen = Recipe.Create(ItemID.BandofRegeneration);
			BandOfRegen.AddIngredient<EmptyBand>();
			BandOfRegen.AddIngredient(ItemID.LifeCrystal);
			BandOfRegen.AddTile(TileID.Anvils);
			BandOfRegen.Register();

			Recipe ShinyRedBalloon = Recipe.Create(ItemID.ShinyRedBalloon);
			ShinyRedBalloon.AddIngredient(ItemID.FallenStar, 5);
			ShinyRedBalloon.AddIngredient(ItemID.Cloud, 20);
			ShinyRedBalloon.AddIngredient(ItemID.Gel, 25);
			ShinyRedBalloon.AddIngredient(ItemID.WhiteString);
			ShinyRedBalloon.AddTile(TileID.SkyMill);
			ShinyRedBalloon.Register();

			Recipe CloudInABottle = Recipe.Create(ItemID.CloudinaBottle);
			CloudInABottle.AddIngredient(ItemID.Bottle);
			CloudInABottle.AddIngredient(ItemID.Cloud, 25);
			CloudInABottle.AddIngredient(ItemID.Feather, 3);
			CloudInABottle.AddIngredient(ItemID.Amethyst, 5);
			CloudInABottle.AddTile(TileID.Anvils);
			CloudInABottle.Register();

			Recipe ShoeSpikes = Recipe.Create(ItemID.ShoeSpikes);
			ShoeSpikes.AddRecipeGroup("IronBar", 3);
			ShoeSpikes.AddIngredient(ItemID.Silk, 5);
			ShoeSpikes.AddIngredient(ItemID.Blinkroot, 2);
			ShoeSpikes.AddTile(TileID.Anvils);
			ShoeSpikes.Register();

			Recipe ClimbingClaws = Recipe.Create(ItemID.ClimbingClaws);
			ClimbingClaws.AddRecipeGroup("IronBar", 3);
			ClimbingClaws.AddIngredient(ItemID.Silk, 5);
			ClimbingClaws.AddIngredient(ItemID.Blinkroot, 3);
			ClimbingClaws.AddTile(TileID.Anvils);
			ClimbingClaws.Register();

			Recipe SandstormInABottle = Recipe.Create(ItemID.SandstorminaBottle);
			SandstormInABottle.AddIngredient(ItemID.Bottle);
			SandstormInABottle.AddIngredient(ItemID.SandBlock, 25);
			SandstormInABottle.AddIngredient(ItemID.Amber, 5);
			SandstormInABottle.AddTile(TileID.Anvils);
			SandstormInABottle.Register();

			Recipe BlizzardInABottle = Recipe.Create(ItemID.BlizzardinaBottle);
			BlizzardInABottle.AddIngredient(ItemID.Bottle);
			BlizzardInABottle.AddIngredient(ItemID.SnowBlock, 25);
			BlizzardInABottle.AddIngredient(ItemID.Sapphire, 5);
			BlizzardInABottle.AddTile(TileID.Anvils);
			BlizzardInABottle.Register();

			Recipe Horseshoe = Recipe.Create(ItemID.LuckyHorseshoe);
			Horseshoe.AddIngredient(ItemID.GoldBar, 10);
			Horseshoe.AddIngredient(ItemID.FallenStar, 5);
			Horseshoe.AddIngredient(ItemID.Cloud, 15);
			Horseshoe.AddTile(TileID.SkyMill);
			Horseshoe.Register();

			Recipe Starshower = Recipe.Create(ItemID.Starfury);
			Starshower.AddIngredient<StarShower>();
			Starshower.AddTile(TileID.SkyMill);
			Starshower.Register();

			Recipe FlyingCarpet = Recipe.Create(ItemID.FlyingCarpet);
			FlyingCarpet.AddIngredient(ItemID.AntlionMandible, 5);
			FlyingCarpet.AddIngredient(ItemID.Amber, 3);
			FlyingCarpet.AddIngredient(ItemID.Silk, 5);
			FlyingCarpet.AddTile(TileID.Anvils);
			FlyingCarpet.Register();

			Recipe FrostburnArrow = Recipe.Create(ItemID.FrostburnArrow, 10);
			FrostburnArrow.AddIngredient(ItemID.FlamingArrow, 10);
			FrostburnArrow.AddIngredient(ItemID.IceBlock);
			FrostburnArrow.Register();

			Recipe PocketMirror = Recipe.Create(ItemID.PocketMirror);
			PocketMirror.AddIngredient(ItemID.MarbleBlock, 25);
			PocketMirror.AddIngredient(ItemID.Glass, 15);
			PocketMirror.AddIngredient(ItemID.SoulofLight, 5);
			PocketMirror.AddIngredient(ItemID.SoulofNight, 5);
			PocketMirror.AddRecipeGroup("TheOutreach:AdamantiteBarRecipeGroup", 7);
			PocketMirror.AddTile(TileID.MythrilAnvil);
			PocketMirror.Register();

			Recipe HandWarmers = Recipe.Create(ItemID.HandWarmer);
			HandWarmers.AddIngredient(ItemID.Silk, 10);
			HandWarmers.AddIngredient(ItemID.WarmthPotion, 3);
			HandWarmers.AddIngredient(ItemID.FlinxFur, 2);
			HandWarmers.AddTile(TileID.Loom);
			HandWarmers.Register();

			
		}
		public override void PostAddRecipes()
		{
			for (int i = 0; i < Recipe.numRecipes; i++)
			{
				Recipe recipe = Main.recipe[i];

				if (recipe.HasResult(ItemID.AnkhCharm))
				{
					recipe.AddIngredient(ItemID.PocketMirror);
					recipe.AddIngredient(ItemID.HandWarmer);
				}
			}
		}
	}
}