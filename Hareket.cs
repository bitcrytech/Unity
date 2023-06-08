using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hareket : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    float _mouseControl;
    public Text BulletsAmount;
    int _bulletsAmount;
   


    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > _mouseControl)
        {
            if (Input.touchCount <= 0 && EventSystem.current.IsPointerOverGameObject()) return; // mouse over UI
            if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) return; // touch over UI 

            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           //Ray _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); for mobile 
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit, 50f))
            {
                GameObject nesne =  Instantiate(bullet, _ray.origin, Quaternion.identity);
                nesne.gameObject.transform.LookAt(hit.point);
                Destroy(nesne, 2f);
            }
            _mouseControl = Time.time + 0.15f;
            _bulletsAmount++;
            BulletsAmount.text = _bulletsAmount.ToString();
        }
    }

}
