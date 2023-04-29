namespace U2.Core;

public enum SearchOption
{
    Equals, // exact match
    Contains, // contains at any place
    Begins, // begins from the specified text
    Ends, // ends on the specified text
    Except, // must not contain the specified text
}
