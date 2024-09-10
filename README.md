# Simple XML Validator

This C# solution project provides a simple XML validator that can determine whether a given XML string is valid or not.

## Requirements

- .NET 7.0 SDK or later

## Project Structure

The solution consists of two main parts:

1. **SimpleXMLValidatorLibrary**: A class library containing the core validation logic.
2. **Main Program**: A console application that demonstrates the usage of the XML validator.

### SimpleXMLValidatorLibrary

Located in `SimpleXMLValidatorLibrary/SimpleXmlValidator.cs`, this library contains the `SimpleXmlValidator` class with a static method `DetermineXml(string xml)`. This method takes an XML string as input and returns a boolean indicating whether the XML is valid or not.

The validation logic checks for:

- Proper opening and closing of tags
- Correct nesting of tags
- Basic attribute validation in opening and closing tag

### Main Program

Located in `Main/Program.cs`, this console application serves two purposes:

1. **Debug Mode**: When compiled in debug mode, it runs a series of test cases to validate the XML validator's functionality.
2. **Release Mode**: When compiled in release mode, it takes an XML string as a command-line argument and outputs whether it's valid or not.

## Usage

### Debug Mode

In debug mode, the program runs predefined test cases and outputs the results. Each test case is marked as "OK" if the result matches the expected outcome, or "NG" if it doesn't. At the end, it displays the number of passed tests out of the total number of tests.

### Release Mode

To use the program in release mode:

1. Compile the solution in release mode.
2. Run the program from the command line, providing an XML string as an argument:

   ``` bash
   SimpleXMLValidator.exe "<XML_STRING>"
   ```

   Replace `<XML_STRING>` with the actual XML you want to validate.

3. The program will output "Valid" if the XML is valid, or "Invalid" if it's not.

## Limitations

This XML validator is designed for simple XML structures and may not handle all complex XML features such as:

- XML declarations
- DOCTYPE declarations
- Comments
- CDATA sections
- Namespaces
- Attributes with normal xml standard [1]
- Special characters in attribute values

## References

[1] [Extensible Markup Language (XML) 1.0 (Fifth Edition), W3C Recommendation 26 November 2017](https://www.w3.org/TR/xml/)
