using UnityEngine;

public class PovController : MonoBehaviour
{
    [SerializeField] private Animator playerUpAnimator;
    [SerializeField] private Animator playerDownAnimator;
    
    [SerializeField] private Animator godUpAnimator;
    [SerializeField] private Animator godDownAnimator;

    [SerializeField] private Camera playerPovCamera;
    [SerializeField] private Camera godPovCamera;

    [SerializeField] private bool godPOV = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TogglePOV()
    {
        if (godPOV)
            MoveToPlayerPOV();
        else
            MoveToGodCam();
    }

    public void MoveToPlayerPOV()
    {
        godPovCamera.gameObject.SetActive(false);
        playerPovCamera.gameObject.SetActive(true);
    }
    
    public void MoveToGodCam()
    {
        playerPovCamera.gameObject.SetActive(false);
        godPovCamera.gameObject.SetActive(true);
    }
}
