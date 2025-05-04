using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Managers")]
    public GameDirector gameDirector;
    [Space(10)]
    [Header("Prefabs")]
    public Enemy enemyPrefab;
    public Apple applePrefab;    
    public GameObject escapeDoorPrefab;
    [Header("WallPrefabs")]
    public GameObject wallPrefab;
    public GameObject dyanmicWallPrefab;
    public GameObject dyanmicWallPiecesPrefab;
    [Space(10)]
    [Header("Map Properties")]
    public float mapXBorders;
    public float mapXBordersForWalls;

    private GameObject _map;

    internal void RestartLevelManager()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }

    private void CreateNewLevel()
    {
        _map = new GameObject("MAP");
        var enemyCount = Random.Range(3, 6);
        for (int i = 0; i < enemyCount; i++)
        {
            if (Random.value < .5f)
            {
                CreateEnemy(i);
            }
            else
            {
                CreateWall(i);
            }
            
        }
        CreateApple();
        CreateEscapeDoor();
    }

    void CreateEscapeDoor()
    {
        var newDoor = Instantiate(escapeDoorPrefab, _map.transform);
        newDoor.transform.position = new Vector3(Random.Range(-mapXBorders, mapXBorders), 0, -9.5f);
    }

    private void CreateWall(int i)
    {
        if (Random.value < .33f)
        {
            var newWall = Instantiate(wallPrefab, _map.transform);
            newWall.transform.position
                = new Vector3(Random.Range(-mapXBordersForWalls, mapXBordersForWalls), 0, -3 + (i * 2));
        }
        else if (Random.value < .66f)
        {
            var newWall = Instantiate(dyanmicWallPrefab, _map.transform);
            newWall.transform.position
                = new Vector3(Random.Range(-mapXBordersForWalls, mapXBordersForWalls), 0, -3 + (i * 2));
        }
        else
        {
            var newWall = Instantiate(dyanmicWallPiecesPrefab, _map.transform);
            newWall.transform.position
                = new Vector3(Random.Range(-mapXBordersForWalls, mapXBordersForWalls), 0, -3 + (i * 2));
        }
    }

    private void CreateApple()
    {
        var newApple = Instantiate(applePrefab, _map.transform);
        newApple.transform.position = new Vector3(Random.Range(-mapXBorders, mapXBorders), 0, 8);
    }

    private void CreateEnemy(int i)
    {
        var newEnemy = Instantiate(enemyPrefab, _map.transform);
        newEnemy.transform.position
            = new Vector3(Random.Range(-mapXBorders, mapXBorders), 0, -3 + (i * 2));
    }

    private void DeleteCurrentLevel()
    {
        Destroy(_map);
    }
}
