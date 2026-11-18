using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float range = 1f;
    protected AutoTargeter targeter;
    private float timer;
    protected virtual bool NeedsTarget => true;
    protected abstract void Fire();

    protected virtual void Awake()
    {
        if (targeter == null)
            targeter = GetComponentInParent<AutoTargeter>();

    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0f) return;

        if (NeedsTarget && targeter.CurrentTarget == null) return;
        timer = cooldown;
        Fire();   // quale Fire? Lo decide la classe vera

    }
}