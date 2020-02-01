using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{

    private int _cameraDragSpeed = 10;
    private float _leftBound;
    private float _rightBound;
    private float _upperBound;
    private float _lowerBound;

    // Start is called before the first frame update
    void Start()
    {
        float _verticalSize = Camera.main.GetComponent<Camera>().orthographicSize;  
        float _horizontalSize = _verticalSize * Screen.width / Screen.height;
        spriteBounds = GameObject.FindWithTag("Background").GetComponentInChildren<SpriteRenderer>();
        _leftBound = (float)(_horizontalSize - spriteBounds.sprite.bounds.size.x / 2.0f);
        _rightBound = (float)(spriteBounds.sprite.bounds.size.x / 2.0f - _horizontalSize);
        _lowerBound = (float)(_verticalSize - spriteBounds.sprite.bounds.size.y / 2.0f);
        _upperBound = (float)(spriteBounds.sprite.bounds.size.y  / 2.0f - _verticalSize);
    }

    // Update is called once per frame
    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float speed = _cameraDragSpeed * Time.deltaTime;
            _xpos = Input.GetAxis("Mouse X") * speed;
            _ypos = Input.GetAxis("Mouse Y") * speed;

            Camera.main.transform.position -= new Vector3(_xpos, y_pos, 0);
        }
    }

 
}
