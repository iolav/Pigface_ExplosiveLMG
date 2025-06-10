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
            NailBombInstance[] BombInstances = Resources.FindObjectsOfTypeAll<NailBombInstance>();

            NailBombInstance NewBomb = UnityEngine.Object.Instantiate(BombInstances[0], __instance.muzzlePoint.position, __instance.transform.rotation);

            float Force = 100f;
            NewBomb.GetComponent<Rigidbody>().AddForce(__instance.muzzlePoint.forward * Force * 1.5f + __instance.muzzlePoint.up * Force / 8f, ForceMode.Impulse);
        }
    }
}