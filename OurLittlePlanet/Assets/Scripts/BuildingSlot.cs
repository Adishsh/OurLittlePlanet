using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BuildingSlot : MonoBehaviour
{
    [SerializeField] public int index;
    [SerializeField] public float m_HoveringDisplayTimee = 1f;
    public List<BuildingSlot> m_AdjasentSlots { get; private set; }
    public Building building { get; private set; }
    public bool WasCalculated = false;
    [SerializeField] Animator animator;
    [SerializeField] GameObject resourcesPanel;
    [SerializeField] TextMeshPro resources;
    [SerializeField] TextMeshPro polution;
    [SerializeField] TextMeshPro Buildingname;
    [SerializeField] AmountAdded m_CardHoverAnimator;
    [SerializeField] ParticleSystem m_BuildAnim;

    private Coroutine showingResources;
    private bool IsHovering;


    public BuildingSlot(List<BuildingSlot> adjasentSlots)
    {
        m_AdjasentSlots = adjasentSlots;
    }

    public void Build(Card card, WorldMap map)
    {
        m_BuildAnim.Emit(100);

        var cardData = card.m_CardData;
        resources.text = cardData.m_Resources.ToString();
        polution.text = cardData.m_Pollution.ToString();
        Buildingname.text = cardData.m_CardName;
        if (cardData.m_Building && cardData.m_Building.CanBuildBuilding(map))
        {
            DestroyBuilding();
            building = cardData.m_Building;
            Vector3 newPosition = transform.position + building.transform.position;
            var newRotation = building.transform.rotation * transform.rotation;
            building = Instantiate(building, newPosition, newRotation, transform);
            building.m_CardData = cardData;
            building.slot = this;
            AudioManager.S.Play_Sound((AudioManager.SoundTypes.Construction));
        }
    }

    public void DestroyBuilding()
    {
        if (building != null)
        {
            building.DestroyBuilding.Invoke();
            building.m_CardData = null;
            Destroy(building.gameObject);
            building = null;
        }
        animator.Play("BuildingSlotDestroy");
    }

    public bool HasCardData()
    {
        return building?.m_CardData != null;
    }

    private void OnMouseUp()
    {
        Debug.Log("BuildCard 3");
        EventManager.instance.BuildCard.Invoke(index);
    }

    public CardImpact GetCardCalaulation(StatsManager statsManager, WorldMap map)
    {
        return building?.GetCardCalaulation(statsManager, map);
    }

    void OnMouseOver()
    {
        if (StatsManager.Instance.CardIsDragged)
        {
            StatsManager.Instance.buildingSlotSelected = this;
            animator.SetBool("Hover", true);
        }
        if (building != null && showingResources == null)
        {
            IsHovering = true;
           showingResources = StartCoroutine(ShowResourcesPanel());
        }
    }
       

     IEnumerator ShowResourcesPanel()
    {
        yield  return new WaitForSeconds(0.6f);
        if(IsHovering && !StatsManager.Instance.CardIsDragged)
        {
        m_CardHoverAnimator.PlayAmountAdded(transform , building.m_CardData.m_Pollution, building.m_CardData.m_Resources, building.m_CardData.m_CardName);
        }

    }
    void OnMouseExit()
    {
        animator.SetBool("Hover", false);
        IsHovering = false;
        if (StatsManager.Instance.CardIsDragged)
        {
        }
        if (StatsManager.Instance.buildingSlotSelected == this)
        {
            StatsManager.Instance.buildingSlotSelected = null;
        }
        resourcesPanel.SetActive(false);
        if (building != null && showingResources != null)
        {
            m_CardHoverAnimator.Hide();
            StopCoroutine(showingResources);
            showingResources = null;
        }

    }

}
