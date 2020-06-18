public abstract class BallState : ArkanoidState
{
    protected Ball ball;

    protected BallState(Ball ball)
    {
        this.ball = ball;
        Initialize();
    }

    protected abstract void OnHit(); //This method describe what will happen after hit
}