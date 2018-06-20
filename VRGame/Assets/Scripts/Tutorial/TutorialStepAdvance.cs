using Framework.Events;

public class TutorialStepAdvance : TutorialResetTrigger
{
    public GameEvent evt;

    public override void Reset()
    {
        evt.Raise();
    }
}