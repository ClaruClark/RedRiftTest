public interface IClickable
{
    ClickableType GetClickableType();
    void Click();
    void DoSomething();
}

public enum ClickableType
{
    Button, Platform
}