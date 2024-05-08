using HarmonyLib;
using RimWorld;
using Verse;

namespace DrugsInInventory
{
    [HarmonyPatch(typeof(Pawn_DrugPolicyTracker))]
    [HarmonyPatch(nameof(Pawn_DrugPolicyTracker.AllowedToTakeToInventory))]
    public static class Patch_Pawn_DrugPolicyTracker
    {
        public static bool Prefix(Pawn_DrugPolicyTracker __instance, ThingDef thingDef, ref bool __result)
        {
            if (!thingDef.IsIngestible)
            {
                Log.Error(thingDef + " is not ingestible.");
                __result = false;
            }
            else if (!thingDef.IsDrug)
            {
                Log.Error("AllowedToTakeScheduledEver on non-drug " + thingDef);
                __result = false;
            }
            else if (thingDef.IsNonMedicalDrug && !__instance.pawn.CanTakeDrug(thingDef))
            {
                __result = false;
            }
            else
            {
                DrugPolicyEntry drugPolicyEntry = __instance.CurrentPolicy[thingDef];
                __result = __instance.pawn.inventory.innerContainer.TotalStackCountOfDef(thingDef) < drugPolicyEntry.takeToInventory;
            }

            return false;
        }
    }
}
