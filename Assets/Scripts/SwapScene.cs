using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwapScene : MonoBehaviour
{
    [SerializeField]
    private Button SwapButton;

    [SerializeField]
    private Button QuitButton;
    [SerializeField]
    private Button LoadSceneButton;
    [SerializeField]
    private Image NFT1;
    [SerializeField]
    private Image NFT2;
    void Start()
    {
        QuitButton.onClick.AddListener(Application.Quit);
        SwapButton.onClick.AddListener(()=>ChangeInterface());
        LoadSceneButton.onClick.AddListener(()=>LoadScene());
    }

    // Update is called once per frame
    private void ChangeInterface()
    {
        QuitButton.gameObject.SetActive(false);
        SwapButton.gameObject.SetActive(false);
        NFT1.gameObject.SetActive(true);
        NFT2.gameObject.SetActive(true);
        LoadSceneButton.gameObject.SetActive(true);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
