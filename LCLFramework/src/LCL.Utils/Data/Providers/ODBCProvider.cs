﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LCL.Data.Providers
{
    internal class ODBCProvider : ISqlProvider
    {
        #region ISqlConverter Members

        public string ConvertToSpecialDbSql(string commonSql)
        {
            return ConverterFactory.ReParameterName.Replace(commonSql, "?p${number}");
        }

        public string GetParameterName(int number)
        {
            return "?p" + number;
        }

        public string ProcudureReturnParameterName
        {
            get { return "ReturnValue"; }
        }

        #endregion
    }
}
