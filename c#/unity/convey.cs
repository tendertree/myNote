public class BeltItem:MonoBehavior{
 public GameObject Item;
 private voide Awake(){
     item=gameObject;
 }
}

public class BeltManager:MonoBehavior{
 public float speed=2f
}


public class Belt:MonoBehavior{
    private static int _id = 0;
    public Belt next;
    public BeltItem beltItem;
    public bool isUsed;
    private BeltManager _manager;
 private void Start()
 {
   _manager = FindObjectOfTYpe<BeltManager>();
   next=null;
   next=FindNext();
   gameObject.name = $"Belt:{_id++}";
 }
 private void Update(){
  if(next==null) next = FindNext();
   if(beltItem!=null && beltItem.item !=null){
     StartCoroutine(StartMove());
   }
}
 public Vector3 GetItemPosition(){
    var padding = 0.3f;
    var pos = transform.position;
    return new Vector3(pos.x, pos.y + padding, pos.z);
 }
 private IEnumerator MoveNext(){
  isUsed=true;
 }   

 private Belt FindNext()
 {
 Transform cur = transform;
 RaycastHit hit;
 var forward = transfrom.forward;
 Ray ray = new Ray(cur.position,forward);
 if(Physics.Raycast(ray,out hit, 1f))
 {
   Belt item = hit.collider.GetComponent<Belt>();
   if(item !=null) return item;
 }
  return null;
 }
 private voied StartMove(){
     isUsed = true; 
     if(beltItem.Item!=null && next!=null&& next.isUsed ==false){

         Vector3 to = next.GetItemPosition()
         next.isUsed = true;
         var step = _manager.speed * Time.deltaTime;
         while(beltItem.Item.transform.position != to){
             beltItem.item.transform.position =
              Vector3.MoveTowards(beltItem.transform.positon,to,step);
             yield return null;
         }
         isUsed=false;
         next.beltItem = beltItem;
         beltItem = null;
     }
  } 
}
