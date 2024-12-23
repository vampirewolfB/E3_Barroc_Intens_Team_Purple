﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

#pragma warning disable 219, 612, 618
#nullable disable

namespace BarrocIntens.Models
{
    internal partial class ProductEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BarrocIntens.Models.Product",
                typeof(Product),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var description = runtimeEntityType.AddProperty(
                "Description",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("Description", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Description>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            description.TypeMapping = MySqlStringTypeMapping.Default.Clone(
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
            description.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            description.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var expenseId = runtimeEntityType.AddProperty(
                "ExpenseId",
                typeof(int?),
                nullable: true);
            expenseId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                keyComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                providerValueComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)));
            expenseId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var imagePath = runtimeEntityType.AddProperty(
                "ImagePath",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("ImagePath", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ImagePath>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            imagePath.TypeMapping = MySqlStringTypeMapping.Default.Clone(
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
            imagePath.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            imagePath.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
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

            var price = runtimeEntityType.AddProperty(
                "Price",
                typeof(decimal),
                propertyInfo: typeof(Product).GetProperty("Price", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Price>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0m);
            price.TypeMapping = MySqlDecimalTypeMapping.Default.Clone(
                comparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                keyComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                providerValueComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "decimal(8,2)",
                    precision: 8,
                    scale: 2));
            price.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            price.AddAnnotation("Relational:ColumnType", "decimal(8, 2)");

            var productCategoryId = runtimeEntityType.AddProperty(
                "ProductCategoryId",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("ProductCategoryId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductCategoryId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            productCategoryId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
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
            productCategoryId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var quoteId = runtimeEntityType.AddProperty(
                "QuoteId",
                typeof(int?),
                nullable: true);
            quoteId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                keyComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)),
                providerValueComparer: new ValueComparer<int?>(
                    (Nullable<int> v1, Nullable<int> v2) => v1.HasValue && v2.HasValue && (int)v1 == (int)v2 || !v1.HasValue && !v2.HasValue,
                    (Nullable<int> v) => v.HasValue ? (int)v : 0,
                    (Nullable<int> v) => v.HasValue ? (Nullable<int>)(int)v : default(Nullable<int>)));
            quoteId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { expenseId });

            var index0 = runtimeEntityType.AddIndex(
                new[] { productCategoryId });

            var index1 = runtimeEntityType.AddIndex(
                new[] { quoteId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ExpenseId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType);

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Expense).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Expense).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("ProductCategoryId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var productCategory = declaringEntityType.AddNavigation("ProductCategory",
                runtimeForeignKey,
                onDependent: true,
                typeof(ProductCategory),
                propertyInfo: typeof(Product).GetProperty("ProductCategory", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductCategory>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey3(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("QuoteId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType);

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Quote).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Quote).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Products");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
