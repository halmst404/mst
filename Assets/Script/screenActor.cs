using UnityEngine;
using System.Collections;

public class screenActor : MonoBehaviour {

    public actorManager m_manager;

	// Use this for initialization
	void Start () {

        Material temp = m_manager.GetlayerMaterial(
            LayerMask.LayerToName(gameObject.layer));
        

        //ホログラムを作成
        CreateHologram( temp );

	}
	
	// Update is called once per frame
	void Update () {

     
	}

    //holoレイヤーにオブジェクトのコピーを作成
    private void CreateHologram( Material mat)
    {
        GameObject New = new GameObject();
        New.name = gameObject.name + "(Hologram)";
        New.gameObject.layer = LayerMask.NameToLayer("holo");

        //メッシュをコピー
        New.AddComponent<MeshRenderer>();
        New.AddComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;

        //マテリアルの設定
        New.renderer.material = mat;

        //親に
        New.transform.parent = gameObject.transform;
        New.transform.localPosition = new Vector3(0, 0, 0);
    }
}
