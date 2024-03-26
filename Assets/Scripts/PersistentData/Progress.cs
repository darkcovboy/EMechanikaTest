using UnityEngine;

namespace PersistentData
{
    public class Progress
    {
        private const string ProgressKey = "Progress";
        public ProgressData ProgressData;
        
        public Progress()
        {
            LoadProgressOrInitNew();
        }

        public void Save() => PlayerPrefs.SetString(ProgressKey, ProgressData.ToJson());

        private void LoadProgressOrInitNew() => ProgressData = LoadProgress() ?? NewProgress();

        private ProgressData NewProgress() => new ProgressData(false,200, 200,0, 0, 0);

        private ProgressData LoadProgress() => PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<ProgressData>();
    }
}