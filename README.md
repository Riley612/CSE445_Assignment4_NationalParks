# National Parks XML Validation & JSON Conversion

## Project Overview

This project was developed for CSE445: Distributed Software Development at Arizona State University taught by Yinong Chen.

The goal of this assignment was to create an XML directory containing information about U.S. national parks using a provided visual tree diagram, define its structure using an XML Schema (XSD), and develop a C# application that validates XML files and converts XML data into JSON.

The project also includes an intentionally incorrect XML file to test how the validation process detects errors.

## Skills Demonstrated

- **Technical Specification Interpretation:** Translated a visual XML tree diagram into a structured XML document and corresponding XSD schema.
- **XML & XSD Development:** Defined element relationships, ordering, data types, and attribute requirements.
- **Schema Validation:** Implemented XML validation and error reporting in C#.
- **Data Transformation:** Converted XML data into JSON using Newtonsoft.Json.
- **Testing & Debugging:** Created intentionally invalid XML data to test validation behavior.
- **Remote File Integration:** Accessed XML and XSD resources hosted on GitHub through URLs.

## Technologies Used

- C#
- XML
- XML Schema (XSD)
- Newtonsoft.Json
- .NET
- GitHub for hosting XML and XSD files

## Project Files

| File | Description |
|---|---|
| `NationalParks.xml` | Contains information about 11 U.S. national parks, including names, phone numbers, addresses, ratings, and nearest airports. |
| `NationalParks.xsd` | Defines the required XML structure, element order, data types, and required or optional attributes. |
| `NationalParksErrors.xml` | An XML file containing five intentional errors used to test schema validation. |
| `submission.cs` | Contains the C# application responsible for validating XML files against the XSD and converting XML into JSON. |

## XML Structure

The XML file uses `NationalParks` as the root element, containing multiple `NationalPark` elements.

Each national park includes:

- **Name:** Name of the national park
- **Phone:** One or more contact phone numbers
- **Address:** Street number, street, city, state, and ZIP code
- **NearestAirport:** Required attribute identifying a nearby airport
- **Rating:** Optional attribute representing the park's rating

The XSD defines the order of these elements and ensures that required information is present.

## XML Validation

The C# application includes a `Verification()` method that accepts two URLs:

1. An XML file URL
2. An XSD file URL

The method reads the XML file and validates it against the provided schema.

If the XML is valid, the method returns:

`No errors are found`

If validation fails, the method returns information about the errors encountered.

### Testing Invalid XML

The `NationalParksErrors.xml` file includes five intentional errors:

1. Incorrect root element name
2. Missing required attribute
3. Missing Phone element
4. Missing Address closing tag
5. Duplicate Name element

These errors demonstrate how XML validation identifies problems with document structure and schema requirements.

## XML to JSON Conversion

The `Xml2Json()` method reads a valid XML file from a URL and converts its contents into JSON using Newtonsoft.Json.

The resulting JSON preserves the national park information, including multiple phone numbers, address details, and optional ratings.

## Application Workflow

1. Validate `NationalParks.xml` against `NationalParks.xsd`.
2. Validate `NationalParksErrors.xml` against the same schema.
3. Convert the valid `NationalParks.xml` file into JSON.
4. Display the validation results and converted JSON in the console.

## What I Learned

This assignment helped me practice creating structured XML documents, defining validation rules with XSD, and working with XML processing libraries in C#.

It also provided experience with error handling, working with remotely hosted files, and converting data between XML and JSON formats.

---

**Course:** CSE445 – Distributed Software Development  
**University:** Arizona State University  
**Project:** Assignment 4 – XML
