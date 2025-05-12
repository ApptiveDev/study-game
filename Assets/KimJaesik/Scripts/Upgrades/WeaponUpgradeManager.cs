using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace KJS
{
    public class WeaponUpgradeManager : MonoBehaviour
    {
        public static WeaponUpgradeManager Instance { get; private set; }

        [Header("무기 오브젝트 (플레이어 하위 오브젝트)")]
        public GameObject energyWaveCannon;
        public GameObject missileLauncher;
        public GameObject turretAddOn;

        private List<WeaponData> allWeapons;

        [Header("발사체 프리팹")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject missilePrefab;
        [SerializeField] private GameObject energyWavePrefab;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            InitializeWeapons();
        }

        private void InitializeWeapons()
        {
            allWeapons = new List<WeaponData>
            {
                new WeaponData {
                    weaponName = "turretAddOn",
                    description = "Deploys auto-aiming turrets that shoot bullets at the nearest enemy.",
                    weaponObject = turretAddOn,
                    upgradeAction = () => {
                        if (turretAddOn == null)
                        {
                            Debug.LogWarning("turretAddOn is null. Upgrade skipped.");
                            return;
                        }
                        var turrets = turretAddOn.GetComponentsInChildren<KJS.Turret_AddOn>();
                        foreach (var turret in turrets)
                        {
                            turret.castTime *= 0.9f;
                        }
                    }
                },
                new WeaponData {
                    weaponName = "energyWaveCannon",
                    description = "Fires a powerful straight-line wave that pierces through enemies.",
                    weaponObject = energyWaveCannon,
                    upgradeAction = () => {
                        var cannon = energyWaveCannon.GetComponent<KJS.EnergyWaveCannon>();
                        if (cannon != null)
                        { 
                            cannon.castTime *= 0.8f;
                        }
                    }
                },
                new WeaponData {
                    weaponName = "missileLauncher",
                    description = "Launches homing missiles to the left and right.",
                    weaponObject = missileLauncher,
                    upgradeAction = () => {
                        var launcher = missileLauncher.GetComponent<KJS.MissileLauncher>();
                        if (launcher != null)
                        {
                            launcher.castTime *= 0.8f;
                        }
                        if (missilePrefab != null)
                        {
                            var missile = missilePrefab.GetComponent<KJS.Missile>();
                            if (missile != null)
                            {
                                missile.homingSpeed *= 1.2f;
                            }
                        }
                    }
                }
            };

            foreach (var weapon in allWeapons)
            {
                weapon.weaponObject.SetActive(false);
            }

            int randomIndex = Random.Range(0, allWeapons.Count);
            allWeapons[randomIndex].ActivateWeapon();
        }

        public List<WeaponData> GetRandomWeapons(int count = 3)
        {
            return allWeapons.OrderBy(w => Random.value).Take(count).ToList();
        }
    }
}