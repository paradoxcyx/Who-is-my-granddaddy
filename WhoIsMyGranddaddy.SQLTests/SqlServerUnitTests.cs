using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace WhoIsMyGranddaddy.SQLTests
{
    [TestClass()]
    public class SqlServerUnitTests : SqlDatabaseTestClass
    {

        public SqlServerUnitTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetDescendantsByIdentityNumberTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerUnitTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetRootAscendantsByIdentityNumberTest_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition checksumCondition1;
            this.site_GetDescendantsByIdentityNumberTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.site_GetRootAscendantsByIdentityNumberTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            site_GetDescendantsByIdentityNumberTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            site_GetRootAscendantsByIdentityNumberTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            checksumCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            // 
            // site_GetDescendantsByIdentityNumberTest_TestAction
            // 
            site_GetDescendantsByIdentityNumberTest_TestAction.Conditions.Add(checksumCondition1);
            resources.ApplyResources(site_GetDescendantsByIdentityNumberTest_TestAction, "site_GetDescendantsByIdentityNumberTest_TestAction");
            // 
            // site_GetRootAscendantsByIdentityNumberTest_TestAction
            // 
            resources.ApplyResources(site_GetRootAscendantsByIdentityNumberTest_TestAction, "site_GetRootAscendantsByIdentityNumberTest_TestAction");
            // 
            // site_GetDescendantsByIdentityNumberTestData
            // 
            this.site_GetDescendantsByIdentityNumberTestData.PosttestAction = null;
            this.site_GetDescendantsByIdentityNumberTestData.PretestAction = null;
            this.site_GetDescendantsByIdentityNumberTestData.TestAction = site_GetDescendantsByIdentityNumberTest_TestAction;
            // 
            // site_GetRootAscendantsByIdentityNumberTestData
            // 
            this.site_GetRootAscendantsByIdentityNumberTestData.PosttestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTestData.PretestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTestData.TestAction = site_GetRootAscendantsByIdentityNumberTest_TestAction;
            // 
            // checksumCondition1
            // 
            checksumCondition1.Checksum = "1767318493";
            checksumCondition1.Enabled = true;
            checksumCondition1.Name = "checksumCondition1";
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void site_GetDescendantsByIdentityNumberTest()
        {
            SqlDatabaseTestActions testActions = this.site_GetDescendantsByIdentityNumberTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }

        [TestMethod()]
        public void site_GetRootAscendantsByIdentityNumberTest()
        {
            SqlDatabaseTestActions testActions = this.site_GetRootAscendantsByIdentityNumberTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions site_GetDescendantsByIdentityNumberTestData;
        private SqlDatabaseTestActions site_GetRootAscendantsByIdentityNumberTestData;
    }
}
