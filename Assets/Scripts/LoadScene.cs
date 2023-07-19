using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class LoadScene:MonoBehaviour
    {
        public void LoadSceneTest()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void LoadSceneTest1()
        {
            SceneManager.LoadScene("SampleScene 1");
        }
    }
}