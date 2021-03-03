using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



// struct State{
//     public int posX, posZ;
//     public float mapx;
// }

public class Floor : MonoBehaviour
{
    public GameObject wallPre;
    public GameObject Box;
    public GameObject Point;
    public GameObject EndPoint;//to store the letter of the word;
    public GameObject man;
    public GameObject addGate;
    public GameObject multGate;
    public GameObject alphGate;
    public GameObject Slot;
    public TextMesh txt;
    private GameObject _instance;
    

    int posX, posZ;

    //State[] list = new State[5];
    //int list_cnt = 0;
    int cube_cnt;
    //static int slot_cnt = 3;
    float[] level1_key = {15, 15, 5};
    float[] level2_key = {6, 15, 18};
    float[] level3_key = {1 , 12, 12};
    int cnt_addGate;
    int cnt_multGate;
    int cnt_aplhGate;
    int total_cntGate; // should be updated each time a gate is used or in each Update()

    // void pre_clear(){
    //     list_cnt = 0;
    // }
    // void pre_save(int POSX, int POSZ){
    //     list[list_cnt].posX = POSX;
    //     list[list_cnt].posZ = POSZ;
    //     list[list_cnt].mapx = map[POSX, POSZ];
    //     list_cnt++;
    // }
    
    bool victory(){
        bool win = false;
        if(level == 1){
            // for ( int i = 0; i < 12; i++){
            //     for (int j = 0; j < 12; j++){
                    if(cnt_multGate >0 && cnt_addGate > 0 && cnt_aplhGate >0){
                        win = true;
                    }
            //     }
            // }
        }else if(level == 2){
            for ( int i = 0; i < 12; i++){
                for (int j = 0; j < 12; j++){
                    if(map[i,j] == 15 && map[i,j+1] == 14 
                    && map[i,j+2] == 5){
                        win = true;
                    }else if(map[i,j] == 15 && map[i+1,j] == 14
                    && map[i+2,j] == 5){
                        win = true;
                    }
                }
            }
        }else if(level == 3){
            for ( int i = 0; i < 12; i++){
                for (int j = 0; j < 12; j++){
                    if(map[i,j] == level2_key[0] && map[i,j+1] == level2_key[1] 
                    && map[i,j+2] == level2_key[2]){
                        win = true;
                    }else if(map[i,j] == level2_key[0] && map[i+1,j] == level2_key[1]
                    && map[i+2,j] == level2_key[2]){
                        win = true;
                    }
                }
            }
        }else if(level == 4){
            for ( int i = 0; i < 12; i++){
                for (int j = 0; j < 12; j++){
                    if(map[i,j] == level3_key[0] && map[i,j+1] == level3_key[1] 
                    && map[i,j+2] == level3_key[2]){
                        win = true;
                    }else if(map[i,j] == level3_key[0] && map[i+1,j] == level3_key[1]
                    && map[i+2,j] == level3_key[2]){
                        win = true;
                    }
                }
            }
        }
        return win;
        
    }

    //0 = empty
    //0.01f ~ 0.26f = 1 ~ 26 in numbers
    //1~26 = A~Z
    //27 = walls
    //29 = player(man)
    //29 = adder
    //30 = multiplier
    //31 = ASCII gate
    static float[,] map = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,28,0,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,30,0,0,0,0,31,0,0,27},
        {27,0,0.01f,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };

    static float[,] map_0 = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,28,0,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,30,0,0,0,0,31,0,0,27},
        {27,0,0.01f,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };

  static float[,] map_1 = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0.01f,0,27},
        {27,0,31,0.01f,0,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,30,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0.01f,0,0,0,0,0,0,27},
        {27,0,0,0,29,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,28,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };
static float[,] map_2 = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,31,0,0,0,0,0,30,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,0,0,0,0,0,27},
        {27,0,0.01f,28,0.01f,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };

    static float[,] map_3 = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,28,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,31,0.01f,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,30,0,0,0,0,27},
        {27,0,0.01f,0,0.01f,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };

    GameObject x;

    // Start is called before the first frame update
    void Start()
    {
         x = GameObject.Find("victory_UI");
         x.SetActive(false);
        init();
        draw();
    }

    // Update is called once per frame
    void Update()
    {
        draw();
        if(move()){
            print("xxxxxxxxxxxxxxxxxxxxx\n");
            x.SetActive(true);
             
            set_level(level);
        }
       
    }

    static int level = 0;
    void init()
      {
          

          cube_cnt = 0;
          cnt_aplhGate = 0;
          cnt_multGate = 0;
          cnt_addGate = 0;
          total_cntGate = 0;
  
         GameObject x = GameObject.Find("level");
        string tmp = "";
        if(level == 0){
            tmp = "Use WASD to place the tiles next to the tunnels and push another through.";
        }else if(level == 1){
            tmp = "Riddle: Five, Four, Three, Two...";
        }else if(level == 2){
            tmp = "Riddle: 4-u";
        }else if(level == 3){
            tmp = "Not one, not some, but...";
        }
          x.GetComponent<Text>().text = tmp; 
  
          if (level == 0)
          {
              map = new float[12,12]{
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,28,0,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,30,0,0,0,0,31,0,0,27},
        {27,0,0.01f,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };
              for (int i = 0; i < 12; i++)
              {
                  for (int j = 0; j < 12; j++)
                  {
                      if (map[i, j] > 0 && map[i, j] < 27 )
                      {
                          cube_cnt++; //number of boxes ++
                      }
                      if (map[i, j] == 28)
                      {
                          posX = i;
                          posZ = j;
                        //  pre_save(i, j);
                      }
                  }
              }
          }
          else if (level == 1)
          {
              map = new float[12, 12] {
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0.01f,0,27},
        {27,0,31,0.01f,0,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,30,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0.01f,0,0,0,0,0,0,27},
        {27,0,0,0,29,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,28,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
    };
              for (int i = 0; i < 12; i++)
              {
                  for (int j = 0; j < 12; j++)
                  {
                      if (map[i, j] > 0 && map[i, j] < 27 )
                      {
                          cube_cnt++; //number of boxes ++
                      }
                      if (map[i, j] == 28)
                      {
                          posX = i;
                          posZ = j;
                        //  pre_save(i, j);
                      }
                  }
              }
          }
          else if(level == 2){
              map = new float[12, 12] {
        {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,31,0,0,0,0,0,30,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,0,0,0,0,0,27},
        {27,0,0.01f,28,0.01f,0.01f,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
        };
        for (int i = 0; i < 12; i++)
              {
                  for (int j = 0; j < 12; j++)
                  {
                      if (map[i, j] > 0 && map[i, j] < 27 )
                      {
                          cube_cnt++; //number of boxes ++
                      }
                      if (map[i, j] == 28)
                      {
                          posX = i;
                          posZ = j;
                        //  pre_save(i, j);
                      }
                  }
              }
          }else if(level == 3){ 
              map = new float[12, 12] {
         {27,27,27,27,27,27,27,27,27,27,27,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,28,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,31,0.01f,0,0,29,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,30,0,0,0,0,27},
        {27,0,0.01f,0,0.01f,0,0,0,0,0,0,27},
        {27,0,0,0.01f,0,0,0,0,0,0,0,27},
        {27,0,0,0,0,0,0,0,0,0,0,27},
        {27,27,27,27,27,27,27,27,27,27,27,27},
        };
        for (int i = 0; i < 12; i++)
              {
                  for (int j = 0; j < 12; j++)
                  {
                      if (map[i, j] > 0 && map[i, j] < 27 )
                      {
                          cube_cnt++; //number of boxes ++
                      }
                      if (map[i, j] == 28)
                      {
                          posX = i;
                          posZ = j;
                        //  pre_save(i, j);
                      }
                  }
              }

          }
          level++;
          //Game_UI_Manage.Level++;
      }
    void draw(){
        destroyMap();
        for(int i = 0; i < 12; i++){
            for(int j = 0; j < 12; j ++){
                
                if(map[i,j] == 27){

                }else if(map[i,j] == 0){

                }else if(map[i,j] == 28){
                    _instance = Instantiate(man, new Vector3(j-1, 0.5f, -i+10), Quaternion.Euler(-90.0f,0.0f, 0.0f));
                    _instance.tag = "bricks";
                }else if(map[i,j] > 0 && map[i,j] < 27){
                    if(map[i,j] < 1){
                        float value = map[i,j] * 100;
                        txt.text = Mathf.Round(value).ToString();
                    }else{
                        char ch = (char)(map[i,j] + 64);
                        txt.text = ch.ToString();
                    }
                    _instance = Instantiate(Box, new Vector3(j-1, 0, -i+10), Quaternion.Euler(-90.0f,0.0f, 0.0f));
                    _instance.tag = "bricks";
                }else if(map[i,j] == 29){
                    _instance = Instantiate(addGate, new Vector3(j-1, 0, -i+10), Quaternion.Euler(0.0f,90.0f, 90.0f));
                    _instance.tag = "bricks";
                    //Debug.Log(addGate.tag);
                // }else if(map[i,j] == 7){
                //     Instantiate(Slot, getPoint(i, 0.5f, j), Quaternion.identity);
                }else if(map[i,j] == 30){
                    _instance = Instantiate(multGate, new Vector3(j-1, 0, -i+10), Quaternion.Euler(0.0f,0.0f, 90.0f));
                    _instance.tag = "bricks";
                }else if(map[i,j] == 31){
                    _instance = Instantiate(alphGate, new Vector3(j-1, 0, -i+10), Quaternion.Euler(0.0f,0.0f, 90.0f));
                    _instance.tag = "bricks";
                }
            }
        }
    }

   void destroyMap(){
        GameObject[] gos = GameObject.FindGameObjectsWithTag("bricks");
        foreach (var go in gos){
            Destroy(go);
        }
    }

    bool move(){
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
                moveUp();
        } else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){

            moveDown();
        }else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){

            moveLeft();
        }else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){

            moveRight();
        }
        total_cntGate = cnt_addGate + cnt_aplhGate + cnt_multGate;
        Debug.Log(level);
        // }else if(Input.GetKeyDown(KeyCode.Z)){
        //     if(list_cnt > 0){
        //         cnt--;
        //         for(int i = 0; i < list_cnt; i++){
        //             int tx = list[i].posX;
        //             int ty = list[i].posZ;
        //             float tmax = list[i].mapx;

        //             map[tx, ty] = tmax;
        //         }
        //         posX = list[0].posX;
        //         posZ = list[0].posZ;
        //         pre_clear();

        //     }
        // }
        //destroyMap();
        return victory();
    }

    void moveUp(){
        if(posX-1 >= 0){
            if(map[posX - 1, posZ] == 0) {
                if(map[posX, posZ] == 28){
                    // pre_clear();
                    // pre_save(posX, posZ);
                    // pre_save(posX-1, posZ);

                    map[posX, posZ] = 0;
                    map[posX-1, posZ] = 28;
                    posX--;
                }
            }else if(map[posX-1, posZ] > 0 && map[posX-1, posZ] < 27){ // if up the man it is the box
                if(posX-2 >= 0){
                    if(map[posX-2, posZ] == 0){             //up the box it is empty
                        if(map[posX, posZ] == 28){
                            // pre_clear();
                            // pre_save(posX, posZ);
                            // pre_save(posX-1, posZ);
                            // pre_save (posX-2, posZ);

                            map[posX-2, posZ] = map[posX-1, posZ];
                            map[posX-1, posZ] = 28;
                            map[posX, posZ] = 0;
                            posX--;
                        }
                    }else if(map[posX-2, posZ] == 30){  //if up the box it is a mutiplier
                        if(posX-3 >= 0){     
                            if(map[posX-3, posZ] == 0){     //if up the multipiler it is empty
                                if(map[posX-1, posZ] <1){       //if the box is a number
                                    float multee = map[posX-1, posZ] *100;
                                    float multer1 = 1, multer2 = 1;
                                    if(map[posX-2, posZ-1] >0 && map[posX-2, posZ-1] <1){
                                        multer1 = 100 * map[posX-2, posZ-1];
                                    }if(map[posX-2, posZ+1] >0 && map[posX-2, posZ+1] <1){
                                        multer2 = 100 * map[posX-2, posZ+1];}
                                    
                                    float result = (multee * multer1 * multer2);
                                    while(result > 26){
                                        result-= 26;
                                    }
                                    result /= 100;

                                    // pre_clear();
                                    // pre_save(posX, posZ);
                                    // pre_save(posX-1, posZ);
                                    // pre_save(posX-3, posZ);

                                    map[posX-3, posZ]=result;
                                    map[posX-1,posZ] = 28;
                                    map[posX, posZ] = 0;
                                    posX--;
                                    cnt_multGate++;
                                }
                            }
                        }
                    }else if(map[posX-2, posZ] == 31){  //if up the box it is a ASCII
                        if(posX-3 >= 0){
                            if(map[posX-3, posZ] == 0){ 
                                float num;                  //up the ASCII it is empty
                               if(map[posX-1, posZ] < 1){
                                    num = Mathf.Round(map[posX-1, posZ] * 100);
                               }else{
                                   num = Mathf.Round(map[posX-1, posZ])* 0.01f;
                               }
                                // pre_clear();
                                // pre_save(posX, posZ);
                                // pre_save(posX-1, posZ);
                                // pre_save(posX-3, posZ);

                                map[posX-3, posZ]=num;
                                map[posX-1,posZ] = 28;
                                map[posX, posZ] = 0;
                                posX--;
                                cnt_aplhGate++;
                            }
                        }
                    }
                }
            }
        }
    }

    void moveDown(){
        if(posX+1 < 11){
            if(map[posX + 1, posZ] == 0) {
                if(map[posX, posZ] == 28){
                    // pre_clear();
                    // pre_save(posX, posZ);
                    // pre_save(posX+1, posZ);
                    map[posX, posZ] = 0;
                    map[posX+1, posZ] = 28;
                    posX++;
                }
            }else if(map[posX+1, posZ] > 0 && map[posX+1, posZ] < 27){  //up the man it is box
                if(posX+2 <11){
                    if(map[posX+2, posZ] == 0){         //up the box it is empty
                        if(map[posX, posZ] == 28){
                            // pre_clear();
                            // pre_save(posX, posZ);
                            // pre_save(posX+1, posZ);
                            // pre_save (posX+2, posZ);

                            map[posX+2, posZ] = map[posX+1, posZ];
                            map[posX+1, posZ] = 28;
                            map[posX, posZ] = 0;
                            posX++;
                        }
                    }else if(map[posX+2, posZ] == 30){  //if up the box it is a mutiplier
                        if(posX+3 < 11){     
                            if(map[posX+3, posZ] == 0){     //if up the multipiler it is empty
                                if(map[posX+1, posZ] <1){       //if the box is a number
                                    float multee = map[posX+1, posZ] * 100;
                                    float multer1 = 1, multer2 = 1;
                                    if(map[posX+2, posZ-1] >0 && map[posX+2, posZ-1] <1){
                                        multer1 = 100 * map[posX+2, posZ-1];
                                    }if(map[posX+2, posZ+1] >0 && map[posX+2, posZ+1] <1){
                                        multer2 = 100 * map[posX+2, posZ+1];}
                                    
                                    float result = (multee * multer1 * multer2);
                                    while(result > 26){
                                        result-= 26;
                                    }
                                    result /= 100;

                                    // pre_clear();
                                    // pre_save(posX, posZ);
                                    // pre_save(posX+1, posZ);
                                    // pre_save(posX+3, posZ);

                                    map[posX+3, posZ]=result;
                                    map[posX+1,posZ] = 28;
                                    map[posX, posZ] = 0;

                                    posX++;
                                    cnt_multGate++;
                                }
                            }
                        }
                    }else if(map[posX+2, posZ] == 31){  //if up the box it is a ASCII
                        if(posX+3 >= 0){
                            if(map[posX+3, posZ] == 0){     //up the ASCII it is empty
                                float num;
                                if(map[posX+1, posZ] < 1){
                                    num = Mathf.Round(map[posX+1, posZ] * 100);
                                }else{
                                   num = Mathf.Round(map[posX+1, posZ])* 0.01f;
                                }
                                // pre_clear();
                                // pre_save(posX, posZ);
                                // pre_save(posX+1, posZ);
                                // pre_save(posX+3, posZ);

                                map[posX+3, posZ]=num;
                                map[posX+1,posZ] = 28;
                                map[posX, posZ] = 0;
                                posX++;
                                cnt_aplhGate++;
                            }
                        }
                    }
                }
            }
        }
    }

    void moveLeft(){
        if(posZ - 1 >=0){
            if(map[posX,posZ-1] == 0){ // if left the man it is empty
                if(map[posX, posZ] == 28){
                    // pre_clear();
                    // pre_save(posX, posZ);
                    // pre_save(posX, posZ -1);

                    map[posX, posZ -1] = 28;
                    map[posX, posZ] = 0;
                    posZ--;
                }
            }else if(map[posX, posZ-1] > 0 && map[posX, posZ-1] < 27){
                if(posZ - 2 >= 0){
                    if(map[posX, posZ - 2] == 0){       //if left the box it is empty
                        if(map[posX, posZ] == 28){
                            // pre_clear();
                            // pre_save(posX, posZ);
                            // pre_save(posX, posZ-1);
                            // pre_save(posX, posZ-2);

                            map[posX, posZ-2] = map[posX, posZ -1];
                            map[posX, posZ-1] = 28;
                            map[posX, posZ] =0;
                            posZ--;
                        }
                    }else if(map[posX, posZ-2] == 29){      // if left the box it is an adder
                        if( posZ - 3 >= 0){
                            if (map[posX, posZ - 3] == 0){  //if left the adder it is empty
                                if(map[posX, posZ-1] < 1){
                                    float addee = map[posX, posZ -1];
                                    float adder1 = 0, adder2 = 0;
                                    if(map[posX+1, posZ-2] >0 && map[posX+1, posZ-2] < 1){
                                        adder1 = map[posX+1, posZ-2];
                                    }if(map[posX-1, posZ-2] >0 && map[posX-1, posZ-2] < 1){
                                        adder2 = map[posX-1, posZ-2];
                                    }
                                    float result = addee+adder1+adder2;
                                    while(result > .26f){
                                        result-= .26f;
                                    }
                                    // pre_clear();
                                    // pre_save(posX, posZ);
                                    // pre_save(posX, posZ -1);
                                    // pre_save(posX, posZ - 3);

                                    map[posX, posZ -3] = result;
                                    map[posX, posZ -1] = 28;
                                    map[posX, posZ] = 0;
                                    posZ--;
                                    cnt_addGate++;
                                }
                            }
                        }
                    }
                    // }else if(map[posX, posZ-2] == 31){      // if left the box it is an ASCII
                    //     if(posZ - 3 >= 0){
                    //         if (map[posX, posZ - 3] == 0){  //if left the adder it is empty
                    //             float num = map[posX, posZ-1] * 100;
                                
                    //             pre_clear();
                    //             pre_save(posX, posZ);
                    //             pre_save(posX, posZ-1);
                    //             pre_save(posX, posZ - 3);

                    //             map[posX, posZ - 3] = num;
                    //             map[posX, posZ - 1] = 28;
                    //             map[posX, posZ] = 0;
                    //             posZ--;
                    //         }
                    //     }
                    // }
                }
            }
        }
    }

    void moveRight(){
        if(posZ + 1 >=0){
            if(map[posX,posZ+1] == 0){ // if right the man it is empty
                if(map[posX, posZ] == 28){
                    // pre_clear();
                    // pre_save(posX, posZ);
                    // pre_save(posX, posZ +1);

                    map[posX, posZ +1] = 28;
                    map[posX, posZ] = 0;
                    posZ++;
                }
            }else if(map[posX, posZ+1] > 0 && map[posX, posZ+1] < 27){
                if(posZ + 2 >= 0){
                    if(map[posX, posZ + 2] == 0){       //if right the box it is empty
                        if(map[posX, posZ] == 28){
                            // pre_clear();
                            // pre_save(posX, posZ);
                            // pre_save(posX, posZ+1);
                            // pre_save(posX, posZ+2);

                            map[posX, posZ+2] = map[posX, posZ +1];
                            map[posX, posZ+1] = 28;
                            map[posX, posZ] =0;
                            posZ++;
                        }
                    }else if(map[posX, posZ+2] == 29){      // if left the box it is an adder
                        if(posZ + 3>= 0){
                            if (map[posX, posZ + 3] == 0){  //if left the adder it is empty
                                if(map[posX, posZ+1] < 1){
                                    float addee = map[posX, posZ +1];
                                    float adder1 = 0, adder2 = 0;
                                    if(map[posX+1, posZ+2] >0 && map[posX+1, posZ+2] < 1){
                                        adder1 = map[posX+1, posZ+2];
                                    }if(map[posX-1, posZ+2] >0 && map[posX-1, posZ+2] < 1){
                                        adder2 = map[posX-1, posZ+2];
                                    }
                                    float result = (addee+adder1+adder2);
                                    while(result > .26f){
                                        result-= .26f;
                                    }
                                    // pre_clear();
                                    // pre_save(posX, posZ);
                                    // pre_save(posX, posZ +1);
                                    // pre_save(posX, posZ + 3);

                                    map[posX, posZ +3] = result;
                                    map[posX, posZ +1] = 28;
                                    map[posX, posZ] = 0;
                                    posZ++;
                                    cnt_addGate++;
                                }
                            }
                        }
                    }
                    // }else if(map[posX, posZ+2] == 31){      // if left the box it is an ASCII
                    //     if(posZ +3 >= 0){
                    //         if (map[posX, posZ + 3] == 0){  //if left the adder it is empty
                    //             float num = map[posX, posZ+1] * 100;
                                
                    //             pre_clear();
                    //             pre_save(posX, posZ);
                    //             pre_save(posX, posZ+1);
                    //             pre_save(posX, posZ + 3);

                    //             map[posX, posZ + 3] = num;
                    //             map[posX, posZ + 1] = 28;
                    //             map[posX, posZ] = 0;
                    //             posZ++;
                    //         }
                    //     }
                    // }
                }
            }
        }
    }

     public void onResetClick()
    {
        level--;
        Debug.Log(level);
        set_level(level);
        SceneManager.LoadScene("Game");
    }

     public void onHomeClick(){
        level = 0;
        set_level(level);
        SceneManager.LoadScene("Menu");
    }

    public void onContiClick(){
        SceneManager.LoadScene("Game");
    }

    public void onVicHomeClick(){
        level = 0;
        set_level(level);
        SceneManager.LoadScene("Menu");


    }

    public void set_level(int Level)
    {
        level = Level;
        if (Level == 0)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    map[i, j] = map_0[i, j];

        }
        else if (Level == 1)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    map[i, j] = map_2[i, j];
        }
        else if(level == 2)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    map[i, j] = map_2[i, j];
        }
        else if(level == 3)
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    map[i, j] = map_3[i, j];
        }
    }
}