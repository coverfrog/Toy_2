using Unity.Netcode;

public class ContentMainMenu : State<ContentManager>
{
    protected override void OnEnter(ContentManager owner)
    {
        UIManager.Instance.PageMainMenu.SetActive(true);
    }

    protected override void OnUpdate(ContentManager owner)
    {
       
    }

    protected override void OnExit(ContentManager owner)
    {
        UIManager.Instance.PageMainMenu.SetActive(false);
    }
}