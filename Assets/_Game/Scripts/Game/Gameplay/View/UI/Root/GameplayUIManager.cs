
public class GameplayUIManager : UIManager
{
    public GameplayUIManager(DIContainer container) 
        : base(container)
    {
    }

    public PopupInventoryViewModel OpenPopupInventory()
    {
        var gameStateProxy = Container.Resolve<IGameStateProvider>().GameStateProxy;
        var inventoryService = Container.Resolve<InventoryService>();
        var viewModel = new PopupInventoryViewModel(gameStateProxy.InventoryProxy, inventoryService);

        var sceneUI = Container.Resolve<GameplaySceneUIViewModel>();
        sceneUI.OpenPopup(viewModel);

        return viewModel;
    }

    public ScreenGameplayViewModel OpenScreenGameplay()
    {
        var viewModel = new ScreenGameplayViewModel(this);

        var sceneUI = Container.Resolve<GameplaySceneUIViewModel>();
        sceneUI.OpenScreen(viewModel);

        return viewModel;
    }
}