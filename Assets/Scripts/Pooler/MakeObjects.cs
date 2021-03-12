using System.Collections;
using UnityEngine;

public class MakeObjects : MonoBehaviour 
{
	[Header("The was already present in the object pooler")]
	[SerializeField] private int CoinIndex = 0;
	[SerializeField] private int differentIndex = 0;
	[Header("This will be added to the object pooler when the game begins")]
	[SerializeField] private GameObject prefabCoins;
	[SerializeField] private int countCoins = 10;
	
	[Space(10)]
	[SerializeField] private Transform spawnPoint;

	[SerializeField] private float distanceSpawnMeteor = 35f;
	[SerializeField] private float timeSpawnMeteor = 1f;
	[Space(15)]
	[SerializeField] private float distanceSpawnCoins = 35f;
	[SerializeField] private float timeSpawnCoins = 5f;
	
	
	private ObjectPooler _op;
	
	private void Start()
	{
		_op = ObjectPooler.sharedInstance;
		differentIndex = _op.AddObject(prefabCoins,countCoins);
		Random.InitState((int)System.DateTime.Now.Ticks);
		
		StartCoroutine(SpawnMeteor());
		StartCoroutine(SpawnCoins());
	}

	private IEnumerator SpawnCoins()
	{
		GameObject coin = _op.GetPooledObject(differentIndex);
		
		CalculatePosition(coin,distanceSpawnCoins);
		coin.SetActive(true);
		
		yield return new WaitForSeconds(timeSpawnCoins);

		StartCoroutine(SpawnCoins());
	}

	private IEnumerator SpawnMeteor()
	{
		GameObject meteor = _op.GetPooledObject(CoinIndex);
		
		CalculatePosition(meteor,distanceSpawnMeteor);
		meteor.SetActive(true);
		meteor.GetComponent<Meteor>().sphereCol.enabled = true;

		yield return new WaitForSeconds(timeSpawnMeteor);

		StartCoroutine(SpawnMeteor());
	}

	private void CalculatePosition(GameObject gameObj,float distance)
	{
		gameObj.transform.rotation = spawnPoint.transform.rotation;
		Vector3 pos = Random.onUnitSphere * distance;
		gameObj.transform.position = spawnPoint.transform.position + pos;

	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0f, 0.16f, 1f);
		Gizmos.DrawWireSphere(transform.position, distanceSpawnMeteor);
		
		Gizmos.color = new Color(0.55f, 0.1f, 1f);
		Gizmos.DrawWireSphere(transform.position, distanceSpawnCoins);
	}
}
