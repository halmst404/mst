using UnityEngine;
using System.Collections;

public class actorManager : MonoBehaviour {

    public Material m_WorldA_Material;    //Aのホログラムの色
    public Material m_WorldB_Material;
    public Material m_WorldC_Material;
    public Material m_WorldD_Material;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //
    public Material GetlayerMaterial(string Layer)
    {
        if( Layer == "worldA" )
            return m_WorldA_Material;
        if( Layer == "worldB" )
            return m_WorldB_Material;
        if( Layer == "worldC" )
            return m_WorldC_Material;
        if( Layer == "worldD" )
            return m_WorldD_Material;

        return null;
    }
}
