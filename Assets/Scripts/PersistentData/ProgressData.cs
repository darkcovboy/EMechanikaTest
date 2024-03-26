using System;
using System.Collections.Generic;

namespace PersistentData
{
    [Serializable]
    public class ProgressData
    {
        public bool IntroduceCutsceneShowed;
        public int MeatCollected;
        public int MoneyCollected;
        public int CountTigers;
        public int CountBanks;
        public int CountButchers;

        public ProgressData(bool introduceCutsceneShowed, int meatCollected, int moneyCollected, int countTigers, int countBanks, int countButchers)
        {
            IntroduceCutsceneShowed = introduceCutsceneShowed;
            MeatCollected = meatCollected;
            MoneyCollected = moneyCollected;
            CountTigers = countTigers;
            CountBanks = countBanks;
            CountButchers = countButchers;
        }
    }
}