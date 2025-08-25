public class ContentGame : State<ContentManager>
{
    protected override void OnEnter(ContentManager owner)
    {
        SceneLoader.LoadScene("Game", this, null, null, null);
    }

    protected override void OnUpdate(ContentManager owner)
    {
       
    }

    protected override void OnExit(ContentManager owner)
    {
        
    }
}