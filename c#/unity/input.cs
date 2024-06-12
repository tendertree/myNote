//simple mapping moused to world position
public static Vector3 GetMouseWorldPosition ()=> Instance.GetMousePosition_Instancemain
private Vector3 GetMouseWorldPosition_Instance(){
Ray ray= Camera.main.ScreenPointToRay(Input.mouseposition)
 if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask)){
 return raycastHit.point ;
 }else{
 return Vector3.zero;
 }
}

//simpler version 
Ray ray= Camera.main.ScreenPointToRay(Input.mouseposition)
RaycastHit hit;
 if (Physics.Raycast(ray, out hit)){
 return hit.point 
}
//use nearClipPlane
private Vector3 lastPosition
[SerializeField]
private LayerMask nask
public Vector3 GetMousePosition(){
Vector3 mousePos = Input.mousePosition;
    mousePos.z = sceneCamera.nearClipPlane;
    Ray ray = sceneCamera.ScreenPointToRay(mousePos);
    RaycastHit hit;
    if(Physics.Raycast(ray,out hit, 100, mask)){
        lastPosition = hit.point;
    }
return lastPoistion
}




