using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace netstandar
{
    
    public class XMLUtil
    {
        private ArrayList Results = new ArrayList();
        private XmlTextReader Reader;

        public bool Validar(string XMLPath, string XSDPath, out string strError)
        {

            bool bRc = true;

            string strXSDParsed = "";
            Results.Clear();
            strError = "";

            try
            {
                strError += strXSDParsed;

                // 1- Read XML file content
                Reader = new XmlTextReader(XMLPath);

                // 2- Read Schema file content
                StreamReader SR = new StreamReader(XSDPath);

                // 3- Create a new instance of XmlSchema object
                XmlSchema Schema = new XmlSchema();


                // 4- Set XmlSchema object by calling XmlSchema.Read() method
                Schema = XmlSchema.Read(SR, new ValidationEventHandler(ValidationEventHandler));

                // 5- Create a new instance of XmlValidationReader object
                XmlValidatingReader ValidatingReader = new XmlValidatingReader(Reader);
                // 6- Set ValidationType for XmlValidationReader object
                ValidatingReader.ValidationType = ValidationType.Schema;
                // 7- Add Schema to XmlValidationReader Schemas collection
                ValidatingReader.Schemas.Add(Schema);

                // 8- Add your ValidationEventHandler address to 
                // XmlValidationReader's ValidationEventHandler
                ValidatingReader.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                // 9- Read XML content in a loop
                while (ValidatingReader.Read())
                { /*Empty loop*/}
                SR.Close();
                Reader.Close();
            }

            // try
            //Handle exceptions if you want
            catch (UnauthorizedAccessException AccessEx)
            {
                strError += AccessEx.ToString();
                bRc = false;
                throw AccessEx;
            }// catch
            catch (Exception Ex)
            {
                strError += Ex.ToString();
                bRc = false;
            }// catch
            finally
            {
                if (Results.Count > 0)
                {
                    foreach (string s in Results)
                        strError += string.Format("\n{0}", s);
                    bRc = false;
                }
            }

            return bRc;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            // 10- Implement your logic for each validation iteration
            string strTemp;
            strTemp = "Línea: " + this.Reader.LineNumber + " - Posición: " +
                this.Reader.LinePosition + " - " + args.Message;

            this.Results.Add(strTemp);
  
        }
    }
}
