using System.Collections.Generic;

namespace KJS
{
    public enum FactionType
    {
        Neutral,
        Player,
        Enemy,
        Ally
    }

    public enum FactionRelationType
    {
        Neutral,
        Ally,
        Hostile
    }

    public static class FactionRules
    {
        private static Dictionary<(FactionType, FactionType), FactionRelationType> relationMap;

        private static bool initialized = false;

        public static void Initialize()
        {
            if (initialized) return;

            relationMap = new()
            {
                { (FactionType.Player, FactionType.Enemy), FactionRelationType.Hostile },
                { (FactionType.Enemy, FactionType.Player), FactionRelationType.Hostile },
                { (FactionType.Player, FactionType.Ally), FactionRelationType.Ally },
                { (FactionType.Ally, FactionType.Player), FactionRelationType.Ally },
                { (FactionType.Ally, FactionType.Enemy), FactionRelationType.Hostile },
                { (FactionType.Enemy, FactionType.Ally), FactionRelationType.Hostile }
                // 나머지 조합은 Neutral로 처리됨
            };

            initialized = true;
        }

        public static FactionRelationType GetRelation(FactionType a, FactionType b)
        {
            Initialize();

            if (relationMap.TryGetValue((a, b), out var relation))
                return relation;

            return FactionRelationType.Neutral;
        }

        public static bool AreHostile(FactionType a, FactionType b)
        {
            return GetRelation(a, b) == FactionRelationType.Hostile;
        }

        public static bool AreAllies(FactionType a, FactionType b)
        {
            return GetRelation(a, b) == FactionRelationType.Ally;
        }
    }
}
