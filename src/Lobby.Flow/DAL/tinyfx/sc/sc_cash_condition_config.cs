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
	/// 体现条件配置
	/// 【表 sc_cash_condition_config 的实体类】
	/// </summary>
	[DataContract]
	[Obsolete]
	public class Sc_cash_condition_configEO : IRowMapper<Sc_cash_condition_configEO>
	{
		/// <summary>
		/// 构造函数 
		/// </summary>
		public Sc_cash_condition_configEO()
		{
			this.ConditionType = 0;
			this.FirstPayAmountStart = 0;
			this.FirstPayAmountEnd = 0;
			this.CashCompareTotalPayAmount = 0.00f;
			this.TotalPayCountStart = 0;
			this.TotalPayCountEnd = 0;
			this.TotalPayAmountStartLimit = 0;
			this.TotalPayAmountMaxLimit = 0;
			this.BalanceStartAmount = 0;
			this.BalanceEndAmount = 0;
			this.TotalPayAmount = 0;
			this.HistoryTotalPayAmountMultiple = 0.00f;
			this.HistoryTotalPayAmountMultiple1 = 0.00f;
			this.CashMultipLimit = 0.00f;
			this.CashAmountLimit = 0;
			this.BalanceLimit = 0;
			this.OrderNum = 0;
		}
		#region 主键原始值 & 主键集合
	    
		/// <summary>
		/// 当前对象是否保存原始主键值，当修改了主键值时为 true
		/// </summary>
		public bool HasOriginal { get; protected set; }
		
		private int _originalConfigID;
		/// <summary>
		/// 【数据库中的原始主键 ConfigID 值的副本，用于主键值更新】
		/// </summary>
		public int OriginalConfigID
		{
			get { return _originalConfigID; }
			set { HasOriginal = true; _originalConfigID = value; }
		}
	    /// <summary>
	    /// 获取主键集合。key: 数据库字段名称, value: 主键值
	    /// </summary>
	    /// <returns></returns>
	    public Dictionary<string, object> GetPrimaryKeys()
	    {
	        return new Dictionary<string, object>() { { "ConfigID", ConfigID }, };
	    }
	    /// <summary>
	    /// 获取主键集合JSON格式
	    /// </summary>
	    /// <returns></returns>
	    public string GetPrimaryKeysJson() => SerializerUtil.SerializeJson(GetPrimaryKeys());
		#endregion // 主键原始值
		#region 所有字段
		/// <summary>
		/// 配置ID
		/// 【主键 int】
		/// </summary>
		[DataMember(Order = 1)]
		public int ConfigID { get; set; }
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
		/// 条件类型
		/// 0-预留
		/// 1-判断是否审批，FirstPayAmountStart、FirstPayAmountEnd、CashCompareTotalPayAmount
		/// 2-判断是否审批，TotalPayCountStart、TotalPayCountEnd、CashCompareTotalPayAmount
		/// 3-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit
		/// 4-判断是否可提现，BalanceStartAmount、BalanceEndAmount、TotalPayAmount
		/// 5-判断是否审批，HistoryTotalPayAmountMultiple、HistoryTotalPayAmountMultiple1
		/// 6-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit、CashMultipLimit、CashAmountLimit、BalanceLimit
		/// 7-判断是否审批，HistoryTotalPayAmountMultiple
		/// 8-判断是否审批，HistoryTotalPayAmountMultiple、HistoryTotalPayAmountMultiple1
		/// 9-判断是否审批，HistoryTotalPayAmountMultiple + 提现审批是否有退回、挂起记录
		/// 10-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit、CashMultipLimit、CashAmountLimit、BalanceLimit
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 5)]
		public int ConditionType { get; set; }
		/// <summary>
		/// 首次充值金额起始值
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 6)]
		public long FirstPayAmountStart { get; set; }
		/// <summary>
		/// 首次充值金额截止值
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 7)]
		public long FirstPayAmountEnd { get; set; }
		/// <summary>
		/// 本次提现金额对比累计充值金额
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 8)]
		public float CashCompareTotalPayAmount { get; set; }
		/// <summary>
		/// 累计充值次数起始值
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 9)]
		public int TotalPayCountStart { get; set; }
		/// <summary>
		/// 累计充值次数截止值
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 10)]
		public int TotalPayCountEnd { get; set; }
		/// <summary>
		/// 累计充值起始金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 11)]
		public long TotalPayAmountStartLimit { get; set; }
		/// <summary>
		/// 累计充值金额截止值
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 12)]
		public long TotalPayAmountMaxLimit { get; set; }
		/// <summary>
		/// 余额起始区间
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 13)]
		public long BalanceStartAmount { get; set; }
		/// <summary>
		/// 余额截止区间
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 14)]
		public long BalanceEndAmount { get; set; }
		/// <summary>
		/// 充值总金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 15)]
		public long TotalPayAmount { get; set; }
		/// <summary>
		/// 历史总充值金额倍数
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 16)]
		public float HistoryTotalPayAmountMultiple { get; set; }
		/// <summary>
		/// 历史总充值金额倍数1
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 17)]
		public float HistoryTotalPayAmountMultiple1 { get; set; }
		/// <summary>
		/// 提现倍数
		/// 【字段 float(10,2)】
		/// </summary>
		[DataMember(Order = 18)]
		public float CashMultipLimit { get; set; }
		/// <summary>
		/// 提现金额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 19)]
		public long CashAmountLimit { get; set; }
		/// <summary>
		/// 余额
		/// 【字段 bigint】
		/// </summary>
		[DataMember(Order = 20)]
		public long BalanceLimit { get; set; }
		/// <summary>
		/// 排序字段
		/// 【字段 int】
		/// </summary>
		[DataMember(Order = 21)]
		public int OrderNum { get; set; }
		#endregion // 所有列
		#region 实体映射
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public Sc_cash_condition_configEO MapRow(IDataReader reader)
		{
			return MapDataReader(reader);
		}
		
		/// <summary>
		/// 将IDataReader映射成实体对象
		/// </summary>
		/// <param name = "reader">只进结果集流</param>
		/// <return>实体对象</return>
		public static Sc_cash_condition_configEO MapDataReader(IDataReader reader)
		{
		    Sc_cash_condition_configEO ret = new Sc_cash_condition_configEO();
			ret.ConfigID = reader.ToInt32("ConfigID");
			ret.OriginalConfigID = ret.ConfigID;
			ret.OperatorID = reader.ToString("OperatorID");
			ret.CountryID = reader.ToString("CountryID");
			ret.CurrencyID = reader.ToString("CurrencyID");
			ret.ConditionType = reader.ToInt32("ConditionType");
			ret.FirstPayAmountStart = reader.ToInt64("FirstPayAmountStart");
			ret.FirstPayAmountEnd = reader.ToInt64("FirstPayAmountEnd");
			ret.CashCompareTotalPayAmount = reader.ToSingle("CashCompareTotalPayAmount");
			ret.TotalPayCountStart = reader.ToInt32("TotalPayCountStart");
			ret.TotalPayCountEnd = reader.ToInt32("TotalPayCountEnd");
			ret.TotalPayAmountStartLimit = reader.ToInt64("TotalPayAmountStartLimit");
			ret.TotalPayAmountMaxLimit = reader.ToInt64("TotalPayAmountMaxLimit");
			ret.BalanceStartAmount = reader.ToInt64("BalanceStartAmount");
			ret.BalanceEndAmount = reader.ToInt64("BalanceEndAmount");
			ret.TotalPayAmount = reader.ToInt64("TotalPayAmount");
			ret.HistoryTotalPayAmountMultiple = reader.ToSingle("HistoryTotalPayAmountMultiple");
			ret.HistoryTotalPayAmountMultiple1 = reader.ToSingle("HistoryTotalPayAmountMultiple1");
			ret.CashMultipLimit = reader.ToSingle("CashMultipLimit");
			ret.CashAmountLimit = reader.ToInt64("CashAmountLimit");
			ret.BalanceLimit = reader.ToInt64("BalanceLimit");
			ret.OrderNum = reader.ToInt32("OrderNum");
		    return ret;
		}
		
		#endregion
	}
	#endregion // EO

	#region MO
	/// <summary>
	/// 体现条件配置
	/// 【表 sc_cash_condition_config 的操作类】
	/// </summary>
	[Obsolete]
	public class Sc_cash_condition_configMO : MySqlTableMO<Sc_cash_condition_configEO>
	{
		/// <summary>
		/// 表名
		/// </summary>
	    public override string TableName { get; set; } = "`sc_cash_condition_config`";
	    
		#region Constructors
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "database">数据来源</param>
		public Sc_cash_condition_configMO(MySqlDatabase database) : base(database) { }
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name = "connectionStringName">配置文件.config中定义的连接字符串名称</param>
		public Sc_cash_condition_configMO(string connectionStringName = null) : base(connectionStringName) { }
	    /// <summary>
	    /// 构造函数
	    /// </summary>
	    /// <param name="connectionString">数据库连接字符串，如server=192.168.1.1;database=testdb;uid=root;pwd=root</param>
	    /// <param name="commandTimeout">CommandTimeout时间</param>
	    public Sc_cash_condition_configMO(string connectionString, int commandTimeout) : base(connectionString, commandTimeout) { }
		#endregion // Constructors
	    
	    #region  Add
		/// <summary>
		/// 插入数据
		/// </summary>
		/// <param name = "item">要插入的实体对象</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="useIgnore_">是否使用INSERT IGNORE</param>
		/// <return>受影响的行数</return>
		public override int Add(Sc_cash_condition_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			item.ConfigID = Database.ExecSqlScalar<int>(sql_, paras_, tm_); 
			return 1;
		}
		public override async Task<int> AddAsync(Sc_cash_condition_configEO item, TransactionManager tm_ = null, bool useIgnore_ = false)
		{
			RepairAddData(item, useIgnore_, out string sql_, out List<MySqlParameter> paras_);
			item.ConfigID = await Database.ExecSqlScalarAsync<int>(sql_, paras_, tm_); 
	        return 1;
		}
	    private void RepairAddData(Sc_cash_condition_configEO item, bool useIgnore_, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = useIgnore_ ? "INSERT IGNORE" : "INSERT";
			sql_ += $" INTO {TableName} (`OperatorID`, `CountryID`, `CurrencyID`, `ConditionType`, `FirstPayAmountStart`, `FirstPayAmountEnd`, `CashCompareTotalPayAmount`, `TotalPayCountStart`, `TotalPayCountEnd`, `TotalPayAmountStartLimit`, `TotalPayAmountMaxLimit`, `BalanceStartAmount`, `BalanceEndAmount`, `TotalPayAmount`, `HistoryTotalPayAmountMultiple`, `HistoryTotalPayAmountMultiple1`, `CashMultipLimit`, `CashAmountLimit`, `BalanceLimit`, `OrderNum`) VALUE (@OperatorID, @CountryID, @CurrencyID, @ConditionType, @FirstPayAmountStart, @FirstPayAmountEnd, @CashCompareTotalPayAmount, @TotalPayCountStart, @TotalPayCountEnd, @TotalPayAmountStartLimit, @TotalPayAmountMaxLimit, @BalanceStartAmount, @BalanceEndAmount, @TotalPayAmount, @HistoryTotalPayAmountMultiple, @HistoryTotalPayAmountMultiple1, @CashMultipLimit, @CashAmountLimit, @BalanceLimit, @OrderNum);SELECT LAST_INSERT_ID();";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ConditionType", item.ConditionType, MySqlDbType.Int32),
				Database.CreateInParameter("@FirstPayAmountStart", item.FirstPayAmountStart, MySqlDbType.Int64),
				Database.CreateInParameter("@FirstPayAmountEnd", item.FirstPayAmountEnd, MySqlDbType.Int64),
				Database.CreateInParameter("@CashCompareTotalPayAmount", item.CashCompareTotalPayAmount, MySqlDbType.Float),
				Database.CreateInParameter("@TotalPayCountStart", item.TotalPayCountStart, MySqlDbType.Int32),
				Database.CreateInParameter("@TotalPayCountEnd", item.TotalPayCountEnd, MySqlDbType.Int32),
				Database.CreateInParameter("@TotalPayAmountStartLimit", item.TotalPayAmountStartLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@TotalPayAmountMaxLimit", item.TotalPayAmountMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceStartAmount", item.BalanceStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceEndAmount", item.BalanceEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@TotalPayAmount", item.TotalPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple", item.HistoryTotalPayAmountMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", item.HistoryTotalPayAmountMultiple1, MySqlDbType.Float),
				Database.CreateInParameter("@CashMultipLimit", item.CashMultipLimit, MySqlDbType.Float),
				Database.CreateInParameter("@CashAmountLimit", item.CashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceLimit", item.BalanceLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
			};
		}
		public int AddByBatch(IEnumerable<Sc_cash_condition_configEO> items, int batchCount, TransactionManager tm_ = null)
		{
			var ret = 0;
			foreach (var sql in BuildAddBatchSql(items, batchCount))
			{
				ret += Database.ExecSqlNonQuery(sql, tm_);
	        }
			return ret;
		}
	    public async Task<int> AddByBatchAsync(IEnumerable<Sc_cash_condition_configEO> items, int batchCount, TransactionManager tm_ = null)
	    {
	        var ret = 0;
	        foreach (var sql in BuildAddBatchSql(items, batchCount))
	        {
	            ret += await Database.ExecSqlNonQueryAsync(sql, tm_);
	        }
	        return ret;
	    }
	    private IEnumerable<string> BuildAddBatchSql(IEnumerable<Sc_cash_condition_configEO> items, int batchCount)
		{
			var count = 0;
	        var insertSql = $"INSERT INTO {TableName} (`ConfigID`, `OperatorID`, `CountryID`, `CurrencyID`, `ConditionType`, `FirstPayAmountStart`, `FirstPayAmountEnd`, `CashCompareTotalPayAmount`, `TotalPayCountStart`, `TotalPayCountEnd`, `TotalPayAmountStartLimit`, `TotalPayAmountMaxLimit`, `BalanceStartAmount`, `BalanceEndAmount`, `TotalPayAmount`, `HistoryTotalPayAmountMultiple`, `HistoryTotalPayAmountMultiple1`, `CashMultipLimit`, `CashAmountLimit`, `BalanceLimit`, `OrderNum`) VALUES ";
			var sql = new StringBuilder();
	        foreach (var item in items)
			{
				count++;
				sql.Append($"({item.ConfigID},'{item.OperatorID}','{item.CountryID}','{item.CurrencyID}',{item.ConditionType},{item.FirstPayAmountStart},{item.FirstPayAmountEnd},{item.CashCompareTotalPayAmount},{item.TotalPayCountStart},{item.TotalPayCountEnd},{item.TotalPayAmountStartLimit},{item.TotalPayAmountMaxLimit},{item.BalanceStartAmount},{item.BalanceEndAmount},{item.TotalPayAmount},{item.HistoryTotalPayAmountMultiple},{item.HistoryTotalPayAmountMultiple1},{item.CashMultipLimit},{item.CashAmountLimit},{item.BalanceLimit},{item.OrderNum}),");
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
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByPK(int configID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(configID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByPKAsync(int configID, TransactionManager tm_ = null)
		{
			RepiarRemoveByPKData(configID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepiarRemoveByPKData(int configID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
		/// <summary>
		/// 删除指定实体对应的记录
		/// </summary>
		/// <param name = "item">要删除的实体</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Remove(Sc_cash_condition_configEO item, TransactionManager tm_ = null)
		{
			return RemoveByPK(item.ConfigID, tm_);
		}
		public async Task<int> RemoveAsync(Sc_cash_condition_configEO item, TransactionManager tm_ = null)
		{
			return await RemoveByPKAsync(item.ConfigID, tm_);
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
		#region RemoveByConditionType
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByConditionType(int conditionType, TransactionManager tm_ = null)
		{
			RepairRemoveByConditionTypeData(conditionType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByConditionTypeAsync(int conditionType, TransactionManager tm_ = null)
		{
			RepairRemoveByConditionTypeData(conditionType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByConditionTypeData(int conditionType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `ConditionType` = @ConditionType";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32));
		}
		#endregion // RemoveByConditionType
		#region RemoveByFirstPayAmountStart
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFirstPayAmountStart(long firstPayAmountStart, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstPayAmountStartData(firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFirstPayAmountStartAsync(long firstPayAmountStart, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstPayAmountStartData(firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFirstPayAmountStartData(long firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `FirstPayAmountStart` = @FirstPayAmountStart";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64));
		}
		#endregion // RemoveByFirstPayAmountStart
		#region RemoveByFirstPayAmountEnd
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByFirstPayAmountEnd(long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstPayAmountEndData(firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByFirstPayAmountEndAsync(long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByFirstPayAmountEndData(firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByFirstPayAmountEndData(long firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `FirstPayAmountEnd` = @FirstPayAmountEnd";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64));
		}
		#endregion // RemoveByFirstPayAmountEnd
		#region RemoveByCashCompareTotalPayAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashCompareTotalPayAmountData(cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByCashCompareTotalPayAmountData(cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashCompareTotalPayAmountData(float cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashCompareTotalPayAmount` = @CashCompareTotalPayAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float));
		}
		#endregion // RemoveByCashCompareTotalPayAmount
		#region RemoveByTotalPayCountStart
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTotalPayCountStart(int totalPayCountStart, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayCountStartData(totalPayCountStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTotalPayCountStartAsync(int totalPayCountStart, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayCountStartData(totalPayCountStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTotalPayCountStartData(int totalPayCountStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TotalPayCountStart` = @TotalPayCountStart";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32));
		}
		#endregion // RemoveByTotalPayCountStart
		#region RemoveByTotalPayCountEnd
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTotalPayCountEnd(int totalPayCountEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayCountEndData(totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTotalPayCountEndAsync(int totalPayCountEnd, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayCountEndData(totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTotalPayCountEndData(int totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TotalPayCountEnd` = @TotalPayCountEnd";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32));
		}
		#endregion // RemoveByTotalPayCountEnd
		#region RemoveByTotalPayAmountStartLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTotalPayAmountStartLimit(long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountStartLimitData(totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountStartLimitData(totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTotalPayAmountStartLimitData(long totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TotalPayAmountStartLimit` = @TotalPayAmountStartLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByTotalPayAmountStartLimit
		#region RemoveByTotalPayAmountMaxLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountMaxLimitData(totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountMaxLimitData(totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTotalPayAmountMaxLimitData(long totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByTotalPayAmountMaxLimit
		#region RemoveByBalanceStartAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBalanceStartAmount(long balanceStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceStartAmountData(balanceStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBalanceStartAmountAsync(long balanceStartAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceStartAmountData(balanceStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBalanceStartAmountData(long balanceStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BalanceStartAmount` = @BalanceStartAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBalanceStartAmount
		#region RemoveByBalanceEndAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBalanceEndAmount(long balanceEndAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceEndAmountData(balanceEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBalanceEndAmountAsync(long balanceEndAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceEndAmountData(balanceEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBalanceEndAmountData(long balanceEndAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BalanceEndAmount` = @BalanceEndAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByBalanceEndAmount
		#region RemoveByTotalPayAmount
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByTotalPayAmount(long totalPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountData(totalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByTotalPayAmountAsync(long totalPayAmount, TransactionManager tm_ = null)
		{
			RepairRemoveByTotalPayAmountData(totalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByTotalPayAmountData(long totalPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `TotalPayAmount` = @TotalPayAmount";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64));
		}
		#endregion // RemoveByTotalPayAmount
		#region RemoveByHistoryTotalPayAmountMultiple
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryTotalPayAmountMultipleData(historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryTotalPayAmountMultipleData(historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByHistoryTotalPayAmountMultipleData(float historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float));
		}
		#endregion // RemoveByHistoryTotalPayAmountMultiple
		#region RemoveByHistoryTotalPayAmountMultiple1
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryTotalPayAmountMultiple1Data(historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			RepairRemoveByHistoryTotalPayAmountMultiple1Data(historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByHistoryTotalPayAmountMultiple1Data(float historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float));
		}
		#endregion // RemoveByHistoryTotalPayAmountMultiple1
		#region RemoveByCashMultipLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashMultipLimit(float cashMultipLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMultipLimitData(cashMultipLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashMultipLimitAsync(float cashMultipLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCashMultipLimitData(cashMultipLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashMultipLimitData(float cashMultipLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashMultipLimit` = @CashMultipLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float));
		}
		#endregion // RemoveByCashMultipLimit
		#region RemoveByCashAmountLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByCashAmountLimit(long cashAmountLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCashAmountLimitData(cashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByCashAmountLimitAsync(long cashAmountLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByCashAmountLimitData(cashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByCashAmountLimitData(long cashAmountLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `CashAmountLimit` = @CashAmountLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByCashAmountLimit
		#region RemoveByBalanceLimit
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByBalanceLimit(long balanceLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceLimitData(balanceLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByBalanceLimitAsync(long balanceLimit, TransactionManager tm_ = null)
		{
			RepairRemoveByBalanceLimitData(balanceLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByBalanceLimitData(long balanceLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `BalanceLimit` = @BalanceLimit";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64));
		}
		#endregion // RemoveByBalanceLimit
		#region RemoveByOrderNum
		/// <summary>
		/// 按字段删除
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name="tm_">事务管理对象</param>
		public int RemoveByOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderNumData(orderNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> RemoveByOrderNumAsync(int orderNum, TransactionManager tm_ = null)
		{
			RepairRemoveByOrderNumData(orderNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairRemoveByOrderNumData(int orderNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"DELETE FROM {TableName} WHERE `OrderNum` = @OrderNum";
			paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
		}
		#endregion // RemoveByOrderNum
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
		public int Put(Sc_cash_condition_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutAsync(Sc_cash_condition_configEO item, TransactionManager tm_ = null)
		{
			RepairPutData(item, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutData(Sc_cash_condition_configEO item, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID, `CountryID` = @CountryID, `CurrencyID` = @CurrencyID, `ConditionType` = @ConditionType, `FirstPayAmountStart` = @FirstPayAmountStart, `FirstPayAmountEnd` = @FirstPayAmountEnd, `CashCompareTotalPayAmount` = @CashCompareTotalPayAmount, `TotalPayCountStart` = @TotalPayCountStart, `TotalPayCountEnd` = @TotalPayCountEnd, `TotalPayAmountStartLimit` = @TotalPayAmountStartLimit, `TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit, `BalanceStartAmount` = @BalanceStartAmount, `BalanceEndAmount` = @BalanceEndAmount, `TotalPayAmount` = @TotalPayAmount, `HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple, `HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1, `CashMultipLimit` = @CashMultipLimit, `CashAmountLimit` = @CashAmountLimit, `BalanceLimit` = @BalanceLimit, `OrderNum` = @OrderNum WHERE `ConfigID` = @ConfigID_Original";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", item.OperatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CountryID", item.CountryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@CurrencyID", item.CurrencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ConditionType", item.ConditionType, MySqlDbType.Int32),
				Database.CreateInParameter("@FirstPayAmountStart", item.FirstPayAmountStart, MySqlDbType.Int64),
				Database.CreateInParameter("@FirstPayAmountEnd", item.FirstPayAmountEnd, MySqlDbType.Int64),
				Database.CreateInParameter("@CashCompareTotalPayAmount", item.CashCompareTotalPayAmount, MySqlDbType.Float),
				Database.CreateInParameter("@TotalPayCountStart", item.TotalPayCountStart, MySqlDbType.Int32),
				Database.CreateInParameter("@TotalPayCountEnd", item.TotalPayCountEnd, MySqlDbType.Int32),
				Database.CreateInParameter("@TotalPayAmountStartLimit", item.TotalPayAmountStartLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@TotalPayAmountMaxLimit", item.TotalPayAmountMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceStartAmount", item.BalanceStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceEndAmount", item.BalanceEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@TotalPayAmount", item.TotalPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple", item.HistoryTotalPayAmountMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", item.HistoryTotalPayAmountMultiple1, MySqlDbType.Float),
				Database.CreateInParameter("@CashMultipLimit", item.CashMultipLimit, MySqlDbType.Float),
				Database.CreateInParameter("@CashAmountLimit", item.CashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@BalanceLimit", item.BalanceLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@OrderNum", item.OrderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID_Original", item.HasOriginal ? item.OriginalConfigID : item.ConfigID, MySqlDbType.Int32),
			};
		}
		
		/// <summary>
		/// 更新实体集合到数据库
		/// </summary>
		/// <param name = "items">要更新的实体对象集合</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int Put(IEnumerable<Sc_cash_condition_configEO> items, TransactionManager tm_ = null)
		{
			int ret = 0;
			foreach (var item in items)
			{
		        ret += Put(item, tm_);
			}
			return ret;
		}
		public async Task<int> PutAsync(IEnumerable<Sc_cash_condition_configEO> items, TransactionManager tm_ = null)
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
		/// /// <param name = "configID">配置ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int configID, string set_, params object[] values_)
		{
			return Put(set_, "`ConfigID` = @ConfigID", ConcatValues(values_, configID));
		}
		public async Task<int> PutByPKAsync(int configID, string set_, params object[] values_)
		{
			return await PutAsync(set_, "`ConfigID` = @ConfigID", ConcatValues(values_, configID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="values_">参数值</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int configID, string set_, TransactionManager tm_, params object[] values_)
		{
			return Put(set_, "`ConfigID` = @ConfigID", tm_, ConcatValues(values_, configID));
		}
		public async Task<int> PutByPKAsync(int configID, string set_, TransactionManager tm_, params object[] values_)
		{
			return await PutAsync(set_, "`ConfigID` = @ConfigID", tm_, ConcatValues(values_, configID));
		}
		/// <summary>
		/// 按主键更新指定列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name = "set_">更新的列数据</param>
		/// <param name="paras_">参数值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutByPK(int configID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
	        };
			return Put(set_, "`ConfigID` = @ConfigID", ConcatParameters(paras_, newParas_), tm_);
		}
		public async Task<int> PutByPKAsync(int configID, string set_, IEnumerable<MySqlParameter> paras_, TransactionManager tm_ = null)
		{
			var newParas_ = new List<MySqlParameter>() {
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
	        };
			return await PutAsync(set_, "`ConfigID` = @ConfigID", ConcatParameters(paras_, newParas_), tm_);
		}
		#endregion // PutByPK
		
		#region PutXXX
		#region PutOperatorID
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOperatorIDByPK(int configID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(configID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOperatorIDByPKAsync(int configID, string operatorID, TransactionManager tm_ = null)
		{
			RepairPutOperatorIDByPKData(configID, operatorID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOperatorIDByPKData(int configID, string operatorID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OperatorID` = @OperatorID  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
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
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCountryIDByPK(int configID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(configID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCountryIDByPKAsync(int configID, string countryID, TransactionManager tm_ = null)
		{
			RepairPutCountryIDByPKData(configID, countryID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCountryIDByPKData(int configID, string countryID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CountryID` = @CountryID  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
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
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCurrencyIDByPK(int configID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(configID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCurrencyIDByPKAsync(int configID, string currencyID, TransactionManager tm_ = null)
		{
			RepairPutCurrencyIDByPKData(configID, currencyID, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCurrencyIDByPKData(int configID, string currencyID, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CurrencyID` = @CurrencyID  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
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
		#region PutConditionType
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConditionTypeByPK(int configID, int conditionType, TransactionManager tm_ = null)
		{
			RepairPutConditionTypeByPKData(configID, conditionType, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutConditionTypeByPKAsync(int configID, int conditionType, TransactionManager tm_ = null)
		{
			RepairPutConditionTypeByPKData(configID, conditionType, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutConditionTypeByPKData(int configID, int conditionType, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `ConditionType` = @ConditionType  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutConditionType(int conditionType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ConditionType` = @ConditionType";
			var parameter_ = Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutConditionTypeAsync(int conditionType, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `ConditionType` = @ConditionType";
			var parameter_ = Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutConditionType
		#region PutFirstPayAmountStart
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstPayAmountStartByPK(int configID, long firstPayAmountStart, TransactionManager tm_ = null)
		{
			RepairPutFirstPayAmountStartByPKData(configID, firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFirstPayAmountStartByPKAsync(int configID, long firstPayAmountStart, TransactionManager tm_ = null)
		{
			RepairPutFirstPayAmountStartByPKData(configID, firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFirstPayAmountStartByPKData(int configID, long firstPayAmountStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FirstPayAmountStart` = @FirstPayAmountStart  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstPayAmountStart(long firstPayAmountStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstPayAmountStart` = @FirstPayAmountStart";
			var parameter_ = Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFirstPayAmountStartAsync(long firstPayAmountStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstPayAmountStart` = @FirstPayAmountStart";
			var parameter_ = Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFirstPayAmountStart
		#region PutFirstPayAmountEnd
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstPayAmountEndByPK(int configID, long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			RepairPutFirstPayAmountEndByPKData(configID, firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutFirstPayAmountEndByPKAsync(int configID, long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			RepairPutFirstPayAmountEndByPKData(configID, firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutFirstPayAmountEndByPKData(int configID, long firstPayAmountEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `FirstPayAmountEnd` = @FirstPayAmountEnd  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutFirstPayAmountEnd(long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstPayAmountEnd` = @FirstPayAmountEnd";
			var parameter_ = Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutFirstPayAmountEndAsync(long firstPayAmountEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `FirstPayAmountEnd` = @FirstPayAmountEnd";
			var parameter_ = Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutFirstPayAmountEnd
		#region PutCashCompareTotalPayAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashCompareTotalPayAmountByPK(int configID, float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			RepairPutCashCompareTotalPayAmountByPKData(configID, cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashCompareTotalPayAmountByPKAsync(int configID, float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			RepairPutCashCompareTotalPayAmountByPKData(configID, cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashCompareTotalPayAmountByPKData(int configID, float cashCompareTotalPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashCompareTotalPayAmount` = @CashCompareTotalPayAmount  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashCompareTotalPayAmount(float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashCompareTotalPayAmount` = @CashCompareTotalPayAmount";
			var parameter_ = Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashCompareTotalPayAmount` = @CashCompareTotalPayAmount";
			var parameter_ = Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashCompareTotalPayAmount
		#region PutTotalPayCountStart
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayCountStartByPK(int configID, int totalPayCountStart, TransactionManager tm_ = null)
		{
			RepairPutTotalPayCountStartByPKData(configID, totalPayCountStart, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTotalPayCountStartByPKAsync(int configID, int totalPayCountStart, TransactionManager tm_ = null)
		{
			RepairPutTotalPayCountStartByPKData(configID, totalPayCountStart, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTotalPayCountStartByPKData(int configID, int totalPayCountStart, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TotalPayCountStart` = @TotalPayCountStart  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayCountStart(int totalPayCountStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayCountStart` = @TotalPayCountStart";
			var parameter_ = Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTotalPayCountStartAsync(int totalPayCountStart, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayCountStart` = @TotalPayCountStart";
			var parameter_ = Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTotalPayCountStart
		#region PutTotalPayCountEnd
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayCountEndByPK(int configID, int totalPayCountEnd, TransactionManager tm_ = null)
		{
			RepairPutTotalPayCountEndByPKData(configID, totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTotalPayCountEndByPKAsync(int configID, int totalPayCountEnd, TransactionManager tm_ = null)
		{
			RepairPutTotalPayCountEndByPKData(configID, totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTotalPayCountEndByPKData(int configID, int totalPayCountEnd, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TotalPayCountEnd` = @TotalPayCountEnd  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayCountEnd(int totalPayCountEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayCountEnd` = @TotalPayCountEnd";
			var parameter_ = Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTotalPayCountEndAsync(int totalPayCountEnd, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayCountEnd` = @TotalPayCountEnd";
			var parameter_ = Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTotalPayCountEnd
		#region PutTotalPayAmountStartLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmountStartLimitByPK(int configID, long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountStartLimitByPKData(configID, totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTotalPayAmountStartLimitByPKAsync(int configID, long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountStartLimitByPKData(configID, totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTotalPayAmountStartLimitByPKData(int configID, long totalPayAmountStartLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TotalPayAmountStartLimit` = @TotalPayAmountStartLimit  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmountStartLimit(long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmountStartLimit` = @TotalPayAmountStartLimit";
			var parameter_ = Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmountStartLimit` = @TotalPayAmountStartLimit";
			var parameter_ = Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTotalPayAmountStartLimit
		#region PutTotalPayAmountMaxLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmountMaxLimitByPK(int configID, long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountMaxLimitByPKData(configID, totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTotalPayAmountMaxLimitByPKAsync(int configID, long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountMaxLimitByPKData(configID, totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTotalPayAmountMaxLimitByPKData(int configID, long totalPayAmountMaxLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit";
			var parameter_ = Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit";
			var parameter_ = Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTotalPayAmountMaxLimit
		#region PutBalanceStartAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceStartAmountByPK(int configID, long balanceStartAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceStartAmountByPKData(configID, balanceStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBalanceStartAmountByPKAsync(int configID, long balanceStartAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceStartAmountByPKData(configID, balanceStartAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBalanceStartAmountByPKData(int configID, long balanceStartAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BalanceStartAmount` = @BalanceStartAmount  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceStartAmount(long balanceStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceStartAmount` = @BalanceStartAmount";
			var parameter_ = Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBalanceStartAmountAsync(long balanceStartAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceStartAmount` = @BalanceStartAmount";
			var parameter_ = Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBalanceStartAmount
		#region PutBalanceEndAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceEndAmountByPK(int configID, long balanceEndAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceEndAmountByPKData(configID, balanceEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBalanceEndAmountByPKAsync(int configID, long balanceEndAmount, TransactionManager tm_ = null)
		{
			RepairPutBalanceEndAmountByPKData(configID, balanceEndAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBalanceEndAmountByPKData(int configID, long balanceEndAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BalanceEndAmount` = @BalanceEndAmount  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceEndAmount(long balanceEndAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceEndAmount` = @BalanceEndAmount";
			var parameter_ = Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBalanceEndAmountAsync(long balanceEndAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceEndAmount` = @BalanceEndAmount";
			var parameter_ = Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBalanceEndAmount
		#region PutTotalPayAmount
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmountByPK(int configID, long totalPayAmount, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountByPKData(configID, totalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutTotalPayAmountByPKAsync(int configID, long totalPayAmount, TransactionManager tm_ = null)
		{
			RepairPutTotalPayAmountByPKData(configID, totalPayAmount, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutTotalPayAmountByPKData(int configID, long totalPayAmount, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `TotalPayAmount` = @TotalPayAmount  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutTotalPayAmount(long totalPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmount` = @TotalPayAmount";
			var parameter_ = Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutTotalPayAmountAsync(long totalPayAmount, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `TotalPayAmount` = @TotalPayAmount";
			var parameter_ = Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutTotalPayAmount
		#region PutHistoryTotalPayAmountMultiple
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryTotalPayAmountMultipleByPK(int configID, float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			RepairPutHistoryTotalPayAmountMultipleByPKData(configID, historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutHistoryTotalPayAmountMultipleByPKAsync(int configID, float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			RepairPutHistoryTotalPayAmountMultipleByPKData(configID, historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutHistoryTotalPayAmountMultipleByPKData(int configID, float historyTotalPayAmountMultiple, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple";
			var parameter_ = Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple";
			var parameter_ = Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHistoryTotalPayAmountMultiple
		#region PutHistoryTotalPayAmountMultiple1
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryTotalPayAmountMultiple1ByPK(int configID, float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			RepairPutHistoryTotalPayAmountMultiple1ByPKData(configID, historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutHistoryTotalPayAmountMultiple1ByPKAsync(int configID, float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			RepairPutHistoryTotalPayAmountMultiple1ByPKData(configID, historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutHistoryTotalPayAmountMultiple1ByPKData(int configID, float historyTotalPayAmountMultiple1, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1";
			var parameter_ = Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1";
			var parameter_ = Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutHistoryTotalPayAmountMultiple1
		#region PutCashMultipLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMultipLimitByPK(int configID, float cashMultipLimit, TransactionManager tm_ = null)
		{
			RepairPutCashMultipLimitByPKData(configID, cashMultipLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashMultipLimitByPKAsync(int configID, float cashMultipLimit, TransactionManager tm_ = null)
		{
			RepairPutCashMultipLimitByPKData(configID, cashMultipLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashMultipLimitByPKData(int configID, float cashMultipLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashMultipLimit` = @CashMultipLimit  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashMultipLimit(float cashMultipLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMultipLimit` = @CashMultipLimit";
			var parameter_ = Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashMultipLimitAsync(float cashMultipLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashMultipLimit` = @CashMultipLimit";
			var parameter_ = Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashMultipLimit
		#region PutCashAmountLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashAmountLimitByPK(int configID, long cashAmountLimit, TransactionManager tm_ = null)
		{
			RepairPutCashAmountLimitByPKData(configID, cashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutCashAmountLimitByPKAsync(int configID, long cashAmountLimit, TransactionManager tm_ = null)
		{
			RepairPutCashAmountLimitByPKData(configID, cashAmountLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutCashAmountLimitByPKData(int configID, long cashAmountLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `CashAmountLimit` = @CashAmountLimit  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutCashAmountLimit(long cashAmountLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashAmountLimit` = @CashAmountLimit";
			var parameter_ = Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutCashAmountLimitAsync(long cashAmountLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `CashAmountLimit` = @CashAmountLimit";
			var parameter_ = Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutCashAmountLimit
		#region PutBalanceLimit
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceLimitByPK(int configID, long balanceLimit, TransactionManager tm_ = null)
		{
			RepairPutBalanceLimitByPKData(configID, balanceLimit, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutBalanceLimitByPKAsync(int configID, long balanceLimit, TransactionManager tm_ = null)
		{
			RepairPutBalanceLimitByPKData(configID, balanceLimit, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutBalanceLimitByPKData(int configID, long balanceLimit, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `BalanceLimit` = @BalanceLimit  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutBalanceLimit(long balanceLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceLimit` = @BalanceLimit";
			var parameter_ = Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutBalanceLimitAsync(long balanceLimit, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `BalanceLimit` = @BalanceLimit";
			var parameter_ = Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutBalanceLimit
		#region PutOrderNum
		/// <summary>
		/// 按主键更新列数据
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNumByPK(int configID, int orderNum, TransactionManager tm_ = null)
		{
			RepairPutOrderNumByPKData(configID, orderNum, out string sql_, out List<MySqlParameter> paras_);
			return Database.ExecSqlNonQuery(sql_, paras_, tm_);
		}
		public async Task<int> PutOrderNumByPKAsync(int configID, int orderNum, TransactionManager tm_ = null)
		{
			RepairPutOrderNumByPKData(configID, orderNum, out string sql_, out List<MySqlParameter> paras_);
			return await Database.ExecSqlNonQueryAsync(sql_, paras_, tm_);
		}
		private void RepairPutOrderNumByPKData(int configID, int orderNum, out string sql_, out List<MySqlParameter> paras_)
		{
			sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum  WHERE `ConfigID` = @ConfigID";
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32),
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
	 
		/// <summary>
		/// 更新一列数据
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>受影响的行数</return>
		public int PutOrderNum(int orderNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum";
			var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
			return Database.ExecSqlNonQuery(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		public async Task<int> PutOrderNumAsync(int orderNum, TransactionManager tm_ = null)
		{
			string sql_ = $"UPDATE {TableName} SET `OrderNum` = @OrderNum";
			var parameter_ = Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32);
			return await Database.ExecSqlNonQueryAsync(sql_, new MySqlParameter[] { parameter_ }, tm_);
		}
		#endregion // PutOrderNum
		#endregion // PutXXX
		#endregion // Put
	   
		#region Set
		
		/// <summary>
		/// 插入或者更新数据
		/// </summary>
		/// <param name = "item">要更新的实体对象</param>
		/// <param name="tm">事务管理对象</param>
		/// <return>true:插入操作；false:更新操作</return>
		public bool Set(Sc_cash_condition_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.ConfigID) == null)
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
		public async Task<bool> SetAsync(Sc_cash_condition_configEO item, TransactionManager tm = null)
		{
			bool ret = true;
			if(GetByPK(item.ConfigID) == null)
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
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <param name="isForUpdate_">是否使用FOR UPDATE锁行</param>
		/// <return></return>
		public Sc_cash_condition_configEO GetByPK(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return Database.ExecSqlSingle(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<Sc_cash_condition_configEO> GetByPKAsync(int configID, TransactionManager tm_ = null, bool isForUpdate_ = false)
		{
			RepairGetByPKData(configID, out string sql_, out List<MySqlParameter> paras_, isForUpdate_, tm_);
			return await Database.ExecSqlSingleAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		private void RepairGetByPKData(int configID, out string sql_, out List<MySqlParameter> paras_, bool isForUpdate_ = false, TransactionManager tm_ = null)
		{
			sql_ = BuildSelectSQL("`ConfigID` = @ConfigID", 0, null, null, isForUpdate_);
			paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
		}
		#endregion // GetByPK
		
		#region GetXXXByPK
		
		/// <summary>
		/// 按主键查询 OperatorID（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetOperatorIDByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`OperatorID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<string> GetOperatorIDByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`OperatorID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CountryID（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCountryIDByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`CountryID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<string> GetCountryIDByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`CountryID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CurrencyID（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public string GetCurrencyIDByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)GetScalar("`CurrencyID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<string> GetCurrencyIDByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (string)await GetScalarAsync("`CurrencyID`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 ConditionType（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetConditionTypeByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`ConditionType`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<int> GetConditionTypeByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`ConditionType`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FirstPayAmountStart（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetFirstPayAmountStartByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`FirstPayAmountStart`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetFirstPayAmountStartByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`FirstPayAmountStart`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 FirstPayAmountEnd（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetFirstPayAmountEndByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`FirstPayAmountEnd`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetFirstPayAmountEndByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`FirstPayAmountEnd`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashCompareTotalPayAmount（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetCashCompareTotalPayAmountByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`CashCompareTotalPayAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<float> GetCashCompareTotalPayAmountByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`CashCompareTotalPayAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TotalPayCountStart（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetTotalPayCountStartByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`TotalPayCountStart`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<int> GetTotalPayCountStartByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`TotalPayCountStart`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TotalPayCountEnd（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetTotalPayCountEndByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`TotalPayCountEnd`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<int> GetTotalPayCountEndByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`TotalPayCountEnd`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TotalPayAmountStartLimit（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetTotalPayAmountStartLimitByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`TotalPayAmountStartLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetTotalPayAmountStartLimitByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`TotalPayAmountStartLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TotalPayAmountMaxLimit（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetTotalPayAmountMaxLimitByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`TotalPayAmountMaxLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetTotalPayAmountMaxLimitByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`TotalPayAmountMaxLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BalanceStartAmount（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBalanceStartAmountByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`BalanceStartAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetBalanceStartAmountByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`BalanceStartAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BalanceEndAmount（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBalanceEndAmountByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`BalanceEndAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetBalanceEndAmountByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`BalanceEndAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 TotalPayAmount（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetTotalPayAmountByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`TotalPayAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetTotalPayAmountByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`TotalPayAmount`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 HistoryTotalPayAmountMultiple（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetHistoryTotalPayAmountMultipleByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`HistoryTotalPayAmountMultiple`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<float> GetHistoryTotalPayAmountMultipleByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`HistoryTotalPayAmountMultiple`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 HistoryTotalPayAmountMultiple1（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetHistoryTotalPayAmountMultiple1ByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`HistoryTotalPayAmountMultiple1`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<float> GetHistoryTotalPayAmountMultiple1ByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`HistoryTotalPayAmountMultiple1`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashMultipLimit（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public float GetCashMultipLimitByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)GetScalar("`CashMultipLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<float> GetCashMultipLimitByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (float)await GetScalarAsync("`CashMultipLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 CashAmountLimit（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetCashAmountLimitByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`CashAmountLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetCashAmountLimitByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`CashAmountLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 BalanceLimit（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public long GetBalanceLimitByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)GetScalar("`BalanceLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<long> GetBalanceLimitByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (long)await GetScalarAsync("`BalanceLimit`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		
		/// <summary>
		/// 按主键查询 OrderNum（字段）
		/// </summary>
		/// /// <param name = "configID">配置ID</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return></return>
		public int GetOrderNumByPK(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)GetScalar("`OrderNum`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		public async Task<int> GetOrderNumByPKAsync(int configID, TransactionManager tm_ = null)
		{
			var paras_ = new List<MySqlParameter>() 
			{
				Database.CreateInParameter("@ConfigID", configID, MySqlDbType.Int32),
			};
			return (int)await GetScalarAsync("`OrderNum`", "`ConfigID` = @ConfigID", paras_, tm_);
		}
		#endregion // GetXXXByPK
		#region GetByXXX
		#region GetByOperatorID
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, int top_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, int top_)
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
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, int top_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, int top_, TransactionManager tm_)
		{
			return await GetByOperatorIDAsync(operatorID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OperatorID（字段） 查询
		/// </summary>
		/// /// <param name = "operatorID">运营商编码</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, string sort_)
		{
			return GetByOperatorID(operatorID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, string sort_)
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
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, string sort_, TransactionManager tm_)
		{
			return GetByOperatorID(operatorID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_condition_configEO> GetByOperatorID(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOperatorIDAsync(string operatorID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OperatorID` = @OperatorID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OperatorID", operatorID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByOperatorID
		#region GetByCountryID
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID)
		{
			return GetByCountryID(countryID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, int top_)
		{
			return GetByCountryID(countryID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, int top_)
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
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, int top_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, int top_, TransactionManager tm_)
		{
			return await GetByCountryIDAsync(countryID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CountryID（字段） 查询
		/// </summary>
		/// /// <param name = "countryID">国家编码ISO 3166-1三位字母</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, string sort_)
		{
			return GetByCountryID(countryID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, string sort_)
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
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, string sort_, TransactionManager tm_)
		{
			return GetByCountryID(countryID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_condition_configEO> GetByCountryID(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCountryIDAsync(string countryID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CountryID` = @CountryID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CountryID", countryID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByCountryID
		#region GetByCurrencyID
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, int top_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, int top_)
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
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, int top_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, TransactionManager tm_)
		{
			return await GetByCurrencyIDAsync(currencyID, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CurrencyID（字段） 查询
		/// </summary>
		/// /// <param name = "currencyID">货币类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, string sort_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_)
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
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, string sort_, TransactionManager tm_)
		{
			return GetByCurrencyID(currencyID, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, string sort_, TransactionManager tm_)
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
		public List<Sc_cash_condition_configEO> GetByCurrencyID(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCurrencyIDAsync(string currencyID, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CurrencyID` = @CurrencyID", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CurrencyID", currencyID, MySqlDbType.VarChar));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByCurrencyID
		#region GetByConditionType
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType)
		{
			return GetByConditionType(conditionType, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType)
		{
			return await GetByConditionTypeAsync(conditionType, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, TransactionManager tm_)
		{
			return GetByConditionType(conditionType, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, TransactionManager tm_)
		{
			return await GetByConditionTypeAsync(conditionType, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, int top_)
		{
			return GetByConditionType(conditionType, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, int top_)
		{
			return await GetByConditionTypeAsync(conditionType, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, int top_, TransactionManager tm_)
		{
			return GetByConditionType(conditionType, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, int top_, TransactionManager tm_)
		{
			return await GetByConditionTypeAsync(conditionType, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, string sort_)
		{
			return GetByConditionType(conditionType, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, string sort_)
		{
			return await GetByConditionTypeAsync(conditionType, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, string sort_, TransactionManager tm_)
		{
			return GetByConditionType(conditionType, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, string sort_, TransactionManager tm_)
		{
			return await GetByConditionTypeAsync(conditionType, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 ConditionType（字段） 查询
		/// </summary>
		/// /// <param name = "conditionType">条件类型</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByConditionType(int conditionType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ConditionType` = @ConditionType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByConditionTypeAsync(int conditionType, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`ConditionType` = @ConditionType", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@ConditionType", conditionType, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByConditionType
		#region GetByFirstPayAmountStart
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, TransactionManager tm_)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, TransactionManager tm_)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, int top_)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, int top_)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, int top_, TransactionManager tm_)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, int top_, TransactionManager tm_)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, string sort_)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, string sort_)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, string sort_, TransactionManager tm_)
		{
			return GetByFirstPayAmountStart(firstPayAmountStart, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, string sort_, TransactionManager tm_)
		{
			return await GetByFirstPayAmountStartAsync(firstPayAmountStart, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountStart（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountStart">首次充值金额起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountStart(long firstPayAmountStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstPayAmountStart` = @FirstPayAmountStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountStartAsync(long firstPayAmountStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstPayAmountStart` = @FirstPayAmountStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountStart", firstPayAmountStart, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByFirstPayAmountStart
		#region GetByFirstPayAmountEnd
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, TransactionManager tm_)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, TransactionManager tm_)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, int top_)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, int top_)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, int top_, TransactionManager tm_)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, int top_, TransactionManager tm_)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, string sort_)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, string sort_)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, string sort_, TransactionManager tm_)
		{
			return GetByFirstPayAmountEnd(firstPayAmountEnd, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, string sort_, TransactionManager tm_)
		{
			return await GetByFirstPayAmountEndAsync(firstPayAmountEnd, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 FirstPayAmountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "firstPayAmountEnd">首次充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByFirstPayAmountEnd(long firstPayAmountEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstPayAmountEnd` = @FirstPayAmountEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByFirstPayAmountEndAsync(long firstPayAmountEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`FirstPayAmountEnd` = @FirstPayAmountEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@FirstPayAmountEnd", firstPayAmountEnd, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByFirstPayAmountEnd
		#region GetByCashCompareTotalPayAmount
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, TransactionManager tm_)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, TransactionManager tm_)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, int top_)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, int top_)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, int top_, TransactionManager tm_)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, int top_, TransactionManager tm_)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, string sort_)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, string sort_)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, string sort_, TransactionManager tm_)
		{
			return GetByCashCompareTotalPayAmount(cashCompareTotalPayAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, string sort_, TransactionManager tm_)
		{
			return await GetByCashCompareTotalPayAmountAsync(cashCompareTotalPayAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashCompareTotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "cashCompareTotalPayAmount">本次提现金额对比累计充值金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashCompareTotalPayAmount(float cashCompareTotalPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashCompareTotalPayAmount` = @CashCompareTotalPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashCompareTotalPayAmountAsync(float cashCompareTotalPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashCompareTotalPayAmount` = @CashCompareTotalPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashCompareTotalPayAmount", cashCompareTotalPayAmount, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByCashCompareTotalPayAmount
		#region GetByTotalPayCountStart
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart)
		{
			return GetByTotalPayCountStart(totalPayCountStart, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, TransactionManager tm_)
		{
			return GetByTotalPayCountStart(totalPayCountStart, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, TransactionManager tm_)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, int top_)
		{
			return GetByTotalPayCountStart(totalPayCountStart, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, int top_)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, int top_, TransactionManager tm_)
		{
			return GetByTotalPayCountStart(totalPayCountStart, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, int top_, TransactionManager tm_)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, string sort_)
		{
			return GetByTotalPayCountStart(totalPayCountStart, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, string sort_)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, string sort_, TransactionManager tm_)
		{
			return GetByTotalPayCountStart(totalPayCountStart, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, string sort_, TransactionManager tm_)
		{
			return await GetByTotalPayCountStartAsync(totalPayCountStart, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountStart（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountStart">累计充值次数起始值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountStart(int totalPayCountStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayCountStart` = @TotalPayCountStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountStartAsync(int totalPayCountStart, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayCountStart` = @TotalPayCountStart", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountStart", totalPayCountStart, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByTotalPayCountStart
		#region GetByTotalPayCountEnd
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, TransactionManager tm_)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, TransactionManager tm_)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, int top_)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, int top_)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, int top_, TransactionManager tm_)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, int top_, TransactionManager tm_)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, string sort_)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, string sort_)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, string sort_, TransactionManager tm_)
		{
			return GetByTotalPayCountEnd(totalPayCountEnd, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, string sort_, TransactionManager tm_)
		{
			return await GetByTotalPayCountEndAsync(totalPayCountEnd, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayCountEnd（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayCountEnd">累计充值次数截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayCountEnd(int totalPayCountEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayCountEnd` = @TotalPayCountEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayCountEndAsync(int totalPayCountEnd, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayCountEnd` = @TotalPayCountEnd", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayCountEnd", totalPayCountEnd, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByTotalPayCountEnd
		#region GetByTotalPayAmountStartLimit
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, TransactionManager tm_)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, TransactionManager tm_)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, int top_)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, int top_)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, int top_, TransactionManager tm_)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, int top_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, string sort_)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, string sort_)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, string sort_, TransactionManager tm_)
		{
			return GetByTotalPayAmountStartLimit(totalPayAmountStartLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, string sort_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountStartLimitAsync(totalPayAmountStartLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountStartLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountStartLimit">累计充值起始金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountStartLimit(long totalPayAmountStartLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmountStartLimit` = @TotalPayAmountStartLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountStartLimitAsync(long totalPayAmountStartLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmountStartLimit` = @TotalPayAmountStartLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountStartLimit", totalPayAmountStartLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByTotalPayAmountStartLimit
		#region GetByTotalPayAmountMaxLimit
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, TransactionManager tm_)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, TransactionManager tm_)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, int top_)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, int top_)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, int top_, TransactionManager tm_)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, int top_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, string sort_)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, string sort_)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, string sort_, TransactionManager tm_)
		{
			return GetByTotalPayAmountMaxLimit(totalPayAmountMaxLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, string sort_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountMaxLimitAsync(totalPayAmountMaxLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmountMaxLimit（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmountMaxLimit">累计充值金额截止值</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmountMaxLimit(long totalPayAmountMaxLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountMaxLimitAsync(long totalPayAmountMaxLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmountMaxLimit` = @TotalPayAmountMaxLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmountMaxLimit", totalPayAmountMaxLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByTotalPayAmountMaxLimit
		#region GetByBalanceStartAmount
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount)
		{
			return GetByBalanceStartAmount(balanceStartAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, TransactionManager tm_)
		{
			return GetByBalanceStartAmount(balanceStartAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, TransactionManager tm_)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, int top_)
		{
			return GetByBalanceStartAmount(balanceStartAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, int top_)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, int top_, TransactionManager tm_)
		{
			return GetByBalanceStartAmount(balanceStartAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, int top_, TransactionManager tm_)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, string sort_)
		{
			return GetByBalanceStartAmount(balanceStartAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, string sort_)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, string sort_, TransactionManager tm_)
		{
			return GetByBalanceStartAmount(balanceStartAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBalanceStartAmountAsync(balanceStartAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BalanceStartAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceStartAmount">余额起始区间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceStartAmount(long balanceStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceStartAmount` = @BalanceStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceStartAmountAsync(long balanceStartAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceStartAmount` = @BalanceStartAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceStartAmount", balanceStartAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByBalanceStartAmount
		#region GetByBalanceEndAmount
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount)
		{
			return GetByBalanceEndAmount(balanceEndAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, TransactionManager tm_)
		{
			return GetByBalanceEndAmount(balanceEndAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, TransactionManager tm_)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, int top_)
		{
			return GetByBalanceEndAmount(balanceEndAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, int top_)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, int top_, TransactionManager tm_)
		{
			return GetByBalanceEndAmount(balanceEndAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, int top_, TransactionManager tm_)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, string sort_)
		{
			return GetByBalanceEndAmount(balanceEndAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, string sort_)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, string sort_, TransactionManager tm_)
		{
			return GetByBalanceEndAmount(balanceEndAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, string sort_, TransactionManager tm_)
		{
			return await GetByBalanceEndAmountAsync(balanceEndAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BalanceEndAmount（字段） 查询
		/// </summary>
		/// /// <param name = "balanceEndAmount">余额截止区间</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceEndAmount(long balanceEndAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceEndAmount` = @BalanceEndAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceEndAmountAsync(long balanceEndAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceEndAmount` = @BalanceEndAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceEndAmount", balanceEndAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByBalanceEndAmount
		#region GetByTotalPayAmount
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount)
		{
			return GetByTotalPayAmount(totalPayAmount, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, TransactionManager tm_)
		{
			return GetByTotalPayAmount(totalPayAmount, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, TransactionManager tm_)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, int top_)
		{
			return GetByTotalPayAmount(totalPayAmount, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, int top_)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, int top_, TransactionManager tm_)
		{
			return GetByTotalPayAmount(totalPayAmount, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, int top_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, string sort_)
		{
			return GetByTotalPayAmount(totalPayAmount, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, string sort_)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, string sort_, TransactionManager tm_)
		{
			return GetByTotalPayAmount(totalPayAmount, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, string sort_, TransactionManager tm_)
		{
			return await GetByTotalPayAmountAsync(totalPayAmount, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 TotalPayAmount（字段） 查询
		/// </summary>
		/// /// <param name = "totalPayAmount">充值总金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByTotalPayAmount(long totalPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmount` = @TotalPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByTotalPayAmountAsync(long totalPayAmount, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`TotalPayAmount` = @TotalPayAmount", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@TotalPayAmount", totalPayAmount, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByTotalPayAmount
		#region GetByHistoryTotalPayAmountMultiple
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, int top_)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, int top_)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, int top_, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, int top_, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, string sort_)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, string sort_)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, string sort_, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple(historyTotalPayAmountMultiple, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, string sort_, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultipleAsync(historyTotalPayAmountMultiple, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple">历史总充值金额倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple(float historyTotalPayAmountMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultipleAsync(float historyTotalPayAmountMultiple, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryTotalPayAmountMultiple` = @HistoryTotalPayAmountMultiple", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple", historyTotalPayAmountMultiple, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByHistoryTotalPayAmountMultiple
		#region GetByHistoryTotalPayAmountMultiple1
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, int top_)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, int top_)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, int top_, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, int top_, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, string sort_)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, string sort_)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, string sort_, TransactionManager tm_)
		{
			return GetByHistoryTotalPayAmountMultiple1(historyTotalPayAmountMultiple1, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, string sort_, TransactionManager tm_)
		{
			return await GetByHistoryTotalPayAmountMultiple1Async(historyTotalPayAmountMultiple1, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 HistoryTotalPayAmountMultiple1（字段） 查询
		/// </summary>
		/// /// <param name = "historyTotalPayAmountMultiple1">历史总充值金额倍数1</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByHistoryTotalPayAmountMultiple1(float historyTotalPayAmountMultiple1, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByHistoryTotalPayAmountMultiple1Async(float historyTotalPayAmountMultiple1, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`HistoryTotalPayAmountMultiple1` = @HistoryTotalPayAmountMultiple1", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@HistoryTotalPayAmountMultiple1", historyTotalPayAmountMultiple1, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByHistoryTotalPayAmountMultiple1
		#region GetByCashMultipLimit
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit)
		{
			return GetByCashMultipLimit(cashMultipLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, TransactionManager tm_)
		{
			return GetByCashMultipLimit(cashMultipLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, TransactionManager tm_)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, int top_)
		{
			return GetByCashMultipLimit(cashMultipLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, int top_)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, int top_, TransactionManager tm_)
		{
			return GetByCashMultipLimit(cashMultipLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, int top_, TransactionManager tm_)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, string sort_)
		{
			return GetByCashMultipLimit(cashMultipLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, string sort_)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, string sort_, TransactionManager tm_)
		{
			return GetByCashMultipLimit(cashMultipLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, string sort_, TransactionManager tm_)
		{
			return await GetByCashMultipLimitAsync(cashMultipLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashMultipLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashMultipLimit">提现倍数</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashMultipLimit(float cashMultipLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMultipLimit` = @CashMultipLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashMultipLimitAsync(float cashMultipLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashMultipLimit` = @CashMultipLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashMultipLimit", cashMultipLimit, MySqlDbType.Float));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByCashMultipLimit
		#region GetByCashAmountLimit
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit)
		{
			return GetByCashAmountLimit(cashAmountLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, TransactionManager tm_)
		{
			return GetByCashAmountLimit(cashAmountLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, TransactionManager tm_)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, int top_)
		{
			return GetByCashAmountLimit(cashAmountLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, int top_)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, int top_, TransactionManager tm_)
		{
			return GetByCashAmountLimit(cashAmountLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, int top_, TransactionManager tm_)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, string sort_)
		{
			return GetByCashAmountLimit(cashAmountLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, string sort_)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, string sort_, TransactionManager tm_)
		{
			return GetByCashAmountLimit(cashAmountLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, string sort_, TransactionManager tm_)
		{
			return await GetByCashAmountLimitAsync(cashAmountLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 CashAmountLimit（字段） 查询
		/// </summary>
		/// /// <param name = "cashAmountLimit">提现金额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByCashAmountLimit(long cashAmountLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashAmountLimit` = @CashAmountLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByCashAmountLimitAsync(long cashAmountLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`CashAmountLimit` = @CashAmountLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@CashAmountLimit", cashAmountLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByCashAmountLimit
		#region GetByBalanceLimit
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit)
		{
			return GetByBalanceLimit(balanceLimit, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit)
		{
			return await GetByBalanceLimitAsync(balanceLimit, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, TransactionManager tm_)
		{
			return GetByBalanceLimit(balanceLimit, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, TransactionManager tm_)
		{
			return await GetByBalanceLimitAsync(balanceLimit, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, int top_)
		{
			return GetByBalanceLimit(balanceLimit, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, int top_)
		{
			return await GetByBalanceLimitAsync(balanceLimit, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, int top_, TransactionManager tm_)
		{
			return GetByBalanceLimit(balanceLimit, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, int top_, TransactionManager tm_)
		{
			return await GetByBalanceLimitAsync(balanceLimit, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, string sort_)
		{
			return GetByBalanceLimit(balanceLimit, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, string sort_)
		{
			return await GetByBalanceLimitAsync(balanceLimit, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, string sort_, TransactionManager tm_)
		{
			return GetByBalanceLimit(balanceLimit, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, string sort_, TransactionManager tm_)
		{
			return await GetByBalanceLimitAsync(balanceLimit, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 BalanceLimit（字段） 查询
		/// </summary>
		/// /// <param name = "balanceLimit">余额</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByBalanceLimit(long balanceLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceLimit` = @BalanceLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByBalanceLimitAsync(long balanceLimit, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`BalanceLimit` = @BalanceLimit", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@BalanceLimit", balanceLimit, MySqlDbType.Int64));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByBalanceLimit
		#region GetByOrderNum
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum)
		{
			return GetByOrderNum(orderNum, 0, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum)
		{
			return await GetByOrderNumAsync(orderNum, 0, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, 0, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, TransactionManager tm_)
		{
			return await GetByOrderNumAsync(orderNum, 0, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name = "top_">获取行数</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, int top_)
		{
			return GetByOrderNum(orderNum, top_, string.Empty, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, int top_)
		{
			return await GetByOrderNumAsync(orderNum, top_, string.Empty, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name = "top_">获取行数</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, int top_, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, top_, string.Empty, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, int top_, TransactionManager tm_)
		{
			return await GetByOrderNumAsync(orderNum, top_, string.Empty, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name = "sort_">排序表达式</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, string sort_)
		{
			return GetByOrderNum(orderNum, 0, sort_, null);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, string sort_)
		{
			return await GetByOrderNumAsync(orderNum, 0, sort_, null);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, string sort_, TransactionManager tm_)
		{
			return GetByOrderNum(orderNum, 0, sort_, tm_);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, string sort_, TransactionManager tm_)
		{
			return await GetByOrderNumAsync(orderNum, 0, sort_, tm_);
		}
		
		/// <summary>
		/// 按 OrderNum（字段） 查询
		/// </summary>
		/// /// <param name = "orderNum">排序字段</param>
		/// <param name = "top_">获取行数</param>
		/// <param name = "sort_">排序表达式</param>
		/// <param name="tm_">事务管理对象</param>
		/// <return>实体对象集合</return>
		public List<Sc_cash_condition_configEO> GetByOrderNum(int orderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
			return Database.ExecSqlList(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		public async Task<List<Sc_cash_condition_configEO>> GetByOrderNumAsync(int orderNum, int top_, string sort_, TransactionManager tm_)
		{
			var sql_ = BuildSelectSQL("`OrderNum` = @OrderNum", top_, sort_);
			var paras_ = new List<MySqlParameter>();
			paras_.Add(Database.CreateInParameter("@OrderNum", orderNum, MySqlDbType.Int32));
			return await Database.ExecSqlListAsync(sql_, paras_, tm_, Sc_cash_condition_configEO.MapDataReader);
		}
		#endregion // GetByOrderNum
		#endregion // GetByXXX
		#endregion // Get
	}
	#endregion // MO
}
