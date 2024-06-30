public class SpawnerAuthoring:MonoBehavior{
        public GameObject Prefab;
        class Baker:Baker<SpanewAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring){
             var entity=GetEntity(TrnasformUsageFlags.None);
             AddComponent(entity, new Spawner{
                  Prefab=GetEntity(authoring.Prefab,TransformUsageFlags.None)
                 }});
        }}
 
        }
        struct Spawner:IcomponentData{
            public Entity Prefab;
        }
        }

