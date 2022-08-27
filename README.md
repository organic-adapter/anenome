# anenome
Set the Anenome.CLI as the Startup Project and run

# Assumptions
## Sorting
Based on the potential outputs two arbitrary property sorts were detected.
### Maintain Source Sort
When adding, moving, or removing properties maintain the original sort when outputting.

### Sorted Alphabetically
Sort output properties alphabetically.

*This is an assumption*

## Type Ambiguity
Given the type ambiguity and the nature of coding challenges it was assumed this is a string format to string format challenge.

# Questions
## Output Sorting
Are the assumptions true? Or are we dealing with completely arbitrary property sorting.
__Meaning, the output property order need to be hard coded for each instance.__
## Type Ambiguity
It is assumed these are ambiguous strings. 

But they can also be dynamically typed objects. Dynamically typed objects would change the nature of the solution.


# More Magic
It was designed to convert the format from a parenthesis based single line. We would need to extend the code to support variations.

Samples:

```
(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
(Zid, name, Qemail, type(id, name, customFields(c1, c2, c3(a1, a2, a3))), externalId)
```

# Developer notes
## Why we did not build a serializer.
One of the original designs was to flow through a series of Contact models. Implying a custom serializer to Deserialize the 1st format into an object and another serializer to Serialize the object into the 2nd format.

However, with the property type ambiguity the developer felt it was safer to do a straight up string format to string format to meet the MVP.

Below is a potential base contract. This is when the smells from the potential solution started to rise.
```CSharp
public class Contact
{
    public string Id { get; set; } //Assumed type
    public string Name { get; set; } //Assumed type
    public string Email { get; set; } //Assumed type
    public ContactType Type { get; set; } //Assumed type
    public string ExternalId { get; set; } //Assumed type
}

public class ContactType
{
    public string Id { get; set; } //Assumed type
    public string Name { get; set; } //Assumed type 
    public Dictionary<string, Object> CustomFields { get; set; } //Assumed Extensible Type
}
```

When using a serializer we could use serializer annotations to explicitly set the Property order
instead of making assumptions.
```CSharp
public class ContactAlpha
{
    [Order(2)]
    public string Id { get; set; } //Assumed type
    [Order(3)]
    public string Name { get; set; } //Assumed type
    [Order(0)]
    public string Email { get; set; } //Assumed type
    [Order(4)]
    public ContactType Type { get; set; } //Assumed type
    [Order(1)]
    public string ExternalId { get; set; } //Assumed type
}

public class ContactType
{
    [Order(1)]
    public string Id { get; set; } //Assumed type
    [Order(2)]
    public string Name { get; set; } //Assumed type 
    [Order(0)]
    public Dictionary<string, Object> CustomFields { get; set; } //Assumed Extensible Type would need to be sorted
}
```