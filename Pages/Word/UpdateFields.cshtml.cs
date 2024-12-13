#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class UpdateFields : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;
    public UpdateFields(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public ActionResult OnPost(string Group1, string Button, string UnlinkFields)
    {
        string basePath = _hostingEnvironment.WebRootPath;
        string dataPath = basePath + @"/Word/TemplateUpdateFields.docx";
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (Group1 == null)
            return null;
            // return View();
        string contenttype1 = "application/vnd.ms-word.document.12";
        if (Button == "View Template")
        {
            return File(fileStream, contenttype1, "TemplateUpdateFields.docx");
        }

        //Loads the template document.
        string dataPathField = basePath + @"/Word/TemplateUpdateFields.docx";
        FileStream fileStreamField = new FileStream(dataPathField, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        WordDocument document = new WordDocument(fileStreamField, FormatType.Docx);
        fileStreamField.Dispose();
        fileStreamField = null;

        //Create MailMergeDataTable
        MailMergeDataTable mailMergeDataTableStock = GetMailMergeDataTableStock();
        // Execute Mail Merge with groups.
        document.MailMerge.ExecuteGroup(mailMergeDataTableStock);

        //Update fields in the document.
        document.UpdateDocumentFields();

        //Unlink the fields in Word document when UnlinkFields is enable.
        if (UnlinkFields == "UnlinkFields")
            UnlinkFieldsInDocument(document);

        FormatType type = FormatType.Docx;
        string filename = "Update Fields.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "Update Fields.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "Update Fields.xml";
            contenttype = "application/msword";
        }

        #endregion Document SaveOption

        MemoryStream ms = new MemoryStream();
        document.Save(ms, type);
        document.Close();
        ms.Position = 0;
        return File(ms, contenttype, filename);
    }

    /// <summary>
    /// Iterates to document elements and get fields.
    /// </summary>
    /// <param name="document">Input Word document.</param>
    /// <param name="fieldType">Type of the field to find in document.</param>
    private void UnlinkFieldsInDocument(WordDocument document)
    {
        //Iterates each section and get the tables.
        foreach (WSection section in document.Sections)
        {
            RemoveFieldCodesInTextBody(section.Body);
        }
    }

    /// <summary>
    /// Iterates into body items.
    /// </summary>
    private void RemoveFieldCodesInTextBody(WTextBody textBody)
    {
        for (int i = 0; i < textBody.ChildEntities.Count; i++)
        {
            //IEntity is the basic unit in DocIO DOM.                 
            IEntity bodyItemEntity = textBody.ChildEntities[i];

            //A Text body has 3 types of elements - Paragraph, Table, and Block Content Control
            //Decides the element type by using EntityType
            switch (bodyItemEntity.EntityType)
            {
                case EntityType.Paragraph:
                    WParagraph paragraph = bodyItemEntity as WParagraph;
                    //Iterates into paragraph items.
                    RemoveFieldCodesInParagraph(paragraph.Items);
                    break;

                case EntityType.Table:
                    //Table is a collection of rows and cells
                    //Iterates through table's DOM                        
                    RemoveFieldCodesInTable(bodyItemEntity as WTable);
                    break;

                case EntityType.BlockContentControl:
                    BlockContentControl blockContentControl = bodyItemEntity as BlockContentControl;
                    //Iterates to the body items of Block Content Control.
                    RemoveFieldCodesInTextBody(blockContentControl.TextBody);
                    break;
            }
        }
    }

    /// <summary>
    /// Iterates into paragraph items.
    /// </summary>
    /// <param name="paragraph">The paragraph.</param>
    /// <param name="fieldType">Type of field.</param>
    private void RemoveFieldCodesInParagraph(ParagraphItemCollection paraItems)
    {
        for (int i = 0; i < paraItems.Count; i++)
        {
            if (paraItems[i] is WField)
            {
                WField field = paraItems[i] as WField;
                field.Unlink();
            }
            else if (paraItems[i] is WTextBox)
            {
                //If paragraph item is textbox, iterates into textbody of textbox.
                WTextBox textBox = paraItems[i] as WTextBox;
                RemoveFieldCodesInTextBody(textBox.TextBoxBody);
            }
            else if (paraItems[i] is Shape)
            {
                //If paragraph item is shape, iterates into textbody of shape.
                Shape shape = paraItems[i] as Shape;
                RemoveFieldCodesInTextBody(shape.TextBody);
            }
            else if (paraItems[i] is InlineContentControl)
            {
                //If paragraph item is inline content control, iterates into its item.
                InlineContentControl inlineContentControl = paraItems[i] as InlineContentControl;
                RemoveFieldCodesInParagraph(inlineContentControl.ParagraphItems);
            }
        }
    }

    /// <summary>
    /// Iterates into table.
    /// </summary>
    /// <param name="table">The table.</param>
    /// <param name="fieldType">Type of Field.</param>
    private void RemoveFieldCodesInTable(WTable table)
    {
        //Iterates the row collection in a table
        foreach (WTableRow row in table.Rows)
        {
            //Iterates the cell collection in a table row
            foreach (WTableCell cell in row.Cells)
            {
                RemoveFieldCodesInTextBody(cell);
            }
        }
    }

    /// <summary>
    /// Gets the mail merge data table.
    /// </summary>       
    private MailMergeDataTable GetMailMergeDataTableStock()
    {
        List<StockDetails> stockDetails = new List<StockDetails>();
        FileStream fs = new FileStream(_hostingEnvironment.WebRootPath + @"/Word/StockDetails.xml", FileMode.Open,
            FileAccess.Read);
        XmlReader reader = XmlReader.Create(fs);
        if (reader == null)
            throw new Exception("reader");
        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();
        if (reader.LocalName != "StockMarket")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);
        reader.Read();
        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();
        while (reader.LocalName != "StockMarket")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "StockDetails":
                        stockDetails.Add(GetStockDetails(reader));
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "StockMarket") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        MailMergeDataTable dataTable = new MailMergeDataTable("StockDetails", stockDetails);
        reader.Dispose();
        fs.Dispose();
        return dataTable;
    }

    /// <summary>
    /// Gets the StockDetails.
    /// </summary>
    /// <param name="reader">The reader.</param>

    private StockDetails GetStockDetails(XmlReader reader)
    {
        if (reader == null)
            throw new Exception("reader");
        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();
        if (reader.LocalName != "StockDetails")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);
        reader.Read();
        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();
        StockDetails stockDetails = new StockDetails();
        while (reader.LocalName != "StockDetails")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "TradeNo":
                        stockDetails.TradeNo = reader.ReadElementContentAsString();
                        break;
                    case "CompanyName":
                        stockDetails.CompanyName = reader.ReadElementContentAsString();
                        break;
                    case "CostPrice":
                        stockDetails.CostPrice = reader.ReadElementContentAsString();
                        break;
                    case "SharesCount":
                        stockDetails.SharesCount = reader.ReadElementContentAsString();
                        break;
                    case "SalesPrice":
                        stockDetails.SalesPrice = reader.ReadElementContentAsString();
                        break;

                    default:
                        reader.Skip();
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "StockDetails") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return stockDetails;
    }
}

public class StockDetails
{
    #region Fields
    private string m_tradeNo;
    private string m_companyName;
    private string m_costPrice;
    private string m_sharesCount;
    private string m_salesPrice;        
    #endregion
    #region Properties
    public string TradeNo
    {
        get { return m_tradeNo; }
        set { m_tradeNo = value; }
    }
    public string CompanyName
    {
        get { return m_companyName; }
        set { m_companyName = value; }
    }
    public string CostPrice
    {
        get { return m_costPrice; }
        set { m_costPrice = value; }
    }
    public string SharesCount
    {
        get { return m_sharesCount; }
        set { m_sharesCount = value; }
    }
    public string SalesPrice
    {
        get { return m_salesPrice; }
        set { m_salesPrice = value; }
    }
       
    #endregion
    #region Constructor
    public StockDetails(string tradeNo, string companyName, string costPrice, string sharesCount, string salesPrice)
    {
        m_tradeNo = tradeNo;
        m_companyName = companyName;
        m_costPrice = costPrice;
        m_sharesCount = sharesCount;
        m_salesPrice = salesPrice;
    }
    public StockDetails()
    { }
    #endregion
}