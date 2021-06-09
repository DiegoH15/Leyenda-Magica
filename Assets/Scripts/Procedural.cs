using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject Cesped;
    public GameObject Camino;
    public GameObject Entrada;
    public GameObject Arbol;
    public Vector3 vector3;
     
    // Start is called before the first frame update
    void Start()
    {
       /* Vector3[] positionArray = new Vector3[40];
        positionArray[0] = new Vector3(1.58f, -1.16f, 0.79f);
        positionArray[1] = new Vector3(-1.51f, -1.46f, 3.46f);
        positionArray[2] = new Vector3(-2.77f, -1.46f, 0.91f);
        positionArray[3] = new Vector3(-4.51f, -1.46f, 3.5f);
        positionArray[4] = new Vector3(-5.28f, -1.46f, 0.51f);
        positionArray[5] = new Vector3(-6.72f, -1.46f, 4.18f);
        positionArray[6] = new Vector3(-7.87f, -1.46f, 1.57f);
        positionArray[7] = new Vector3(-2.51f, -1.46f, -1.79f);
        positionArray[8] = new Vector3(-5.22f, -1.46f, -2.96f);
        positionArray[9] = new Vector3(-7.71f, -1.46f, -4.52f);
        positionArray[10] = new Vector3(-5.24f, -1.46f, -5.51f);
        positionArray[11] = new Vector3(-1.05f, -1.46f, -4.64f);
        positionArray[12] = new Vector3(0.29f, -1.46f, -7.33f);
        positionArray[13] = new Vector3(1.21f, -1.46f, -9.72f);
        positionArray[14] = new Vector3(1.22f, -1.46f, -12.23f);
        positionArray[15] = new Vector3(1.12f, -1.46f, -14.31f);
        positionArray[16] = new Vector3(0.93f, -1.46f, -16.54f);
        positionArray[17] = new Vector3(-1.83f, -1.46f, -17.81f);
        positionArray[18] = new Vector3(-2.57f, -1.46f, -19.75f);
        positionArray[19] = new Vector3(-3.39f, -1.46f, -22.15f);
        positionArray[20] = new Vector3(-1.83f, -1.46f, -17.81f);
        positionArray[21] = new Vector3(15.58f, -1.46f, -24.54f);
        positionArray[22] = new Vector3(15.74f, -1.46f, -21.9f);
        positionArray[23] = new Vector3(13.98f, -1.46f, -19.62f);
        positionArray[24] = new Vector3(13.58f, -1.46f, -17.1f);
        positionArray[25] = new Vector3(11.48f, -1.46f, -16.26f);
        positionArray[26] = new Vector3(10.06f, -1.46f, -13.8f);
        positionArray[27] = new Vector3(11.5f, -1.46f, -11.46f);
        positionArray[28] = new Vector3(10.56f, -1.46f, -9.18f);
        positionArray[29] = new Vector3(10.51f, -1.46f, -6.42f);
        positionArray[30] = new Vector3(13.33f, -1.46f, -5.41f);
        positionArray[31] = new Vector3(14.16f, -1.46f, -3.05f);
        positionArray[32] = new Vector3(12.52f, -1.46f, -0.64f);
        positionArray[33] = new Vector3(11.69f, -1.46f, 1.6f);
        positionArray[34] = new Vector3(9.12f, -1.46f, 3.88f);
        positionArray[35] = new Vector3(6.07f, -1.46f, 4.45f);
        positionArray[36] = new Vector3(3.17f, -1.46f, 4.02f);
        positionArray[37] = new Vector3(0.57f, -1.46f, 3.67f);
        positionArray[38] = new Vector3(9.8f, -1.22f, -3.35f);
        positionArray[39] = new Vector3(1.58f, -1.16f, -3.54f);
        positionArray[40] = new Vector3(17.81f, -1.46f, -26.11f);
        positionArray[41] = new Vector3(18.68f, -1.46f, -23.47f);
        positionArray[42] = new Vector3(18.06f, -1.46f, -20.22f);
        positionArray[43] = new Vector3(16.41f, -1.46f, -17.19f);
        positionArray[44] = new Vector3(14.63f, -1.46f, -13.26f);
        positionArray[45] = new Vector3(18f, -1.46f, -14.27f);
        positionArray[46] = new Vector3(15.79f, -1.46f, -10.24f);
        positionArray[47] = new Vector3(13.53f, -1.46f, -8.6f);
        positionArray[48] = new Vector3(16.94f, -1.46f, -7.18f);
        positionArray[49] = new Vector3(18.84f, -1.46f, -10.55f);
        positionArray[50] = new Vector3(19.43f, -1.46f, -7.68f);
        positionArray[51] = new Vector3(17.23f, -1.46f, -4.18f);
        positionArray[52] = new Vector3(19.32f, -1.46f, -2.94f);
        positionArray[53] = new Vector3(15.97f, -1.46f, -1.21f);
        positionArray[54] = new Vector3(17.89f, -1.46f, 0.78f);
        positionArray[55] = new Vector3(14.84f, -1.46f, 1.77f);
        positionArray[56] = new Vector3(17.28f, -1.46f, 3.32f);
        positionArray[57] = new Vector3(13.26f, -1.46f, 3.98f);
        positionArray[58] = new Vector3(-3.02f, -1.46f, -8.73f);
        positionArray[59] = new Vector3(-5.57f, -1.46f, -8.14f);
        positionArray[60] = new Vector3(-3.65f, -1.46f, -12.1f);
        positionArray[61] = new Vector3(-7.9f, -1.46f, -7.96f);
        positionArray[62] = new Vector3(-7.34f, -1.46f, -11.07f);
        positionArray[63] = new Vector3(-1.7f, -1.46f, -13.95f);
        positionArray[65] = new Vector3(-5.14f, -1.46f, -14.88f);
        positionArray[66] = new Vector3(-5.51f, -1.46f, -17.62f);
        positionArray[67] = new Vector3(-6.5f, -1.46f, -20.48f);
        positionArray[68] = new Vector3(-7.93f, -1.46f, -23.71f);
        positionArray[69] = new Vector3(-8.31f, -1.46f, -14.27f);
        positionArray[70] = new Vector3(-8.55f, -1.46f, -17.62f);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
