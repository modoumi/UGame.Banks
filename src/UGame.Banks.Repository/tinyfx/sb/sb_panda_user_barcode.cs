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
	/// panda支付表-用户barcode
	/// 【表 sb_panda_user_barcode 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sb_panda_user_barcodeEO : IRowMapper<Sb_panda_user_barcodeEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sb_panda_user_barcodeEO()
		{
			this.RecDate = DateTime.Now;
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
		/// 用户编码
		/// 【主键 varchar(38)】
		/// </summary>
		[DataMember(Order = 1)]
		public string UserID { get; set; }
		/// <summary>
		/// 还款码
		/// 【字段 varchar(500)】
		/// </summary>
		[DataMember(Order = 2)]
		public string BarCode { get; set; }
		/// <summary>
		/// 我方向对方请求的订单号
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 3)]
		public string OwnOrderId { get; set; }
		/// <summary>
		/// 对方订单号
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 4)]
		public string PlatOrderNum { get; set; }
		/// <summary>
		/// app编码
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
		/// 货币编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 7)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 时间记录
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 8)]
		public DateTime RecDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sb_panda_user_barcodeEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sb_panda_user_barcodeEO MapDataReader(IDataReader reader)
		{
		    Sb_panda_user_barcodeEO ret = new Sb_panda_user_barcodeEO();
			ret.UserID = reader.ToString("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.BarCode = reader.ToString("BarCode");
			ret.OwnOrderId = reader.ToString("OwnOrderId");
			ret.PlatOrderNum = reader.ToString("PlatOrderNum");
			ret.AppID = reader.ToString("AppID");
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// panda支付表-用户barcode
	/// 【表 sb_panda_user_barcode 的操作类】
	/// </summary>
	[Obsolete]
	public class Sb_panda_user_barcodeMO : MySqlTableMO<Sb_panda_user_barcodeEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sb_panda_user_barcode`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sb_panda_user_barcodeMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sb_panda_user_barcodeMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sb_panda_user_barcodeMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sb_panda_user_barcodeEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`UserID`, `BarCode`, `OwnOrderId`, `PlatOrderNum`, `AppID`, `OperatorID`, `CurrencyID`, `RecDate`) VALUE (@UserID, @BarCode, @OwnOrderId, @PlatOrderNum, @AppID, @OperatorID, @CurrencyID, @RecDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BarCode", item.BarCode != null ? item.BarCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OwnOrderId", item.OwnOrderId != null ? item.OwnOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@PlatOrderNum", item.PlatOrderNum != null ? item.PlatOrderNum : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@AppID", item.AppID != null ? item.AppID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sb_panda_user_barcodeEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sb_panda_user_barcodeEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sb_panda_user_barcodeEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`UserID`, `BarCode`, `OwnOrderId`, `PlatOrderNum`, `AppID`, `OperatorID`, `CurrencyID`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.UserID}','{item.BarCode}','{item.OwnOrderId}','{item.PlatOrderNum}','{item.AppID}','{item.OperatorID}','{item.CurrencyID}','{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "userID">用户编码</param>
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
		public int Remove(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.UserID, tm_);
		}
		public async Task<int> RemoveAsync(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.UserID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
		#region RemoveByBarCode
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBarCode(string barCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBarCodeData(barCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBarCodeAsync(string barCode, TransactionManager tm_ = null)
		{
			RepairRemoveByBarCodeData(barCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBarCodeData(string barCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (barCode != null ? "`BarCode` = @BarCode" : "`BarCode` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (barCode != null)
				paras_.Add(Database.CreateInParameter("@BarCode", barCode, MySqlDbType.VarChar));
		}
		#endregion // RemoveByBarCode
		#region RemoveByOwnOrderId
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOwnOrderId(string ownOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnOrderIdData(ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOwnOrderIdAsync(string ownOrderId, TransactionManager tm_ = null)
		{
			RepairRemoveByOwnOrderIdData(ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOwnOrderIdData(string ownOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
		}
		#endregion // RemoveByOwnOrderId
		#region RemoveByPlatOrderNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
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
		/// /// <param name = "appID">app编码</param>
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
		/// /// <param name = "currencyID">货币编码</param>
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
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			RepairRemoveByRecDateData(recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByRecDateData(DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `RecDate` = @RecDate";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
		}
		#endregion // RemoveByRecDate
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
		public int Put(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sb_panda_user_barcodeEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sb_panda_user_barcodeEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID, `BarCode` = @BarCode, `OwnOrderId` = @OwnOrderId, `PlatOrderNum` = @PlatOrderNum, `AppID` = @AppID, `OperatorID` = @OperatorID, `CurrencyID` = @CurrencyID WHERE `UserID` = @UserID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@BarCode", item.BarCode != null ? item.BarCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@OwnOrderId", item.OwnOrderId != null ? item.OwnOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
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
		public int Put(IEnumerable<Sb_panda_user_barcodeEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sb_panda_user_barcodeEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		#region PutBarCode
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "barCode">还款码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBarCodeByPK(string userID, string barCode, TransactionManager tm_ = null)
		{
			RepairPutBarCodeByPKData(userID, barCode, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBarCodeByPKAsync(string userID, string barCode, TransactionManager tm_ = null)
		{
			RepairPutBarCodeByPKData(userID, barCode, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBarCodeByPKData(string userID, string barCode, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BarCode` = @BarCode  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BarCode", barCode != null ? barCode : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBarCode(string barCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BarCode` = @BarCode";
			var parameter_ = Database.CreateInParameter("@BarCode", barCode != null ? barCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBarCodeAsync(string barCode, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BarCode` = @BarCode";
			var parameter_ = Database.CreateInParameter("@BarCode", barCode != null ? barCode : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBarCode
		#region PutOwnOrderId
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnOrderIdByPK(string userID, string ownOrderId, TransactionManager tm_ = null)
		{
			RepairPutOwnOrderIdByPKData(userID, ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOwnOrderIdByPKAsync(string userID, string ownOrderId, TransactionManager tm_ = null)
		{
			RepairPutOwnOrderIdByPKData(userID, ownOrderId, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOwnOrderIdByPKData(string userID, string ownOrderId, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOwnOrderId(string ownOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId";
			var parameter_ = Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOwnOrderIdAsync(string ownOrderId, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OwnOrderId` = @OwnOrderId";
			var parameter_ = Database.CreateInParameter("@OwnOrderId", ownOrderId != null ? ownOrderId : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOwnOrderId
		#region PutPlatOrderNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "platOrderNum">对方订单号</param>
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
		/// /// <param name = "platOrderNum">对方订单号</param>
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
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "appID">app编码</param>
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
		/// /// <param name = "appID">app编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "currencyID">货币编码</param>
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
		/// /// <param name = "currencyID">货币编码</param>
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
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string userID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(userID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string userID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(userID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string userID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDate(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutRecDateAsync(DateTime recDate, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate";
			var parameter_ = Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutRecDate
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sb_panda_user_barcodeEO item, TransactionManager tm = null)
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
		public async Task<bool> SetAsync(Sb_panda_user_barcodeEO item, TransactionManager tm = null)
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
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sb_panda_user_barcodeEO GetByPK(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<Sb_panda_user_barcodeEO> GetByPKAsync(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
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
		/// 按主键查询 BarCode（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetBarCodeByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`BarCode`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetBarCodeByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`BarCode`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OwnOrderId（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOwnOrderIdByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OwnOrderId`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetOwnOrderIdByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OwnOrderId`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 PlatOrderNum（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		/// /// <param name = "userID">用户编码</param>
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
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`UserID` = @UserID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByBarCode
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode)
		{
			return GetByBarCode(barCode, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode)
		{
			return await GetByBarCodeAsync(barCode, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, TransactionManager tm_)
		{
			return GetByBarCode(barCode, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, TransactionManager tm_)
		{
			return await GetByBarCodeAsync(barCode, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, int top_)
		{
			return GetByBarCode(barCode, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, int top_)
		{
			return await GetByBarCodeAsync(barCode, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, int top_, TransactionManager tm_)
		{
			return GetByBarCode(barCode, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, int top_, TransactionManager tm_)
		{
			return await GetByBarCodeAsync(barCode, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, string sort_)
		{
			return GetByBarCode(barCode, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, string sort_)
		{
			return await GetByBarCodeAsync(barCode, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, string sort_, TransactionManager tm_)
		{
			return GetByBarCode(barCode, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, string sort_, TransactionManager tm_)
		{
			return await GetByBarCodeAsync(barCode, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BarCode（字段） 查询
		/// </summary>
		/// /// <param name = "barCode">还款码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByBarCode(string barCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(barCode != null ? "`BarCode` = @BarCode" : "`BarCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (barCode != null)
				paras_.Add(Database.CreateInParameter("@BarCode", barCode, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByBarCodeAsync(string barCode, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(barCode != null ? "`BarCode` = @BarCode" : "`BarCode` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (barCode != null)
				paras_.Add(Database.CreateInParameter("@BarCode", barCode, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByBarCode
		#region GetByOwnOrderId
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId)
		{
			return GetByOwnOrderId(ownOrderId, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, int top_)
		{
			return GetByOwnOrderId(ownOrderId, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, int top_, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, string sort_)
		{
			return GetByOwnOrderId(ownOrderId, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, string sort_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, string sort_, TransactionManager tm_)
		{
			return GetByOwnOrderId(ownOrderId, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, string sort_, TransactionManager tm_)
		{
			return await GetByOwnOrderIdAsync(ownOrderId, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OwnOrderId（字段） 查询
		/// </summary>
		/// /// <param name = "ownOrderId">我方向对方请求的订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOwnOrderId(string ownOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOwnOrderIdAsync(string ownOrderId, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(ownOrderId != null ? "`OwnOrderId` = @OwnOrderId" : "`OwnOrderId` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (ownOrderId != null)
				paras_.Add(Database.CreateInParameter("@OwnOrderId", ownOrderId, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByOwnOrderId
		#region GetByPlatOrderNum
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum)
		{
			return GetByPlatOrderNum(platOrderNum, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, int top_)
		{
			return GetByPlatOrderNum(platOrderNum, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, int top_, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, string sort_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, string sort_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, string sort_, TransactionManager tm_)
		{
			return GetByPlatOrderNum(platOrderNum, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, string sort_, TransactionManager tm_)
		{
			return await GetByPlatOrderNumAsync(platOrderNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 PlatOrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "platOrderNum">对方订单号</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByPlatOrderNum(string platOrderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(platOrderNum != null ? "`PlatOrderNum` = @PlatOrderNum" : "`PlatOrderNum` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (platOrderNum != null)
				paras_.Add(Database.CreateInParameter("@PlatOrderNum", platOrderNum, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByPlatOrderNumAsync(string platOrderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(platOrderNum != null ? "`PlatOrderNum` = @PlatOrderNum" : "`PlatOrderNum` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (platOrderNum != null)
				paras_.Add(Database.CreateInParameter("@PlatOrderNum", platOrderNum, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByPlatOrderNum
		#region GetByAppID
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID)
		{
			return GetByAppID(appID, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, int top_)
		{
			return GetByAppID(appID, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, int top_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, int top_, TransactionManager tm_)
		{
			return GetByAppID(appID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, int top_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, string sort_)
		{
			return GetByAppID(appID, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, string sort_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, string sort_, TransactionManager tm_)
		{
			return GetByAppID(appID, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, string sort_, TransactionManager tm_)
		{
			return await GetByAppIDAsync(appID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AppID（字段） 查询
		/// </summary>
		/// /// <param name = "appID">app编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByAppID(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByAppIDAsync(string appID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(appID != null ? "`AppID` = @AppID" : "`AppID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (appID != null)
				paras_.Add(Database.CreateInParameter("@AppID", appID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByAppID
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sb_panda_user_barcodeEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, int top_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币编码</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, int top_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, string sort_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">时间记录</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sb_panda_user_barcodeEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		public async Task<List<Sb_panda_user_barcodeEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sb_panda_user_barcodeEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
