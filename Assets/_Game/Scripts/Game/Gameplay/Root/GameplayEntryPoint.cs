using UnityEngine;

namespace Assets._Game.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameplaySceneUIView _sceneUIRootPrefab;

        private DIContainer _sceneContainer;

        public void Run(DIContainer sceneContaiener)
        {
            _sceneContainer = sceneContaiener;
            GameplayRegistrations.Register(_sceneContainer);

            var uiManager = _sceneContainer.Resolve<GameplayUIManager>();
            uiManager.OpenPopupInventory();

            InitUI(_sceneContainer);
        }

        private void InitUI(DIContainer sceneContainer)
        {
            var uiRoot = sceneContainer.Resolve<UIRootView>();
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRoot.AttachSceneUI(uiScene.gameObject);

            var uiSceneRootViewModel = sceneContainer.Resolve<GameplaySceneUIViewModel>();
            uiScene.Bind(uiSceneRootViewModel);

            // �������� ����
            var uiManager = sceneContainer.Resolve<GameplayUIManager>();
            uiManager.OpenScreenGameplay();
        }
    }
}