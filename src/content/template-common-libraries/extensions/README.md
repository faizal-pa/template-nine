# Template9.Common.Extensions

This library contains useful extension methods used across multiple products.

## Number Extensions

The following methods are provided as extensions to numbers.

| Method              | Type | Description                                                                                 |
|---------------------|------|---------------------------------------------------------------------------------------------|
| IsBetween           | int  | Returns true if the integer is greater than the lower bound and lower than the upper bound. |
| IsSuccessStatusCode | int  | Returns true if the integer is in the 2xx range.                                            |

## IEnumerable Extensions

The following methods are provided as extensions to IEnumerable&lt;T&gt;.

| Method                 | Description                                                   |
|------------------------|---------------------------------------------------------------|
| IsNotNullAndHasItems() | Returns true if the collection is instantiated and populated. |
| IsNullOrEmpty()        | Returns true if the collection is null or empty.              |
| Shuffle()              | Randomly shuffles the collection.                             |


## DateTimeOffset Extensions

The following methods are provided as extensions on DateTimeOffset.

| Method            | Description                                                            |
|-------------------|------------------------------------------------------------------------|
| GetEndOfDay()     | Returns a DateTimeOffset representing the end of the day (23:59:59)    |
| GetStartOfDay()   | Returns a DateTimeOffset representing the beginning of the day (0:0:0) |


## Generic Extensions

The following methods are provided as extensions on generics (T).

| Method             | Description                                                   |
|--------------------|---------------------------------------------------------------|
| DeepClone()        | Performs a deep clone of an object using JSON serialization   |
| In(params T[] set) | Returns true if the object is in the set                      |

> [!TIP]
> DeepClone optionally accepts a parameter of type `JsonSerializerOptions` to override the defaults used in the serialization/deserialization of objects for a single operation. The default values used for serialization/deserialization can be changed by assigning a value to `DeepClone.Options`.

## Enum Extensions

The following methods are provided as extensions on strings for converting to an enum.

| Method                        | Description                                                                                      |
|-------------------------------|--------------------------------------------------------------------------------------------------|
| ToEnum&lt;TEnum&gt;               | Converts a case-insensitive string to a enum value. Throws an exception if no value is found.    |
| ToEnum&lt;TEnum&gt;(defaultValue) | Converts a case-insensitive string to a enum value. Returns `defaultValue` if no value is found. |

## String Extensions

The following methods are provided as extensions on strings.

| Method                              | Description                                                                   |
|-------------------------------------|-------------------------------------------------------------------------------|
| Contains(string[] values)           | Checks if the string contains any of the specified string values.             |
| Contains(char[] values)             | Checks if the string contains any of the specified char values.               |
| EndsWith(string[] values)           | Checks if the string ends with any of the specified string values.            |
| FromBase64()                        | Decodes a Base64 string.                                                      |
| HasWhiteSpace()                     | Checks whether the string ahs any white space characters.                     |
| StartsWith(string[] values)         | Checks if the string starts with any of the specified string values.          |
| ToBase64()                          | Encodes a string to Base64.                                                   |
| UriCombine(string, params string[]) | Combines the strings into a uri using the forward slash (/) as the separator. |

## IConfiguration Extensions

| Method          | Returns | Description                                                                 |
|-----------------|---------|-----------------------------------------------------------------------------|
| IsToolExecuting | bool    | Returns true if the application is running in the context of a tool.        |
| ExecutingTool   | [Tool](Template9.Common.Extensions/Tool.cs)    | Returns the tool currently being executed. |