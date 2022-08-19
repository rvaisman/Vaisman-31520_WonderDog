using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Postpro : MonoBehaviour
{

    public PostProcessVolume volumen;
    public Vignette _vignette;
    public MotionBlur _motionBlur;
    bool sube;
    float value;
    // Start is called before the first frame update
    void Start()
    {
        
        volumen.profile.TryGetSettings(out _vignette);
        volumen.profile.TryGetSettings(out _motionBlur);
        sube = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            value = _vignette.intensity.value;

            if (sube)
            {
                value += 0.1f;

              if (value >= 1f)
              {
                    value = 1f;
                    _vignette.intensity.value = 1f;
                    sube = false;
              } else
                {
                    _vignette.intensity.value = value;
                } 


            }


            if (!sube)
            {
                value -= 0.1f;

                if (value <= 0)
                {
                    value = 0;
                    _vignette.intensity.value = 0;
                    sube = true;
                }
                else
                {
                    _vignette.intensity.value = value;
                }


            }


        }
    }
}
