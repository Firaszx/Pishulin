using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
namespace XMLExample
{
    public class DocumentChange
    {
        public static void Check<T>(string PathTo,T Temp)
        {
            Type MyType = Temp.GetType();           
            String NewFname = Path.Combine(Path.GetDirectoryName(PathTo), "qwd.docx");
            File.Copy(PathTo, NewFname, true);                           
                using (WordprocessingDocument NewDoc = WordprocessingDocument.Open(NewFname, true))
                {
                    PropertyInfo[] properties = MyType.GetProperties();
                    if (properties.Length > 0)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            //Console.WriteLine(property.Name); 
                            foreach (var paragraph in NewDoc.MainDocumentPart.Document.Descendants<Paragraph>())
                            {
                                if (paragraph != null)//?
                                {
                                    foreach (var run in paragraph.Descendants<Run>())
                                    {
                                    foreach (var text in run.Descendants<Text>())
                                    {
                                        if (text.Text.Contains('{' + property.Name + '}'))
                                        {                                           
                                            text.Text = text.Text.Replace('{'+property.Name +'}',property.GetValue(Temp).ToString() ); //properties.GetValue
                                        }
                                    }
                                    }
                                }
                                NewDoc.MainDocumentPart.Document.Save();
                            }
                        }
                    }
                }
              

        }
    }
}