using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _initBodyCount = 5;
    [SerializeField] private SnakeInfo _snakeInfo;
    [SerializeField] private Snake _snake;

    protected Snake SpawnSnake()
    {
        var snake = Instantiate(_snake);
        snake.Init(_speed, _snakeInfo);

        snake.CreateHead();
        for (int i = 0; i < _initBodyCount; i++)
        {
            snake.CreateBodyPart();
        }
        return snake;
    }
}