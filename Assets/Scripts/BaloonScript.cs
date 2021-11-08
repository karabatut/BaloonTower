using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonScript : MonoBehaviour
{
    Rigidbody rb;
    public Material[] materials;
    MeshRenderer meshRenderer;
    SpringJoint joint;
    Vector3 initialPos;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Ba�lang�� noktas� parentin pozisyonu olarak belirlenir.
        initialPos = transform.parent.position;

        //Balonun ilk s�n�k vaziyette ba�lar.
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        //�p etkisi Spring Joint ile verildi.
        joint = GetComponent<SpringJoint>();
        lineRenderer = GetComponent<LineRenderer>();

        //Spring Joint ayarlar�
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = initialPos;

        joint.maxDistance = 4f;

        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        //5 tane material aras�ndan birisi se�ilir.
        meshRenderer.material = materials[Random.Range(0, 5)];
    }

    // Update is called once per frame
    void Update()
    {
        //Balonun y�kselmesi ve havada kalmas� i�in s�rekli force uygulan�r.
        rb.AddForce(new Vector3(0f, .2f, 0f), ForceMode.Force);

        //Balon scalei 1 olana kadar �i�er.
        if(transform.localScale.x < 1f)
        {
            transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime * 0.2f;
        }

        //Balonun ipi yarat�l�r.
        createRope();
    }

    private void createRope()
    {
        //Balonun pozisyonundan ba�lang�� noktas�na line �izilir.
        lineRenderer.SetPosition(0, initialPos);
        lineRenderer.SetPosition(1, transform.position);

        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
    }
}
