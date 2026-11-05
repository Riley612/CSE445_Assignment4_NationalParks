using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;



/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Submission
    {
        public static string xmlURL = "https://raw.githubusercontent.com/Riley612/CSE445_Assignment4_NationalParks/refs/heads/main/NationalParks.xml";
        public static string xmlErrorURL = "https://raw.githubusercontent.com/Riley612/CSE445_Assignment4_NationalParks/refs/heads/main/NationalParksErrors.xml";
        public static string xsdURL = "https://raw.githubusercontent.com/Riley612/CSE445_Assignment4_NationalParks/refs/heads/main/NationalParks.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        //Verification looks for errors in the xml files and returns a message stating if errors are found or not 
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            //return "No Error" if XML is valid. Otherwise, return the desired exception message.

            
            //Setting up a validator using the XmlReader class
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.Schemas.Add(null, xsdUrl);
            readerSettings.ValidationType = ValidationType.Schema;

            //Prepping output messages
            string noErrorsMessage = "No errors are found"; //Errors not found
            string errorMessage = ""; //Errors found

            //Listening for XSD validation errors
            readerSettings.ValidationEventHandler += (sender, e) =>
            {
                errorMessage += e.Message + "\n"; //Adds found errors to output message for found errors
            };

            //Try to open and read the XML
             try
             {

                 XmlReader reader = XmlReader.Create(xmlUrl, readerSettings);
                    while (reader.Read() == true)
                    {
                       

                    }
                    //decide which error message to return 
                    if (errorMessage.Length > 0) // errors found
                    {
                        return errorMessage;
                    }
                    else //no errors found
                    {
                        return noErrorsMessage;
                    }
             }
             catch (XmlException e)
             {
                return errorMessage + "\n" + e.Message;
             }

        }

        public static string Xml2Json(string xmlUrl)
        {
            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))

            //Creating a string variable to hold the downloaded xml
            string downloadedXml = DownloadContent(xmlUrl);
            //Creating an XmlDocument object to load the xml into
            XmlDocument xmlDoc = new XmlDocument(); 
            xmlDoc.LoadXml(downloadedXml);
            xmlDoc.DocumentElement.RemoveAttribute("noNamespaceSchemaLocation","http://www.w3.org/2001/XMLSchema-instance");
            xmlDoc.DocumentElement.RemoveAttribute("xsi","http://www.w3.org/2000/xmlns/");
            //Using serialize to convert xml to json and hold it in jsonText variable
            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc.DocumentElement);
            return jsonText;
        }

        // Helper method to download content from URL
        private static string DownloadContent(string url)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }

}