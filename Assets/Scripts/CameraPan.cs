using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject background;
    
    private int _cameraDragSpeed = 10;
    private float _leftBound;
    private float _rightBound;
    private float _upperBound;
    private float _lowerBound;

    // Start is called before the first frame update
    private void Start()
    {   
        float _verticalExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        float _horizontalExtent = _verticalExtent * Screen.width / Screen.height;
        Bounds spriteBounds = background.GetComponentInChildren<SpriteRenderer>().sprite.bounds;
        Debug.Log(spriteBounds);
        _leftBound = (float)(_horizontalExtent - spriteBounds.size.x * 0.5f);
        _rightBound = (float)(spriteBounds.size.x * 0.5 - _horizontalExtent);
        _lowerBound = (float)(_verticalExtent - spriteBounds.size.y * 0.5f);
        _upperBound = (float)(spriteBounds.size.y  * 0.5 - _verticalExtent);
        Debug.Log(_leftBound);
        Debug.Log(_rightBound);
        Debug.Log(_lowerBound);
        Debug.Log(_upperBound);
        Debug.Log(Camera.main.transform.position);
    }


    // Update is called once per frame
    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float speed = _cameraDragSpeed * Time.deltaTime;
            float _xpos = Input.GetAxis("Mouse X") * speed;
            float _ypos = Input.GetAxis("Mouse Y") * speed;
            //float _xpos = Mathf.Clamp(Input.GetAxis("Mouse X") * speed , _leftBound, _rightBound);
            //float _ypos = Mathf.Clamp(Input.GetAxis("Mouse Y") * speed, _lowerBound, _upperBound);
            Camera.main.transform.position -= new Vector3(_xpos, _ypos, 0);
            //transform.Translate(-_xpos, -_ypos, 0);
            //Debug.Log(_xpos);
            //Debug.Log(_ypos);
            //Debug.Log(Camera.main.transform.position);
        }
    }
}