using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    // Materialを入れる
    Material myMaterial;

    // Emissionの最小値
    private float minEmission = 0.2f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    //発光速度
    private int speed = 5;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    private bool _isFire;
    private OBJECT_TAG objTag;
    // Start is called before the first frame update
    void Start()
    {

        // タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
            objTag = OBJECT_TAG.SmallStar;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
            objTag = OBJECT_TAG.LargeStar;
        }
        else if (tag == "SmallCloudTag" )
        {
            this.defaultColor = Color.cyan;
            objTag = OBJECT_TAG.SmallCloud;
        }
        else if(tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
            objTag = OBJECT_TAG.LargeCloud;
        }
        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        _isFire = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
        _isFire = true;
    }

    public OBJECT_TAG SetTag()
    {
        if(_isFire)
        {
            _isFire = false;
            
            return objTag;
        }

        return OBJECT_TAG.None;
        
    }
    
}
