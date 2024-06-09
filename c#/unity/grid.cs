public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera _sceneCamera;
    private Vector3 _lastPos;
    [SerializeField]
    private Layermask _mask;
    public event Action OnClicked, OnExit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            onExit?.Invoke();
    }
    public bool IsPointerOverUI() =>
          EventSystem.current.IsPointOverGameObject();
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _sceneCamera.nearClipPlane;
        Ray ray = _sceenCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            _lastPos = hit.point;
        }
        return _lastPos;
    }
}


public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator; //custom cursor 
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private ObjectDatabaseSo database;
    private int selectedObjectIndex = -1;
    [SerializeField]
    private GameObject gridVisualization;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private GridData floorData, funitureData;

    private Renderer previewRenderer;
    private List<GameObject> list;

    private void Start()
    {
        StopPlacement();
        floorData = new();
        funitureData = new();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }
    /*
    * activate palcement mode 
    */
    private void StartPlacement(int ID)
    {
        selectedObjectIndex = database.objectsData.FindIndex(data => data.id == ID);
        StopPlacement();
        if (selectedObjectIndex < 0)
        {
            Debug.LogError($"No Id found {ID}");
            return;
        }
        gridVisualization.SetActive(true);
        cellIndicator.SetActicve(true);
        inputManager.onClicked += PlaceStructure;
        inputManager.onExit += StopPlacement;
    }
    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridVisualization.SetActive(false);
        cellIndicator.SetActicve(false);
        inputManager.onClicked -= PlaceStructure;
        inputManager.onExit -= StopPlacement;
    }
    private void PlaceStructure()
    {
        if (inputManager.IsPointingOverUI())
        {
            return;
        }
        //set mouse indicator pos
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        bool placementValidity =
    CheckPlacementValidation(gridPosition, selectedObjectIndex);
        if (placementValidity == false) return
        audioSource.play();

        GameObject newObject =
        Instantiate(database.objectsData[selectedObjectIndex].prefab);
        newObject.transform.position = grid.CellToWorld(gridPosition);
    }
    private void Update()
    {
        if (selectedObjectIndex < 0) { return; }
        //set mouse indicator pos
        Vector3 mousePos = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePos)
     bool placementValidity =
 CheckPlacementValidation(gridPosition, selectedObjectIndex);
        previewReneder.material.color = placementValidity ? Color.white : Color.red;

        mouseIndicator.transform.position = mousePos;
        //world pos to grid mapping 

        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private bool CheckPlacementValidation
    (Vector3Int gridPosition, int selectedObjectIndex)
    {
        GirdData selectedData
        = database.objectsData[selectedObjectIndex].ID == 0 ?
        floorData : furnitureDAta
     return selectedData.CanPlaceObjectAt
  (gridPosition, database.objectData[selectedObjectIndex].Size)


  }

    private void RemoveInsideWalls()
    {
        var wallComponent = GameObject.FindObjectsOfType<WallComponent>();
        var childs = wallComponents.Select(c => c.transform.GetChild(0).position.ToString()).ToList();
        var dubPositions = childsGroupBy(c => c).Where(c => c.Coutn() > 1).Select(grp => grp.Key).ToList();
        foreach (wallComponent w in wallComponents)
        {
            var childTransform = w.transform.GetChild(0);
            if (dubPositions.Contains(childTransform.position.ToString()){
                DestoryImmediate(childTransform.gameObject)
              }
        }
    }
}

public class ObjectData
{
    [field: SerializeField]
    publict string Name { get; private set; }
    [field: SerializeField]
    public int Id { get; private set; }
    [field: SerializeField]
    public Vector2Int Size { get; private set; } = Vector2Int.one;
    [field: SerializeField]
    public GameObject prefab { get; private set; }

}

public class ObjectDatabaseSo : ScriptableObject
{
    public List<ObjectData> objectsData;

}
