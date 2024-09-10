using System.Text;

namespace SimpleXMLValidatorLibrary
{
    /// <summary>
    /// Provides functionality to validate simple XML strings.
    /// </summary>
    public class SimpleXmlValidator
    {
        /// <summary>
        /// Determines if the given XML string is valid.
        /// </summary>
        /// <param name="xml">The XML string to validate.</param>
        /// <returns>True if the XML is valid, false otherwise.</returns>
        public static bool DetermineXml(string xml)
        {
            var tagStack = new Stack<string>();
            var currentTag = new StringBuilder();
            bool isClosingTag = false;
            bool insideTag = false;

            foreach (char c in xml)
            {
                switch (c)
                {
                    case '<':
                        if (insideTag)
                            return false; // Invalid: '<' inside a tag
                        insideTag = true;
                        isClosingTag = false;
                        currentTag.Clear();
                        break;

                    case '/':
                        if (insideTag && currentTag.Length == 0)
                            isClosingTag = true;
                        else
                            currentTag.Append(c);
                        break;

                    case '>':
                        if (!insideTag)
                            return false; // Invalid: '>' outside a tag

                        insideTag = false;
                        string tag = currentTag.ToString();

                        if (isClosingTag)
                        {
                            // Check if the closing tag matches the last opened tag
                            if (tagStack.Count == 0 || tagStack.Pop() != tag)
                                return false; // Mismatched closing tag
                        }
                        else
                        {
                            // Add opening tag to the stack
                            tagStack.Push(tag);
                        }

                        currentTag.Clear();
                        break;

                    default:
                        // Append character to current tag if inside a tag
                        if (insideTag)
                            currentTag.Append(c);
                        break;
                }
            }

            // XML is valid if all tags are closed and we're not inside a tag
            return tagStack.Count == 0 && !insideTag;
        }
    }
}