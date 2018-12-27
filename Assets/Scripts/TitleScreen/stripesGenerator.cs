using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripesGenerator : MonoBehaviour {

    public GameObject stripe;
    public Transform stripeTr;

    public GameObject father;
    public Transform fatherTr;

    public GameObject stripeClone;
    public Transform stripeCloneTr;

    float singleStripeXPos;
    float singleStripeYPos;

    public float distanceBetweenStripes = 400.0F;

    Vector3[] stripePos;

    // Use this for initialization
    void Start () {
        stripe = GameObject.Find("SingleStripe");
        stripeTr = GameObject.Find("SingleStripe").transform;
        father = GameObject.Find("Stripes");
        fatherTr = GameObject.Find("Stripes").transform;

        singleStripeXPos = stripeTr.position.x;
        singleStripeYPos = stripeTr.position.y;

        //posXOfAllStripes = fatherTr.position.x;

        for (int i = 0; i < 20; i++)    // GENERUJE 20 PASKÓW W STAŁEJ ODLEGŁOŚCI OD SIEBIE
        {
            Instantiate(stripeTr, new Vector3(((i * distanceBetweenStripes) + singleStripeXPos), singleStripeYPos, 0), Quaternion.identity);
            stripeTr.name = "Stripe"+ i ;
        }
        
        for (int i = 0; i < 19; i++) //  PĘTLA NADAJĄCA PRAWA RODZICIELSKIE OBIEKTOWI STRIPES
        {
            
            //string searchedString = "Stripe" + i + "(Clone)";
            stripeClone = GameObject.Find("Stripe" + i + "(Clone)");
            stripeClone.transform.SetParent(fatherTr);
            stripeClone.GetComponent<returningStripe>().tf = stripeClone.transform;
        }

        //OSTATNI Z PASKÓW NIE MA DOPISKU CLONE WIĘC NIM SIĘ ZAJĄŁEM POZA PĘTLĄ
        stripeClone = GameObject.Find("Stripe19");
        stripeClone.transform.SetParent(fatherTr);
        stripeClone.GetComponent<returningStripe>().tf = stripeClone.transform;

        //TEN PASEK JEST PASKIEM POCZĄTKOWO WIDOCZNYM W HIERARCHII. USUWAM GO ABY NIE WYŚWIETLIĆ DWÓCH TAKICH SAMYCH PASKÓW W MIEJSCU NAJBARDZIEJ PO LEWEJ STRONIE NA STARCIE GRY.
        stripeClone = GameObject.Find("SingleStripe(Clone)");
        Destroy(stripeClone);
    }
}
