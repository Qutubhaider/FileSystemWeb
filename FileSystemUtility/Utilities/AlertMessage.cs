using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemUtility.Utilities
{
    public static class AlertMessage
    {
        public const string RecordAdded = "{0} saved successfully.";
        public const string RecordUpdated = "{0} updated successfully.";
        public const string RecordDeleted = "{0} deleted successfully.";
        public const string OperationalError = "Operational error in {0}.";

        #region Project

        public const string SaveProject = "Project saved successfully.";

        #endregion
    }
}
