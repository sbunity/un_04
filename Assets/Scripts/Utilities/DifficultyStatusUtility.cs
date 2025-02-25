using System.Collections.Generic;
using System.Linq;
using Types;

namespace Utilities
{
    public static class DifficultyStatusUtility
    {
        public static DifficultyStatusType GetDifficultyStatus(ContinentType continent, DifficultyType difficulty, int levelsCount)
        {
            switch (difficulty)
            {
                case DifficultyType.Easy:
                    return DifficultyStatusType.Unlocked;
                case DifficultyType.Medium:
                    return GetStatus(continent, DifficultyType.Easy, levelsCount);
                case DifficultyType.Hard:
                    return GetStatus(continent, DifficultyType.Medium, levelsCount);
            }

            return DifficultyStatusType.Locked;
        }

        private static DifficultyStatusType GetStatus(ContinentType continent, DifficultyType difficulty, int levelsCount)
        {
            List<LevelStatusType> types = new List<LevelStatusType>();

            for (int i = 0; i < levelsCount; i++)
            {
                LevelStatusType type = LevelStatusUtility.GetLevelStatusType(continent, difficulty, i);
                
                types.Add(type);
            }

            DifficultyStatusType difficultyType =
                IsLocked(types) ? DifficultyStatusType.Locked : DifficultyStatusType.Unlocked;

            return difficultyType;
        }

        private static bool IsLocked(List<LevelStatusType> types)
        { 
            return types.Any(type => type == LevelStatusType.Locked);
        }
    }
}