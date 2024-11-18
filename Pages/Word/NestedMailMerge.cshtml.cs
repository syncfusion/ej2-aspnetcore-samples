#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Xml;

namespace EJ2CoreSampleBrowser.Pages.Word;

public class NestedMailMerge : PageModel
{
    public void OnGet()
    {
        
    }
    private readonly IWebHostEnvironment _hostingEnvironment;

    public NestedMailMerge(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult OnPost(string Group1, string Group2, string Group3, string Button)
    {
        if (Group1 == null || Group2 == null || Group3 == null)
            return null;
            // return View();
        string basePath = _hostingEnvironment.WebRootPath;

        string dataPath = string.Empty;
        if (Group2 == "Report")
            dataPath = basePath + @"/Word/Template_Report.doc";
        else
            dataPath = basePath + @"/Word/Template_Letter.doc";

        string contenttype1 = "application/msword";
        string dataPath1 = basePath + @"/Word/Template_Report.doc";
        string dataPath2 = basePath + @"/Word/Template_Letter.doc";
        FileStream fileStream1 = new FileStream(dataPath1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        FileStream fileStream2 = new FileStream(dataPath2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        if (Button == "View Template")
        {
            if (Group2 == "Report")
                return File(fileStream1, contenttype1, "Template_Report.doc");
            else
                return File(fileStream2, contenttype1, "Template_Letter.doc");
        }

        fileStream1.Dispose();
        fileStream1 = null;
        fileStream2.Dispose();
        fileStream2 = null;
        // Creating a new document.
        WordDocument document = new WordDocument();
        // Load template
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        document.Open(fileStream, FormatType.Doc);
        fileStream.Dispose();
        fileStream = null;

        #region Execute Mail merge

        if (Group3 == "Explicit")
        {
            MailMergeDataSet dataSet = GetMailMergeDataSet(basePath);
            List<DictionaryEntry> commands = new List<DictionaryEntry>();
            //DictionaryEntry contain "Source table" (KEY) and "Command" (VALUE)
            DictionaryEntry entry = new DictionaryEntry("Employees", string.Empty);
            commands.Add(entry);

            // To retrive customer details
            entry = new DictionaryEntry("Customers", "EmployeeID = %Employees.EmployeeID%");
            commands.Add(entry);

            // To retrieve order details
            entry = new DictionaryEntry("Orders", "CustomerID = %Customers.CustomerID%");
            commands.Add(entry);

            //Executes nested Mail merge using explicit relational data.
            document.MailMerge.ExecuteNestedGroup(dataSet, commands);
        }
        else
        {
            MailMergeDataTable dataTable = GetMailMergeDataTable(basePath);
            //Executes nested Mail merge using implicit relational data.
            document.MailMerge.ExecuteNestedGroup(dataTable);
        }

        #endregion

        FormatType type = FormatType.Docx;
        string filename = "NestedMailMerge.docx";
        string contenttype = "application/vnd.ms-word.document.12";

        #region Document SaveOption

        //Save as .doc format
        if (Group1 == "WordDoc")
        {
            type = FormatType.Doc;
            filename = "NestedMailMerge.doc";
            contenttype = "application/msword";
        }
        //Save as .xml format
        else if (Group1 == "WordML")
        {
            type = FormatType.WordML;
            filename = "NestedMailMerge.xml";
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
    /// Gets the mail merge data set.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private MailMergeDataSet GetMailMergeDataSet(string basePath)
    {
        List<EmployeeDetails> employees = new List<EmployeeDetails>();
        List<CustomerDetails> customers = new List<CustomerDetails>();
        List<OrderDetails> orders = new List<OrderDetails>();

        FileStream stream = new FileStream(basePath + @"/Word/Employees.xml", FileMode.OpenOrCreate);

        XmlReader reader = XmlReader.Create(stream);

        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "EmployeesList")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        while (reader.LocalName != "EmployeesList")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "Employees":
                        employees.Add(GetEmployee(reader, customers, orders));
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "EmployeesList") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        reader.Dispose();
        stream.Dispose();
        MailMergeDataSet dataSet = new MailMergeDataSet();
        dataSet.Add(new MailMergeDataTable("Employees", employees));
        dataSet.Add(new MailMergeDataTable("Customers", customers));
        dataSet.Add(new MailMergeDataTable("Orders", orders));
        return dataSet;
    }

    /// <summary>
    /// Gets the employee.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="customers">The customers.</param>
    /// <param name="orders">The orders.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private EmployeeDetails GetEmployee(XmlReader reader, List<CustomerDetails> customers, List<OrderDetails> orders)
    {
        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "Employees")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        EmployeeDetails employee = new EmployeeDetails();
        while (reader.LocalName != "Employees")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "EmployeeID":
                        employee.EmployeeID = reader.ReadElementContentAsString();
                        break;
                    case "LastName":
                        employee.LastName = reader.ReadElementContentAsString();
                        break;
                    case "FirstName":
                        employee.FirstName = reader.ReadElementContentAsString();
                        break;
                    case "Address":
                        employee.Address = reader.ReadElementContentAsString();
                        break;
                    case "City":
                        employee.City = reader.ReadElementContentAsString();
                        break;
                    case "Country":
                        employee.Country = reader.ReadElementContentAsString();
                        break;
                    case "Extension":
                        employee.Extension = reader.ReadElementContentAsString();
                        break;
                    case "Customers":
                        customers.Add(GetCustomer(reader, orders));
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "Employees") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return employee;
    }

    /// <summary>
    /// Gets the customer.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="orders">The orders.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private CustomerDetails GetCustomer(XmlReader reader, List<OrderDetails> orders)
    {
        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "Customers")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        CustomerDetails customer = new CustomerDetails();
        while (reader.LocalName != "Customers")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "EmployeeID":
                        customer.EmployeeID = reader.ReadElementContentAsString();
                        break;
                    case "CustomerID":
                        customer.CustomerID = reader.ReadElementContentAsString();
                        break;
                    case "CompanyName":
                        customer.CompanyName = reader.ReadElementContentAsString();
                        break;
                    case "ContactName":
                        customer.ContactName = reader.ReadElementContentAsString();
                        break;
                    case "City":
                        customer.City = reader.ReadElementContentAsString();
                        break;
                    case "Country":
                        customer.Country = reader.ReadElementContentAsString();
                        break;
                    case "Orders":
                        orders.Add(GetOrders(reader));
                        break;
                }

                reader.Read();
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "Customers") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return customer;
    }

    /// <summary>
    /// Gets the mail merge data table.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private MailMergeDataTable GetMailMergeDataTable(string basePath)
    {
        List<EmployeeDetailsImplicit> employees = new List<EmployeeDetailsImplicit>();

        FileStream stream = new FileStream(basePath + @"/Word/Employees.xml", FileMode.OpenOrCreate);

        XmlReader reader = XmlReader.Create(stream);

        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "EmployeesList")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        while (reader.LocalName != "EmployeesList")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "Employees":
                        employees.Add(GetEmployee(reader));
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "EmployeesList") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        reader.Dispose();
        stream.Dispose();
        MailMergeDataTable dataTable = new MailMergeDataTable("Employees", employees);
        return dataTable;
    }

    /// <summary>
    /// Gets the employee.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private EmployeeDetailsImplicit GetEmployee(XmlReader reader)
    {
        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "Employees")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        EmployeeDetailsImplicit employee = new EmployeeDetailsImplicit();
        while (reader.LocalName != "Employees")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "EmployeeID":
                        employee.EmployeeID = reader.ReadElementContentAsString();
                        break;
                    case "LastName":
                        employee.LastName = reader.ReadElementContentAsString();
                        break;
                    case "FirstName":
                        employee.FirstName = reader.ReadElementContentAsString();
                        break;
                    case "Address":
                        employee.Address = reader.ReadElementContentAsString();
                        break;
                    case "City":
                        employee.City = reader.ReadElementContentAsString();
                        break;
                    case "Country":
                        employee.Country = reader.ReadElementContentAsString();
                        break;
                    case "Extension":
                        employee.Extension = reader.ReadElementContentAsString();
                        break;
                    case "Customers":
                        employee.Customers.Add(GetCustomer(reader));
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "Employees") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return employee;
    }

    /// <summary>
    /// Gets the customer.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private CustomerDetailsImplicit GetCustomer(XmlReader reader)
    {
        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "Customers")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        CustomerDetailsImplicit customer = new CustomerDetailsImplicit();
        while (reader.LocalName != "Customers")
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.LocalName)
                {
                    case "EmployeeID":
                        customer.EmployeeID = reader.ReadElementContentAsString();
                        break;
                    case "CustomerID":
                        customer.CustomerID = reader.ReadElementContentAsString();
                        break;
                    case "CompanyName":
                        customer.CompanyName = reader.ReadElementContentAsString();
                        break;
                    case "ContactName":
                        customer.ContactName = reader.ReadElementContentAsString();
                        break;
                    case "City":
                        customer.City = reader.ReadElementContentAsString();
                        break;
                    case "Country":
                        customer.Country = reader.ReadElementContentAsString();
                        break;
                    case "Orders":
                        customer.Orders.Add(GetOrders(reader));
                        break;
                }

                reader.Read();
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "Customers") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return customer;
    }

    /// <summary>
    /// Gets the orders.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">reader</exception>
    /// <exception cref="XmlException">Unexpected xml tag  + reader.LocalName</exception>
    private OrderDetails GetOrders(XmlReader reader)
    {
        if (reader == null)
            throw new Exception("reader");

        while (reader.NodeType != XmlNodeType.Element)
            reader.Read();

        if (reader.LocalName != "Orders")
            throw new XmlException("Unexpected xml tag " + reader.LocalName);

        reader.Read();

        while (reader.NodeType == XmlNodeType.Whitespace)
            reader.Read();

        OrderDetails order = new OrderDetails();
        while (reader.LocalName != "Orders")
        {
            if (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.LocalName)
                {
                    case "OrderID":
                        order.OrderID = reader.ReadElementContentAsString();
                        break;
                    case "CustomerID":
                        order.CustomerID = reader.ReadElementContentAsString();
                        break;
                    case "OrderDate":
                        order.OrderDate = reader.ReadElementContentAsString();
                        break;
                    case "RequiredDate":
                        order.RequiredDate = reader.ReadElementContentAsString();
                        break;
                    case "ShippedDate":
                        order.ShippedDate = reader.ReadElementContentAsString();
                        break;
                }

                reader.Read();
            }
            else
            {
                reader.Read();
                if ((reader.LocalName == "Orders") && reader.NodeType == XmlNodeType.EndElement)
                    break;
            }
        }

        return order;
    }
}

public class EmployeeDetailsImplicit
{
    #region Fields

    private string m_employeeID;
    private string m_lastName;
    private string m_firstName;
    private string m_address;
    private string m_city;
    private string m_country;
    private string m_extension;
    private List<CustomerDetailsImplicit> m_customers;

    #endregion

    #region Properties

    public string EmployeeID
    {
        get { return m_employeeID; }
        set { m_employeeID = value; }
    }

    public string LastName
    {
        get { return m_lastName; }
        set { m_lastName = value; }
    }

    public string FirstName
    {
        get { return m_firstName; }
        set { m_firstName = value; }
    }

    public string Address
    {
        get { return m_address; }
        set { m_address = value; }
    }

    public string City
    {
        get { return m_city; }
        set { m_city = value; }
    }

    public string Country
    {
        get { return m_country; }
        set { m_country = value; }
    }

    public string Extension
    {
        get { return m_extension; }
        set { m_extension = value; }
    }

    public List<CustomerDetailsImplicit> Customers
    {
        get
        {
            if (m_customers == null)
                m_customers = new List<CustomerDetailsImplicit>();
            return m_customers;
        }
        set { m_customers = value; }
    }

    #endregion

    #region Constructor

    public EmployeeDetailsImplicit()
    {
        m_customers = new List<CustomerDetailsImplicit>();
    }

    #endregion
}

public class CustomerDetailsImplicit
{
    #region Fields

    private string m_employeeID;
    private string m_customerID;
    private string m_companyName;
    private string m_city;
    private string m_country;
    private List<OrderDetails> m_orders;

    #endregion

    #region Properties

    public List<OrderDetails> Orders
    {
        get
        {
            if (m_orders == null)
                m_orders = new List<OrderDetails>();
            return m_orders;
        }
        set { m_orders = value; }
    }

    public string EmployeeID
    {
        get { return m_employeeID; }
        set { m_employeeID = value; }
    }

    public string CustomerID
    {
        get { return m_customerID; }
        set { m_customerID = value; }
    }

    public string CompanyName
    {
        get { return m_companyName; }
        set { m_companyName = value; }
    }

    public string ContactName
    {
        get { return m_companyName; }
        set { m_companyName = value; }
    }

    public string City
    {
        get { return m_city; }
        set { m_city = value; }
    }

    public string Country
    {
        get { return m_country; }
        set { m_country = value; }
    }

    #endregion

    #region Constructor

    public CustomerDetailsImplicit()
    {
        m_orders = new List<OrderDetails>();
    }

    #endregion
}

public class EmployeeDetails
{
    #region Fields

    private string m_employeeID;
    private string m_lastName;
    private string m_firstName;
    private string m_address;
    private string m_city;
    private string m_country;
    private string m_extension;

    #endregion

    #region Properties

    public string EmployeeID
    {
        get { return m_employeeID; }
        set { m_employeeID = value; }
    }

    public string LastName
    {
        get { return m_lastName; }
        set { m_lastName = value; }
    }

    public string FirstName
    {
        get { return m_firstName; }
        set { m_firstName = value; }
    }

    public string Address
    {
        get { return m_address; }
        set { m_address = value; }
    }

    public string City
    {
        get { return m_city; }
        set { m_city = value; }
    }

    public string Country
    {
        get { return m_country; }
        set { m_country = value; }
    }

    public string Extension
    {
        get { return m_extension; }
        set { m_extension = value; }
    }

    #endregion
}

public class CustomerDetails
{
    #region Fields

    private string m_employeeID;
    private string m_customerID;
    private string m_companyName;
    private string m_city;
    private string m_country;

    #endregion

    #region Properties

    public string EmployeeID
    {
        get { return m_employeeID; }
        set { m_employeeID = value; }
    }

    public string CustomerID
    {
        get { return m_customerID; }
        set { m_customerID = value; }
    }

    public string CompanyName
    {
        get { return m_companyName; }
        set { m_companyName = value; }
    }

    public string ContactName
    {
        get { return m_companyName; }
        set { m_companyName = value; }
    }

    public string City
    {
        get { return m_city; }
        set { m_city = value; }
    }

    public string Country
    {
        get { return m_country; }
        set { m_country = value; }
    }

    #endregion
}

public class OrderDetails
{
    #region Fields

    private string m_orderID;
    private string m_customerID;
    private string m_orderDate;
    private string m_requiredDate;
    private string m_shippedDate;

    #endregion

    #region Properties

    public string OrderID
    {
        get { return m_orderID; }
        set { m_orderID = value; }
    }

    public string CustomerID
    {
        get { return m_customerID; }
        set { m_customerID = value; }
    }

    public string OrderDate
    {
        get { return m_orderDate; }
        set { m_orderDate = value; }
    }

    public string RequiredDate
    {
        get { return m_requiredDate; }
        set { m_requiredDate = value; }
    }

    public string ShippedDate
    {
        get { return m_shippedDate; }
        set { m_shippedDate = value; }
    }

    #endregion
}