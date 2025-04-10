using UnityEngine;

namespace Assets._Game.Scripts.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private DIContainer _sceneContainer;

        public void Run(DIContainer sceneContaiener)
        {
            _sceneContainer = sceneContaiener;
            GameplayRegistrations.Register(_sceneContainer);

            var uiManager = _sceneContainer.Resolve<GameplayUIManager>();
            uiManager.OpenPopupInventory();
        }
    }
}