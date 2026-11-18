using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BeamWeapon : Weapon
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform muzzle;
    [SerializeField][ColorUsage(true, true)] Color startColor = Color.red;
    [SerializeField][ColorUsage(true, true)] Color endColor = Color.purple;
    [SerializeField] float lineThickness = .25f;

    protected override void Awake()
    {
        base.Awake();
        if (!lineRenderer) lineRenderer = GetComponentInParent<LineRenderer>();
    }

    protected override void Fire()
    {
        targeter?.CurrentTarget.TakeDamage(damage);
    }

    protected override void Update()
    {
        base.Update();

        if(lineRenderer)
        {
            if(targeter && targeter.CurrentTarget != null)
            {
                Vector3 lineStart = muzzle.position;
                Vector3 lineEnd = targeter.TargetPoint;

                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, lineStart);
                lineRenderer.SetPosition(1, lineEnd);

                lineRenderer.startColor = startColor;
                lineRenderer.endColor = endColor;

                lineRenderer.startWidth = lineThickness;
                lineRenderer.endWidth = lineThickness;
            }
            else
            {
                lineRenderer.positionCount = 0;
                lineRenderer.startColor = new Color(0, 0, 0, 0);
                lineRenderer.endColor = new Color(0, 0, 0, 0);
            }
        }

        
    }
}