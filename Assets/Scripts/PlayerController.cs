using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Snake _player;
    private DynamicJoystick _dynamicJoystick;

    private void Start()
    {
        _dynamicJoystick = GetComponent<DynamicJoystick>();
    }
    private void FixedUpdate()
    {
        if (_player == null || _dynamicJoystick == null)
            return;

        _player.Move(_dynamicJoystick.Vertical, _dynamicJoystick.Horizontal);
    }

    public void Init(Snake player)
    {
        _player = player;
    }
}
