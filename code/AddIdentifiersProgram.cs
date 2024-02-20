using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace JsonParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string baseFolder = @"C:\Users\Family\Documents\Docs\en\";
            string folder = "word-processing";

            string[] mdFiles = GetMDFiles(baseFolder + folder);

            foreach (string filePath in mdFiles)
            {
                // Read the contents of the .md file
                string combinedText = File.ReadAllText(filePath);

                string jsonCont = FindJsonContent(combinedText);

                if (!string.IsNullOrEmpty(jsonCont))
                {
                    bool identifierExist = CheckIfIdentifierExist(jsonCont);

                    if (!identifierExist)
                    {
                        // Deserialize the JSON content into a JsonDocument
                        JObject jsonObject = JObject.Parse(jsonCont);

                        string identifier = GetIdentifier(folder, filePath, "");
                        jsonObject["menu"]["docs"]["identifier"] = identifier;

                        string updatedJsonString = jsonObject.ToString(Formatting.Indented);

                        string modifiedMdContent = combinedText.Replace(jsonCont, updatedJsonString);

                        // Write the modified content back to the .md file
                        File.WriteAllText(filePath, modifiedMdContent);
                    }
                }//if
            }//foreach

        }//main

        static string GetIdentifier(string folder, string filePath, string langCode)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string ident = folder + "-" + filename;

            if (!string.IsNullOrEmpty(langCode))
            {
                //ident = ident + "-" + langCode;
                ident = ident.Replace(".", "-");
            }

            return ident;
        }

        static string FindJsonContent(string combinedText)
        {
            //if the file is in Toml
            if (combinedText.Length >= 3 && combinedText.Substring(0, 3) == "---")
            {
                return "";
            }


            Stack<char> stack = new Stack<char>();
            int startIndex = combinedText.IndexOf("{");
            for (int i = startIndex; i < combinedText.Length; i++)
            {
                char c = combinedText[i];
                if (c == '{')
                {
                    stack.Push(c);
                }
                else if (c == '}')
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        // Found the end of the JSON object
                        string jsonContent = combinedText.Substring(startIndex, i - startIndex + 1);

                        // Deserialize the JSON content into a JsonDocument
                        JObject jsonObject = JObject.Parse(jsonContent);

                        if (jsonObject != null)
                        {
                            if (jsonContent.Contains("lastmod"))
                                return jsonContent;
                        }


                        break;
                    }
                }
            }//for

            return "";
        }


        static bool CheckIfIdentifierExist(string jsonContent)
        {
            // Deserialize the JSON content into a JsonDocument
            JObject jsonObject = JObject.Parse(jsonContent);

            var menu = jsonObject["menu"];

            if (menu != null)
            {
                var docs = menu["docs"];

                if (docs != null)
                {
                    var ident = docs["identifier"];

                    if (ident != null)
                        return true;
                }
            }

            return false;
        }

        static string[] GetMDFiles(string folderPath)
        {
            //string folderPath = @"C:\path\to\your\folder";

            // Check if the directory exists
            if (Directory.Exists(folderPath))
            {
                // Get all .md files in the folder
                string[] mdFiles = Directory.GetFiles(folderPath, "*.md");

                // Exclude _index.md files
                mdFiles = mdFiles.Where(file => !Path.GetFileName(file).Equals("_index.md", StringComparison.OrdinalIgnoreCase)).ToArray();

                return mdFiles;

                // Loop through each .md file
                foreach (string file in mdFiles)
                {
                    Console.WriteLine("File Name: " + Path.GetFileName(file));
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }

            return null;
        }//GetMDFiles
    }//Program


}
