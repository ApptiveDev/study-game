using UnityEngine;
using System.Collections.Generic;

namespace KJS
{
    public class TargetManager : MonoBehaviour
    {
        public static TargetManager Instance { get; private set; }

        private List<Faction> factionList = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void Register(Faction faction)
        {
            if (faction != null && !factionList.Contains(faction))
            {
                factionList.Add(faction);
            }
        }

        public void Unregister(Faction faction)
        {
            if (faction != null && factionList.Contains(faction))
            {
                factionList.Remove(faction);
            }
        }

        /// <summary>
        /// 지정된 진영 기준으로 가장 가까운 적대 유닛을 반환합니다.
        /// </summary>
        public Transform GetNearestHostileTarget(Vector3 from, FactionType myFaction, float maxDistance = Mathf.Infinity)
        {
            Transform closest = null;
            float minDistance = maxDistance;

            foreach (var faction in factionList)
            {
                if (faction == null) continue;

                if (!FactionRules.AreHostile(myFaction, faction.type))
                    continue;

                float dist = Vector3.Distance(from, faction.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closest = faction.transform;
                }
            }

            return closest;
        }
    }
}
