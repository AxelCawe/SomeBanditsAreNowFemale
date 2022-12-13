using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace SomeBanditsAreNowFemale.Patches
{
    [HarmonyPatch(typeof(MobileParty), "FillPartyStacks")]
    public static class BanditUnlockerPatch
    {
        [HarmonyPostfix]
        public static void PostFix(MobileParty __instance, PartyTemplateObject pt, int troopNumberLimit = -1)
        {
            if (__instance.IsBandit)
            {
                float playerProgress = Campaign.Current.PlayerProgress;
                float num = 0.4f + 0.8f * playerProgress;
                int num2 = MBRandom.RandomInt(2);
                float num3 = (num2 == 0) ? MBRandom.RandomFloat : (MBRandom.RandomFloat * MBRandom.RandomFloat * MBRandom.RandomFloat * 4f);
                float num4 = (num2 == 0) ? (num3 * 0.8f + 0.2f) : (1f + num3);
                float randomFloat = MBRandom.RandomFloat;
                float randomFloat2 = MBRandom.RandomFloat;
                float randomFloat3 = MBRandom.RandomFloat;
                float f = (pt.Stacks.Count > 0) ? ((float)pt.Stacks[0].MinValue + num * num4 * randomFloat * (float)(pt.Stacks[0].MaxValue - pt.Stacks[0].MinValue)) : 0f;
                float f2 = (pt.Stacks.Count > 1) ? ((float)pt.Stacks[1].MinValue + num * num4 * randomFloat2 * (float)(pt.Stacks[1].MaxValue - pt.Stacks[1].MinValue)) : 0f;
                float f3 = (pt.Stacks.Count > 2) ? ((float)pt.Stacks[2].MinValue + num * num4 * randomFloat3 * (float)(pt.Stacks[2].MaxValue - pt.Stacks[2].MinValue)) : 0f;
                
                for (int i = 3; i < pt.Stacks.Count; ++i)
                {
                    float newF = ((float)pt.Stacks[i].MinValue + num * num4 * randomFloat * (float)(pt.Stacks[i].MaxValue - pt.Stacks[i].MinValue));
                    __instance.AddElementToMemberRoster(pt.Stacks[i].Character, MBRandom.RoundRandomized(newF), false);
                  
                }                
                
            }
        }
    }
}
