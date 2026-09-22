public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    // Delegates to Address rather than reading its country directly, so
    // the "what counts as USA" logic stays owned by Address alone.
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}
