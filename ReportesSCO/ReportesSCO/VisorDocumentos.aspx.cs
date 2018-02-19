using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Telerik.Web.UI;
using Telerik.Web.UI.Widgets;

namespace ReportesSCO
{
    public partial class VisorDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var parametro = Request.QueryString["parametrosurl"].ToString();
                if (parametro == null || parametro != "UmVwb3NpdG9yaW pQ2lkaW1pcG4=")
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    //be sure to set content provider first before doing anything involving paths (e.g. set InitialPath)
                    RadFileExplorer.Configuration.ContentProviderTypeName = typeof(CustomColumnsContentProvider).AssemblyQualifiedName;
                    //RadFileExplorer.InitialPath = Page.ResolveUrl("~/FileExplorer/ExplorerSource/images/Customers/");
                    AddGridColumn("Fecha Modificación", "Datemodi", true);
                    //AddGridColumn("Owner Name", "Owner", false);
                }
            }


            ///AddDateAndOwnerColumns();
        }
        ////private void RemoveGridColumn(string uniqueName)
        ////{
        ////    if (!Object.Equals(RadFileExplorer.Grid.Columns.FindByUniqueNameSafe(uniqueName), null))
        ////    {
        ////        RadFileExplorer.Grid.Columns.Remove(RadFileExplorer.Grid.Columns.FindByUniqueNameSafe(uniqueName));
        ////    }
        ////}

        ////private void AddDateAndOwnerColumns()
        ////{
        ////    if (AddDateColumn.Checked)
        ////    {
        ////        AddGridColumn("Creation Date", "Date", true);
        ////    }
        ////    else
        ////    {
        ////        RemoveGridColumn("Date");
        ////    }

        ////    if (AddOwnerColumn.Checked)
        ////    {
        ////        AddGridColumn("Owner Name", "Owner", false);
        ////    }
        ////    else
        ////    {
        ////        RemoveGridColumn("Owner");
        ////    }

        ////}

        private void AddGridColumn(string name, string uniqueName, bool sortable)
        {
            //remove first if grid has a column with that name
            ////RemoveGridColumn(uniqueName);
            // Add a new column with the specified name
            GridTemplateColumn gridTemplateColumn1 = new GridTemplateColumn();
            gridTemplateColumn1.HeaderText = name;
            if (sortable)
                gridTemplateColumn1.SortExpression = uniqueName;
            gridTemplateColumn1.UniqueName = uniqueName;
            gridTemplateColumn1.DataField = uniqueName;

            RadFileExplorer.Grid.Columns.Add(gridTemplateColumn1);
        }

        protected void RadFileExplorer1_ExplorerPopulated(object sender, RadFileExplorerPopulatedEventArgs e)
        {
            //implement sorting for the custom Date column
            string sortingColumn = e.SortColumnName;

            //string script = string.Format("alert('{0}');", sortingColumn);

            //if (sortingColumn == "Date")
            //{
            //    DateComparer dc = new DateComparer();
            //    e.List.Sort(dc);
            //    if (e.SortDirection.IndexOf("DESC") != -1)
            //    {
            //        //reverse order
            //        e.List.Reverse();
            //    }
            //}
            if (sortingColumn == "Datemodi")
            {
                DateComparer dc = new DateComparer();
                e.List.Sort(dc);
                if (e.SortDirection.IndexOf("DESC") != -1)
                {
                    //reverse order
                    e.List.Reverse();
                }
            }
        }

        public class DateComparer : IComparer<FileBrowserItem>
        {
            int IComparer<FileBrowserItem>.Compare(FileBrowserItem item1, FileBrowserItem item2)
            {
                //treat folders separate from files
                DateTime date1 = DateTime.Parse(item1.Attributes["Datemodi"]);
                DateTime date2 = DateTime.Parse(item2.Attributes["Datemodi"]);
                if (item1 is DirectoryItem)
                {
                    if (item2 is DirectoryItem)
                    {
                        return DateTime.Compare(date1, date2);
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (item2 is DirectoryItem)
                    {
                        return 1;
                    }
                    else
                    {
                        return DateTime.Compare(date1, date2);
                    }
                }
            }
        }

        public class CustomColumnsContentProvider : FileSystemContentProvider
        {
            public CustomColumnsContentProvider(HttpContext context, string[] searchPatterns, string[] viewPaths, string[] uploadPaths, string[] deletePaths, string selectedUrl, string selectedItemTag)
                : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
            {
                // Declaring a constructor is required when creating a custom content provider class
            }

            public override DirectoryItem ResolveDirectory(string path)
            {
                // Update all file items with the additional information (date, owner)
                DirectoryItem oldItem = base.ResolveDirectory(path);

                foreach (FileItem fileItem in oldItem.Files)
                {
                    // Get the information from the physical file
                    FileInfo fInfo = new FileInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(oldItem.Path) + fileItem.Name));

                    // Add the information to the attributes collection of the item. It will be automatically picked up by the FileExplorer
                    // If the name attribute matches the unique name of a grid column

                    fileItem.Attributes.Add("Datemodi", fInfo.CreationTime.ToString());

                    // Type targetType = typeof(System.Security.Principal.NTAccount);
                    // string value = fInfo.GetAccessControl().GetOwner(targetType).Value.Replace("\\", "\\\\");
                    //string ownerName = "Telerik";
                    //fileItem.Attributes.Add("Owner", ownerName);
                }

                return oldItem;
            }

            public override DirectoryItem ResolveRootDirectoryAsTree(string path)
            {
                // Update all directory items with the additional information (date, owner)
                //DirectoryItem oldItem = base.ResolveRootDirectoryAsTree(    path);

                DirectoryItem oldItem = base.ResolveRootDirectoryAsTree(path);



                foreach (DirectoryItem dirItem in oldItem.Directories)
                {
                    // Get the information from the physical directory
                    DirectoryInfo dInfo = new DirectoryInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(dirItem.Path)));

                    // Add the information to the attributes collection of the item. It will be automatically picked up by the FileExplorer
                    // If the name attribute matches the unique name of a grid column

                    dirItem.Attributes.Add("Datemodi", dInfo.LastWriteTime.ToString());

                    //Type targetType = typeof(System.Security.Principal.NTAccount);
                    //string value = dInfo.GetAccessControl().GetOwner(targetType).Value.Replace("\\", "\\\\");
                    //string ownerName = "Telerik";
                    //dirItem.Attributes.Add("Owner", ownerName);
                }

                //oldItem.Files.OrderBy(f => f.Name);
                return oldItem;
            }
        }
    }
}