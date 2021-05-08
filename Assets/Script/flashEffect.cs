using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashEffect : MonoBehaviour
{
    public List<SpriteRenderer> myRenderers;
    public List<Color> myColors;
    public float flashTime = 0.15f;
    public float counter1 = -1;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    // Start is called before the first frame update 
    void Start()
    {
        //myRenderer = gameObject.GetComponent<SpriteRenderer>(); 
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = myRenderers[0].sharedMaterial.shader;
        for (int i = 0; i < myRenderers.Count; i++)
        {

            myColors[i] = myRenderers[i].color;

        }
    }

    // Update is called once per frame 
    void Update()
    {

        
            if (counter1 <= 0 && counter1 > -1)
            {
                normalSprite();
                counter1 = -1;
            }
            else if (counter1 == -1)
            {

            }
            else
            {
                counter1 -= Time.deltaTime;
            }
        
    }

    public void whiteSprite()
    {
        counter1 = flashTime;
        for(int i = 0; i < myRenderers.Count; i++)
        {
            myRenderers[i].material.shader = shaderGUItext;
            myRenderers[i].color = Color.white;
        }


    }

    void normalSprite()
    {
        for (int i = 0; i < myRenderers.Count; i++)
        {
            myRenderers[i].material.shader = shaderSpritesDefault;
            myRenderers[i].color = myColors[i];
        }

    }
}