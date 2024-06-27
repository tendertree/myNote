public class RotateToTarget:MonoBehaviour
{
 public float rotationSeppd;
 private Vector2 direction;
 void Update()
 {
   direction = Camera.main.ScreenToWorldPotin(Input.mousePosition)-transform.position;
   float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
   Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
   transform.rotation = Quaternion.slerp(transform.rotation,rotation,rotationSpeed*Time.deltaTime);

   Vector2 cursorPos = camera.main.ScreenToWorldPoint(Input.mousePosition);
   transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
}
}
