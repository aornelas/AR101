using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour {

   public string Country;
   public float HeightMeters;
   public float TiltSpeed = 3f;

   private GameObject _canvas;
   private string _rocketName;
   private bool _raised;
   private bool _raising;
   private bool _lowering;

   public void Start () {
      _rocketName = gameObject.name;

      var canvasObj = transform.Find ("Rocket Card");
      _canvas = canvasObj.gameObject;
      _canvas.SetActive(false);

      var rocketNameObj = canvasObj.Find ("name");
      rocketNameObj.GetComponent<Text>().text = _rocketName;

      var countryObj = canvasObj.Find ("country");
      countryObj.GetComponent<Text> ().text = Country;

      var heightObj = canvasObj.Find ("height");
      heightObj.GetComponent<Text> ().text = HeightMeters + " m";
   }

   public void Update () {
      if (_raising) {
         if (transform.rotation.eulerAngles.x > 0.1f) {
            transform.rotation =
               Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * TiltSpeed);
         } else {
            _raising = false;
            _raised = true;
            _canvas.SetActive(true);
         }
      }

      if (_lowering) {
         if (transform.rotation.eulerAngles.x < 89.9f) {
            transform.rotation =
               Quaternion.Slerp (transform.rotation, Quaternion.Euler (90, 0, 0), Time.deltaTime * TiltSpeed);
         } else {
            _lowering = false;
            _canvas.SetActive(false);
         }
      }
   }

   public void OnMouseDown()
   {
      if (!_raised && !_raising) {
         _raising = true;
         _lowering = false;
      } else {
         _lowering = true;
         _raising = false;
         _raised = false;
      }
   }
}
