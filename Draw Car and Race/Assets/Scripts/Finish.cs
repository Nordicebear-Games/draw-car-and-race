using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "carTag")
        {
            UIControl.UIManager.LevelCompleted();
        }
    }
}
