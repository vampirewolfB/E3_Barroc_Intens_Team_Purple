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
    internal partial class UserEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "BarrocIntens.Models.User",
                typeof(User),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(User).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
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

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(User).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
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
                    storeTypeName: "varchar(45)",
                    size: 45));
            name.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            name.AddAnnotation("Relational:ColumnType", "varchar(45)");

            var password = runtimeEntityType.AddProperty(
                "Password",
                typeof(string),
                propertyInfo: typeof(User).GetProperty("Password", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<Password>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            password.TypeMapping = MySqlStringTypeMapping.Default.Clone(
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
            password.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            password.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var roleId = runtimeEntityType.AddProperty(
                "RoleId",
                typeof(int),
                propertyInfo: typeof(User).GetProperty("RoleId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<RoleId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0);
            roleId.TypeMapping = MySqlIntTypeMapping.Default.Clone(
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
            roleId.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);

            var userName = runtimeEntityType.AddProperty(
                "UserName",
                typeof(string),
                propertyInfo: typeof(User).GetProperty("UserName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<UserName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            userName.TypeMapping = MySqlStringTypeMapping.Default.Clone(
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
            userName.AddAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.None);
            userName.AddAnnotation("Relational:ColumnType", "varchar(255)");

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { roleId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("RoleId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var role = declaringEntityType.AddNavigation("Role",
                runtimeForeignKey,
                onDependent: true,
                typeof(Role),
                propertyInfo: typeof(User).GetProperty("Role", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(User).GetField("<Role>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var users = principalEntityType.AddNavigation("Users",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<User>),
                propertyInfo: typeof(Role).GetProperty("Users", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Role).GetField("<Users>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "User");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
