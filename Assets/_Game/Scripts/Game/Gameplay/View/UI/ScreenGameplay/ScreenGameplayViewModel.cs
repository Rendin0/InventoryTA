public class ScreenGameplayViewModel : WindowViewModel
{
    public override string Id => "ScreenGameplay";
    
    private readonly GameplayUIManager _uiManager;

    public ScreenGameplayViewModel(GameplayUIManager uiManager)
    {
        _uiManager = uiManager;
    }

    public void OpenInventory()
    {
        _uiManager.OpenPopupInventory();

    }
}