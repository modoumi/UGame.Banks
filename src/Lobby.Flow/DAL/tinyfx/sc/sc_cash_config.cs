/******************************************************
 * 此代码由代码生成器工具自动生成，请不要修改
 * TinyFx代码生成器核心库版本号：1.0.0.0
 * git: https://github.com/jh98net/TinyFx
 * 文档生成时间：2024-03-15 11: 25:47
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
	/// 提现配置
	/// 【表 sc_cash_config 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_configEO : IRowMapper<Sc_cash_configEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_configEO()
		{
			this.AuditStartAmount = 0;
			this.FirstCashMinAmount = 0;
			this.CashMinAmount = 0;
			this.CashMaxAmount = 0;
			this.CashPayAmount = 0;
			this.DayCashMaxLimitAmount = 0;
			this.DayCashNumLimit = 0;
			this.GlobalFirstCashAuditLimit = 0;
			this.CashComparePayMultiple = 0;
			this.HistoryCashComparePayMultiple = 0.00f;
			this.IsAudit = false;
			this.IsVerifyMobile = false;
			this.CurrCashMaxLimit = 0;
			this.RecDate = DateTime.Now;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private string _originalOperatorID;
		/// <summary>
		/// 【数据库中的原始主键 OperatorID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalOperatorID
		{
			get { return _originalOperatorID; }
			set { HasOriginal = true; _originalOperatorID = value; }
		}
		
		private string _originalCountryID;
		/// <summary>
		/// 【数据库中的原始主键 CountryID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalCountryID
		{
			get { return _originalCountryID; }
			set { HasOriginal = true; _originalCountryID = value; }
		}
		
		private string _originalCurrencyID;
		/// <summary>
		/// 【数据库中的原始主键 CurrencyID 值的副本，用于主键值更新】
		/// </summary>
		public string OriginalCurrencyID
		{
			get { return _originalCurrencyID; }
			set { HasOriginal = true; _originalCurrencyID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "OperatorID", OperatorID },  { "CountryID", CountryID },  { "CurrencyID", CurrencyID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 运营商编码
		/// 【主键 varchar(50)】
		/// </summary>
		[DataMember(Order = 1)]
		public string OperatorID { get; set; }
		/// <summary>
		/// 国家编码ISO 3166-1三位字母
		/// 【主键 varchar(5)】
		/// </summary>
		[DataMember(Order = 2)]
		public string CountryID { get; set; }
		/// <summary>
		/// 货币类型
		/// 【主键 varchar(5)】
		/// </summary>
		[DataMember(Order = 3)]
		public string CurrencyID { get; set; }
		/// <summary>
		/// 审核起始金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 4)]
		public long AuditStartAmount { get; set; }
		/// <summary>
		/// 首次提现最小金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 5)]
		public long FirstCashMinAmount { get; set; }
		/// <summary>
		/// 最低提现金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 6)]
		public long CashMinAmount { get; set; }
		/// <summary>
		/// 最大提现金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long CashMaxAmount { get; set; }
		/// <summary>
		/// 提现时,需要满足的充值金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 8)]
		public long CashPayAmount { get; set; }
		/// <summary>
		/// 当天累计提款上限
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 9)]
		public long DayCashMaxLimitAmount { get; set; }
		/// <summary>
		/// 当天累计提款次数上限
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 10)]
		public int DayCashNumLimit { get; set; }
		/// <summary>
		/// 全局首次提款审批限制
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 11)]
		public long GlobalFirstCashAuditLimit { get; set; }
		/// <summary>
		/// 提现对比充值倍数（超过此倍数，不允许提现）
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 12)]
		public int CashComparePayMultiple { get; set; }
		/// <summary>
		/// (历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 13)]
		public float HistoryCashComparePayMultiple { get; set; }
		/// <summary>
		/// 满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 14)]
		public bool IsAudit { get; set; }
		/// <summary>
		/// 
		/// 【字段 tinyint(1)】
		/// </summary>
		[DataMember(Order = 15)]
		public bool IsVerifyMobile { get; set; }
		/// <summary>
		/// 单次提款上限
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 16)]
		public long CurrCashMaxLimit { get; set; }
		/// <summary>
		/// 创建时间
		/// 【字段 datetime】
		/// </summary>
		[DataMember(Order = 17)]
		public DateTime RecDate { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_configEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_configEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_configEO ret = new Sc_cash_configEO();
			ret.OperatorID = reader.ToString("OperatorID");
			ret.OriginalOperatorID = ret.OperatorID;
			ret.CountryID = reader.ToString("CountryID");
			ret.OriginalCountryID = ret.CountryID;
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.OriginalCurrencyID = ret.CurrencyID;
			ret.AuditStartAmount = reader.ToInt64("AuditStartAmount");
			ret.FirstCashMinAmount = reader.ToInt64("FirstCashMinAmount");
			ret.CashMinAmount = reader.ToInt64("CashMinAmount");
			ret.CashMaxAmount = reader.ToInt64("CashMaxAmount");
			ret.CashPayAmount = reader.ToInt64("CashPayAmount");
			ret.DayCashMaxLimitAmount = reader.ToInt64("DayCashMaxLimitAmount");
			ret.DayCashNumLimit = reader.ToInt32("DayCashNumLimit");
			ret.GlobalFirstCashAuditLimit = reader.ToInt64("GlobalFirstCashAuditLimit");
			ret.CashComparePayMultiple = reader.ToInt32("CashComparePayMultiple");
			ret.HistoryCashComparePayMultiple = reader.ToSingle("HistoryCashComparePayMultiple");
			ret.IsAudit = reader.ToBoolean("IsAudit");
			ret.IsVerifyMobile = reader.ToBoolean("IsVerifyMobile");
			ret.CurrCashMaxLimit = reader.ToInt64("CurrCashMaxLimit");
			ret.RecDate = reader.ToDateTime("RecDate");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 提现配置
	/// 【表 sc_cash_config 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_configMO : MySqlTableMO<Sc_cash_configEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_config`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_configMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_configMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_configMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_); 
		}
		public override async Task<int> AddAsync(Sc_cash_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_); 
		}
	    private void RepairAddData(Sc_cash_configEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperatorID`, `CountryID`, `CurrencyID`, `AuditStartAmount`, `FirstCashMinAmount`, `CashMinAmount`, `CashMaxAmount`, `CashPayAmount`, `DayCashMaxLimitAmount`, `DayCashNumLimit`, `GlobalFirstCashAuditLimit`, `CashComparePayMultiple`, `HistoryCashComparePayMultiple`, `IsAudit`, `IsVerifyMobile`, `CurrCashMaxLimit`, `RecDate`) VALUE (@OperatorID, @CountryID, @CurrencyID, @AuditStartAmount, @FirstCashMinAmount, @CashMinAmount, @CashMaxAmount, @CashPayAmount, @DayCashMaxLimitAmount, @DayCashNumLimit, @GlobalFirstCashAuditLimit, @CashComparePayMultiple, @HistoryCashComparePayMultiple, @IsAudit, @IsVerifyMobile, @CurrCashMaxLimit, @RecDate);";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditStartAmount", item.AuditStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@FirstCashMinAmount", item.FirstCashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashMinAmount", item.CashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashMaxAmount", item.CashMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashPayAmount", item.CashPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@DayCashMaxLimitAmount", item.DayCashMaxLimitAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@DayCashNumLimit", item.DayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@GlobalFirstCashAuditLimit", item.GlobalFirstCashAuditLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@CashComparePayMultiple", item.CashComparePayMultiple, MySqlDbType.Int32),
				Database.CreateInParameter("@HistoryCashComparePayMultiple", item.HistoryCashComparePayMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@IsAudit", item.IsAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@IsVerifyMobile", item.IsVerifyMobile, MySqlDbType.Byte),
				Database.CreateInParameter("@CurrCashMaxLimit", item.CurrCashMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@RecDate", item.RecDate, MySqlDbType.DateTime),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_configEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_configEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_configEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`OperatorID`, `CountryID`, `CurrencyID`, `AuditStartAmount`, `FirstCashMinAmount`, `CashMinAmount`, `CashMaxAmount`, `CashPayAmount`, `DayCashMaxLimitAmount`, `DayCashNumLimit`, `GlobalFirstCashAuditLimit`, `CashComparePayMultiple`, `HistoryCashComparePayMultiple`, `IsAudit`, `IsVerifyMobile`, `CurrCashMaxLimit`, `RecDate`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"('{item.OperatorID}','{item.CountryID}','{item.CurrencyID}',{item.AuditStartAmount},{item.FirstCashMinAmount},{item.CashMinAmount},{item.CashMaxAmount},{item.CashPayAmount},{item.DayCashMaxLimitAmount},{item.DayCashNumLimit},{item.GlobalFirstCashAuditLimit},{item.CashComparePayMultiple},{item.HistoryCashComparePayMultiple},{item.IsAudit},{item.IsVerifyMobile},{item.CurrCashMaxLimit},'{item.RecDate.ToString("yyyy-MM-dd HH:mm:ss")}'),");
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, countryID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(operatorID, countryID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(string operatorID, string countryID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_configEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.OperatorID, item.CountryID, item.CurrencyID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_configEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.OperatorID, item.CountryID, item.CurrencyID, tm_);
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
			sql_ = $"DELETE FROM {TableName} WHERE `OperatorID` = @OperatorID";
			paras_ = new List<MySqlParameter>();
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
			sql_ = $"DELETE FROM {TableName} WHERE `CountryID` = @CountryID";
			paras_ = new List<MySqlParameter>();
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
			sql_ = $"DELETE FROM {TableName} WHERE `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
		}
		#endregion // RemoveByCurrencyID
		#region RemoveByAuditStartAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByAuditStartAmount(long auditStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByAuditStartAmountData(auditStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByAuditStartAmountAsync(long auditStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByAuditStartAmountData(auditStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByAuditStartAmountData(long auditStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `AuditStartAmount` = @AuditStartAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByAuditStartAmount
		#region RemoveByFirstCashMinAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFirstCashMinAmount(long firstCashMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstCashMinAmountData(firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFirstCashMinAmountAsync(long firstCashMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstCashMinAmountData(firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFirstCashMinAmountData(long firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `FirstCashMinAmount` = @FirstCashMinAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByFirstCashMinAmount
		#region RemoveByCashMinAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashMinAmount(long cashMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMinAmountData(cashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashMinAmountAsync(long cashMinAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMinAmountData(cashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashMinAmountData(long cashMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashMinAmount` = @CashMinAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByCashMinAmount
		#region RemoveByCashMaxAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashMaxAmount(long cashMaxAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMaxAmountData(cashMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashMaxAmountAsync(long cashMaxAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMaxAmountData(cashMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashMaxAmountData(long cashMaxAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashMaxAmount` = @CashMaxAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByCashMaxAmount
		#region RemoveByCashPayAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashPayAmount(long cashPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashPayAmountData(cashPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashPayAmountAsync(long cashPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashPayAmountData(cashPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashPayAmountData(long cashPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashPayAmount` = @CashPayAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByCashPayAmount
		#region RemoveByDayCashMaxLimitAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashMaxLimitAmountData(dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashMaxLimitAmountData(dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByDayCashMaxLimitAmountData(long dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `DayCashMaxLimitAmount` = @DayCashMaxLimitAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByDayCashMaxLimitAmount
		#region RemoveByDayCashNumLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashNumLimitData(dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByDayCashNumLimitData(dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByDayCashNumLimitData(int dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `DayCashNumLimit` = @DayCashNumLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
		}
		#endregion // RemoveByDayCashNumLimit
		#region RemoveByGlobalFirstCashAuditLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByGlobalFirstCashAuditLimitData(globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByGlobalFirstCashAuditLimitData(globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByGlobalFirstCashAuditLimitData(long globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByGlobalFirstCashAuditLimit
		#region RemoveByCashComparePayMultiple
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashComparePayMultiple(int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByCashComparePayMultipleData(cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashComparePayMultipleAsync(int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByCashComparePayMultipleData(cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashComparePayMultipleData(int cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashComparePayMultiple` = @CashComparePayMultiple";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32));
		}
		#endregion // RemoveByCashComparePayMultiple
		#region RemoveByHistoryCashComparePayMultiple
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryCashComparePayMultipleData(historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryCashComparePayMultipleData(historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByHistoryCashComparePayMultipleData(float historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float));
		}
		#endregion // RemoveByHistoryCashComparePayMultiple
		#region RemoveByIsAudit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsAudit(bool isAudit, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditData(isAudit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsAuditAsync(bool isAudit, TransactionManager tm_ = null)
		{
			RepairRemoveByIsAuditData(isAudit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsAuditData(bool isAudit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsAudit` = @IsAudit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsAudit
		#region RemoveByIsVerifyMobile
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByIsVerifyMobile(bool isVerifyMobile, TransactionManager tm_ = null)
		{
			RepairRemoveByIsVerifyMobileData(isVerifyMobile, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByIsVerifyMobileAsync(bool isVerifyMobile, TransactionManager tm_ = null)
		{
			RepairRemoveByIsVerifyMobileData(isVerifyMobile, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByIsVerifyMobileData(bool isVerifyMobile, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `IsVerifyMobile` = @IsVerifyMobile";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte));
		}
		#endregion // RemoveByIsVerifyMobile
		#region RemoveByCurrCashMaxLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCurrCashMaxLimit(long currCashMaxLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrCashMaxLimitData(currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCurrCashMaxLimitAsync(long currCashMaxLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCurrCashMaxLimitData(currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCurrCashMaxLimitData(long currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CurrCashMaxLimit` = @CurrCashMaxLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByCurrCashMaxLimit
		#region RemoveByRecDate
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
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
		public int Put(Sc_cash_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_configEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `AuditStartAmount` = @AuditStartAmount, `FirstCashMinAmount` = @FirstCashMinAmount, `CashMinAmount` = @CashMinAmount, `CashMaxAmount` = @CashMaxAmount, `CashPayAmount` = @CashPayAmount, `DayCashMaxLimitAmount` = @DayCashMaxLimitAmount, `DayCashNumLimit` = @DayCashNumLimit, `GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit, `CashComparePayMultiple` = @CashComparePayMultiple, `HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple, `IsAudit` = @IsAudit, `IsVerifyMobile` = @IsVerifyMobile, `CurrCashMaxLimit` = @CurrCashMaxLimit WHERE `OperatorID` = @OperatorID_Original AND `CountryID` = @CountryID_Original AND `CurrencyID` = @CurrencyID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@AuditStartAmount", item.AuditStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@FirstCashMinAmount", item.FirstCashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashMinAmount", item.CashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashMaxAmount", item.CashMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@CashPayAmount", item.CashPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@DayCashMaxLimitAmount", item.DayCashMaxLimitAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@DayCashNumLimit", item.DayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@GlobalFirstCashAuditLimit", item.GlobalFirstCashAuditLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@CashComparePayMultiple", item.CashComparePayMultiple, MySqlDbType.Int32),
				Database.CreateInParameter("@HistoryCashComparePayMultiple", item.HistoryCashComparePayMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@IsAudit", item.IsAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@IsVerifyMobile", item.IsVerifyMobile, MySqlDbType.Byte),
				Database.CreateInParameter("@CurrCashMaxLimit", item.CurrCashMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID_Original", item.HasOriginal ? item.OriginalOperatorID : item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID_Original", item.HasOriginal ? item.OriginalCountryID : item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID_Original", item.HasOriginal ? item.OriginalCurrencyID : item.CurrencyID, MySqlDbType.VarChar),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_configEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_configEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string countryID, string currencyID, string set_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", ConcatValues(values_, operatorID, countryID, currencyID));
		}
		public async Task<int> PutByPKAsync(string operatorID, string countryID, string currencyID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", ConcatValues(values_, operatorID, countryID, currencyID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string countryID, string currencyID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", tm_, ConcatValues(values_, operatorID, countryID, currencyID));
		}
		public async Task<int> PutByPKAsync(string operatorID, string countryID, string currencyID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", tm_, ConcatValues(values_, operatorID, countryID, currencyID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(string operatorID, string countryID, string currencyID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
	        };
			return Put(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(string operatorID, string countryID, string currencyID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
	        };
			return await PutAsync(set_, "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutOperatorID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorID(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOperatorIDAsync(string operatorID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID";
			var parameter_ = Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOperatorID
		#region PutCountryID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryID(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCountryIDAsync(string countryID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID";
			var parameter_ = Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCountryID
		#region PutCurrencyID
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyID(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrencyIDAsync(string currencyID, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID";
			var parameter_ = Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrencyID
		#region PutAuditStartAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAuditStartAmountByPK(string operatorID, string countryID, string currencyID, long auditStartAmount, TransactionManager tm_ = null)
		{
			RepairPutAuditStartAmountByPKData(operatorID, countryID, currencyID, auditStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAuditStartAmountByPKAsync(string operatorID, string countryID, string currencyID, long auditStartAmount, TransactionManager tm_ = null)
		{
			RepairPutAuditStartAmountByPKData(operatorID, countryID, currencyID, auditStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutAuditStartAmountByPKData(string operatorID, string countryID, string currencyID, long auditStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `AuditStartAmount` = @AuditStartAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutAuditStartAmount(long auditStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AuditStartAmount` = @AuditStartAmount";
			var parameter_ = Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutAuditStartAmountAsync(long auditStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `AuditStartAmount` = @AuditStartAmount";
			var parameter_ = Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutAuditStartAmount
		#region PutFirstCashMinAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstCashMinAmountByPK(string operatorID, string countryID, string currencyID, long firstCashMinAmount, TransactionManager tm_ = null)
		{
			RepairPutFirstCashMinAmountByPKData(operatorID, countryID, currencyID, firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFirstCashMinAmountByPKAsync(string operatorID, string countryID, string currencyID, long firstCashMinAmount, TransactionManager tm_ = null)
		{
			RepairPutFirstCashMinAmountByPKData(operatorID, countryID, currencyID, firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFirstCashMinAmountByPKData(string operatorID, string countryID, string currencyID, long firstCashMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FirstCashMinAmount` = @FirstCashMinAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstCashMinAmount(long firstCashMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstCashMinAmount` = @FirstCashMinAmount";
			var parameter_ = Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFirstCashMinAmountAsync(long firstCashMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstCashMinAmount` = @FirstCashMinAmount";
			var parameter_ = Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFirstCashMinAmount
		#region PutCashMinAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMinAmountByPK(string operatorID, string countryID, string currencyID, long cashMinAmount, TransactionManager tm_ = null)
		{
			RepairPutCashMinAmountByPKData(operatorID, countryID, currencyID, cashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashMinAmountByPKAsync(string operatorID, string countryID, string currencyID, long cashMinAmount, TransactionManager tm_ = null)
		{
			RepairPutCashMinAmountByPKData(operatorID, countryID, currencyID, cashMinAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashMinAmountByPKData(string operatorID, string countryID, string currencyID, long cashMinAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashMinAmount` = @CashMinAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMinAmount(long cashMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMinAmount` = @CashMinAmount";
			var parameter_ = Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashMinAmountAsync(long cashMinAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMinAmount` = @CashMinAmount";
			var parameter_ = Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashMinAmount
		#region PutCashMaxAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMaxAmountByPK(string operatorID, string countryID, string currencyID, long cashMaxAmount, TransactionManager tm_ = null)
		{
			RepairPutCashMaxAmountByPKData(operatorID, countryID, currencyID, cashMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashMaxAmountByPKAsync(string operatorID, string countryID, string currencyID, long cashMaxAmount, TransactionManager tm_ = null)
		{
			RepairPutCashMaxAmountByPKData(operatorID, countryID, currencyID, cashMaxAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashMaxAmountByPKData(string operatorID, string countryID, string currencyID, long cashMaxAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashMaxAmount` = @CashMaxAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMaxAmount(long cashMaxAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMaxAmount` = @CashMaxAmount";
			var parameter_ = Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashMaxAmountAsync(long cashMaxAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMaxAmount` = @CashMaxAmount";
			var parameter_ = Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashMaxAmount
		#region PutCashPayAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashPayAmountByPK(string operatorID, string countryID, string currencyID, long cashPayAmount, TransactionManager tm_ = null)
		{
			RepairPutCashPayAmountByPKData(operatorID, countryID, currencyID, cashPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashPayAmountByPKAsync(string operatorID, string countryID, string currencyID, long cashPayAmount, TransactionManager tm_ = null)
		{
			RepairPutCashPayAmountByPKData(operatorID, countryID, currencyID, cashPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashPayAmountByPKData(string operatorID, string countryID, string currencyID, long cashPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashPayAmount` = @CashPayAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashPayAmount(long cashPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashPayAmount` = @CashPayAmount";
			var parameter_ = Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashPayAmountAsync(long cashPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashPayAmount` = @CashPayAmount";
			var parameter_ = Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashPayAmount
		#region PutDayCashMaxLimitAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashMaxLimitAmountByPK(string operatorID, string countryID, string currencyID, long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			RepairPutDayCashMaxLimitAmountByPKData(operatorID, countryID, currencyID, dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutDayCashMaxLimitAmountByPKAsync(string operatorID, string countryID, string currencyID, long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			RepairPutDayCashMaxLimitAmountByPKData(operatorID, countryID, currencyID, dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutDayCashMaxLimitAmountByPKData(string operatorID, string countryID, string currencyID, long dayCashMaxLimitAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DayCashMaxLimitAmount` = @DayCashMaxLimitAmount  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashMaxLimitAmount(long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashMaxLimitAmount` = @DayCashMaxLimitAmount";
			var parameter_ = Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashMaxLimitAmount` = @DayCashMaxLimitAmount";
			var parameter_ = Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDayCashMaxLimitAmount
		#region PutDayCashNumLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashNumLimitByPK(string operatorID, string countryID, string currencyID, int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashNumLimitByPKData(operatorID, countryID, currencyID, dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutDayCashNumLimitByPKAsync(string operatorID, string countryID, string currencyID, int dayCashNumLimit, TransactionManager tm_ = null)
		{
			RepairPutDayCashNumLimitByPKData(operatorID, countryID, currencyID, dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutDayCashNumLimitByPKData(string operatorID, string countryID, string currencyID, int dayCashNumLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit";
			var parameter_ = Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `DayCashNumLimit` = @DayCashNumLimit";
			var parameter_ = Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutDayCashNumLimit
		#region PutGlobalFirstCashAuditLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGlobalFirstCashAuditLimitByPK(string operatorID, string countryID, string currencyID, long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			RepairPutGlobalFirstCashAuditLimitByPKData(operatorID, countryID, currencyID, globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutGlobalFirstCashAuditLimitByPKAsync(string operatorID, string countryID, string currencyID, long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			RepairPutGlobalFirstCashAuditLimitByPKData(operatorID, countryID, currencyID, globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutGlobalFirstCashAuditLimitByPKData(string operatorID, string countryID, string currencyID, long globalFirstCashAuditLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit";
			var parameter_ = Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit";
			var parameter_ = Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutGlobalFirstCashAuditLimit
		#region PutCashComparePayMultiple
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashComparePayMultipleByPK(string operatorID, string countryID, string currencyID, int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairPutCashComparePayMultipleByPKData(operatorID, countryID, currencyID, cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashComparePayMultipleByPKAsync(string operatorID, string countryID, string currencyID, int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairPutCashComparePayMultipleByPKData(operatorID, countryID, currencyID, cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashComparePayMultipleByPKData(string operatorID, string countryID, string currencyID, int cashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashComparePayMultiple` = @CashComparePayMultiple  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashComparePayMultiple(int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashComparePayMultiple` = @CashComparePayMultiple";
			var parameter_ = Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashComparePayMultipleAsync(int cashComparePayMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashComparePayMultiple` = @CashComparePayMultiple";
			var parameter_ = Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashComparePayMultiple
		#region PutHistoryCashComparePayMultiple
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryCashComparePayMultipleByPK(string operatorID, string countryID, string currencyID, float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairPutHistoryCashComparePayMultipleByPKData(operatorID, countryID, currencyID, historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutHistoryCashComparePayMultipleByPKAsync(string operatorID, string countryID, string currencyID, float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			RepairPutHistoryCashComparePayMultipleByPKData(operatorID, countryID, currencyID, historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutHistoryCashComparePayMultipleByPKData(string operatorID, string countryID, string currencyID, float historyCashComparePayMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryCashComparePayMultiple(float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple";
			var parameter_ = Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple";
			var parameter_ = Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHistoryCashComparePayMultiple
		#region PutIsAudit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAuditByPK(string operatorID, string countryID, string currencyID, bool isAudit, TransactionManager tm_ = null)
		{
			RepairPutIsAuditByPKData(operatorID, countryID, currencyID, isAudit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsAuditByPKAsync(string operatorID, string countryID, string currencyID, bool isAudit, TransactionManager tm_ = null)
		{
			RepairPutIsAuditByPKData(operatorID, countryID, currencyID, isAudit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsAuditByPKData(string operatorID, string countryID, string currencyID, bool isAudit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsAudit(bool isAudit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit";
			var parameter_ = Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsAuditAsync(bool isAudit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsAudit` = @IsAudit";
			var parameter_ = Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsAudit
		#region PutIsVerifyMobile
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsVerifyMobileByPK(string operatorID, string countryID, string currencyID, bool isVerifyMobile, TransactionManager tm_ = null)
		{
			RepairPutIsVerifyMobileByPKData(operatorID, countryID, currencyID, isVerifyMobile, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutIsVerifyMobileByPKAsync(string operatorID, string countryID, string currencyID, bool isVerifyMobile, TransactionManager tm_ = null)
		{
			RepairPutIsVerifyMobileByPKData(operatorID, countryID, currencyID, isVerifyMobile, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutIsVerifyMobileByPKData(string operatorID, string countryID, string currencyID, bool isVerifyMobile, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `IsVerifyMobile` = @IsVerifyMobile  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutIsVerifyMobile(bool isVerifyMobile, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsVerifyMobile` = @IsVerifyMobile";
			var parameter_ = Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutIsVerifyMobileAsync(bool isVerifyMobile, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `IsVerifyMobile` = @IsVerifyMobile";
			var parameter_ = Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutIsVerifyMobile
		#region PutCurrCashMaxLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrCashMaxLimitByPK(string operatorID, string countryID, string currencyID, long currCashMaxLimit, TransactionManager tm_ = null)
		{
			RepairPutCurrCashMaxLimitByPKData(operatorID, countryID, currencyID, currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrCashMaxLimitByPKAsync(string operatorID, string countryID, string currencyID, long currCashMaxLimit, TransactionManager tm_ = null)
		{
			RepairPutCurrCashMaxLimitByPKData(operatorID, countryID, currencyID, currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrCashMaxLimitByPKData(string operatorID, string countryID, string currencyID, long currCashMaxLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrCashMaxLimit` = @CurrCashMaxLimit  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrCashMaxLimit(long currCashMaxLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrCashMaxLimit` = @CurrCashMaxLimit";
			var parameter_ = Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCurrCashMaxLimitAsync(long currCashMaxLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CurrCashMaxLimit` = @CurrCashMaxLimit";
			var parameter_ = Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCurrCashMaxLimit
		#region PutRecDate
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutRecDateByPK(string operatorID, string countryID, string currencyID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operatorID, countryID, currencyID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutRecDateByPKAsync(string operatorID, string countryID, string currencyID, DateTime recDate, TransactionManager tm_ = null)
		{
			RepairPutRecDateByPKData(operatorID, countryID, currencyID, recDate, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutRecDateByPKData(string operatorID, string countryID, string currencyID, DateTime recDate, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `RecDate` = @RecDate  WHERE `OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime),
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
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
		public bool Set(Sc_cash_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID, item.CountryID, item.CurrencyID) == null)
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
		public async Task<bool> SetAsync(Sc_cash_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.OperatorID, item.CountryID, item.CurrencyID) == null)
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
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_configEO GetByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, countryID, currencyID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<Sc_cash_configEO> GetByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(operatorID, countryID, currencyID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		private void RepairGetByPKData(string operatorID, string countryID, string currencyID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`OperatorID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CountryID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CountryID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)GetScalar("`CurrencyID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 AuditStartAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetAuditStartAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`AuditStartAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetAuditStartAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`AuditStartAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FirstCashMinAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetFirstCashMinAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`FirstCashMinAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetFirstCashMinAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`FirstCashMinAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashMinAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCashMinAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CashMinAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetCashMinAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CashMinAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashMaxAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCashMaxAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CashMaxAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetCashMaxAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CashMaxAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashPayAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCashPayAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CashPayAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetCashPayAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CashPayAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 DayCashMaxLimitAmount（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetDayCashMaxLimitAmountByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`DayCashMaxLimitAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetDayCashMaxLimitAmountByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`DayCashMaxLimitAmount`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 DayCashNumLimit（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetDayCashNumLimitByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`DayCashNumLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<int> GetDayCashNumLimitByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`DayCashNumLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 GlobalFirstCashAuditLimit（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetGlobalFirstCashAuditLimitByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`GlobalFirstCashAuditLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetGlobalFirstCashAuditLimitByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`GlobalFirstCashAuditLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashComparePayMultiple（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetCashComparePayMultipleByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (int)GetScalar("`CashComparePayMultiple`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<int> GetCashComparePayMultipleByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (int)await GetScalarAsync("`CashComparePayMultiple`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 HistoryCashComparePayMultiple（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetHistoryCashComparePayMultipleByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (float)GetScalar("`HistoryCashComparePayMultiple`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<float> GetHistoryCashComparePayMultipleByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (float)await GetScalarAsync("`HistoryCashComparePayMultiple`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsAudit（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsAuditByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsAudit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<bool> GetIsAuditByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsAudit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 IsVerifyMobile（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public bool GetIsVerifyMobileByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (bool)GetScalar("`IsVerifyMobile`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<bool> GetIsVerifyMobileByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (bool)await GetScalarAsync("`IsVerifyMobile`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrCashMaxLimit（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCurrCashMaxLimitByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)GetScalar("`CurrCashMaxLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<long> GetCurrCashMaxLimitByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (long)await GetScalarAsync("`CurrCashMaxLimit`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 RecDate（字段）
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public DateTime GetRecDateByPK(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (DateTime)GetScalar("`RecDate`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		public async Task<DateTime> GetRecDateByPKAsync(string operatorID, string countryID, string currencyID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
			};
			return (DateTime)await GetScalarAsync("`RecDate`", "`OperatorID` = @OperatorID AND `CountryID` = @CountryID AND `CurrencyID` = @CurrencyID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_configEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<Sc_cash_configEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<Sc_cash_configEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_configEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_configEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByAuditStartAmount
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount)
		{
			return GetByAuditStartAmount(auditStartAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, TransactionManager tm_)
		{
			return GetByAuditStartAmount(auditStartAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, TransactionManager tm_)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, int top_)
		{
			return GetByAuditStartAmount(auditStartAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, int top_)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, int top_, TransactionManager tm_)
		{
			return GetByAuditStartAmount(auditStartAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, int top_, TransactionManager tm_)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, string sort_)
		{
			return GetByAuditStartAmount(auditStartAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, string sort_)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, string sort_, TransactionManager tm_)
		{
			return GetByAuditStartAmount(auditStartAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, string sort_, TransactionManager tm_)
		{
			return await GetByAuditStartAmountAsync(auditStartAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 AuditStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "auditStartAmount">审核起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByAuditStartAmount(long auditStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AuditStartAmount` = @AuditStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByAuditStartAmountAsync(long auditStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`AuditStartAmount` = @AuditStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@AuditStartAmount", auditStartAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByAuditStartAmount
		#region GetByFirstCashMinAmount
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, TransactionManager tm_)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, TransactionManager tm_)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, int top_)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, int top_)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, int top_, TransactionManager tm_)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, int top_, TransactionManager tm_)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, string sort_)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, string sort_)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, string sort_, TransactionManager tm_)
		{
			return GetByFirstCashMinAmount(firstCashMinAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, string sort_, TransactionManager tm_)
		{
			return await GetByFirstCashMinAmountAsync(firstCashMinAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FirstCashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "firstCashMinAmount">首次提现最小金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByFirstCashMinAmount(long firstCashMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstCashMinAmount` = @FirstCashMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByFirstCashMinAmountAsync(long firstCashMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstCashMinAmount` = @FirstCashMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstCashMinAmount", firstCashMinAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByFirstCashMinAmount
		#region GetByCashMinAmount
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount)
		{
			return GetByCashMinAmount(cashMinAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, TransactionManager tm_)
		{
			return GetByCashMinAmount(cashMinAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, TransactionManager tm_)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, int top_)
		{
			return GetByCashMinAmount(cashMinAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, int top_)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, int top_, TransactionManager tm_)
		{
			return GetByCashMinAmount(cashMinAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, int top_, TransactionManager tm_)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, string sort_)
		{
			return GetByCashMinAmount(cashMinAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, string sort_)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, string sort_, TransactionManager tm_)
		{
			return GetByCashMinAmount(cashMinAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, string sort_, TransactionManager tm_)
		{
			return await GetByCashMinAmountAsync(cashMinAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashMinAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMinAmount">最低提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMinAmount(long cashMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMinAmount` = @CashMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMinAmountAsync(long cashMinAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMinAmount` = @CashMinAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMinAmount", cashMinAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCashMinAmount
		#region GetByCashMaxAmount
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount)
		{
			return GetByCashMaxAmount(cashMaxAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, TransactionManager tm_)
		{
			return GetByCashMaxAmount(cashMaxAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, TransactionManager tm_)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, int top_)
		{
			return GetByCashMaxAmount(cashMaxAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, int top_)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, int top_, TransactionManager tm_)
		{
			return GetByCashMaxAmount(cashMaxAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, int top_, TransactionManager tm_)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, string sort_)
		{
			return GetByCashMaxAmount(cashMaxAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, string sort_)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, string sort_, TransactionManager tm_)
		{
			return GetByCashMaxAmount(cashMaxAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, string sort_, TransactionManager tm_)
		{
			return await GetByCashMaxAmountAsync(cashMaxAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashMaxAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashMaxAmount">最大提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashMaxAmount(long cashMaxAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMaxAmount` = @CashMaxAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashMaxAmountAsync(long cashMaxAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMaxAmount` = @CashMaxAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMaxAmount", cashMaxAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCashMaxAmount
		#region GetByCashPayAmount
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount)
		{
			return GetByCashPayAmount(cashPayAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, TransactionManager tm_)
		{
			return GetByCashPayAmount(cashPayAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, TransactionManager tm_)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, int top_)
		{
			return GetByCashPayAmount(cashPayAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, int top_)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, int top_, TransactionManager tm_)
		{
			return GetByCashPayAmount(cashPayAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, int top_, TransactionManager tm_)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, string sort_)
		{
			return GetByCashPayAmount(cashPayAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, string sort_)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, string sort_, TransactionManager tm_)
		{
			return GetByCashPayAmount(cashPayAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, string sort_, TransactionManager tm_)
		{
			return await GetByCashPayAmountAsync(cashPayAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashPayAmount">提现时,需要满足的充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashPayAmount(long cashPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashPayAmount` = @CashPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashPayAmountAsync(long cashPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashPayAmount` = @CashPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashPayAmount", cashPayAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCashPayAmount
		#region GetByDayCashMaxLimitAmount
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, TransactionManager tm_)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, TransactionManager tm_)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, int top_)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, int top_)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, int top_, TransactionManager tm_)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, int top_, TransactionManager tm_)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, string sort_)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, string sort_)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, string sort_, TransactionManager tm_)
		{
			return GetByDayCashMaxLimitAmount(dayCashMaxLimitAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, string sort_, TransactionManager tm_)
		{
			return await GetByDayCashMaxLimitAmountAsync(dayCashMaxLimitAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DayCashMaxLimitAmount（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashMaxLimitAmount">当天累计提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashMaxLimitAmount(long dayCashMaxLimitAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashMaxLimitAmount` = @DayCashMaxLimitAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashMaxLimitAmountAsync(long dayCashMaxLimitAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashMaxLimitAmount` = @DayCashMaxLimitAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashMaxLimitAmount", dayCashMaxLimitAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByDayCashMaxLimitAmount
		#region GetByDayCashNumLimit
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, string sort_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, string sort_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, string sort_, TransactionManager tm_)
		{
			return GetByDayCashNumLimit(dayCashNumLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, string sort_, TransactionManager tm_)
		{
			return await GetByDayCashNumLimitAsync(dayCashNumLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 DayCashNumLimit（字段） 查询
		/// </summary>
		/// /// <param name = "dayCashNumLimit">当天累计提款次数上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByDayCashNumLimit(int dayCashNumLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashNumLimit` = @DayCashNumLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByDayCashNumLimitAsync(int dayCashNumLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`DayCashNumLimit` = @DayCashNumLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@DayCashNumLimit", dayCashNumLimit, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByDayCashNumLimit
		#region GetByGlobalFirstCashAuditLimit
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, TransactionManager tm_)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, TransactionManager tm_)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, int top_)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, int top_)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, int top_, TransactionManager tm_)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, int top_, TransactionManager tm_)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, string sort_)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, string sort_)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, string sort_, TransactionManager tm_)
		{
			return GetByGlobalFirstCashAuditLimit(globalFirstCashAuditLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, string sort_, TransactionManager tm_)
		{
			return await GetByGlobalFirstCashAuditLimitAsync(globalFirstCashAuditLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 GlobalFirstCashAuditLimit（字段） 查询
		/// </summary>
		/// /// <param name = "globalFirstCashAuditLimit">全局首次提款审批限制</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByGlobalFirstCashAuditLimit(long globalFirstCashAuditLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByGlobalFirstCashAuditLimitAsync(long globalFirstCashAuditLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`GlobalFirstCashAuditLimit` = @GlobalFirstCashAuditLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@GlobalFirstCashAuditLimit", globalFirstCashAuditLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByGlobalFirstCashAuditLimit
		#region GetByCashComparePayMultiple
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, TransactionManager tm_)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, TransactionManager tm_)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, int top_)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, int top_)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, int top_, TransactionManager tm_)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, int top_, TransactionManager tm_)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, string sort_)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, string sort_)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, string sort_, TransactionManager tm_)
		{
			return GetByCashComparePayMultiple(cashComparePayMultiple, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, string sort_, TransactionManager tm_)
		{
			return await GetByCashComparePayMultipleAsync(cashComparePayMultiple, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "cashComparePayMultiple">提现对比充值倍数（超过此倍数，不允许提现）</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCashComparePayMultiple(int cashComparePayMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashComparePayMultiple` = @CashComparePayMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCashComparePayMultipleAsync(int cashComparePayMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashComparePayMultiple` = @CashComparePayMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashComparePayMultiple", cashComparePayMultiple, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCashComparePayMultiple
		#region GetByHistoryCashComparePayMultiple
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, TransactionManager tm_)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, TransactionManager tm_)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, int top_)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, int top_)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, int top_, TransactionManager tm_)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, int top_, TransactionManager tm_)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, string sort_)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, string sort_)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, string sort_, TransactionManager tm_)
		{
			return GetByHistoryCashComparePayMultiple(historyCashComparePayMultiple, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, string sort_, TransactionManager tm_)
		{
			return await GetByHistoryCashComparePayMultipleAsync(historyCashComparePayMultiple, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HistoryCashComparePayMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyCashComparePayMultiple">(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByHistoryCashComparePayMultiple(float historyCashComparePayMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByHistoryCashComparePayMultipleAsync(float historyCashComparePayMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryCashComparePayMultiple` = @HistoryCashComparePayMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryCashComparePayMultiple", historyCashComparePayMultiple, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByHistoryCashComparePayMultiple
		#region GetByIsAudit
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit)
		{
			return GetByIsAudit(isAudit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit)
		{
			return await GetByIsAuditAsync(isAudit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, int top_)
		{
			return GetByIsAudit(isAudit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, int top_)
		{
			return await GetByIsAuditAsync(isAudit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, int top_, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, int top_, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, string sort_)
		{
			return GetByIsAudit(isAudit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, string sort_)
		{
			return await GetByIsAuditAsync(isAudit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, string sort_, TransactionManager tm_)
		{
			return GetByIsAudit(isAudit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, string sort_, TransactionManager tm_)
		{
			return await GetByIsAuditAsync(isAudit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsAudit（字段） 查询
		/// </summary>
		/// /// <param name = "isAudit">满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsAudit(bool isAudit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAudit` = @IsAudit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsAuditAsync(bool isAudit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsAudit` = @IsAudit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsAudit", isAudit, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByIsAudit
		#region GetByIsVerifyMobile
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile)
		{
			return GetByIsVerifyMobile(isVerifyMobile, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, TransactionManager tm_)
		{
			return GetByIsVerifyMobile(isVerifyMobile, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, TransactionManager tm_)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, int top_)
		{
			return GetByIsVerifyMobile(isVerifyMobile, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, int top_)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, int top_, TransactionManager tm_)
		{
			return GetByIsVerifyMobile(isVerifyMobile, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, int top_, TransactionManager tm_)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, string sort_)
		{
			return GetByIsVerifyMobile(isVerifyMobile, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, string sort_)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, string sort_, TransactionManager tm_)
		{
			return GetByIsVerifyMobile(isVerifyMobile, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, string sort_, TransactionManager tm_)
		{
			return await GetByIsVerifyMobileAsync(isVerifyMobile, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 IsVerifyMobile（字段） 查询
		/// </summary>
		/// /// <param name = "isVerifyMobile"></param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByIsVerifyMobile(bool isVerifyMobile, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsVerifyMobile` = @IsVerifyMobile", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByIsVerifyMobileAsync(bool isVerifyMobile, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`IsVerifyMobile` = @IsVerifyMobile", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@IsVerifyMobile", isVerifyMobile, MySqlDbType.Byte));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByIsVerifyMobile
		#region GetByCurrCashMaxLimit
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, TransactionManager tm_)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, TransactionManager tm_)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, int top_)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, int top_)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, int top_, TransactionManager tm_)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, int top_, TransactionManager tm_)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, string sort_)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, string sort_)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, string sort_, TransactionManager tm_)
		{
			return GetByCurrCashMaxLimit(currCashMaxLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, string sort_, TransactionManager tm_)
		{
			return await GetByCurrCashMaxLimitAsync(currCashMaxLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CurrCashMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "currCashMaxLimit">单次提款上限</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByCurrCashMaxLimit(long currCashMaxLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrCashMaxLimit` = @CurrCashMaxLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByCurrCashMaxLimitAsync(long currCashMaxLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrCashMaxLimit` = @CurrCashMaxLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrCashMaxLimit", currCashMaxLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByCurrCashMaxLimit
		#region GetByRecDate
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate)
		{
			return GetByRecDate(recDate, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, int top_)
		{
			return GetByRecDate(recDate, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, int top_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, int top_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, int top_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, string sort_)
		{
			return GetByRecDate(recDate, 0, sort_, null);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, string sort_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return GetByRecDate(recDate, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, string sort_, TransactionManager tm_)
		{
			return await GetByRecDateAsync(recDate, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 RecDate（字段） 查询
		/// </summary>
		/// /// <param name = "recDate">创建时间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_configEO> GetByRecDate(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_configEO>> GetByRecDateAsync(DateTime recDate, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`RecDate` = @RecDate", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@RecDate", recDate, MySqlDbType.DateTime));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_configEO.MapDataReader);
		}
		#endregion // GetByRecDate
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
