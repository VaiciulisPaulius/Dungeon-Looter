using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{

    [SerializeField] DoorBehaviour _doorBehaviour;

    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorCloseSwitch;

    bool _isPressingSwitch = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPressingSwitch)
        {
            OpenDoor();
        }
        else if (!_isDoorOpen)
        {
            CloseDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2d collision)
    {
        if(collision.CompareTag("Player"))
        {
            _isPressingSwitch = !_isPressingSwitch;
        }
    }
}
