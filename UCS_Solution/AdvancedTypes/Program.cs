
Console.ReadKey();

public class OddClass
{
    // This property starts as null because there is no constructor.
    // Since the compiler detects it may be null, we declare it as nullable (string?).
    // This removes the uninitialized warning, but introduces other warnings
    // when the property is used without checking for null.
    public string? Text { get; private set; }

    private bool _isInitialized;

    // Fishy design - requires Init() before use
    // The class relies on Init() to assign values instead of using a constructor.
    // This is considered poor design because the object can exist in an invalid state.
    public void Init(string text)
    {
        Text = text;
        _isInitialized = true;
    }

    public void DoWork()
    {
        // Validate that Init() was called before proceeding.
        if (!_isInitialized)
        {
            throw new InvalidOperationException("The class is not initialized");
        }

        // Nullability warning (CS8602):
        // 'Text' is nullable, but we are dereferencing it.
        // The compiler warns because Text could still be null here.
        // However, the developer *knows* that Text is set in Init(),
        // so we can suppress the warning using the null-forgiving operator (!).

        // Without null-forgiving operator:
        // Console.WriteLine("Text length: " + Text.Length);

        // With null-forgiving operator:
        Console.WriteLine("Text length: " + Text!.Length);
    }
}

public class OddClass2
{
    // Nullable public property (might not be initialized)
    public string? Text2 { get; set; }

    // Nullable field initialized later via Init()
    public string? Text { get; private set; }
    private bool _isInitialized;

    public void Init(string text)
    {
        // Check that 'text' is not null before assignment
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        Text = text;
        _isInitialized = true;

        // Danger: possible NullReferenceException if Text2 is still null
        Console.WriteLine(Text2.Length);

        // ✅ Safe: null-check before using Text2
        if (Text2 != null)
        {
            Console.WriteLine(Text2.Length);
        }
    }

    public void DoWork()
    {
        if (!_isInitialized)
        {
            throw new InvalidOperationException("The class is not initialized");
        }

        // The '!' null-forgiving operator tells the compiler:
        // “Trust me, Text is not null here.”
        // its value is assigned in Init(), so it is not null

        // Code without null-forgiving operator
        //Console.WriteLine("Text length: " + Text.Length);

        // Code with null-forgiving operator
        Console.WriteLine("Text length: " + Text!.Length);
    }
}