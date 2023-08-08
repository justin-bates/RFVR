using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;



public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; // The Image component of the button
    public Color startColor = Color.white; // The color when not being hovered over
    public Color endColor = Color.gray; // The color when fully hovered over
    public float hoverTime = 3.0f; // Time in seconds to fully change color

    private GameObject hoverHand; // The hand that is currently hovering over the button
    private float hoverProgress;
    private bool gameStarted; // Flag to check if the game has started

    

    public void Awake()
    {
        buttonImage.color = startColor;
    }

    public void Update()
    {
        if (hoverHand != null && !gameStarted)
        {
            hoverProgress += Time.deltaTime / hoverTime;
            buttonImage.fillAmount = hoverProgress;
            buttonImage.color = Color.Lerp(startColor, endColor, hoverProgress);
            if (hoverProgress >= 1.0f)
            {
                // Start the game
                gameStarted = true;
                Debug.Log("start");
                SceneManager.LoadScene("Act 1 Scene", LoadSceneMode.Single);

                buttonImage.gameObject.SetActive(false); // hide the button (remember to hide canvas also)

            }
        }
        else
        {
            hoverProgress = 0.0f;
            buttonImage.fillAmount = hoverProgress;
            buttonImage.color = startColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverHand = eventData.pointerCurrentRaycast.gameObject; //this is the problem... it stores the hovered obj not the hand
        hoverProgress = 0.01f;
        //Debug.Log("Hovering over: " + hoverHand.name);          




    }

    public void OnPointerExit(PointerEventData eventData)
    {

        hoverHand = null;
        hoverProgress = 0.0f;

    }

    public GameObject GetHoverHand()
    {
        return hoverHand;
    }
}
