using UnityEngine;
using UnityEngine.UIElements;

public class TabController : MonoBehaviour
{
    private Button overviewTab, galleryTab;
    private VisualElement overviewPage, galleryPage;

    private void OnEnable()
    {
        // Get the root visual element
        var panel = GetComponent<UIDocument>();
        if (panel == null)
        {
            Debug.LogError("❌ TabController: No UIDocument component found on this GameObject.", this);
            return;
        }
        var root = panel.rootVisualElement;

        // === TAB SETUP ===
        overviewTab = root.Q<Button>("overview-tab");
        galleryTab = root.Q<Button>("gallery-tab");

        overviewPage = root.Q<VisualElement>("overview-page");
        galleryPage = root.Q<VisualElement>("gallery-page");

        // Add click events for tab switching
        overviewTab.clicked += () => ShowPage(overviewTab, overviewPage);
        galleryTab.clicked += () => ShowPage(galleryTab, galleryPage);

        // Show default page
        ShowPage(overviewTab, overviewPage);

    }

    private void ShowPage(Button selectedTab, VisualElement selectedPage)
    {
        // Remove "selected" class from all tabs
        overviewTab.RemoveFromClassList("selected");
        galleryTab.RemoveFromClassList("selected");
        selectedTab.AddToClassList("selected");

        // Hide all pages
        overviewPage.AddToClassList("hidden");
        galleryPage.AddToClassList("hidden");
        overviewPage.RemoveFromClassList("visible");
        galleryPage.RemoveFromClassList("visible");

        // Show selected page
        selectedPage.AddToClassList("visible");
        selectedPage.RemoveFromClassList("hidden");
    }
}
