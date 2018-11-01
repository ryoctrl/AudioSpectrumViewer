using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumViewer : MonoBehaviour {
	private AudioSpectrum spectrum;
    private List<Transform> spectrumBodies = new List<Transform>();
	private float scale = 100;

    void Awake() {
        Transform[] objects = GetComponentsInChildren<Transform>();
        foreach(Transform obj in objects) {
            if(obj.name.StartsWith("SpectrumBody")) {
                spectrumBodies.Add(obj.transform);
            }
        }

        allocateSpectrumBody();
        spectrum = GetComponent<AudioSpectrum>();
    }

    #region private methods
    private void allocateSpectrumBody() {
        if(spectrumBodies.Count == 0) return;
        int numOfBodies = spectrumBodies.Count;
        float bodyWidth = spectrumBodies[0].transform.localScale.x * 1.5f;
        float xPos = -(numOfBodies / 2 * bodyWidth);
        Vector3 bodyPosition;
        foreach(Transform body in spectrumBodies) {
            bodyPosition = spectrumBodies[0].transform.position;
            bodyPosition.x = xPos;
            body.position = bodyPosition;
            xPos += bodyWidth;
        }
    
    }

    #endregion

	void Update() {
        Debug.Log(spectrumBodies.Count);
		for ( int i = 0; i < spectrumBodies.Count; i++ )
        {
            Debug.Log(i);
            var cube = spectrumBodies[ i ];
            var localScale = cube.localScale;
            localScale.y = spectrum.Levels[ i ] * scale;
            cube.localScale = localScale;
        }
	}

}
