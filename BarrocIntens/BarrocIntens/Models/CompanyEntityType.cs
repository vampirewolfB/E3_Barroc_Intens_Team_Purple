﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using BarrocIntens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Models
{
    internal partial class CompanyEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BarrocIntens.Models.Company",
                typeof(Company),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(Company).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var bkrCheckedAt = runtimeEntityType.AddProperty(
                "BkrCheckedAt",
                typeof(DateTime?),
                propertyInfo: typeof(Company).GetProperty("BkrCheckedAt", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<BkrCheckedAt>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            bkrCheckedAt.TypeMapping = MySqlDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                keyComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                providerValueComparer: new ValueComparer<DateTime?>(
                    (Nullable<DateTime> v1, Nullable<DateTime> v2) => v1.HasValue && v2.HasValue && (DateTime)v1 == (DateTime)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<DateTime> v) => v.HasValue ? ((DateTime)v).GetHashCode() : 0,
                    (Nullable<DateTime> v) => v.HasValue ? (Nullable<DateTime>)(DateTime)v : default(Nullable<DateTime>)),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "datetime(6)",
                    size: 6));
            bkrCheckedAt.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            bkrCheckedAt.AddAnnotation("Relational:ColumnType", "datetime(6)");

            var city = runtimeEntityType.AddProperty(
                "City",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("City", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<City>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            city.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(255)",
                    size: 255));
            city.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            city.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var countryCode = runtimeEntityType.AddProperty(
                "CountryCode",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("CountryCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<CountryCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            countryCode.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(3)",
                    size: 3));
            countryCode.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            countryCode.AddAnnotation("Relational:ColumnType", "varchar(3)");

            var houseNumber = runtimeEntityType.AddProperty(
                "HouseNumber",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("HouseNumber", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<HouseNumber>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            houseNumber.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(45)",
                    size: 45));
            houseNumber.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            houseNumber.AddAnnotation("Relational:ColumnType", "varchar(45)");

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            name.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(255)",
                    size: 255));
            name.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            name.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var phone = runtimeEntityType.AddProperty(
                "Phone",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("Phone", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<Phone>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            phone.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(255)",
                    size: 255));
            phone.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            phone.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var street = runtimeEntityType.AddProperty(
                "Street",
                typeof(string),
                propertyInfo: typeof(Company).GetProperty("Street", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<Street>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            street.TypeMapping = MySqlStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varchar(255)",
                    size: 255));
            street.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            street.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var userId = runtimeEntityType.AddProperty(
                "UserId",
                typeof(int),
                propertyInfo: typeof(Company).GetProperty("UserId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<UserId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            userId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
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
            userId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { userId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("UserId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var user = declaringEntityType.AddNavigation("User",
                runtimeForeignKey,
                onDependent: true,
                typeof(User),
                propertyInfo: typeof(Company).GetProperty("User", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Company).GetField("<User>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var company = principalEntityType.AddNavigation("Company",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Company>),
                propertyInfo: typeof(User).GetProperty("Company", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<Company>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Companies");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
