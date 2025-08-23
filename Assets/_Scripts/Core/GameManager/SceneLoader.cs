using System.Collections;
using _Scripts.DesignPattern.Singleton;
using UnityEngine.SceneManagement;

namespace _Scripts.Core.GameManager
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        protected override void Awake()
        {
            base.Awake();
            KeepAlive(true);
            
            // Ensure UICoreScene is loaded
            if(!SceneManager.GetSceneByName("UICoreScene").isLoaded)
                SceneManager.LoadScene("UICoreScene", LoadSceneMode.Additive);
        }
        
        private IEnumerable LoadSceneAsync(string sceneName, bool isAdditive = false)
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerable UnloadSceneAsync(string sceneName)
        {
            if(string.IsNullOrEmpty(sceneName)) yield break;

            var scene = SceneManager.GetSceneByName(sceneName);
            if(!scene.IsValid() || !scene.isLoaded) yield break;
            HideAllGameObjectsInScene(sceneName);
            yield return SceneManager.UnloadSceneAsync(sceneName);
        }
        
        private void HideAllGameObjectsInScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) return;
            
            var scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.IsValid() || !scene.isLoaded) return;
            
            var rootObjects = scene.GetRootGameObjects();
            foreach (var obj in rootObjects)
            {
                obj.SetActive(false);
            }
        }
        
        private void ShowAllGameObjectsInScene(string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName)) return;
            
            var scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.IsValid() || !scene.isLoaded) return;
            
            var rootObjects = scene.GetRootGameObjects();
            foreach (var obj in rootObjects)
            {
                obj.SetActive(true);
            }
        }
    }
}
 