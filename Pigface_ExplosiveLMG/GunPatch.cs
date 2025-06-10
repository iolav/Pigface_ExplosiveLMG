using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pigface_ExplosiveLMG.Patches
{
    [HarmonyPatch(typeof(Gun), "OnGunShot")]
    internal class GunPatch
    {
        static void Postfix(Gun __instance)
        {
            if (!__instance.name.Contains("lmg_gun"))
                return;

            NailBombInstance[] BombInstances = Resources.FindObjectsOfTypeAll<NailBombInstance>();

            NailBombInstance NewBomb = UnityEngine.Object.Instantiate(BombInstances[0], __instance.muzzlePoint.position, __instance.transform.rotation);

            NewBomb.GetComponent<Rigidbody>().AddForce(__instance.muzzlePoint.forward * 1000f, ForceMode.Impulse);
        }
    }
}