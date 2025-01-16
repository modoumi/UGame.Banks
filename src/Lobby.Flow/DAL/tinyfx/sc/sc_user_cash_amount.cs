/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-05-27 20: 09:26
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

namespace Lobby.Flow.DAL
{
	#region EO
	/// <summary>
	/// 
	/// 【表 sc_user_cash_amount 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_user_cash_amountEO : IRowMapper<Sc_user_cash_amountEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_user_cash_amountEO()
		{
			this.BetCashAmount = 0;
			this.WinCashAmount = 0;
			this.BalanceCashAmount = 0;
			this.TempWithdrawAmount = 0;
			this.WithdrawAmount = 0;
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
		/// 运营商编码
		/// 【字段 varchar(50)】
		/// </summary>
		[DataMember(Order = 2)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 3)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币类型
		/// 【字段 varchar(5)】
		/// </summary>
		[DataMember(Order = 4)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 真金下注总额(计算可提现金额,会重置)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 5)]
		public long BetCashAmount { get; set; }
		/// <summary>
		/// 真金返奖总额(计算可提现金额,会重置)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 6)]
		public long WinCashAmount { get; set; }
		/// <summary>
		/// 真金余额(计算可提现金额)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long BalanceCashAmount { get; set; }
		/// <summary>
		/// 充值后的临时可提现真金金额(计算可提现金额)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 8)]
		public long TempWithdrawAmount { get; set; }
		/// <summary>
		/// 可提现真金金额(计算可提现金额)
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 9)]
		public long WithdrawAmount { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_user_cash_amountEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_user_cash_amountEO MapDataReader(IDataReader reader)
		{
		    Sc_user_cash_amountEO ret = new Sc_user_cash_amountEO();
			ret.UserID = reader.ToString("UserID");
			ret.OriginalUserID = ret.UserID;
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.BetCashAmount = reader.ToInt64("BetCashAmount");
			ret.WinCashAmount = reader.ToInt64("WinCashAmount");
			ret.BalanceCashAmount = reader.ToInt64("BalanceCashAmount");
			ret.TempWithdrawAmount = reader.ToInt64("TempWithdrawAmount");
			ret.WithdrawAmount = reader.ToInt64("WithdrawAmount");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 
	/// 【表 sc_user_cash_amount 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_user_cash_amountMO : MySqlTableMO<Sc_user_cash_amountEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_user_cash_amount`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_user_cash_amountMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_user_cash_amountMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_user_cash_amountMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_user_cash_amountEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_user_cash_amountEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_user_cash_amountEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`UserID`, `OperatorID`, `CountryID`, `CurrencyID`, `BetCashAmount`, `WinCashAmount`, `BalanceCashAmount`, `TempWithdrawAmount`, `WithdrawAmount`) VALUE (@UserID, @OperatorID, @CountryID, @CurrencyID, @BetCashAmount, @WinCashAmount, @BalanceCashAmount, @TempWithdrawAmount, @WithdrawAmount);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BetCashAmount", item.BetCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@WinCashAmount", item.WinCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceCashAmount", item.BalanceCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@TempWithdrawAmount", item.TempWithdrawAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@WithdrawAmount", item.WithdrawAmount, MySqlDbType.Int64),
			};
		}
		public int AddByBatch(IEnumerable<Sc_user_cash_amountEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_user_cash_amountEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_user_cash_amountEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`UserID`, `OperatorID`, `CountryID`, `CurrencyID`, `BetCashAmount`, `WinCashAmount`, `BalanceCashAmount`, `TempWithdrawAmount`, `WithdrawAmount`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.UserID}','{item.OperatorID}','{item.CountryID}','{item.CurrencyID}',{item.BetCashAmount},{item.WinCashAmount},{item.BalanceCashAmount},{item.TempWithdrawAmount},{item.WithdrawAmount}),");
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
		public int Remove(Sc_user_cash_amountEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.UserID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_user_cash_amountEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.UserID, tm_);
		}
		#endregion // RemoveByPK
		
		#region RemoveByXXX
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
		#region RemoveByCountryID
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCountryID(string countryID, TransactionManager tm_ = null)
		{
			RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			RepairRemoveByCountryIDData(countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCountryIDData(string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE " + (countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL");
			paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCountryID
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
		#region RemoveByBetCashAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBetCashAmount(long betCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetCashAmountData(betCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBetCashAmountAsync(long betCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBetCashAmountData(betCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBetCashAmountData(long betCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BetCashAmount` = @BetCashAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBetCashAmount
		#region RemoveByWinCashAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByWinCashAmount(long winCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByWinCashAmountData(winCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByWinCashAmountAsync(long winCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByWinCashAmountData(winCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByWinCashAmountData(long winCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `WinCashAmount` = @WinCashAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByWinCashAmount
		#region RemoveByBalanceCashAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBalanceCashAmount(long balanceCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceCashAmountData(balanceCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBalanceCashAmountAsync(long balanceCashAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceCashAmountData(balanceCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBalanceCashAmountData(long balanceCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BalanceCashAmount` = @BalanceCashAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBalanceCashAmount
		#region RemoveByTempWithdrawAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTempWithdrawAmount(long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByTempWithdrawAmountData(tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTempWithdrawAmountAsync(long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByTempWithdrawAmountData(tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTempWithdrawAmountData(long tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TempWithdrawAmount` = @TempWithdrawAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByTempWithdrawAmount
		#region RemoveByWithdrawAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByWithdrawAmount(long withdrawAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByWithdrawAmountData(withdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByWithdrawAmountAsync(long withdrawAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByWithdrawAmountData(withdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByWithdrawAmountData(long withdrawAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `WithdrawAmount` = @WithdrawAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByWithdrawAmount
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
		public int Put(Sc_user_cash_amountEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_user_cash_amountEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_user_cash_amountEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `UserID` = @UserID, `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `BetCashAmount` = @BetCashAmount, `WinCashAmount` = @WinCashAmount, `BalanceCashAmount` = @BalanceCashAmount, `TempWithdrawAmount` = @TempWithdrawAmount, `WithdrawAmount` = @WithdrawAmount WHERE `UserID` = @UserID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", item.UserID, MySqlDbType.VarChar),
				Database.CreateInParameter("@OperatorID", item.OperatorID != null ? item.OperatorID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID != null ? item.CountryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID != null ? item.CurrencyID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@BetCashAmount", item.BetCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@WinCashAmount", item.WinCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceCashAmount", item.BalanceCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@TempWithdrawAmount", item.TempWithdrawAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@WithdrawAmount", item.WithdrawAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID_Original", item.HasOriginal ? item.OriginalUserID : item.UserID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_user_cash_amountEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_user_cash_amountEO> items, TransactionManager tm_ = null)
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
		#region PutCountryID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(string userID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(userID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(string userID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(userID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(string userID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryID(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID != null ? countryID : (object)DBNull.Value, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCountryID
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
		#region PutBetCashAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetCashAmountByPK(string userID, long betCashAmount, TransactionManager tm_ = null)
		{
			RepairPutBetCashAmountByPKData(userID, betCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBetCashAmountByPKAsync(string userID, long betCashAmount, TransactionManager tm_ = null)
		{
			RepairPutBetCashAmountByPKData(userID, betCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBetCashAmountByPKData(string userID, long betCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BetCashAmount` = @BetCashAmount  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBetCashAmount(long betCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetCashAmount` = @BetCashAmount";
			var parameter_ = Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBetCashAmountAsync(long betCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BetCashAmount` = @BetCashAmount";
			var parameter_ = Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBetCashAmount
		#region PutWinCashAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWinCashAmountByPK(string userID, long winCashAmount, TransactionManager tm_ = null)
		{
			RepairPutWinCashAmountByPKData(userID, winCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutWinCashAmountByPKAsync(string userID, long winCashAmount, TransactionManager tm_ = null)
		{
			RepairPutWinCashAmountByPKData(userID, winCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutWinCashAmountByPKData(string userID, long winCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `WinCashAmount` = @WinCashAmount  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWinCashAmount(long winCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WinCashAmount` = @WinCashAmount";
			var parameter_ = Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutWinCashAmountAsync(long winCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WinCashAmount` = @WinCashAmount";
			var parameter_ = Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutWinCashAmount
		#region PutBalanceCashAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceCashAmountByPK(string userID, long balanceCashAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceCashAmountByPKData(userID, balanceCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBalanceCashAmountByPKAsync(string userID, long balanceCashAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceCashAmountByPKData(userID, balanceCashAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBalanceCashAmountByPKData(string userID, long balanceCashAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BalanceCashAmount` = @BalanceCashAmount  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceCashAmount(long balanceCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceCashAmount` = @BalanceCashAmount";
			var parameter_ = Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBalanceCashAmountAsync(long balanceCashAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceCashAmount` = @BalanceCashAmount";
			var parameter_ = Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBalanceCashAmount
		#region PutTempWithdrawAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTempWithdrawAmountByPK(string userID, long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			RepairPutTempWithdrawAmountByPKData(userID, tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTempWithdrawAmountByPKAsync(string userID, long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			RepairPutTempWithdrawAmountByPKData(userID, tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTempWithdrawAmountByPKData(string userID, long tempWithdrawAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TempWithdrawAmount` = @TempWithdrawAmount  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTempWithdrawAmount(long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TempWithdrawAmount` = @TempWithdrawAmount";
			var parameter_ = Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTempWithdrawAmountAsync(long tempWithdrawAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TempWithdrawAmount` = @TempWithdrawAmount";
			var parameter_ = Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTempWithdrawAmount
		#region PutWithdrawAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWithdrawAmountByPK(string userID, long withdrawAmount, TransactionManager tm_ = null)
		{
			RepairPutWithdrawAmountByPKData(userID, withdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutWithdrawAmountByPKAsync(string userID, long withdrawAmount, TransactionManager tm_ = null)
		{
			RepairPutWithdrawAmountByPKData(userID, withdrawAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutWithdrawAmountByPKData(string userID, long withdrawAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `WithdrawAmount` = @WithdrawAmount  WHERE `UserID` = @UserID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutWithdrawAmount(long withdrawAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WithdrawAmount` = @WithdrawAmount";
			var parameter_ = Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutWithdrawAmountAsync(long withdrawAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `WithdrawAmount` = @WithdrawAmount";
			var parameter_ = Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutWithdrawAmount
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_user_cash_amountEO item, TransactionManager tm = null)
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
		public async Task<bool> SetAsync(Sc_user_cash_amountEO item, TransactionManager tm = null)
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
		public Sc_user_cash_amountEO GetByPK(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<Sc_user_cash_amountEO> GetByPKAsync(string userID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(userID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
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
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`UserID` = @UserID", paras_, tm_);
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
		
		/// <summary>
		/// 按主键查询 BetCashAmount（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBetCashAmountByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`BetCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<long> GetBetCashAmountByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`BetCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 WinCashAmount（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetWinCashAmountByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`WinCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<long> GetWinCashAmountByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`WinCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BalanceCashAmount（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBalanceCashAmountByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`BalanceCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<long> GetBalanceCashAmountByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`BalanceCashAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TempWithdrawAmount（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetTempWithdrawAmountByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`TempWithdrawAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<long> GetTempWithdrawAmountByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`TempWithdrawAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 WithdrawAmount（字段）
		/// </summary>
		/// /// <param name = "userID">用户编码(GUID)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetWithdrawAmountByPK(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`WithdrawAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		public async Task<long> GetWithdrawAmountByPKAsync(string userID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@UserID", userID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`WithdrawAmount`", "`UserID` = @UserID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_user_cash_amountEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(operatorID != null ? "`OperatorID` = @OperatorID" : "`OperatorID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (operatorID != null)
				paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, int top_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, string sort_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(countryID != null ? "`CountryID` = @CountryID" : "`CountryID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (countryID != null)
				paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
		public List<Sc_user_cash_amountEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL(currencyID != null ? "`CurrencyID` = @CurrencyID" : "`CurrencyID` IS NULL", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			if (currencyID != null)
				paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByBetCashAmount
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount)
		{
			return GetByBetCashAmount(betCashAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount)
		{
			return await GetByBetCashAmountAsync(betCashAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, TransactionManager tm_)
		{
			return GetByBetCashAmount(betCashAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, TransactionManager tm_)
		{
			return await GetByBetCashAmountAsync(betCashAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, int top_)
		{
			return GetByBetCashAmount(betCashAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, int top_)
		{
			return await GetByBetCashAmountAsync(betCashAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, int top_, TransactionManager tm_)
		{
			return GetByBetCashAmount(betCashAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, int top_, TransactionManager tm_)
		{
			return await GetByBetCashAmountAsync(betCashAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, string sort_)
		{
			return GetByBetCashAmount(betCashAmount, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, string sort_)
		{
			return await GetByBetCashAmountAsync(betCashAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, string sort_, TransactionManager tm_)
		{
			return GetByBetCashAmount(betCashAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBetCashAmountAsync(betCashAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BetCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "betCashAmount">真金下注总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBetCashAmount(long betCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetCashAmount` = @BetCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBetCashAmountAsync(long betCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BetCashAmount` = @BetCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BetCashAmount", betCashAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByBetCashAmount
		#region GetByWinCashAmount
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount)
		{
			return GetByWinCashAmount(winCashAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount)
		{
			return await GetByWinCashAmountAsync(winCashAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, TransactionManager tm_)
		{
			return GetByWinCashAmount(winCashAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, TransactionManager tm_)
		{
			return await GetByWinCashAmountAsync(winCashAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, int top_)
		{
			return GetByWinCashAmount(winCashAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, int top_)
		{
			return await GetByWinCashAmountAsync(winCashAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, int top_, TransactionManager tm_)
		{
			return GetByWinCashAmount(winCashAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, int top_, TransactionManager tm_)
		{
			return await GetByWinCashAmountAsync(winCashAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, string sort_)
		{
			return GetByWinCashAmount(winCashAmount, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, string sort_)
		{
			return await GetByWinCashAmountAsync(winCashAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, string sort_, TransactionManager tm_)
		{
			return GetByWinCashAmount(winCashAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, string sort_, TransactionManager tm_)
		{
			return await GetByWinCashAmountAsync(winCashAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 WinCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "winCashAmount">真金返奖总额(计算可提现金额,会重置)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWinCashAmount(long winCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WinCashAmount` = @WinCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWinCashAmountAsync(long winCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WinCashAmount` = @WinCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WinCashAmount", winCashAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByWinCashAmount
		#region GetByBalanceCashAmount
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount)
		{
			return GetByBalanceCashAmount(balanceCashAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, TransactionManager tm_)
		{
			return GetByBalanceCashAmount(balanceCashAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, TransactionManager tm_)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, int top_)
		{
			return GetByBalanceCashAmount(balanceCashAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, int top_)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, int top_, TransactionManager tm_)
		{
			return GetByBalanceCashAmount(balanceCashAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, int top_, TransactionManager tm_)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, string sort_)
		{
			return GetByBalanceCashAmount(balanceCashAmount, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, string sort_)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, string sort_, TransactionManager tm_)
		{
			return GetByBalanceCashAmount(balanceCashAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBalanceCashAmountAsync(balanceCashAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BalanceCashAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceCashAmount">真金余额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByBalanceCashAmount(long balanceCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceCashAmount` = @BalanceCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByBalanceCashAmountAsync(long balanceCashAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceCashAmount` = @BalanceCashAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceCashAmount", balanceCashAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByBalanceCashAmount
		#region GetByTempWithdrawAmount
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, TransactionManager tm_)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, TransactionManager tm_)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, int top_)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, int top_)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, int top_, TransactionManager tm_)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, int top_, TransactionManager tm_)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, string sort_)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, string sort_)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, string sort_, TransactionManager tm_)
		{
			return GetByTempWithdrawAmount(tempWithdrawAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, string sort_, TransactionManager tm_)
		{
			return await GetByTempWithdrawAmountAsync(tempWithdrawAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TempWithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "tempWithdrawAmount">充值后的临时可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByTempWithdrawAmount(long tempWithdrawAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TempWithdrawAmount` = @TempWithdrawAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByTempWithdrawAmountAsync(long tempWithdrawAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TempWithdrawAmount` = @TempWithdrawAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TempWithdrawAmount", tempWithdrawAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByTempWithdrawAmount
		#region GetByWithdrawAmount
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount)
		{
			return GetByWithdrawAmount(withdrawAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, TransactionManager tm_)
		{
			return GetByWithdrawAmount(withdrawAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, TransactionManager tm_)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, int top_)
		{
			return GetByWithdrawAmount(withdrawAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, int top_)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, int top_, TransactionManager tm_)
		{
			return GetByWithdrawAmount(withdrawAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, int top_, TransactionManager tm_)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, string sort_)
		{
			return GetByWithdrawAmount(withdrawAmount, 0, sort_, null);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, string sort_)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, string sort_, TransactionManager tm_)
		{
			return GetByWithdrawAmount(withdrawAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, string sort_, TransactionManager tm_)
		{
			return await GetByWithdrawAmountAsync(withdrawAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 WithdrawAmount（字段） 查询
		/// </summary>
		/// /// <param name = "withdrawAmount">可提现真金金额(计算可提现金额)</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_user_cash_amountEO> GetByWithdrawAmount(long withdrawAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WithdrawAmount` = @WithdrawAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		public async Task<List<Sc_user_cash_amountEO>> GetByWithdrawAmountAsync(long withdrawAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`WithdrawAmount` = @WithdrawAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@WithdrawAmount", withdrawAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_user_cash_amountEO.MapDataReader);
		}
		#endregion // GetByWithdrawAmount
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
