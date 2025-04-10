
public class GameplayUIManager : UIManager
{
    public GameplayUIManager(DIContainer container) 
        : base(container)
    {
    }

    public PopupInventoryViewModel OpenPopupInventory()
    {
        var gameStateProxy = Container.Resolve<IGameStateProvider>().GameStateProxy;
        var viewModel = new PopupInventoryViewModel(gameStateProxy.InventoryProxy);

        var sceneUI = Container.Resolve<GameplaySceneUIViewModel>();
        sceneUI.OpenPopup(viewModel);

        return viewModel;
    }
}