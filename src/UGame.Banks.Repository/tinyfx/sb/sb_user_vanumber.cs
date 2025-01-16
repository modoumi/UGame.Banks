/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2023-10-24 16: 52:31
 ******************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using MySql.Data.MySqlClient;
using System.Text;
using TinyFx.Data.MySql;

namespace UGame.Banks.Repository
{
	#region EO
	/// <summary>
	/// 用户与虚拟账号对应关系
	/// 【表 sb_user_vanumber 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_user_vanumberEO : IRowMapper<Sb_user_vanumberEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_user_vanumberEO()
		{
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalUserID;
		/// <summary>
		/// 【数据库中的原始主键 UserID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalUserID
		{
			get { return _originalUserID; }
			set { HasOriginal = true; _originalUserID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "UserID", UserID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 用户编码(GUID)
		/// 【主键 varchar(38)】
		/// </summary>
		[DataMember(Order = 1)]
		public string UserID { get; set; }
		/// <summary>
		/// 虚拟账号
		/// 【字段 varchar(500)】
		/// </summary>
		[DataMember(Order = 2)]
		public string VaNumber { get; set; }
		/// <summary>
		/// 我方订单号
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 3)]
		public string OrderID { get; set; }
		/// <summary>
		/// 对方订单号（平台订单号）
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 4)]
		public string PlatOrderNum { get; set; }
		/// <summary>
		/// 应用编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 5)]
		public string AppID { get; set; }
		/// <summary>
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 6)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 货币类型
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 7)]
		public string CurrencyID { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_user_vanumberEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_user_vanumberEO MapDataReader(IDataReader reader)
		{
		    Sb_user_vanumberEO ret = new Sb_user_vanumberEO();
			ret.UserID = reader.ToString("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.VaNumber = reader.ToString("VaNumber");
			ret.OrderID = reader.ToString("OrderID");
			ret.PlatOrderNum = reader.ToString("PlatOrderNum");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CurrencyID = reader.ToString("CurrencyID");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 用户与虚拟账号对应关系
	/// 【表 sb_user_vanumber 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_user_vanumberMO : MySqlTableMO<Sb_user_vanumberEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_user_vanumber`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_user_vanumberMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_user_vanumberMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_user_vanumberMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_user_vanumberEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_user_vanumberEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_user_vanumberEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`UserID`, `VaNumber`, `OrderID`, `PlatOrderNum`, `AppID`, `OperatorID`, `CurrencyID`) VALUE (@UserID, @VaNumber, @OrderID, @PlatOrderNum, @AppID, @OperatorID, @CurrencyID);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VaNumber", item.VaNumber != null ? item.VaNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", item.OrderID != null ? item.OrderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PlatOrderNum", item.PlatOrderNum != null ? item.PlatOrderNum : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
			};
		}
		public int AddByBatch(IEnumerable<Sb_user_vanumberEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_user_vanumberEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_user_vanumberEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`UserID`, `VaNumber`, `OrderID`, `PlatOrderNum`, `AppID`, `OperatorID`, `CurrencyID`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.UserID}','{item.VaNumber}','{item.OrderID}','{item.PlatOrderNum}','{item.AppID}','{item.OperatorID}','{item.CurrencyID}'),");
				if (count == batchCount)
				{
					count = 0;
					sql.Insert(0, insertSql);
					var ret = sql.ToString().TrimEnd(',');
					sql.Clear();
	                yield return ret;
				}
			}
			if (sql.Length > 0)
			{
	            sql.Insert(0, insertSql);
	            yield return sql.ToString().TrimEnd(',');
	        }
	    }
	    #endregion // Add
	    
		#region Remove
		#region RemoveByPK
		/// <summary>
		/// 按主键删除
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string userID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(userID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string userID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(userID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string userID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sb_user_vanumberEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.UserID, tm_);
		}
		public async Task<int> RemoveAsync(Sb_user_vanumberEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.UserID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByVaNumber
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByVaNumber(string vaNumber, TransactionManager tm_ = null)
		{
			RepairRemoveByVaNumberData(vaNumber, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByVaNumberAsync(string vaNumber, TransactionManager tm_ = null)
		{
			RepairRemoveByVaNumberData(vaNumber, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByVaNumberData(string vaNumber, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (vaNumber != null ? "`VaNumber` = @VaNumber" : "`VaNumber` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (vaNumber != null)
				paras_.Add(Database.CreateInParameter("@VaNumber", vaNumber, MySqlDbType.VarChar));
		}
		#endregion // RemoveByVaNumber
		#region RemoveByOrderID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderID(string orderID, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderIDData(orderID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderIDAsync(string orderID, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderIDData(orderID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderIDData(string orderID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (orderID != null ? "`OrderID` = @OrderID" : "`OrderID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (orderID != null)
				paras_.Add(Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOrderID
		#region RemoveByPlatOrderNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPlatOrderNum(string platOrderNum, TransactionManager tm_ = null)
		{
			RepairRemoveByPlatOrderNumData(platOrderNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPlatOrderNumAsync(string platOrderNum, TransactionManager tm_ = null)
		{
			RepairRemoveByPlatOrderNumData(platOrderNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByPlatOrderNumData(string platOrderNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (platOrderNum != null ? "`PlatOrderNum` = @PlatOrderNum" : "`PlatOrderNum` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (platOrderNum != null)
				paras_.Add(Database.CreateInParameter("@PlatOrderNum", platOrderNum, MySqlDbType.VarChar));
		}
		#endregion // RemoveByPlatOrderNum
		#region RemoveByAppID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAppID(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			RepairRemoveByAppIDData(appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAppIDData(string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByAppID
		#region RemoveByOperatorID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOperatorID(string operatorID, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			RepairRemoveByOperatorIDData(operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOperatorIDData(string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOperatorID
		#region RemoveByCurrencyID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrencyIDData(currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCurrencyIDData(string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCurrencyID
		#endregion // RemoveByXXX
	    
		#region RemoveByFKOrUnique
		#endregion // RemoveByFKOrUnique
		#endregion //Remove
	    
		#region Put
		#region PutItem
		/// <summary>
		/// 更新实体到数据库
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(Sb_user_vanumberEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_user_vanumberEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_user_vanumberEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID, `VaNumber` = @VaNumber, `OrderID` = @OrderID, `PlatOrderNum` = @PlatOrderNum, `AppID` = @AppID, `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID WHERE `UserID` = @UserID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@VaNumber", item.VaNumber != null ? item.VaNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OrderID", item.OrderID != null ? item.OrderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PlatOrderNum", item.PlatOrderNum != null ? item.PlatOrderNum : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sb_user_vanumberEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_user_vanumberEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += await PutAsync(item, tm_);
			}
			return ret;
		}
		#endregion // PutItem
		
		#region PutByPK
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string userID, string set_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID", ConcatValues(values_, userID));
		}
		public async Task<int> PutByPKAsync(string userID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`UserID` = @UserID", ConcatValues(values_, userID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string userID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`UserID` = @UserID", tm_, ConcatValues(values_, userID));
		}
		public async Task<int> PutByPKAsync(string userID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`UserID` = @UserID", tm_, ConcatValues(values_, userID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string userID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`UserID` = @UserID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string userID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`UserID` = @UserID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutVaNumber
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVaNumberByPK(string userID, string vaNumber, TransactionManager tm_ = null)
		{
			RepairPutVaNumberByPKData(userID, vaNumber, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutVaNumberByPKAsync(string userID, string vaNumber, TransactionManager tm_ = null)
		{
			RepairPutVaNumberByPKData(userID, vaNumber, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutVaNumberByPKData(string userID, string vaNumber, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `VaNumber` = @VaNumber  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@VaNumber", vaNumber != null ? vaNumber : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutVaNumber(string vaNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VaNumber` = @VaNumber";
			var parameter_ = Database.CreateInParameter("@VaNumber", vaNumber != null ? vaNumber : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutVaNumberAsync(string vaNumber, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `VaNumber` = @VaNumber";
			var parameter_ = Database.CreateInParameter("@VaNumber", vaNumber != null ? vaNumber : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutVaNumber
		#region PutOrderID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderIDByPK(string userID, string orderID, TransactionManager tm_ = null)
		{
			RepairPutOrderIDByPKData(userID, orderID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderIDByPKAsync(string userID, string orderID, TransactionManager tm_ = null)
		{
			RepairPutOrderIDByPKData(userID, orderID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderIDByPKData(string userID, string orderID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderID` = @OrderID  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderID", orderID != null ? orderID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderID(string orderID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderID` = @OrderID";
			var parameter_ = Database.CreateInParameter("@OrderID", orderID != null ? orderID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderIDAsync(string orderID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderID` = @OrderID";
			var parameter_ = Database.CreateInParameter("@OrderID", orderID != null ? orderID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderID
		#region PutPlatOrderNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPlatOrderNumByPK(string userID, string platOrderNum, TransactionManager tm_ = null)
		{
			RepairPutPlatOrderNumByPKData(userID, platOrderNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutPlatOrderNumByPKAsync(string userID, string platOrderNum, TransactionManager tm_ = null)
		{
			RepairPutPlatOrderNumByPKData(userID, platOrderNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutPlatOrderNumByPKData(string userID, string platOrderNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `PlatOrderNum` = @PlatOrderNum  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@PlatOrderNum", platOrderNum != null ? platOrderNum : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutPlatOrderNum(string platOrderNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PlatOrderNum` = @PlatOrderNum";
			var parameter_ = Database.CreateInParameter("@PlatOrderNum", platOrderNum != null ? platOrderNum : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutPlatOrderNumAsync(string platOrderNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `PlatOrderNum` = @PlatOrderNum";
			var parameter_ = Database.CreateInParameter("@PlatOrderNum", platOrderNum != null ? platOrderNum : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutPlatOrderNum
		#region PutAppID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppIDByPK(string userID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(userID, appID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAppIDByPKAsync(string userID, string appID, TransactionManager tm_ = null)
		{
			RepairPutAppIDByPKData(userID, appID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAppIDByPKData(string userID, string appID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AppID` = @AppID  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAppID(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAppIDAsync(string appID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AppID` = @AppID";
			var parameter_ = Database.CreateInParameter("@AppID", appID != null ? appID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAppID
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(string userID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(userID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(string userID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(userID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(string userID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorID(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID != null ? operatorID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorID
		#region PutCurrencyID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(string userID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(userID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(string userID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(userID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(string userID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID != null ? currencyID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrencyID
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_user_vanumberEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.UserID) == null)
			{
				Add(item, tm);
			}
			else
			{
				Put(item, tm);
				ret = false;
			}
			return ret;
		}
		public async Task<bool> SetAsync(Sb_user_vanumberEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.UserID) == null)
			{
				await AddAsync(item, tm);
			}
			else
			{
				await PutAsync(item, tm);
				ret = false;
			}
			return ret;
		}
		
		#endregion // Set
		
		#region Get
		#region GetByPK
		/// <summary>
		/// 按 PK（主键） 查询
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_user_vanumberEO GetByPK(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<Sb_user_vanumberEO> GetByPKAsync(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		private void RepairGetByPKData(string userID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`UserID` = @UserID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 VaNumber（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetVaNumberByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`VaNumber`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetVaNumberByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`VaNumber`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderID（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOrderIDByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OrderID`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetOrderIDByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OrderID`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PlatOrderNum（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetPlatOrderNumByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`PlatOrderNum`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetPlatOrderNumByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`PlatOrderNum`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AppID（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetAppIDByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`AppID`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetAppIDByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`AppID`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CurrencyID`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`UserID` = @UserID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByVaNumber
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber)
		{
			return GetByVaNumber(vaNumber, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber)
		{
			return await GetByVaNumberAsync(vaNumber, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, TransactionManager tm_)
		{
			return GetByVaNumber(vaNumber, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, TransactionManager tm_)
		{
			return await GetByVaNumberAsync(vaNumber, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, int top_)
		{
			return GetByVaNumber(vaNumber, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, int top_)
		{
			return await GetByVaNumberAsync(vaNumber, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, int top_, TransactionManager tm_)
		{
			return GetByVaNumber(vaNumber, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, int top_, TransactionManager tm_)
		{
			return await GetByVaNumberAsync(vaNumber, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, string sort_)
		{
			return GetByVaNumber(vaNumber, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, string sort_)
		{
			return await GetByVaNumberAsync(vaNumber, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, string sort_, TransactionManager tm_)
		{
			return GetByVaNumber(vaNumber, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, string sort_, TransactionManager tm_)
		{
			return await GetByVaNumberAsync(vaNumber, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 VaNumber（字段） 查询
		/// </summary>
		/// /// <param name = "vaNumber">虚拟账号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByVaNumber(string vaNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(vaNumber != null ? "`VaNumber` = @VaNumber" : "`VaNumber` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (vaNumber != null)
				paras_.Add(Database.CreateInParameter("@VaNumber", vaNumber, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByVaNumberAsync(string vaNumber, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(vaNumber != null ? "`VaNumber` = @VaNumber" : "`VaNumber` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (vaNumber != null)
				paras_.Add(Database.CreateInParameter("@VaNumber", vaNumber, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByVaNumber
		#region GetByOrderID
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID)
		{
			return GetByOrderID(orderID, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID)
		{
			return await GetByOrderIDAsync(orderID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, TransactionManager tm_)
		{
			return GetByOrderID(orderID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, TransactionManager tm_)
		{
			return await GetByOrderIDAsync(orderID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, int top_)
		{
			return GetByOrderID(orderID, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, int top_)
		{
			return await GetByOrderIDAsync(orderID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, int top_, TransactionManager tm_)
		{
			return GetByOrderID(orderID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, int top_, TransactionManager tm_)
		{
			return await GetByOrderIDAsync(orderID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, string sort_)
		{
			return GetByOrderID(orderID, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, string sort_)
		{
			return await GetByOrderIDAsync(orderID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, string sort_, TransactionManager tm_)
		{
			return GetByOrderID(orderID, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, string sort_, TransactionManager tm_)
		{
			return await GetByOrderIDAsync(orderID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderID（字段） 查询
		/// </summary>
		/// /// <param name = "orderID">我方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOrderID(string orderID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(orderID != null ? "`OrderID` = @OrderID" : "`OrderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (orderID != null)
				paras_.Add(Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOrderIDAsync(string orderID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(orderID != null ? "`OrderID` = @OrderID" : "`OrderID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (orderID != null)
				paras_.Add(Database.CreateInParameter("@OrderID", orderID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByOrderID
		#region GetByPlatOrderNum
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum)
		{
			return GetByPlatOrderNum(platOrderNum, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, int top_)
		{
			return GetByPlatOrderNum(platOrderNum, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, int top_, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, string sort_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, string sort_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, string sort_, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, string sort_, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号（平台订单号）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByPlatOrderNum(string platOrderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(platOrderNum != null ? "`PlatOrderNum` = @PlatOrderNum" : "`PlatOrderNum` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (platOrderNum != null)
				paras_.Add(Database.CreateInParameter("@PlatOrderNum", platOrderNum, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(platOrderNum != null ? "`PlatOrderNum` = @PlatOrderNum" : "`PlatOrderNum` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (platOrderNum != null)
				paras_.Add(Database.CreateInParameter("@PlatOrderNum", platOrderNum, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByPlatOrderNum
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, int top_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, string sort_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">应用编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, int top_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, string sort_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_user_vanumberEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		public async Task<List<Sb_user_vanumberEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_user_vanumberEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
