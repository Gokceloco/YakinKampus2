using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Enemy enemyPrefab;
    public Apple applePrefab;

    public float mapXBorders;

    private GameObject _map;

    internal void RestartLevelManager()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }

    private void CreateNewLevel()
    {
        _map = new GameObject("MAP");
        for (int i = 0; i < 5; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, _map.transform);
            newEnemy.transform.position 
                = new Vector3(Random.Range(-mapXBorders, mapXBorders), 0, -3 + (i * 2));
            newEnemy.StartEnemy(gameDirector);
        }
        var newApple = Instantiate(applePrefab, _map.transform);
        newApple.transform.position = new Vector3(Random.Range(-mapXBorders, mapXBorders), 0, 8);
    }

    private void DeleteCurrentLevel()
    {
        Destroy(_map);
    }
}
