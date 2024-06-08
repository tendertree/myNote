public class LevelManager : MonoBehaviour
{
    public static LevelManger Instance;
    [SerializedField] private GameObject _loaderCanvas;
    [SerializedField] private Image _progressBar;
    private float target;
    void Awake()
    {
        if (Instance = null)
        {
            Instance = this;
            DontDestoryOnLoas(gameObject);
        }
        else
        {
            Destory(gameObject);
        }
    }
    public async void LoadScene(string SceneName)
    {
        _target = 0;
        _progressBar.fillAmout = 0;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        _loaderCanvas.SetActiv(true);

        do
        {
            await Task.Dealy(100);
            _target = scene.progress;


        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
        _loaderCanvas.SetActive(false);
    }

    void Update()
    {
        _progressBar.fillAmout = Mathf.MoveTowards(_progressBar.fillAmout, _target, 3 * Time.deltaTime);
    }
}
