using HarmonyLib;
using Verse;

namespace DrugsInInventory
{
    public class DrugsInInventoryMod : Mod
    {
        public const string PACKAGE_ID = "drugsininventory.1trickPwnyta";
        public const string PACKAGE_NAME = "Drugs in Inventory";

        public DrugsInInventoryMod(ModContentPack content) : base(content)
        {
            Harmony harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
