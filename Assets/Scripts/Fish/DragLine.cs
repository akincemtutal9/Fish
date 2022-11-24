using System;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    #region Fix Render Visual

    public Material material;
    public float startWidth = 0.2f;
    public float endWidth = 0.1f;
    public Color startColor = Color.white;
    public Color endColor = Color.clear;

    #endregion

    private LineRenderer lineRenderer;
    private Rigidbody rb;
    private Target target;
    public LayerMask layerMask;
    public GameObject LastHitGameObject;
    
    [SerializeField] private GameObject playerGameObject;



    private void Awake()
    {
        playerGameObject = GameObject.Find("Player2");
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        if (lineRenderer == null) //bulmazsa koyuver
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        target = GetComponent<Target>();
        rb = GetComponent<Rigidbody>();
        if (rb == null) //bulmazsa koyuver
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Burdan aşağısı Scriptable olabilir ya da grafikçiler halleder.
        lineRenderer.enabled = false; // Oyun basi gozukmesin line
        lineRenderer.positionCount = 2; // 2 pointte bitecek yani baslangıc pointi ve bitiş pointi olacak
        lineRenderer.material = material;
        lineRenderer.startWidth = endWidth;
        lineRenderer.endWidth = startWidth;
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
        lineRenderer.numCapVertices = 20;
    }

    void Update()
    {
        LineMove();
    }

    public void LineMove()
    {
        Vector3 mousePosition = Input.mousePosition;
        // Line renderer ta Input olarak 3 tane fonksiyon var bastın-tuttun-bıraktın
        // Input(0) mousedaki sol
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;
        
        if (Input.GetMouseButtonDown(0)) // down bastın anlamında
        {
            if (Physics.Raycast(ray, out hitInfo, 550))
            {
                LastHitGameObject = hitInfo.transform.gameObject;// Burdaki amac sadece karaktere basinca haraket ettirmek
                Debug.Log(LastHitGameObject);
                Vector3 startRenderPosition = hitInfo.point + Vector3.forward;
                lineRenderer.SetPosition(0,
                    startRenderPosition); // bunun ilk pozisyonunun geldin ilk pozisyon yaptın burda
                lineRenderer.SetPosition(1,
                    startRenderPosition); // bunun ikinci pozisyonu da geldin ilk pozisyon yaptın
                lineRenderer.enabled = true;
            }
        }
        if (Input.GetMouseButton(0) && LastHitGameObject == playerGameObject) // basılı tutuyon anlamında
        {
            if (Physics.Raycast(ray, out hitInfo, 550))
            {
                Vector3 endRenderPosition = hitInfo.point + Vector3.forward;
                lineRenderer.SetPosition(1, endRenderPosition); // ikinci pozisyonu geldin burda updateledin 
            }
        }

        if (Input.GetMouseButtonUp(0)) //up bıraktın anlamında
        {
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                lineRenderer.enabled = false;
                // alttaki kodda updatelenmiş end positionuyla ilk pozisyondan ikinciyi çıkarıyoruz(Oyuna göre "eksi" ile çarparız)
                Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
                inputForce.y = 0f;
                //Vector3 to = transform.position - inputForce;
                //playerGameObject.transform.DOMove(to, 2);
                rb.AddForce(-inputForce, ForceMode.Impulse);
            }
        }
    }
}


    
    

