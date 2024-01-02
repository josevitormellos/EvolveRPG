
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_STATUS_RADAR : MonoBehaviour
{
    [SerializeField] private Material radarMaterial;
    private GraphRadarStatus stats;

    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake(){
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
    }
    public void SetStats(GraphRadarStatus stats){
        this.stats = stats;
        stats.onStatsChanged += Stats_OnStatsChanged;
        UpadateStatsVisual();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e){
        UpadateStatsVisual();
    }


    private void UpadateStatsVisual(){
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[8];
        Vector2[] uv = new Vector2[8];
        int[] triangles = new int[3 * 7];

        float angleIncrement = 360f / 7;
        float radarChartSize = 141.4f;

        Vector3 rosaVertex = Quaternion.Euler(0, 0, angleIncrement * 0) * Vector3.up *  radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Rosa);
        int rosaVertexIndex = 1;

        Vector3 laranjaVertex = Quaternion.Euler(0, 0, angleIncrement *1) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Laranja);
        int laranjaVertexIndex = 2;
        Vector3 roxoVertex = Quaternion.Euler(0, 0, angleIncrement *2) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Roxo);
        int roxoVertexIndex = 3;
        Vector3 vermelhoVertex = Quaternion.Euler(0, 0, angleIncrement *3) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Vermelho);
        int vermelhoVertexIndex = 4;
        Vector3 azulVertex = Quaternion.Euler(0, 0, angleIncrement *4) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Azul);
        int azulVertexIndex = 5;
        Vector3 verdeVertex = Quaternion.Euler(0, 0, angleIncrement *5) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Verde);
        int verdeVertexIndex = 6;
        Vector3 pretoVertex = Quaternion.Euler(0, 0, angleIncrement *6) * Vector3.up  * radarChartSize * stats.GetStatAmountNormalized(GraphRadarStatus.Type.Preto);
        int pretoVertexIndex = 7;
        vertices[0] = Vector3.zero;
        vertices[rosaVertexIndex] = rosaVertex;
        vertices[laranjaVertexIndex] = laranjaVertex;
        vertices[roxoVertexIndex] = roxoVertex;
        vertices[vermelhoVertexIndex] = vermelhoVertex;
        vertices[azulVertexIndex] = azulVertex;
        vertices[verdeVertexIndex] = verdeVertex;
        vertices[pretoVertexIndex] = pretoVertex;


        triangles[0] = 0;
        triangles[1] = rosaVertexIndex;
        triangles[2] = laranjaVertexIndex;

        triangles[3] = 0;
        triangles[4] = laranjaVertexIndex;
        triangles[5] = roxoVertexIndex;

        triangles[6] = 0;
        triangles[7] = roxoVertexIndex;
        triangles[8] = vermelhoVertexIndex;

        triangles[9] = 0;
        triangles[10] = vermelhoVertexIndex;
        triangles[11] = azulVertexIndex;

        triangles[12] = 0;
        triangles[13] = azulVertexIndex;
        triangles[14] = verdeVertexIndex;

        triangles[15] = 0;
        triangles[16] = verdeVertexIndex;
        triangles[17] = pretoVertexIndex;

        triangles[18] = 0;
        triangles[19] = pretoVertexIndex;
        triangles[20] = rosaVertexIndex;



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, null);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 
}
