using UnityEngine;

[CreateAssetMenu(fileName = "SnakeInfo", menuName = "SnakeInfo/Snake Info")]
public class SnakeInfo : ScriptableObject
{
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _bodyPart;

    public GameObject Head => _head;
    public GameObject BodyPart => _bodyPart;
}
