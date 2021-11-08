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
        //Baþlangýç noktasý parentin pozisyonu olarak belirlenir.
        initialPos = transform.parent.position;

        //Balonun ilk sönük vaziyette baþlar.
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        //Ýp etkisi Spring Joint ile verildi.
        joint = GetComponent<SpringJoint>();
        lineRenderer = GetComponent<LineRenderer>();

        //Spring Joint ayarlarý
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = initialPos;

        joint.maxDistance = 4f;

        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        //5 tane material arasýndan birisi seçilir.
        meshRenderer.material = materials[Random.Range(0, 5)];
    }

    // Update is called once per frame
    void Update()
    {
        //Balonun yükselmesi ve havada kalmasý için sürekli force uygulanýr.
        rb.AddForce(new Vector3(0f, .2f, 0f), ForceMode.Force);

        //Balon scalei 1 olana kadar þiþer.
        if(transform.localScale.x < 1f)
        {
            transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime * 0.2f;
        }

        //Balonun ipi yaratýlýr.
        createRope();
    }

    private void createRope()
    {
        //Balonun pozisyonundan baþlangýç noktasýna line çizilir.
        lineRenderer.SetPosition(0, initialPos);
        lineRenderer.SetPosition(1, transform.position);

        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
    }
}
