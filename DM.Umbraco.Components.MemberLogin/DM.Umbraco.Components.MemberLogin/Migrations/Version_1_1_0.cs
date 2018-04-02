using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;
using Umbraco.Core.Services;

namespace DM.MemberLogin.Migrations {
    [Migration("1.0.0", 1, "DM.MemberLogin")]
    public class Version_1_1_0 : MigrationBase {
        public Version_1_1_0(ISqlSyntaxProvider sqlSyntax, ILogger logger) : base(sqlSyntax, logger) {
        }

        public override void Up() {
			MacroService macroService = (MacroService)ApplicationContext.Current.Services.MacroService;
			if(macroService.GetByAlias("MemberLogin") == null){
				Macro memberLoginMacro = new Macro(
					"MemberLogin",
					"Member Login Form",
					scriptPath: "~/Views/MacroPartials/MemberLogin/Member Login.cshtml",
					useInEditor:true
				);

				macroService.Save(memberLoginMacro);
			}
        }

        public override void Down() {
            //Nothing to do!
        }
    }
}