﻿namespace DrugsInInventory
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{DrugsInInventoryMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
