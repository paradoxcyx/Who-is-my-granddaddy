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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerUnitTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction;
            this.site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            // 
            // site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction
            // 
            resources.ApplyResources(site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction, "site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction" +
                    "");
            // 
            // site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson_TestAction
            // 
            resources.ApplyResources(site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson_TestAction, "site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQue" +
                    "riedPerson_TestAction");
            // 
            // site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData
            // 
            this.site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData.PosttestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData.PretestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData.TestAction = site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize_TestAction;
            // 
            // site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData
            // 
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData.PosttestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData.PretestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData.TestAction = site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson_TestAction;
            // 
            // site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData
            // 
            this.site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData.PosttestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData.PretestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData.TestAction = site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull_TestAction;
            // 
            // site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull_TestAction
            // 
            resources.ApplyResources(site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull_TestAction, "site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherI" +
                    "d_ShouldBeNull_TestAction");
            // 
            // site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData
            // 
            this.site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData.PosttestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData.PretestAction = null;
            this.site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData.TestAction = site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction;
            // 
            // site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction
            // 
            resources.ApplyResources(site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction, "site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage_TestAction");
            // 
            // site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData
            // 
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData.PosttestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData.PretestAction = null;
            this.site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData.TestAction = site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction;
            // 
            // site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction
            // 
            resources.ApplyResources(site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction, "site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants_TestAction");
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
        public void site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSize()
        {
            SqlDatabaseTestActions testActions = this.site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData;
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
        public void site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPerson()
        {
            SqlDatabaseTestActions testActions = this.site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData;
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
        public void site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNull()
        {
            SqlDatabaseTestActions testActions = this.site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData;
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
        public void site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkage()
        {
            SqlDatabaseTestActions testActions = this.site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData;
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
        public void site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendants()
        {
            SqlDatabaseTestActions testActions = this.site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData;
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



        private SqlDatabaseTestActions site_GetDescendantsByIdentityNumberTest_RecordCountShouldMatchPageSizeData;
        private SqlDatabaseTestActions site_GetRootAscendantsByIdentityNumberTest_EnsureIfNoAscendantsFoundReturnBackQueriedPersonData;
        private SqlDatabaseTestActions site_GetDescendantsByIdentityNumberTest_FirstRecordOnFirstPage_FatherIdAndMotherId_ShouldBeNullData;
        private SqlDatabaseTestActions site_GetDescendantsByIdentityNumberTest_EnsureValidPartnerLinkageData;
        private SqlDatabaseTestActions site_GetRootAscendantsByIdentityNumberTest_EnsureCorrectAscendantsData;
    }
}
