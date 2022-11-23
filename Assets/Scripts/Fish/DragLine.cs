using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using DG.Tweening;
using UnityEditor.PackageManager;
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
    private List<Vector3> points = new List<Vector3>();
    private Rigidbody rb;
    private Target target;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private int pushSpeed = 0;
    [SerializeField] private Camera camera;

    
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

    // Update is called once per frame
    void Update()
    {
        LineMove();

    }

    public void LineMove()
    {

        Vector3 mousePosition = Input.mousePosition;
        /*
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            Vector3 eklenecek = hitInfo.point;
            eklenecek.y = 0f;
            points.Add(eklenecek);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
        */
        // Line renderer ta Input olarak 3 tane fonksiyon var bastın-tuttun-bıraktın
        // Input(0) mousedaki sol
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0)) // down bastın anlamında
        {
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                Vector3 startRenderPosition = hitInfo.point + Vector3.forward;

                lineRenderer.SetPosition(0,
                    startRenderPosition); // bunun ilk pozisyonunun geldin ilk pozisyon yaptın burda
                lineRenderer.SetPosition(1,
                    startRenderPosition); // bunun ikinci pozisyonu da geldin ilk pozisyon yaptın
                lineRenderer.enabled = true;
            }
        }

        if (Input.GetMouseButton(0)) // basılı tutuyon anlamında
        {
            if (Physics.Raycast(ray, out hitInfo, 1000))
            {
                Vector3 endRenderPosition = hitInfo.point + Vector3.forward;
                lineRenderer.SetPosition(1, endRenderPosition); // ikinci pozisyonu geldin burda updateledin 
            }
        }

        if (Input.GetMouseButtonUp(0)) //up bıraktın anlamında
        {
            lineRenderer.enabled = false;
            // alttaki kodda updatelenmiş end positionuyla ilk pozisyondan ikinciyi çıkarıyoruz(Oyuna göre "eksi" ile çarparız)
            Vector3 inputForce = lineRenderer.GetPosition(0) - lineRenderer.GetPosition(1);
            inputForce.y = 0f;
            Vector3 to = transform.position - inputForce;
            //playerGameObject.transform.DOMove(to, 2);
            rb.AddForce(-inputForce ,ForceMode.Impulse);
        }
    }
}
