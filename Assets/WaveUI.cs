using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    // [SerializeField]
    // WaveSpawner spawner;
    
    [SerializeField]
    Animator waveAnimator;
    
    [SerializeField]
    Text waveCountdownText;
    
    [SerializeField]
    Text waveCountText;

    // Start is called before the first frame update
    void Start()
    {
        // if (spawner == null) {
        //     Debug.LogError("No spawner referenced!");
        //     this.enabled = false;
        // }
        if (waveAnimator == null) {
            Debug.LogError("No waveAnimator referenced!");
            this.enabled = false;
        }
        if (waveCountdownText == null) {
            Debug.LogError("No waveCountdownText referenced!");
            this.enabled = false;
        }
        if (waveCountText == null) {
            Debug.LogError("No waveCountText referenced!");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateCountingUI() {
        Debug.Log("UpdateCountingUI");
    }
    
    void UpdateSpawningUI() {
        Debug.Log("UpdateSpawningUI");
    }
}
