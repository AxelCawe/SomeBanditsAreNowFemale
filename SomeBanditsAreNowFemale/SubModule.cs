using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.MountAndBlade;

namespace SomeBanditsAreNowFemale
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            new Harmony("SomeBanditsAreNowFemale").PatchAll(Assembly.GetExecutingAssembly());
        }

    }
}
