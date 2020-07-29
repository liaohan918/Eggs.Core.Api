using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;

namespace Eggs.Core.Api.Model.Seed
{
    public class FrameSeed
    {

        /// <summary>
        /// 生成Model层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <param name="isMuti"></param>
        /// <returns></returns>
        public static bool CreateModels(SqlSugarClient sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null)
        {

            try
            {
                Create_Model_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"C:\my-file\Eggs.Core.Api.Model", "Eggs.Core.Api.Model.Models", tableNames, "", isMuti);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 生成IRepository层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <returns></returns>
        public static bool CreateIRepositorys(SqlSugarClient sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null)
        {

            try
            {
                Create_IRepository_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"C:\my-file\Eggs.Core.Api.IRepository", "Eggs.Core.Api.IRepository", tableNames, "", isMuti);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        /// <summary>
        /// 生成 IService 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <returns></returns>
        public static bool CreateIServices(SqlSugarClient sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null)
        {

            try
            {
                Create_IServices_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"C:\my-file\Eggs.Core.Api.IServices", "Eggs.Core.Api.IServices", tableNames, "", isMuti);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        /// <summary>
        /// 生成 Repository 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <returns></returns>
        public static bool CreateRepository(SqlSugarClient sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null)
        {

            try
            {
                Create_Repository_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"C:\my-file\Eggs.Core.Api.Repository", "Eggs.Core.Api.Repository", tableNames, "", isMuti);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }



        /// <summary>
        /// 生成 Service 层
        /// </summary>
        /// <param name="sqlSugarClient">sqlsugar实例</param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="isMuti"></param>
        /// <param name="tableNames">数据库表名数组，默认空，生成所有表</param>
        /// <returns></returns>
        public static bool CreateServices(SqlSugarClient sqlSugarClient, string ConnId, bool isMuti = false, string[] tableNames = null)
        {

            try
            {
                Create_Services_ClassFileByDBTalbe(sqlSugarClient, ConnId, $@"C:\my-file\Eggs.Core.Api.Services", "Eggs.Core.Api.Services", tableNames, "", isMuti);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }





        #region 根据数据库表生产Model层

        /// <summary>
        /// 功能描述:根据数据库表生产Model层
        /// 作　　者:Eggs.Core.Api
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        /// <param name="blnSerializable">是否序列化</param>
        private static void Create_Model_ClassFileByDBTalbe(
          SqlSugarClient sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false,
          bool blnSerializable = false)
        {
            //多库文件分离
            if (isMuti)
            {
                strPath = strPath + @"\Models\" + ConnId;
                strNameSpace = strNameSpace + "." + ConnId;
            }

            var IDbFirst = sqlSugarClient.DbFirst;
            if (lstTableNames != null && lstTableNames.Length > 0)
            {
                IDbFirst = IDbFirst.Where(lstTableNames);
            }
            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

                  .SettingClassTemplate(p => p =
@"{using}

namespace " + strNameSpace + @"
{
{ClassDescription}
    [SugarTable( ""{ClassName}"", """ + ConnId + @""")]" + (blnSerializable ? "\n    [Serializable]" : "") + @"
    public class {ClassName}" + (string.IsNullOrEmpty(strInterface) ? "" : (" : " + strInterface)) + @"
    {
        public {ClassName}()
        {
        }
        {PropertyName}
    }
}")
                  .SettingPropertyDescriptionTemplate(p => p = string.Empty)
                  .SettingPropertyTemplate(p => p =
@"{SugarColumn}
           public {PropertyType} {PropertyName} { get; set; }")

                   //.SettingConstructorTemplate(p => p = "              this._{PropertyName} ={DefaultValue};")

                   .ToClassStringList(strNameSpace);
            CreateFilesByClassStringList(ls, strPath, "{0}");
        }
        #endregion


        #region 根据数据库表生产IRepository层

        /// <summary>
        /// 功能描述:根据数据库表生产IRepository层
        /// 作　　者:Eggs.Core.Api
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_IRepository_ClassFileByDBTalbe(
          SqlSugarClient sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false
            )
        {
            //多库文件分离
            if (isMuti)
            {
                strPath = strPath + @"\" + ConnId;
                strNameSpace = strNameSpace + "." + ConnId;
            }

            var IDbFirst = sqlSugarClient.DbFirst;
            if (lstTableNames != null && lstTableNames.Length > 0)
            {
                IDbFirst = IDbFirst.Where(lstTableNames);
            }
            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

                 .SettingClassTemplate(p => p =
@"using Eggs.Core.Api.IRepository.Base;
using Eggs.Core.Api.Model.Models" + (isMuti ? "." + ConnId + "" : "") + @";

namespace " + strNameSpace + @"
{
	/// <summary>
	/// I{ClassName}Repository
	/// </summary>	
    public interface I{ClassName}Repository : IBaseRepository<{ClassName}>" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
    }
}")

                  .ToClassStringList(strNameSpace);
            CreateFilesByClassStringList(ls, strPath, "I{0}Repository");
        }
        #endregion


        #region 根据数据库表生产IServices层

        /// <summary>
        /// 功能描述:根据数据库表生产IServices层
        /// 作　　者:Eggs.Core.Api
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_IServices_ClassFileByDBTalbe(
          SqlSugarClient sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false)
        {
            //多库文件分离
            if (isMuti)
            {
                strPath = strPath + @"\" + ConnId;
                strNameSpace = strNameSpace + "." + ConnId;
            }

            var IDbFirst = sqlSugarClient.DbFirst;
            if (lstTableNames != null && lstTableNames.Length > 0)
            {
                IDbFirst = IDbFirst.Where(lstTableNames);
            }
            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

                  .SettingClassTemplate(p => p =
@"using Eggs.Core.Api.IServices.BASE;
using Eggs.Core.Api.Model.Models" + (isMuti ? "." + ConnId + "" : "") + @";

namespace " + strNameSpace + @"
{	
	/// <summary>
	/// I{ClassName}Services
	/// </summary>	
    public interface I{ClassName}Services :IBaseServices<{ClassName}>" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
	{
    }
}")

                   .ToClassStringList(strNameSpace);
            CreateFilesByClassStringList(ls, strPath, "I{0}Services");
        }
        #endregion



        #region 根据数据库表生产 Repository 层

        /// <summary>
        /// 功能描述:根据数据库表生产 Repository 层
        /// 作　　者:Eggs.Core.Api
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_Repository_ClassFileByDBTalbe(
          SqlSugarClient sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false)
        {
            //多库文件分离
            if (isMuti)
            {
                strPath = strPath + @"\" + ConnId;
                strNameSpace = strNameSpace + "." + ConnId;
            }

            var IDbFirst = sqlSugarClient.DbFirst;
            if (lstTableNames != null && lstTableNames.Length > 0)
            {
                IDbFirst = IDbFirst.Where(lstTableNames);
            }
            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

                  .SettingClassTemplate(p => p =
@"using Eggs.Core.Api.IRepository" + (isMuti ? "." + ConnId + "" : "") + @";
using Eggs.Core.Api.IRepository.UnitOfWork;
using Eggs.Core.Api.Model.Models" + (isMuti ? "." + ConnId + "" : "") + @";
using Eggs.Core.Api.Repository.Base;

namespace " + strNameSpace + @"
{
	/// <summary>
	/// {ClassName}Repository
	/// </summary>
    public class {ClassName}Repository : BaseRepository<{ClassName}>, I{ClassName}Repository" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
        public {ClassName}Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}")
                  .ToClassStringList(strNameSpace);


            CreateFilesByClassStringList(ls, strPath, "{0}Repository");
        }
        #endregion


        #region 根据数据库表生产 Services 层

        /// <summary>
        /// 功能描述:根据数据库表生产 Services 层
        /// 作　　者:Eggs.Core.Api
        /// </summary>
        /// <param name="sqlSugarClient"></param>
        /// <param name="ConnId">数据库链接ID</param>
        /// <param name="strPath">实体类存放路径</param>
        /// <param name="strNameSpace">命名空间</param>
        /// <param name="lstTableNames">生产指定的表</param>
        /// <param name="strInterface">实现接口</param>
        /// <param name="isMuti"></param>
        private static void Create_Services_ClassFileByDBTalbe(
          SqlSugarClient sqlSugarClient,
          string ConnId,
          string strPath,
          string strNameSpace,
          string[] lstTableNames,
          string strInterface,
          bool isMuti = false)
        {
            //多库文件分离
            if (isMuti)
            {
                strPath = strPath + @"\" + ConnId;
                strNameSpace = strNameSpace + "." + ConnId;
            }

            var IDbFirst = sqlSugarClient.DbFirst;
            if (lstTableNames != null && lstTableNames.Length > 0)
            {
                IDbFirst = IDbFirst.Where(lstTableNames);
            }
            var ls = IDbFirst.IsCreateDefaultValue().IsCreateAttribute()

                  .SettingClassTemplate(p => p =
@"using Eggs.Core.Api.IRepository" + (isMuti ? "." + ConnId + "" : "") + @";
using Eggs.Core.Api.IServices" + (isMuti ? "." + ConnId + "" : "") + @";
using Eggs.Core.Api.Model.Models" + (isMuti ? "." + ConnId + "" : "") + @";
using Eggs.Core.Api.Services.BASE;

namespace " + strNameSpace + @"
{
    public partial class {ClassName}Services : BaseServices<{ClassName}>, I{ClassName}Services" + (string.IsNullOrEmpty(strInterface) ? "" : (" , " + strInterface)) + @"
    {
        private readonly I{ClassName}Repository _dal;
        public {ClassName}Services(I{ClassName}Repository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
    }
}")
                  .ToClassStringList(strNameSpace);

            CreateFilesByClassStringList(ls, strPath, "{0}Services");
        }
        #endregion


        #region 根据模板内容批量生成文件
        /// <summary>
        /// 根据模板内容批量生成文件
        /// </summary>
        /// <param name="ls">类文件字符串list</param>
        /// <param name="strPath">生成路径</param>
        /// <param name="fileNameTp">文件名格式模板</param>
        private static void CreateFilesByClassStringList(Dictionary<string, string> ls, string strPath, string fileNameTp)
        {

            foreach (var item in ls)
            {
                var fileName = $"{string.Format(fileNameTp, item.Key)}.cs";
                var fileFullPath = Path.Combine(strPath, fileName);
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                File.WriteAllText(fileFullPath, item.Value);
            }
        }
        #endregion
    }
}
