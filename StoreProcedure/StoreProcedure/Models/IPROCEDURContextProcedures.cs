﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreProcedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace StoreProcedure.Models
{
    public partial interface IPROCEDURContextProcedures
    {
        Task<List<GetCategoryHierarchyWParams1Result>> GetCategoryHierarchyWParams1Async(int? CategoryID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<IDLISTESIYLEGETIRMEResult>> IDLISTESIYLEGETIRMEAsync(DataTable CategoryIDList, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
