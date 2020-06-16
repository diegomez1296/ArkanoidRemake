public abstract class BallState
{
    protected Ball ball;

    public BallState(Ball ball)
    {
        this.ball = ball;
        Initialize();
    }

    protected abstract void Initialize(); //This method describe values of our Block

    protected abstract void OnHit(); //This method describe what will happen after hit
}