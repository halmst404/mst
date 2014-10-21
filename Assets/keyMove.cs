using UnityEngine;
using System.Collections;

public class keyMove : MonoBehaviour
{
    //public
    public const int MOVE_UP    = 0;
    public const int MOVE_DOWN  = 1;
    public const int MOVE_LEFT  = 2;
    public const int MOVE_RIGHT = 3;
    public Camera camera;

    private int nNowState  = 0;
    public int MoveSpeed = 5;

    //コンストラクタ
    void Awake()
    {
        nNowState = MOVE_DOWN;
    }

    //キー入力
    void InputKey()
    {
        if( Input.GetKey( KeyCode.A ))
        {
            setObjState(MOVE_LEFT);
        }
        if( Input.GetKey( KeyCode.S ))
        {
            setObjState(MOVE_DOWN);
        }
        if( Input.GetKey( KeyCode.D ))
        {
            setObjState(MOVE_RIGHT);
        }
        if( Input.GetKey( KeyCode.W ))
        {
            setObjState(MOVE_UP);
        }
    }

    //移動計算
    public void setObjState( int nState )
    {
        int nRot = ( nState - nNowState ) * 90;
        Vector3 v3TransformValue = new Vector3();
        Vector3 v3CameraForward = new Vector3();
        Vector3 V3CameraRight = new Vector3();

        v3CameraForward = camera.transform.forward;
        v3CameraForward.y = 0.0f;

        V3CameraRight = camera.transform.right;
        V3CameraRight.y = 0.0f;

        switch( nState )
        {
            case MOVE_UP:
                v3TransformValue = v3CameraForward * Time.deltaTime; 
                break;
            case MOVE_DOWN:
                v3TransformValue = (-v3CameraForward) * Time.deltaTime;
                break;
            case MOVE_LEFT:
                v3TransformValue = (-V3CameraRight) * Time.deltaTime;
                break;
            case MOVE_RIGHT:
                v3TransformValue = (V3CameraRight) * Time.deltaTime;
                break;
        }

        transform.Rotate(Vector3.up, nRot);
        transform.Translate(v3TransformValue * MoveSpeed, Space.World);

        nNowState = nState;
    }
	
	// Update is called once per frame
	void Update ()
    {
        InputKey();    
	}
}
