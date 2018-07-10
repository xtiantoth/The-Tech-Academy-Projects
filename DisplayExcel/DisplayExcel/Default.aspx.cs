using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace DisplayExcel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connecting to the Excel File
            string fileName = @"c:\Users\User\source\repos\DisplayExcel\DisplayExcel\App_Data\ExcelDatabase2.xlsx";
            string sConnectionString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source='{0}';Extended Properties='Excel 12.0 Xml;HDR=YES;'", fileName);

            OleDbConnection connectionObject = new OleDbConnection(sConnectionString);
            connectionObject.Open();

            
            //Selecting all data
            OleDbCommand selectionCommand = new OleDbCommand("SELECT * FROM [sheet1$]", connectionObject);

            OleDbDataAdapter objAdapter = new OleDbDataAdapter();

            objAdapter.SelectCommand = selectionCommand;

            
            //Copying data to DATATABLE
            DataSet ExcelDataset = new DataSet();   
            DataTable ExcelTable = new DataTable();
            objAdapter.Fill(ExcelDataset, "ImportedFromExcel");

            ExcelTable = ExcelDataset.Tables[0];

            
            //Clearing existing data in MDF file
            ConvertedFromExcelEntities2 mdf = new ConvertedFromExcelEntities2();
            string MDFtable = "ImportedFromExcel";
            string sqlSelect = "select * from "+MDFtable;
            string sqlDelete = "delete from " + MDFtable;

            mdf.Database.ExecuteSqlCommand(sqlSelect);
            mdf.Database.ExecuteSqlCommand(sqlDelete);

            
            //Adding data from Excel file to MDF database file
            foreach (DataRow row in ExcelTable.Rows)
            {
                mdf.ImportedFromExcels.Add(new ImportedFromExcel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Age = Convert.ToInt32(row["Age"])
                }
                    );
            }
            mdf.SaveChanges();

            connectionObject.Close();

            //Displaying data in GridView
            ConvertedFromExcelEntities2 db = new ConvertedFromExcelEntities2();
            List<ImportedFromExcel> allTables = new List<ImportedFromExcel>();
            foreach (var table in db.ImportedFromExcels)
            {
                ImportedFromExcel OneTable = new ImportedFromExcel();
                OneTable.Id = table.Id;
                OneTable.Name = table.Name;
                OneTable.Age = table.Age;
                allTables.Add(OneTable);
            }
            GridView1.DataSource = allTables;
            GridView1.DataBind();

        }
}
}