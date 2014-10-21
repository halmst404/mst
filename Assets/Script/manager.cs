using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {

    enum FadeState
    {
        None,
        Out,
        Wait,
        In
    };

    private static GUITexture m_this;

    private static FadeState m_State;  //状態
    private static string m_strFadeTo; //フェード先
    private static float m_fAlpha;
    private static float m_fFeedTime;

    //シーンの非同期読み込み用
    private static AsyncOperation m_Async;

    void Awake()
    {
        //シーン遷移しても維持する設定
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () 
    {
        m_State = FadeState.None;
        m_this = GetComponent<GUITexture>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        switch( m_State )
        {
            case FadeState.In:
                m_fAlpha += Time.deltaTime / (m_fFeedTime / 2);
                if (m_fAlpha > 1.0f)
                {
                 //   m_Async.allowSceneActivation = true;
                    Application.LoadLevel(m_strFadeTo);
                    m_State = FadeState.Wait;
                }
                break;

            case FadeState.Wait:
               // if (m_Async.isDone)
                {
                    //シーンの読み込みが終わってたらフェードアウト
                    m_State = FadeState.Out;
                }
                break;

            case FadeState.Out:
                m_fAlpha -= Time.deltaTime / (m_fFeedTime / 2);
                if (m_fAlpha < 0.0f)
                {
                    m_State = FadeState.None;
                }
                break;
        }

        m_this.color = new Color(1.0f, 1.0f, 1.0f, m_fAlpha);

        if (Input.GetKey(KeyCode.Space))
            FadeTo("game" , 2);
	}

    /* フェード
     *  string str : フェード先シーンの名前
     *  float fTime : フェードにかける時間
     * */
    public static void FadeTo(string str , float fTime)
    {
        /* TODO:非同期したい
        Debug.Log(str);
        //非同期読み込み
        m_Async = Application.LoadLevelAsync(1);
        m_Async.allowSceneActivation = false;    //読み込み終わってもロードしない
         * */

        m_fFeedTime = fTime;
        m_State = FadeState.In;
        m_fAlpha = 0.0f;
        m_strFadeTo = str;
        
    }
}
