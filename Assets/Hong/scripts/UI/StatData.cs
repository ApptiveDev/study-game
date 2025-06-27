using UnityEngine;
namespace AJH
{
    [CreateAssetMenu(fileName = "StatData", menuName = "Scriptable Objects/StatData")]
    public class StatData : ScriptableObject
    {
        public enum StatType {Speed, Defense, Gold}
        public StatType statType; // 스탯 종류
        public string statName; // 스탯 이름
        public float baseValue; // 기본 값
        public float[] upgradeValues = new float[3]; // 레벨에 따른 값 배열
        public int[] upgradeCosts = new int[3]; // 업그레이드 비용 배열

    }
}
