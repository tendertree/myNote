public class PlayerController:MonoBehavior{
[SerializeField] private float _speed=1;
    private void Update(){
        if(Input.GetKeyDown(KeyCode.W)) trnasfrom.position += Vector3.forward;        
        }
    }



public class PlayerController:MonoBehavior{
[SerializeField] private float _speed=1;
[SerializeField] private RigidBody _rb;
    private void Update(){
       var dir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        transform.Translate(dir*_speed*Time.deltaTime);
        _rb.velocity = dir * speed 
        }
    }


void Update(){
     transform.position = Vector3.MoveTowards(transform.position,movePoint.position,moveSpeed * Time.deltatime);
  if(Vector3.Distance(transform.position,movePoint.posisiton <=.05f){
    if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))=1f){
        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"),0f,0f);
    }
    if(Mathf.Abs(Input.GetAxisRaw("Vertical"))=1f){
        movePoint.position += new Vector3(Input.GetAxisRaw("Vertical"),0f);
    }
   }
