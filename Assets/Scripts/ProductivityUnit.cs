using UnityEngine;

public class ProductivityUnit : Unit
{
    [SerializeField]
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile CurrentPile = m_Target as ResourcePile;

            if (CurrentPile != null)
            {
                m_CurrentPile = CurrentPile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
