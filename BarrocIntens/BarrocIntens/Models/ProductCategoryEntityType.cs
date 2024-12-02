﻿// <auto-generated />
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

#pragma warning disable 219, 612, 618
#nullable disable

namespace BarrocIntens.Models
{
    internal partial class ProductCategoryEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BarrocIntens.Models.ProductCategory",
                typeof(ProductCategory),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(ProductCategory).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ProductCategory).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var isEmployeeOnly = runtimeEntityType.AddProperty(
                "IsEmployeeOnly",
                typeof(bool),
                propertyInfo: typeof(ProductCategory).GetProperty("IsEmployeeOnly", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ProductCategory).GetField("<IsEmployeeOnly>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            isEmployeeOnly.TypeMapping = MySqlSByteTypeMapping.Default.Clone(
                comparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                keyComparer: new ValueComparer<bool>(
                    (bool v1, bool v2) => v1 == v2,
                    (bool v) => v.GetHashCode(),
                    (bool v) => v),
                providerValueComparer: new ValueComparer<sbyte>(
                    (sbyte v1, sbyte v2) => v1 == v2,
                    (sbyte v) => (int)v,
                    (sbyte v) => v),
                converter: new ValueConverter<bool, sbyte>(
                    (bool v) => (sbyte)(v ? 1 : 0),
                    (sbyte v) => v == 1),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<bool, sbyte>(
                    JsonSByteReaderWriter.Instance,
                    new ValueConverter<bool, sbyte>(
                        (bool v) => (sbyte)(v ? 1 : 0),
                        (sbyte v) => v == 1)));
            isEmployeeOnly.SetSentinelFromProviderValue((sbyte)0);
            isEmployeeOnly.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            isEmployeeOnly.AddAnnotation("Relational:ColumnType", "tinyint");

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(ProductCategory).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(ProductCategory).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
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

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            return runtimeEntityType;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "ProductCategories");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
