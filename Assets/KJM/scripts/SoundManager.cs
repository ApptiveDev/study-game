using UnityEngine;

namespace KJM
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        public AudioClip swordClip;
        public AudioClip arrowClip;
        public AudioClip bombClip;
        public AudioClip WandClip;
        private AudioSource sound;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

        }

        public void PlayWeaponSound(string weaponName)
        {
            AudioClip clip = null;

            switch (weaponName)
            {
                case "sword":
                    clip = swordClip;
                    break;
                case "arrow":
                    clip = arrowClip;
                    break;
                case "bomb":
                    clip = bombClip;
                    break;
                case "Wand":
                    clip = WandClip;
                    break;
            }
            if (clip != null)
            {
                sound.PlayOneShot(clip);
            }
        }
    }
}