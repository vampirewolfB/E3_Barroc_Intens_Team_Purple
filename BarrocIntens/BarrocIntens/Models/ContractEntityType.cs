﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

#pragma warning disable 219, 612, 618
#nullable disable

namespace BarrocIntens.Models
{
    internal partial class ContractEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BarrocIntens.Models.Contract",
                typeof(Contract),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(Contract).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0);
            id.TypeMapping = MySqlIntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            id.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            var companyId = runtimeEntityType.AddProperty(
                "CompanyId",
                typeof(int),
                propertyInfo: typeof(Contract).GetProperty("CompanyId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<CompanyId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            companyId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            companyId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var endDate = runtimeEntityType.AddProperty(
                "EndDate",
                typeof(DateTime),
                propertyInfo: typeof(Contract).GetProperty("EndDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<EndDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            endDate.TypeMapping = MySqlDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "datetime(6)",
                    size: 6));
            endDate.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            endDate.AddAnnotation("Relational:ColumnType", "datetime(6)");

            var startDate = runtimeEntityType.AddProperty(
                "StartDate",
                typeof(DateTime),
                propertyInfo: typeof(Contract).GetProperty("StartDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<StartDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            startDate.TypeMapping = MySqlDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "datetime(6)",
                    size: 6));
            startDate.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            startDate.AddAnnotation("Relational:ColumnType", "datetime(6)");

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(Contract.PaymentTypes),
                propertyInfo: typeof(Contract).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            type.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<Contract.PaymentTypes>(
                    (Contract.PaymentTypes v1, Contract.PaymentTypes v2) => object.Equals((object)v1, (object)v2),
                    (Contract.PaymentTypes v) => v.GetHashCode(),
                    (Contract.PaymentTypes v) => v),
                keyComparer: new ValueComparer<Contract.PaymentTypes>(
                    (Contract.PaymentTypes v1, Contract.PaymentTypes v2) => object.Equals((object)v1, (object)v2),
                    (Contract.PaymentTypes v) => v.GetHashCode(),
                    (Contract.PaymentTypes v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "enum('Monthly','Perodic')"),
                converter: new ValueConverter<Contract.PaymentTypes, string>(
                    (Contract.PaymentTypes v) => v.ToString(),
                    (string v) => StringEnumConverter<Contract.PaymentTypes, string, Contract.PaymentTypes>.ConvertToEnum(v)),
                storeTypePostfix: StoreTypePostfix.None,
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<Contract.PaymentTypes, string>(
                    JsonStringReaderWriter.Instance,
                    new ValueConverter<Contract.PaymentTypes, string>(
                        (Contract.PaymentTypes v) => v.ToString(),
                        (string v) => StringEnumConverter<Contract.PaymentTypes, string, Contract.PaymentTypes>.ConvertToEnum(v))));
            type.SetSentinelFromProviderValue("Monthly");
            type.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            type.AddAnnotation("Relational:ColumnType", "enum('Monthly','Perodic')");

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { companyId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("CompanyId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var company = declaringEntityType.AddNavigation("Company",
                runtimeForeignKey,
                onDependent: true,
                typeof(Company),
                propertyInfo: typeof(Contract).GetProperty("Company", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Contract).GetField("<Company>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var contracts = principalEntityType.AddNavigation("Contracts",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Contract>),
                propertyInfo: typeof(Company).GetProperty("Contracts", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<Contracts>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Contracts");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
