//@BaseCode

#if IDINT_ON
global using IdType = System.Int32;
#elif IDLONG_ON
global using IdType = System.Int64;
#elif IDGUID_ON
global using IdType = System.Guid;
#else
global using IdType = System.Int32;
#endif
global using Common = SETemplate.Common;
global using CommonEnums = SETemplate.Common.Enums;
global using CommonContracts = SETemplate.Common.Contracts;
global using CommonModels = SETemplate.Common.Models;
global using CommonModules = SETemplate.Common.Modules;
global using SETemplate.Common.Extensions;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.EntityFrameworkCore;

