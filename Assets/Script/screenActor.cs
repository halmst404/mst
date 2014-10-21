using UnityEngine;
using System.Collections;

public class screenActor : MonoBehaviour {

    private Color GetlayerColor()
    {
        string layer = LayerMask.LayerToName(gameObject.layer);

        if (layer == "worldA")
        {
            return Color.red;
        }
        if (layer == "worldB")
        {
            return Color.blue;
        }
        if (layer == "worldC")
        {
            return Color.yellow;
        }
        if (layer == "worldD")
        {
            return Color.green;
        }

        return Color.grey;
    }

	// Use this for initialization
	void Start () {

        //ホログラムを作成
        CreateHologram(GetlayerColor());

	}
	
	// Update is called once per frame
	void Update () {
	}

    //holoレイヤーにオブジェクトのコピーを作成
    private void CreateHologram( Color col)
    {
        GameObject New = new GameObject();
        New.name = gameObject.name + "(Hologram)";
        New.gameObject.layer = LayerMask.NameToLayer("holo");

        //メッシュをコピー
        New.AddComponent<MeshRenderer>();
        New.AddComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;

        //マテリアルの設定
        New.renderer.material = Resources.Load<Material>( "holo" );
        New.renderer.material.color = col;

        //親に
        New.transform.parent = gameObject.transform;
        New.transform.localPosition = new Vector3(0, 0, 0);
    }
}
