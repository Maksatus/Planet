using UnityEngine;
using Random = UnityEngine.Random;

public class CreatingEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int[] objectCount;
    [SerializeField] private float distance = 20f;
    [Space(15)] 
    [SerializeField] private MeshFilter coordinateVertexMesh;

    [Header("If the spawn is by sphere then true")]
    [SerializeField] private bool isSphere;

    private Vector3[] _vertices;

    private void Awake()
    {
        if (isSphere) return;
        var oMesh = coordinateVertexMesh.sharedMesh;
        _vertices = oMesh.vertices;
    }

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < objectCount[i]; j++)
            {
                Vector3 pos = RandomPos(isSphere);
                var heading = transform.position - pos;
                var direction = heading / distance; 
                
                Instantiate(objects[i], pos, Quaternion.LookRotation(direction,Vector3.up));
            }
        }
    }
    
    private Vector3 RandomPos(bool flag)
    {
        if (flag)
        {
            return Random.onUnitSphere * distance;
        }
        else
        {
            int index = Random.Range(0, _vertices.Length);
            return _vertices[index];
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.29f, 0.27f);
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
