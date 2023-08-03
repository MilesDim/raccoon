using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; 
using UnityEngine.SceneManagement;

public class raccoon : MonoBehaviour
   {[SerializeField] float moveSpeed = 504f;
   [SerializeField] Rigidbody rb;
   Collider cl;
   Animator anim;
   
   // [SerializeField] private GameObject _startingSceneTransition; 
   [SerializeField] private GameObject _endingSceneTransition;

   enum Directions
   {
      Left ,
      Right,
      Up,
      Down
   }

   Dictionary<Directions, bool> canMove = new Dictionary<Directions, bool>()
   {
      {Directions.Left, true},
      {Directions.Right, true},
      {Directions.Up, true},
      {Directions.Down, true},
   };
   Dictionary<Directions, bool> winMove = new Dictionary<Directions, bool>()
   {
      {Directions.Left, false},
      {Directions.Right, false},
      {Directions.Up, false},
      {Directions.Down, false},
   };
   Dictionary<Directions, Vector3> vects = new Dictionary<Directions, Vector3>()
   {
      {Directions.Left, new Vector3()},
      {Directions.Right, new Vector3()},
      {Directions.Up, new Vector3()},
      {Directions.Down, new Vector3()},
   }; 

   bool isWin = false;

   static int maxColliders = 1;
   static int maxColliders2 = 1;
   Collider[] pickedPlatfroms = new Collider[maxColliders];
   Collider[] pickedWalls = new Collider[maxColliders2];
   // Collider[] pickedWallsFiltered;
   // int pickWallCollidersFiltered;
   int pickPlatformColliders;
   int pickWallColliders;
   int prevAngle = 0;
   Quaternion startRotation;
   Quaternion originalRot;
   AudioSource stepsound;
   
   [SerializeField] private LayerMask wallsLayer;
   int sceneIndex;

 
   void Start(){
      anim = gameObject.GetComponent<Animator>();
      stepsound = gameObject.GetComponent<AudioSource>();
      originalRot = transform.rotation; 
      sceneIndex = SceneManager.GetActiveScene().buildIndex;

      // recalcMoves();
     /// _startingSceneTransition.SetActive(true);  
   }

   void FixedUpdate(){
      recalcMoves();
   }

 
   public void setWin (bool win) {
      isWin = win;
   }

   private void winAnim(){
      if(isWin){
         _endingSceneTransition.SetActive(true); 
         anim.SetTrigger("call-boune"); 
         nextScene();
      }
   } 

   void nextScene(){
      // SceneManager.LoadScene("Level2");
      SceneManager.LoadScene(sceneIndex + 1);
   }

   private void rotatePlayer(Directions dir, int angle){ 
      Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, angle, 0)); 
       rb.MoveRotation(deltaRotation * originalRot);
     
   }

   public void MoveRight()
   {  
      if(winMove[Directions.Right]){
         winAnim();
      }else if(canMove[Directions.Right]){ 
         stepsound.Play();
         rb.MovePosition(vects[Directions.Right]);
         rotatePlayer(Directions.Right, -90);
      }
   }

   public void MoveLeft()
   {
      if(winMove[Directions.Left]){
         winAnim();
      }else if(canMove[Directions.Left]){  
         stepsound.Play();
         rb.MovePosition(vects[Directions.Left]); 
         rotatePlayer(Directions.Left, 90);  
      }
   }

   public void MoveUp()
   {
      if(winMove[Directions.Up]){
         winAnim();
      }else if(canMove[Directions.Up]){ 
         stepsound.Play();
         rb.MovePosition(vects[Directions.Up]); 
         rotatePlayer(Directions.Up, -180); 
      }
   }

   public void MoveDown()
   {
      if(winMove[Directions.Down]){
         winAnim();
      }else if(canMove[Directions.Down]){ 
stepsound.Play();
         rb.MovePosition(vects[Directions.Down]); 
         rotatePlayer(Directions.Down, 360); 
      }
   }


   string toJson<T>(Dictionary<Directions, T> dict)
   {
      var entries = dict.Select(d =>
         string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
      return "{" + string.Join(",", entries) + "}";
   }

   private bool isCanMove(Dictionary<Directions, Vector3> vectors, Directions dirKey){
      pickPlatformColliders = Physics.OverlapSphereNonAlloc(vectors[dirKey] + Vector3.down * 2, 0.1f, pickedPlatfroms); 
      // pickWallColliders = Physics.OverlapSphereNonAlloc(vectors[dirKey] - getVector(dirKey) * 2 + Vector3.up, 0.5f, pickedWalls);

      if(pickPlatformColliders > 0){
         var bounds = pickedPlatfroms[0].gameObject.transform.GetComponent<Renderer>().bounds; 
         vectors[dirKey] = new Vector3(bounds.center.x, 0, bounds.center.z);
      } 

      
      Collider[] pickedColliders = new Collider[1];
      int colliders = Physics.OverlapSphereNonAlloc(rb.position + Vector3.down * 2, 0.5f, pickedColliders);
      var currentTerrainBounds = pickedColliders[0].gameObject.transform.GetComponent<Renderer>().bounds; 
      Vector3 midPoint = new Vector3(currentTerrainBounds.center.x, 0, currentTerrainBounds.center.z);
      pickWallColliders = Physics.OverlapSphereNonAlloc(midPoint + getVector(dirKey) * currentTerrainBounds.size.x / 2, 0.5f, pickedWalls, wallsLayer);

      // Debug.Log(dirKey+" pickWallColliders = "+pickWallColliders);
     

      // for (int i = 0; i < pickWallColliders; i++) { 
      //    Debug.Log("pickedWalls[i].gameObject.tag = " + pickedWalls[i].gameObject.tag);
      // }
       

      // Debug.Log("pickedWalls = " + pickedWalls);

      // bool haveWall = false;
      // if(pickWallColliders > 0){
      //    for (int i = 0; i < pickWallColliders; i++) { 
      //       if(pickedWalls[i].gameObject.tag == "fence"){
      //          haveWall = true;
      //       }
      //       // Debug.Log(dirKey + " - "+ i + ". pickedWall = " + pickedWalls[i].gameObject.name);
      //    }
      // }

      // pickedWallsFiltered = pickedWalls.Where(c => c.gameObject.tag == "Player").ToArray();
      // pickWallCollidersFiltered = pickWallColliders > 0 
      //    ? pickedWallsFiltered.Length
      //    : 0;
 
      // return pickWallCollidersFiltered == 0 
      // return haveWall ? pickPlatformColliders > 0 : false;
      // return !haveWall ? pickPlatformColliders > 0 : false;
      // return pickWallColliders == 0 
      //    ? pickPlatformColliders > 0
      //    : false; 

      return pickWallColliders == 0 ? pickPlatformColliders > 0 : false;
   }

   void OnDrawGizmos(){ 
      // walls
      float rad = 0.5f;
      // var bounds = transform.GetComponent<Renderer>().bounds;

      Collider[] pickedColliders = new Collider[1];
      int colliders = Physics.OverlapSphereNonAlloc(rb.position + Vector3.down * 2, 0.5f, pickedColliders);
      
      var bounds = pickedColliders[0].gameObject.transform.GetComponent<Renderer>().bounds; 
      Vector3 center = new Vector3(bounds.center.x, 0, bounds.center.z);
    
      Gizmos.DrawWireSphere(center, rad);
      Gizmos.color = Color.red;    
      Gizmos.DrawWireSphere(center - getVector(Directions.Left) * bounds.size.x / 2, rad);
      Gizmos.color = Color.green; 
      Gizmos.DrawWireSphere(center - getVector(Directions.Right) * bounds.size.x / 2, rad);
      Gizmos.color = Color.blue; 
      Gizmos.DrawWireSphere(center - getVector(Directions.Up) * bounds.size.x / 2, rad);
      Gizmos.color = Color.white; 
      Gizmos.DrawWireSphere(center - getVector(Directions.Down) * bounds.size.x / 2, rad);

      
      // Gizmos.DrawWireSphere(center + new Vector3(bounds.size.x / 2, 0, 0), rad);

      // Vector3 center = new Vector3(bounds.center.x, 0, bounds.center.z);
      // Gizmos.color = Color.red;
      // Gizmos.DrawWireSphere(rb.position + getVector(Directions.Left) * 2 + Vector3.up , rad);
      // Gizmos.color = Color.green;
      // Gizmos.DrawWireSphere(rb.position + getVector(Directions.Right) * 2 + Vector3.up , rad);
      // Gizmos.color = Color.blue;
      // Gizmos.DrawWireSphere(rb.position + getVector(Directions.Up) * 1.5f + Vector3.up , rad);
      // Gizmos.color = Color.white;
      // Gizmos.DrawWireSphere(rb.position + getVector(Directions.Down) * 1.5f + Vector3.up , rad);




      // Gizmos.color = Color.red;
      // Gizmos.DrawWireSphere(vects[Directions.Left] - getVector(Directions.Left) * 2 + Vector3.up , rad);
      // Gizmos.color = Color.green;
      // Gizmos.DrawWireSphere(vects[Directions.Right] - getVector(Directions.Right) * 2 + Vector3.up , rad);
      // Gizmos.color = Color.blue;
      // Gizmos.DrawWireSphere(vects[Directions.Up] - getVector(Directions.Up) * 1.5f + Vector3.up , rad);
      // Gizmos.color = Color.white;
      // Gizmos.DrawWireSphere(vects[Directions.Down] - getVector(Directions.Down) * 1.5f + Vector3.up , rad);

      // platforms
      // Gizmos.color = Color.red;
      // Gizmos.DrawWireSphere(vects[Directions.Left] + Vector3.down * 2, 0.1f);
      // Gizmos.color = Color.green;
      // Gizmos.DrawWireSphere(vects[Directions.Right] + Vector3.down * 2, 0.1f);
      // Gizmos.color = Color.blue;
      // Gizmos.DrawWireSphere(vects[Directions.Up] + Vector3.down * 2, 0.1f);
      // Gizmos.color = Color.white;
      // Gizmos.DrawWireSphere(vects[Directions.Down] + Vector3.down * 2, 0.1f);
   }
 

   private bool isFinishMove(Dictionary<Directions, Vector3> vectors, Directions dirKey){
      pickPlatformColliders = Physics.OverlapSphereNonAlloc(vectors[dirKey] + Vector3.down * 2, 0.1f, pickedPlatfroms);

      if(pickPlatformColliders > 0){
         if(pickedPlatfroms[0].gameObject.tag == "finish"){
            return true;
         }
      }
      return false;
   }

   private void recalcMoves(){ 
      Dictionary<Directions, bool> tempDict = new Dictionary<Directions, bool>();
      foreach(KeyValuePair<Directions, bool> dict in canMove)
      {
         vects[dict.Key] = rb.position + getVector(dict.Key) * moveSpeed * Time.fixedDeltaTime;
         tempDict[dict.Key] = isCanMove(vects, dict.Key);
         // Debug.Log(dict.Key + " - isCanMove = " + tempDict[dict.Key]);
         winMove[dict.Key] = isFinishMove(vects, dict.Key);
      }  

      canMove = tempDict;
   }

   private Vector3 getVector(Directions dir){
      switch(dir){
         default:
         case Directions.Down:
            return Vector3.back;
         case Directions.Up:
            return Vector3.forward;
         case Directions.Left:
            return Vector3.left;
         case Directions.Right:
            return Vector3.right;
      }
   }
   
}
