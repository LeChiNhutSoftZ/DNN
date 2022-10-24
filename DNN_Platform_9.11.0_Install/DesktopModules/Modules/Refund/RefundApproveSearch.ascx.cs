using DotNetNuke.Entities.Modules.Prompt;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Definitions;
using DotNetNuke.Entities.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel.Protocols.WSTrust;
using System.Data;
using PetaPoco;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using DotNetNuke.Common.Controls;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Services.Social.Messaging.Internal.Views;

namespace Modules.Refund
{
    public partial class RefundApproveSearch : DotNetNuke.Entities.Modules.PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            ddlTab.Items.Add(new ListItem("Please select a Tab Page", "0", true));
            ddlModule.Items.Add(new ListItem("Please select a Module", "0", true));
            ddlDefinition.Items.Add(new ListItem("Please select a Definition", "0", true));
            bindStatusDropDownList();
        }
        private void bindStatusDropDownList()
        {
            
            //Tab info
            foreach(TabInfo tab in TabController.Instance.GetTabsByPortal(PortalId).Values)
            {
                if (tab.IsSuperTab && tab.DisableLink)
                {
                    continue;
                }
                string value = tab.TabID.ToString();
                string text = value + " - " + tab.TabName;
                ddlTab.Items.Add(new ListItem(text, value));
            }

            //Module Info
            foreach (DesktopModuleInfo module in DesktopModuleController.GetDesktopModules(PortalId).Values)
            {
                if (module.ModuleName.StartsWith("Modules.") == false)
                {
                    continue;
                }
                string value = module.DesktopModuleID.ToString();
                string text = value + " - " + module.ModuleName;
                ddlModule.Items.Add(new ListItem(text, value));
            }
        }
        protected void LoadTabModule(object sender, EventArgs e = null)
        {
            if(string.IsNullOrWhiteSpace(ddlTab.SelectedValue))
            {
                
            }
        }
        protected void LoadModuleDefinition(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ddlModule.SelectedValue))
            {
                return;
            }
            ddlDefinition.Items.Clear();
            ddlDefinition.ClearSelection();
            int desktopModuleID = int.Parse(ddlModule.SelectedValue);
            foreach(ModuleDefinitionInfo definition
                in ModuleDefinitionController.GetModuleDefinitionsByDesktopModuleID(desktopModuleID).Values)
            {
                string value = definition.DesktopModuleID.ToString();
                string test = value + " - " +definition.DefinitionName;
                ddlDefinition.Items.Add(new ListItem(test, value));
            }
        }
        protected void AddModule (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ddlDefinition.SelectedValue))
            {
                return ;
            }

            int tabID = int.Parse(ddlTab.SelectedValue);
            ModuleInfo module = new ModuleInfo
            {
                TabID = tabID,
                PortalID = PortalId,
                ModuleDefID = int.Parse(ddlDefinition.SelectedValue),
                ModuleTitle = ddlDefinition.SelectedItem.Attributes["DefinitionName"],
                CacheMethod = string.Empty,
                DisplayPrint = false,
                InheritViewPermissions = true,
                IsShareable = true,
                IsShareableViewOnly = true,
                PaneName = "ContentPane"
            };
            int result = ModuleController.Instance.AddModule(module);
            if(result > 0)
            {
                TabController.Instance.ClearCache(PortalId);
                LoadTabModule(module);
                Console.WriteLine("Add module definition success.");
                Console.WriteLine("hi");
                //("Add module definition success.", ModuleMessage.ModuleMessageType.GreenSuccess);
               
            }
            else
            {
                Console.WriteLine("Add module definition fail.");
                //Console.WriteLine("Add module definition fail.", ModuleMessage.ModuleMessageType.RedError);
            }
        }


    }
}