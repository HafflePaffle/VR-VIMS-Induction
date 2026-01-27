using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SingletonSetup
{
    public class SingletonSettings : MonoBehaviour
    {
        public static SingletonSettings Instance { get; private set; }

        public float degreesPerSecond = 80f;
        public int sceneIndex = 0;
        public bool lyingDown = false;
        public bool rotateLeft = false;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

