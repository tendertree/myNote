public Transform cameraTransform;


public float fastSpeed; //3
public float normalSpeed;  //0.5
public float movementSpeed; //1
public flaot movementTime;  //5
public float rotationAmount; // 1
public Vector3 ZoomAmount;

public Vector3 newPos
public Vector3 newZoom
public Quaternion newRot

public Vector3 dragStartPosition
public Vector3 dragCurrentPosition;

public Vector3 rotateStartPosition
public Vector3 rotateCurrentPosition;

void Start()
{
 newPos = transfrom.position;
 newRot = transform.rotation;
 newZoom = cameraTransform.localPositon;
}

void Update()
{
  if(followTransform !=null){
      transform.posiiton = followTransform.positon;   
  }else
  {
  HandleMouseInput();
  HandleMovement()
  }

  if(Input.GetKeyDown(Keycode.Escape)){
     followTransform = null;
  }
}
void HandleMouseInput(){
   if(Input.mouseScrollDelta.y !=0){
     newZoom += Input.mouseScrollDelta.y * zoomAmount;
   }
   if(Input.GetMouseButtonDown(0)){
      Plane plane = new Plane(Vector3.up,Vector3.zero);
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      float entry;
     if(plane.Raycast(ray, out entry)){
            dragCurrentPostion = ray.GetPoint(entry);
            newPosition = transform.position +dragStartPosition - dragCurrentPosition;
     }
   }
if(Input.GetMouseButtonDown(2))
     {
         rotateStartPosition = Input.mousePosition;
     
     } if(Input.GetMouseButton(2)){
  rotateStartPosition = Input.mousePosition;
     vector3 difference = rotateStartPosition- rotateCurrentPosition;
         rotateStartPosition = rotateCurrentPosition;
         newRotation *= Quaternion.Euler(Vector3.up*(-difference.x/5f));
     
     }
}

void HandleMovement()
{
 
  if(Input.GetKey(KeyCode.LeftShift)){
     movementSpeed=fastSpeed;
  }else{
     movementSpeed=normalSpeed;
  }
  if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
     newPos +=(transform.forward * movementSpeed);
  }
  if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Down)){
     newPos +=(transform.forward * -movementSpeed);
  }
  if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Left)){
     newPos +=(transform.righd * -movementSpeed);
  }
  if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Right)){
     newPos +=(transform.right * movementSpeed);
  } 
   if(Input.GetKey(KeyCode.Q)){
     newRot *= Quaternion.Euler(Vector3.up * rotationAmount); 
  }
   if(Input.GetKey(KeyCode.E)){
     newRot *= Quaternion.Euler(Vector3.up * -rotationAmount); 
  }
  if(Input.GetKey(KeyCode.R)){
     newZom *= zoomAmount; 
  }
     if(Input.GetKey(KeyCode.F)){
     newZom *= -zoomAmount; 
  }
  transform.posiiton = Vector3.Lerp(transform.position, newPos, Tiem.deltaTime * movemenTime);
transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Tiem.deltaTime);
cameraTransform.localPosition = Vector3.Lerp(cameratransform.localPositon, newZoom, Time.deltaTime * movementSpeed)
     }
