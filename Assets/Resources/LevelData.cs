using System.Collections.Generic;

namespace Assets.Levels
{
    [System.Serializable]
    public class LevelData
    {
        public List<Levels> Levels;
    }

    [System.Serializable]
    public class Levels
    {
        /// <summary>
        /// Unity serializer support only variables...
        /// </summary>
        public int Level;
        public string LevelSetup;
    }
}
