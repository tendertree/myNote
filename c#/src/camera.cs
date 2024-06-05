 public Transform cameraTransform;
public float fastSpeed; //3
public float normalSpeed;  //0.5
public float movementSpeed; //1
public float movementTime;  //5
public float rotationAmount; // 1
public Vector3 zoomAmount;

public Vector3 newPos;
public Vector3 newZoom;
public Quaternion newRot;

public Vector3 dragStartPosition;
public Vector3 dragCurrentPosition;

public Vector3 rotateStartPosition;
public Vector3 rotateCurrentPosition;

void Start()
{
    newPos = transform.position;
    newRot = transform.rotation;
    newZoom = cameraTransform.localPosition;
}

void Update()
{
    if (followTransform != null)
    {
        transform.position = followTransform.position;
    }
    else
    {
        HandleMouseInput();
        HandleMovement();
    }

    if (Input.GetKeyDown(KeyCode.Escape))
    {
        followTransform = null;
    }
}

void HandleMouseInput()
{
    if (Input.mouseScrollDelta.y != 0)
    {
        newZoom += Input.mouseScrollDelta.y * zoomAmount;
    }
    if (Input.GetMouseButtonDown(0))
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float entry;
        if (plane.Raycast(ray, out entry))
        {
            dragCurrentPosition = ray.GetPoint(entry);
            newPos = transform.position + dragStartPosition - dragCurrentPosition;
        }
    }
    if (Input.GetMouseButtonDown(2))
    {
        rotateStartPosition = Input.mousePosition;
    }
    if (Input.GetMouseButton(2))
    {
        rotateCurrentPosition = Input.mousePosition;
        Vector3 difference = rotateStartPosition - rotateCurrentPosition;
        rotateStartPosition = rotateCurrentPosition;
        newRot *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
    }
}

void HandleMovement()
{
    if (Input.GetKey(KeyCode.LeftShift))
    {
        movementSpeed = fastSpeed;
    }
    else
    {
        movementSpeed = normalSpeed;
    }
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    {
        newPos += (transform.forward * movementSpeed);
    }
    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
        newPos += (transform.forward * -movementSpeed);
    }
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
        newPos += (transform.right * -movementSpeed);
    }
    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
        newPos += (transform.right * movementSpeed);
    }
    if (Input.GetKey(KeyCode.Q))
    {
        newRot *= Quaternion.Euler(Vector3.up * rotationAmount);
    }
    if (Input.GetKey(KeyCode.E))
    {
        newRot *= Quaternion.Euler(Vector3.up * -rotationAmount);
    }
    if (Input.GetKey(KeyCode.R))
    {
        newZoom *= zoomAmount;
    }
    if (Input.GetKey(KeyCode.F))
    {
        newZoom *= -zoomAmount;
    }
    transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
    transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime);
    cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementSpeed);
}
   }
