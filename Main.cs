using BepInEx;
using EVP;
using HarmonyLib;

namespace Lake_SpeedMod
{
    [BepInPlugin("com.skyfoxcoder.lake_speedmod", "Lake Speed Mod", "1.0")]
    [BepInProcess("Lake.exe")]
    public class Lake_SpeedMod : BaseUnityPlugin
    {
        private static Harmony _harmonyInstance;

        void Awake()
        {
            _harmonyInstance = new Harmony("com.skyfoxcoder.lake_speedmod");
            _harmonyInstance.PatchAll();
        }

        void OnDestroy()
        {
            _harmonyInstance.UnpatchSelf();
        }
    }

    [HarmonyPatch(typeof(PlayerMovementController), "Awake")]
    class PlayerPatch
    {
        private static readonly AccessTools.FieldRef<PlayerMovementController, float> sprintSpeedModifierRef = AccessTools.FieldRefAccess<PlayerMovementController, float>("SprintSpeedModifier");
        static void Prefix(PlayerMovementController __instance)
        {
            sprintSpeedModifierRef(__instance) = 5f;
        }
    }

    [HarmonyPatch(typeof(VehicleController), "OnEnable")]
    class VehiclePatch
    {
        private static readonly AccessTools.FieldRef<VehicleController, float> forceCurveShapeRef = AccessTools.FieldRefAccess<VehicleController, float>("forceCurveShape");
        private static readonly AccessTools.FieldRef<VehicleController, float> driveForceToMaxSlipRef = AccessTools.FieldRefAccess<VehicleController, float>("driveForceToMaxSlip");
        private static readonly AccessTools.FieldRef<VehicleController, float> maxSpeedForwardRef = AccessTools.FieldRefAccess<VehicleController, float>("maxSpeedForward");
        private static readonly AccessTools.FieldRef<VehicleController, float> antiRollRef = AccessTools.FieldRefAccess<VehicleController, float>("antiRoll");
        private static readonly AccessTools.FieldRef<VehicleController, float> maxDriveForceRef = AccessTools.FieldRefAccess<VehicleController, float>("maxDriveForce");
        private static readonly AccessTools.FieldRef<VehicleController, float> tireFrictionRef = AccessTools.FieldRefAccess<VehicleController, float>("tireFriction");
        private static readonly AccessTools.FieldRef<VehicleController, float> aeroBalanceRef = AccessTools.FieldRefAccess<VehicleController, float>("aeroBalance");

        static void Prefix(VehicleController __instance)
        {
            forceCurveShapeRef(__instance) = 0.9999f;
            driveForceToMaxSlipRef(__instance) = 0;
            maxSpeedForwardRef(__instance) = 40f;
            antiRollRef(__instance) = 1f;
            maxDriveForceRef(__instance) = 10000f;
            tireFrictionRef(__instance) = 3f;
            aeroBalanceRef(__instance) = 100;
        }
    }
}
