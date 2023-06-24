using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Util
{
    public class ResetSave : MonoBehaviour
    {
        public static ResetSave Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void BigReset()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }
}