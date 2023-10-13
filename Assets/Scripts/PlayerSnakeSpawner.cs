using UnityEngine;

public class PlayerSnakeSpawner : SnakeSpawner
{
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        var snake = SpawnSnake();
        _playerController.Init(snake);
    }
}