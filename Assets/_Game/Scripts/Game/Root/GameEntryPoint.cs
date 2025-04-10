using Assets._Game.Scripts.Common;
using Assets._Game.Scripts.Game.Gameplay.Root;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Game.Scripts.Game.Root
{
    public class GameEntryPoint : MonoBehaviour
    {
        private static GameEntryPoint _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void EntryPoint()
        {
            Application.targetFrameRate = 60;

            _instance = new();
            _instance.Run();
        }

        private readonly DIContainer _rootContainer = new();
        private readonly Coroutines _coroutines;

        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            IConfigProvider configProvider = new LocalConfigProvider();
            _rootContainer.RegisterInstance(configProvider);
        }

        private async void Run()
        {
            await _rootContainer.Resolve<IConfigProvider>().LoadGameConfig();

            _coroutines.StartCoroutine(StartGameplay());
        }

        private IEnumerator StartGameplay()
        {
            yield return LoadScene(SceneNames.Boot);
            yield return LoadScene(SceneNames.Gameplay);

            // Пропуск кадра, ибо новая сцена может загрузиться до выгрузки старой
            yield return null;

            var sceneContaiener = new DIContainer(_rootContainer);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(sceneContaiener);

        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}