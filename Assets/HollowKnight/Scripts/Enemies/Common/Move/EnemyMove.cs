
using Core.Entity;
public class EnemyMove : EMove
{
    protected void OnEnable()
    {
        moveStrategy = new EGroundChase();
    }

    protected override void LoadComponentInParent()
    {
        base.LoadComponentInParent();
        entity = transform.parent;
    }
}
